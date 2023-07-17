using Education_Assignments_App.Models;
using Education_Assignments_App.Services;
using Education_Essignments_App.Models;
using Education_Essignments_App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education_Essignments_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    { 
        private readonly TeacherService _teacherService;
        private TeacherController(TeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        public async Task<List<Teacher>> Get()
        {
            return await _teacherService.GetAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Teacher teacher)
        {
            await _teacherService.CreateAsync(teacher);
            return CreatedAtAction(nameof(Get), new { id = teacher.Id }, teacher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToStudent(string id, [FromBody] string departement)
        {
            await _teacherService.AddToTeacherAsync(id, departement);
            return NoContent();
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> Delete(string id)
        {
            await _teacherService.DeleteAsync(id);
            return NoContent();
        }

    }
}
