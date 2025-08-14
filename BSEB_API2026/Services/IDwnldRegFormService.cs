using BSEB_API2026.Model.DTO;

namespace BSEB_API2026.Services
{
    public interface IDwnldRegFormService
    {
        Task<List<StudentDTO>> GetStudentDataAsync(int collegeId, string collegeCode, string studentName, int facultyId);
        Task<List<StudentExtendedDTO>> GetStudentDataforPayment(int collegeId, string collegeCode, string studentName, int facultyId,string subcategory);
    }
}
