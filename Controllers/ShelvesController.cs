using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP.CustomException;
using TP.DTO;
using TP.Filters;
using TP.Services.Shelve;

namespace TP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShelvesController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IShelvesService _shelvesService;
        private readonly IMapper _mapper;

        public ShelvesController(ILogger<BooksController> logger, IShelvesService shelvesService, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _shelvesService = shelvesService ?? throw new ArgumentNullException(nameof(shelvesService));
        }
        
        [HttpGet, Route("/shelves")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ShelveDTO> result;
            try {
                result = await _shelvesService.GetShelves(new ShelvesFilters(){});
            }
            catch (AlreadyInDBException e) {
                Console.WriteLine(e);
                return Problem(e.Message);
            }
            catch (NotFoundException e) {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
            catch (BadRequestException e) {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
            return Ok(result);
        }

        [HttpGet, Route("/shelves/search")]
        public async Task<IActionResult> Search([FromQuery (Name = "id")] string id)
        {
            IEnumerable<ShelveDTO> result;
            try {
                result = await _shelvesService.GetShelves(new ShelvesFilters(){
                    FilterByBookId = id,
                });
            }
            catch (AlreadyInDBException e) {
                Console.WriteLine(e);
                return Problem(e.Message);
            }
            catch (NotFoundException e) {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
            catch (BadRequestException e) {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
            return Ok(result);
        }
        
        [HttpPost, Route("/shelves/add")]
        public async Task<IActionResult> AddToShelve([FromBody] ShelveCreateDTO createShelveDTO)
        {
            ShelveDTO result;
            try {
                result = await _shelvesService.PostShelve(createShelveDTO);
            }
            catch (AlreadyInDBException e) {
                Console.WriteLine(e);
                return Problem(e.Message);
            }
            catch (NotFoundException e) {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
            catch (BadRequestException e) {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
            catch (ArgumentNullException e) {
                Console.WriteLine(e);
                return Problem(e.Message);
            }
            return Created("/shelve/add", result);
        }
    }
}
