using BusinessLayer.DTO;
using BusinessLayer.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentContactController : Controller
    {
        private readonly IStudentContactService _service;
        public StudentContactController(IStudentContactService service)
        {
            _service = service;
        }

        // GET api/<StudentContactController>/Get/
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

        // GET api/<StudentContactController>/GetByUser/5
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

        // GET api/<StudentContactController>/GetById/5
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

        // GET api/<StudentContactController>/GetPage/?pageNum=5&pageLength=5
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

        // POST api/<StudentContactController>/Post
        [HttpPost]
        public IActionResult Post([FromBody] StudentContactDTO studentContact)
        {
            try
            {
                _service.Post(studentContact);
                return CreatedAtAction(nameof(GetById), new { id = studentContact.Id }, studentContact); // 201 Created
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // PUT api/<StudentContactController>/Put
        [HttpPut]
        public IActionResult Put([FromBody] StudentContactDTO studentContact)
        {
            try
            {
                _service.Put(studentContact);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // 500 Internal Server Error
            }
        }

        // DELETE api/<StudentContactController>/Delete/5
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
