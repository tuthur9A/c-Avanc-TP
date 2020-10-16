using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TP.CustomException;
using TP.DTO;
using TP.Filters;
using TP.Services.Book;
using TP.Services.GoogleAPI;
using TP.Services.Shelve;

namespace TP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBooksService _bookService;
        private readonly IShelvesService _shelvesService;
        private readonly IMapper _mapper;
        private readonly IGoogleAPIClientService _googleApiClientService;

        public BooksController(ILogger<BooksController> logger, IBooksService bookService, IGoogleAPIClientService googleAPIClientService, IMapper mapper, IShelvesService shelvesService)
        {
            _logger = logger;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            _shelvesService = shelvesService ?? throw new ArgumentNullException(nameof(shelvesService));
            _googleApiClientService = googleAPIClientService ?? throw new ArgumentNullException(nameof(googleAPIClientService));
        }

        [HttpGet, Route("/")]
        public async Task<IEnumerable<BookDTO>> Get()
        {
            return await _bookService.GetBooks(new BooksFilters(){});
        }

        [HttpGet, Route("/google")]
        public async Task<IActionResult> GetFromGoogle([FromQuery(Name = "q")] string search)
        {
            var booksList = new List<BookDTO>(){};
            try {
                dynamic result = JsonConvert.DeserializeObject(await _googleApiClientService.Search(search));
                foreach (var item in result.items)
                {
                    var book = new BookDTO() {};
                    book.AverageRating = item.volumeInfo.averageRating;
                    var authors = new List<string>(){};
                    if (item.volumeInfo.authors != null) {
                        foreach(string author in item.volumeInfo.authors) {
                            authors.Add(author);
                        }
                    }
                    
                    book.Authors = authors;
                    book.ImageLinks = new ImageLinkDTO(){
                        SmallThumbnail = item?.volumeInfo?.imageLinks?.smallThumbnail,
                        Thumbnail = item?.volumeInfo?.imageLinks?.thumbnail,
                    };
                    var identifier = new List<IndustryIdentifierDTO>(){};
                    if (item.volumeInfo.industryIdentifiers != null) {
                        foreach (var identifierItem in item.volumeInfo.industryIdentifiers)
                        {
                            var id = new IndustryIdentifierDTO() {
                            Identifier = identifierItem.identifier,
                                Type = identifierItem.type,
                            };
                            identifier.Add(id);
                        }
                    }
                    book.IndustryIdentifiers = identifier;
                    book.InfoLink = item.volumeInfo.infoLink;
                    book.Language = item.volumeInfo.language;
                    book.PageCount = item.volumeInfo.pageCount;
                    book.PreviewLink = item.volumeInfo.previewLink;
                    book.PrintType = item.volumeInfo.printType;
                    book.PublishedDate = item.volumeInfo.publishedDate;
                    book.Publisher = item.volumeInfo.publisher;
                    book.RatingsCount = item.volumeInfo.ratingsCount;
                    book.Title = item.volumeInfo.title;
                    booksList.Add(book);
                    await _bookService.PostBook(book);
                }
            }
            catch (AlreadyInDBException e) {
                Console.WriteLine(e);
                return Problem("AlreadyInDBException: " + e.Message);
            }
            catch (NotFoundException e) {
                Console.WriteLine(e);
                return NotFound("NotFoundException: " + e.Message);
            }
            catch (BadRequestException e) {
                Console.WriteLine(e);
                return BadRequest("BadRequestException: " + e.Message);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return Problem("Exception: " + e.Message);
            }
            return Ok(booksList);
        }

                [HttpGet, Route("/search")]
        public async Task<IActionResult> Search([FromQuery(Name = "title")] string title)
        {
            IEnumerable<BookDTO> booksList ;
            try {
                    var result = await _bookService.GetBooks(new BooksFilters(){
                        FilterByTitle = title,
                        PageNumber = 1,
                        PageSize = 10,
                    });
                    if (result.Count() == 0) {
                        return NoContent();
                    }
                    booksList = await _shelvesService.SearchBooksInShelves(result);
            }
            catch (AlreadyInDBException e) {
                Console.WriteLine(e);
                return Problem("AlreadyInDBException: " + e.Message);
            }
            catch (NotFoundException e) {
                Console.WriteLine(e);
                return NotFound("NotFoundException: " + e.Message);
            }
            catch (BadRequestException e) {
                Console.WriteLine(e);
                return BadRequest("BadRequestException: " + e.Message);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return Problem("Exception: " + e.Message);
            }
            return Ok(booksList);
        }
    }
}
