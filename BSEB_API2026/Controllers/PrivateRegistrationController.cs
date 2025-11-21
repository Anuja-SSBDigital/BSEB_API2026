using BSEB_API2026.Data;
using BSEB_API2026.Model.DTO;
using BSEB_API2026.Services;
using Microsoft.AspNetCore.Mvc;

namespace BSEB_API2026.Controllers
{
    public class PrivateRegistrationController : Controller
    {

        private readonly ITheoryadmitcardService _service;
        private readonly AppDbContext _db;
        private readonly IStudentRegistrationService _studentRegistrationService;

        public PrivateRegistrationController(
            ITheoryadmitcardService service,
            AppDbContext db,
            IStudentRegistrationService studentRegistrationService)
        {
            _service = service;
            _db = db;
            _studentRegistrationService = studentRegistrationService;
        }

        [NonAction]
        [HttpGet("faculties")]
        public async Task<IActionResult> GetFaculties()
        {
            var data = await _service.GetFacultiesAsync();
            return Ok(data);
        }

        [HttpGet("PrivateStudentsRegisterList")]
        public async Task<IActionResult> ViewStudentsList(
            [FromQuery] int collegeId,
            [FromQuery] int facultyId,
            [FromQuery] string regMode,
            [FromQuery] string? categoryType,
            [FromQuery] string? studentName)
        {
            try
            {

                // ✅ Use the correct service for student registration
                var data = await _studentRegistrationService
                    .GetStudentsAsync(collegeId, facultyId, regMode, categoryType, studentName);

               
                if (data is null || !data.Any())
                    return NotFound(new { message = "No records found." });

                return Ok(data);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error", detail = ex.Message });
            }
        }


        [NonAction]
        [HttpPost("student/{studentId}/register")]
        public IActionResult RegisterStudent(string studentId, string categoryType = "Regular")
        {
            return Ok(new
            {
                Message = "Redirect to student registration form",
                Url = $"studentregform?studentId={studentId}&categoryType={categoryType}"
            });
        }


        [NonAction]
        [HttpDelete("student/{studentId}")]
        public IActionResult DeleteStudent(string studentId)
        {
            return Ok(new { Message = $"Student {studentId} deleted successfully" });
        }
    }
}

