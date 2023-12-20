using BusinessLayer.DTO;
using BusinessLayer.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfessorContactController : Controller
    {
        private readonly IProfessorContactService _service;
        public ProfessorContactController(IProfessorContactService service)
        {
            _service = service;
        }

        // GET api/<ProfessorContactController>/Get/
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _service.Get();
                return Ok(result); // 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // GET api/<ProfessorContactController>/GetByUser/5
        [HttpGet]
        public IActionResult GetByUser(int id)
        {
            try
            {
                var result = _service.GetByUser(id);
                if (result != null)
                {
                    return Ok(result); // 200 OK
                }
                else
                {
                    return NotFound(); // 404 Not Found
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // GET api/<ProfessorContactController>/GetById/5
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _service.Get(id);
                if (result != null)
                {
                    return Ok(result); // 200 OK
                }
                else
                {
                    return NotFound(); // 404 Not Found
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // GET api/<ProfessorContactController>/GetPage/?pageNum=5&pageLength=5
        [HttpGet]
        public IActionResult GetPage(int pageNum, int pageLength)
        {
            try
            {
                var result = _service.Get(pageNum, pageLength);
                return Ok(result); // 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // POST api/<ProfessorContactController>/Post
        [HttpPost]
        public IActionResult Post([FromBody] ProfessorContactDTO professorContact)
        {
            try
            {
                var x= _service.Post(professorContact);
                professorContact.Id = x.objectIds[0];
                return CreatedAtAction(nameof(GetById), new { id = x.objectIds }, professorContact); // 201 Created
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // PUT api/<ProfessorContactController>/Put
        [HttpPut]
        public IActionResult Put([FromBody] ProfessorContactDTO professorContact)
        {
            try
            {
                _service.Put(professorContact);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // DELETE api/<ProfessorContactController>/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }
    }
}
