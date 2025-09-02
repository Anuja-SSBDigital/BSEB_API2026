using BSEB_API2026.Data;    
using BSEB_API2026.Model.DTO;
using BSEB_API2026.Services;  
using Microsoft.AspNetCore.Mvc;

#pragma warning disable 

namespace BSEB_API2026.Controllers 
{
    [ApiController]          
    [Route("api/[controller]")]
    public class RegularRegistrationController : ControllerBase
    {
        private readonly ITheoryadmitcardService _service;
        private readonly AppDbContext _db;
        private readonly IStudentRegistrationService _studentRegistrationService;

        public RegularRegistrationController(
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

             

        [HttpGet("RegularStudentsRegisterList")]

        public async Task<IActionResult> ViewStudentsList(
            [FromQuery] int collegeId,        
            [FromQuery] int facultyId,
            [FromQuery] string regMode,               
            [FromQuery] string? categoryType,  
            [FromQuery] string? studentName)
        {
            try
            {
              
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
