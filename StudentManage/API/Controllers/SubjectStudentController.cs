using BusinessLayer.DTO;
using BusinessLayer.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectStudentController : ControllerBase
    {
        private readonly ISubjectStudentService _service;
        public SubjectStudentController(ISubjectStudentService service)
        {
            _service = service;
        }

        // GET api/<SubjectStudentController>/Get/
        [HttpGet]
        public ActionResult<List<SubjectStudentDTO>> Get()
        {
            try
            {
                var subjectStudents = _service.Get();
                return Ok(subjectStudents);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET api/<SubjectStudentController>/GetById/?subjectId=5&studentId=5
        [HttpGet]
        public ActionResult<SubjectStudentDTO?> GetById(int subjectId, int studentId)
        {
            try
            {
                var subjectStudent = _service.Get(subjectId, studentId);
                if (subjectStudent == null)
                    return NotFound(); // 404 Not Found

                return Ok(subjectStudent);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET api/<SubjectStudentController>/GetByStudent/5
        [HttpGet]
        public ActionResult<List<SubjectStudentDTO>> GetByStudent(int id)
        {
            try
            {
                var subjectStudents = _service.GetByStudent(id);
                return Ok(subjectStudents);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET api/<SubjectStudentController>/GetBySubject/5
        [HttpGet]
        public ActionResult<List<SubjectStudentDTO>> GetBySubject(int id)
        {
            try
            {
                var subjectStudents = _service.GetBySubject(id);
                return Ok(subjectStudents);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET api/<SubjectStudentController>/GetPage/?pageNum=5&pageLength=5
        [HttpGet]
        public ActionResult<List<SubjectStudentDTO>> GetPage(int pageNum, int pageLength)
        {
            try
            {
                var subjectStudents = _service.GetPage(pageNum, pageLength);
                return Ok(subjectStudents);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST api/<SubjectStudentController>/Post
        [HttpPost]
        public ActionResult<ActionStatusDTO> Post(SubjectStudentDTO subject)
        {
            try
            {
                var result = _service.Post(subject);
                subject.SubjectId = result.ObjectIds[0];
                subject.StudentId = result.ObjectIds[1];
                return CreatedAtAction(nameof(GetById), new { subjectId = subject.SubjectId, studentId = subject.StudentId }, result);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST api/<SubjectStudentController>/Put
        [HttpPut]
        public ActionResult<ActionStatusDTO> Put(SubjectStudentDTO subject)
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

        // POST api/<SubjectStudentController>/Delete
        [HttpDelete]
        public ActionResult<ActionStatusDTO> Delete(int subjectId, int studentId)
        {
            try
            {
                var result = _service.Delete(subjectId, studentId);
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
