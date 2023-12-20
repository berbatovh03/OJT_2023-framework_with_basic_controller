using BusinessLayer.DTO;
using BusinessLayer.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        // GET api/<StudentController>/Get/
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

        // GET api/<StudentController>/GetByName/?name=name
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

        // GET api/<StudentController>/GetById/5
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

        // GET api/<StudentController>/GetPage/?pageNum=5&pageLength=5
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

        // GET api/<StudentController>/GetPageByName/?pageNum=5&pageLength=5&name=name
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

        // POST api/<StudentController>/Post
        [HttpPost]
        public IActionResult Post([FromBody] StudentDTO student)
        {
            try
            {
                _service.Post(student);
                return CreatedAtAction(nameof(GetById), new { id = student.Id }, student); // 201 Created
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // PUT api/<StudentController>/Put
        [HttpPut]
        public IActionResult Put([FromBody] StudentDTO student)
        {
            try
            {
                _service.Put(student);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // DELETE api/<StudentController>/Delete/5
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
