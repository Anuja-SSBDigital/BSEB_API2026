using BSEB_API2026.Model;
using BSEB_API2026.Model.DTO;

namespace BSEB_API2026.Services
{
    public interface ILoginService
    {
        Task<(List<CollegeMaster> data, string message)> GetStudentData(string username, string password);
    }
}
