using BSEB_API2026.Model.DTO;

namespace BSEB_API2026.Services
{
    public interface _InterRegistrationFormService
    {
        Task<List<StudentRegistrationDTo>> GetStudentRegistrationViewData(string studentId, string? collegeId,int facultyId);
    }
}
