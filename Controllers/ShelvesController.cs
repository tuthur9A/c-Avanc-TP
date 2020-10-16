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
        private readonly IShelvesService _shelvesService;

        public ShelvesController(IShelvesService shelvesService)
        {
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
            return Created("/shelve/add", result);
        }

        [HttpPut, Route("/shelves/{shelveId}/add/book/{bookId}")]
        public async Task<IActionResult> AddBookToShelve(string bookId, string shelveId)
        {
            ShelveDTO result;
            try {
                result = await _shelvesService.AddBookToShelve(bookId, shelveId);
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
            return Created("", result);
        }

        [HttpPut, Route("/shelves/{shelveId}/remove/book/{bookId}")]
        public async Task<IActionResult> DeleteBookFromShelve(string bookId, string shelveId)
        {
            ShelveDTO result;
            try {
                result = await _shelvesService.DeleteBookFromShelve(bookId,shelveId);
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
            return Ok(result);
        }

        [HttpPut, Route("/shelves/{id}/update")]
        public async Task<IActionResult> UpdateToShelve(string id, [FromBody] ShelveCreateDTO createShelveDTO)
        {
            ShelveDTO result;
            try {
                result = await _shelvesService.PutShelve(id, createShelveDTO);
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
            return Ok(result);
        }

        [HttpDelete, Route("/shelves/{id}")]
        public async Task<IActionResult> DeleteShelve(string id)
        {
            try {
                await _shelvesService.DeleteShelve(id);
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
            return NoContent();
        }
    }
}
