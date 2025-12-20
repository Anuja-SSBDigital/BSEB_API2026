using BSEB_API2026.Model.DTO;
using BSEB_API2026.Services;
using Microsoft.AspNetCore.Mvc;

#pragma warning disable

namespace BSEB_API2026.Controllers
{
    public class PracticaladmitcardController : Controller
    {
        private readonly IPracticaladmitcardService _service;

        private readonly PracticaladmitcardService _admitCardService;

        public PracticaladmitcardController(IPracticaladmitcardService service)
        {
            _service = service;
        }


        [NonAction]
        [HttpGet("faculties")]
        public async Task<IActionResult> GetFaculties()
        {
            var data = await _service.GetFacultiesAsync();
            return Ok(data);
        }


        [HttpGet("PracticalAdmitCardsStudentLists")]
        public async Task<IActionResult> GetStudents([FromQuery] string collegeId, [FromQuery] string facultyId)
        {

            var data = await _service.GetStudentsAsync(collegeId, facultyId);
            if (!data.Any())
                return NotFound(new { message = "No students found" });

            return Ok(data);
        }


        [NonAction]
        [HttpPost("download-admitcards")]
        public IActionResult DownloadAdmitCards([FromBody] List<StudentDto> selectedStudents)
        {

            if (selectedStudents == null || selectedStudents.Count == 0)
                return BadRequest(new { message = "Please select at least one student" });


            return Ok(new
            {
                message = "Admit cards generated",
                students = selectedStudents
            });
        }
    }
}