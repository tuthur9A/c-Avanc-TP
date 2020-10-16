using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using TP.DTO;
using TP.Services.Book;
using TP.Services.GoogleAPI;
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
        [HttpGet, Route("/shelve/add")]
        public async Task<IActionResult> AddToShelve([FromQuery(Name = "id")] string id)
        {
            ShelveDTO result;
            try {
                var createShelve = new ShelveCreateDTO() {
                    BookId = id,
                };
                result = await _shelvesService.PostShelve(createShelve);
            }
            catch (ArgumentException e) {
                Console.WriteLine(e);
                return Problem(e.Message);
            }
            return Ok(result);
        }
    }
}
