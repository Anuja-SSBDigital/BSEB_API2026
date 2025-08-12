using BSEB_API2026.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSEB_API2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DwnldRegForm : ControllerBase
    {
        private readonly IDwnldRegFormService _DwnldRegFormService;

        public DwnldRegForm(IDwnldRegFormService DwnldRegFormService)
        {
            _DwnldRegFormService = DwnldRegFormService;
        }

        [HttpGet("GetStudentData")]
        public async Task<IActionResult> GetStudentData(int collegeId, string collegeCode, string studentName, int facultyId)
        {
            var result = await _DwnldRegFormService.GetStudentDataAsync(collegeId, collegeCode, studentName, facultyId);
            return Ok(result);
        }
    }
}
