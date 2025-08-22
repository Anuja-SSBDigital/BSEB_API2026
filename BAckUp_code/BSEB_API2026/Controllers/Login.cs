using BSEB_API2026.Model.DTO;
using BSEB_API2026.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BSEB_API2026.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _LoginService;

        public LoginController(ILoginService loginService)
        {

            _LoginService = loginService;
        }

        [HttpGet("LoginData")]
        public async Task<IActionResult> LoginData(string UserName, string Password)
        {
            var (data, message) = await _LoginService.GetStudentData(UserName, Password);
            if (data == null || data.Count == 0)
            {
                return NotFound(new ApiResponse<List<CollegeMaster>>(message, null));
            }

            return Ok(new ApiResponse<List<CollegeMaster>>(message, data));
        }
    }
}
