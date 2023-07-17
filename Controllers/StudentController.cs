using Microsoft.AspNetCore.Mvc;
using Education_Assignments_App.Services;
using Education_Assignments_App.Models;

namespace Education_Assignments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _mongoDBService;

        public StudentController(StudentService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }
        [HttpGet]
        public async Task<List<Student>> Get() {
            return await _mongoDBService.GetAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            await _mongoDBService.CreateAsync(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToStudent(string id, [FromBody] string subject)
        {
            await _mongoDBService.AddToStudentAsync(id, subject);
            return NoContent();
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mongoDBService.DeleteAsync(id);
            return NoContent();
        }






    }
  

}
