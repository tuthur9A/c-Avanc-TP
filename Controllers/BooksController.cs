using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using TP.DTO;
using TP.Services.Book;
using TP.Services.GoogleAPI;

namespace TP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBooksService _bookService;
        private readonly IGoogleAPIClientService _googleApiClientService;

        public BooksController(ILogger<BooksController> logger, IBooksService bookService, IGoogleAPIClientService googleAPIClientService)
        {
            _logger = logger;
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            _googleApiClientService = googleAPIClientService ?? throw new ArgumentNullException(nameof(googleAPIClientService));
        }

        [HttpGet, Route("/")]
        public async Task<IEnumerable<BookDTO>> Get()
        {
            return await _bookService.GetBooks();
        }

        [HttpGet, Route("/google")]
        public async Task<IEnumerable<BookDTO>> GetFromGoogle([FromQuery(Name = "q")] string search)
        {
            var result = await _googleApiClientService.Search(search);
            Log.ForContext<BooksController>().Information(JsonConvert.SerializeObject(result));
            return new List<BookDTO>(){};
        }
    }
}
