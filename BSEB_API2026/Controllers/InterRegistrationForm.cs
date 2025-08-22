using BSEB_API2026.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSEB_API2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterRegistrationForm : ControllerBase
    {
        private readonly _InterRegistrationFormService _InterRegistrationFormService;

        public InterRegistrationForm(_InterRegistrationFormService InterRegistrationFormService)
        {
            _InterRegistrationFormService = InterRegistrationFormService;
        }

        [HttpGet("GetStudentRegistrationViewDataAsync")]
        public async Task<IActionResult> GetStudentRegistrationViewDataAsync(string studentIds, string? CollegeId, int facultyId)
        {

            CollegeId = string.IsNullOrWhiteSpace(CollegeId) ? "" : CollegeId;
            CollegeId = string.IsNullOrWhiteSpace(CollegeId) ? "" : CollegeId;
            var result = await _InterRegistrationFormService.GetStudentRegistrationViewData(studentIds, CollegeId, facultyId);
            return Ok(result);
        }
    }
}
