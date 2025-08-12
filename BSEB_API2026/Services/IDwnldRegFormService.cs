using BSEB_API2026.Model.DTO;

namespace BSEB_API2026.Services
{
    public interface IDwnldRegFormService
    {
        Task<List<StudentDTo>> GetStudentDataAsync(int collegeId, string collegeCode, string studentName, int facultyId);
    }
}
