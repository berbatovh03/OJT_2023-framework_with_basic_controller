using BusinessLayer.DTO;
using BusinessLayer.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;
        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        // GET api/<SubjectController>/Get/
        [HttpGet]
        public ActionResult<List<SubjectDTO>> Get()
        {
            try
            {
                var subjects = _service.Get();
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET api/<SubjectController>/GetByName/?name=name
        [HttpGet]
        public ActionResult<List<SubjectDTO>> GetByName(string name)
        {
            try
            {
                var subjects = _service.Get(name);
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET api/<SubjectController>/GetById/5
        [HttpGet]
        public ActionResult<SubjectDTO?> GetById(int id)
        {
            try
            {
                var subject = _service.Get(id);
                if (subject == null)
                    return NotFound(); // 404 Not Found

                return Ok(subject);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET api/<SubjectController>/GetPage/?pageNum=5&pageLength=5
        [HttpGet]
        public ActionResult<List<SubjectDTO>> GetPage(int pageNum, int pageLength)
        {
            try
            {
                var subjects = _service.Get(pageNum, pageLength);
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET api/<SubjectController>/GetPageByName/?pageNum=5&pageLength=5&name=name
        [HttpGet]
        public ActionResult<List<SubjectDTO>> GetPageByName(int pageNum, int pageLength, string name)
        {
            try
            {
                var subjects = _service.Get(pageNum, pageLength, name);
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST api/<SubjectController>/Post
        [HttpPost]
        public ActionResult<ActionStatusDTO> Post(SubjectDTO subject)
        {
            try
            {
                var result = _service.Post(subject);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result); // 201 Created
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST api/<SubjectController>/Put
        [HttpPut]
        public ActionResult<ActionStatusDTO> Put(SubjectDTO subject)
        {
            try
            {
                var result = _service.Put(subject);
                if (result == null)
                    return NotFound(); // 404 Not Found

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST api/<SubjectController>/Delete
        [HttpDelete("{id}")]
        public ActionResult<ActionStatusDTO> Delete(int id)
        {
            try
            {
                var result = _service.Delete(id);
                if (result == null)
                    return NotFound(); // 404 Not Found

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
