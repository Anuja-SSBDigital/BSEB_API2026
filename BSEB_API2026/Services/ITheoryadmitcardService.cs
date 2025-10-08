using BSEB_API2026.Model.DTO;

namespace BSEB_API2026.Services
{
    public interface ITheoryadmitcardService
    {
        Task<IEnumerable<FacultyDto>> GetFacultiesAsync();
        Task<IEnumerable<StudentDto>> GetStudentsAsync(string collegeId, string facultyId);
    }
}
