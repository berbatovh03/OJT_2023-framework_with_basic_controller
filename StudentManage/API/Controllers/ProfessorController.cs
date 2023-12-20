using BusinessLayer.DTO;
using BusinessLayer.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        private readonly IProfessorService _service;
        public ProfessorController(IProfessorService service)
        {
            _service = service;
        }

        // GET api/<ProfessorController>/Get/
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

        // GET api/<ProfessorController>/GetByName/?name=name
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            try
            {
                var result = _service.Get(name);
                return Ok(result); // 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // GET api/<ProfessorController>/GetBySubject/5
        [HttpGet]
        public IActionResult GetBySubject(int id)
        {
            try
            {
                var result = _service.GetBySubject(id);
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

        // GET api/<ProfessorController>/GetById/5
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

        // GET api/<ProfessorController>/GetPage/?pageNum=5&pageLength=5
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

        // GET api/<ProfessorController>/GetPageByName/?pageNum=5&pageLength=5&name=name
        [HttpGet]
        public IActionResult GetPageByName(int pageNum, int pageLength, string name)
        {
            try
            {
                var result = _service.Get(pageNum, pageLength, name);
                return Ok(result); // 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // POST api/<ProfessorController>/Post
        [HttpPost]
        public IActionResult Post([FromBody] ProfessorDTO professor)
        {
            try
            {
                _service.Post(professor);
                return CreatedAtAction(nameof(GetById), new { id = professor.Id }, professor); // 201 Created
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // PUT api/<ProfessorController>/Put
        [HttpPut]
        public IActionResult Put([FromBody] ProfessorDTO professor)
        {
            try
            {
                _service.Put(professor);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // DELETE api/<ProfessorController>/Delete/5
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
