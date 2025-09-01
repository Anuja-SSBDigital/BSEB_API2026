using Microsoft.EntityFrameworkCore;
using BSEB_API2026.Data;
using BSEB_API2026.Model.DTO;
using BSEB_API2026.Services;
using System.Data;

namespace CollegeSeatAPI.Services
{
    public class CollegeService : IStudentRegistrationService
    {
        private readonly AppDbContext _db;

        public CollegeService(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get students list by calling stored procedure: sp_GetStudentRegiListData
        /// </summary>
        public async Task<IEnumerable<GetStudentRegiListData>> GetStudentsAsync(
            int collegeId,
            int facultyId,     
            string regMode,     
            string? categoryType,           
            string? studentName)   
        {
            if (string.IsNullOrWhiteSpace(regMode))
                throw new ArgumentException(
                    "regMode is required and must be one of: ofss, non-ofss, display-registered.",
                    nameof(regMode));    
             
            var mode = regMode.Trim().ToLowerInvariant();
                  
           
            // Validate and default CategoryType based on SP logic
            switch (mode)
            {
                case "ofss":
                    if (string.IsNullOrWhiteSpace(categoryType))
                        categoryType = "Regular";
                    break;

                case "non-ofss":
                    if (string.IsNullOrWhiteSpace(categoryType))
                        categoryType = "Private";
                    break;

                case "display-registered":
                    if (string.IsNullOrWhiteSpace(categoryType))
                        throw new ArgumentException(
                            "For regMode=display-registered, categoryType is required (e.g., 'Regular' or 'Private').",
                            nameof(categoryType));
                    break;

                default:
                    throw new ArgumentException(
                        "regMode must be one of: ofss, non-ofss, display-registered.",
                        nameof(regMode));
            }

            // Let studentName remain null/empty, SP handles both
            var rows = await _db.Set<GetStudentRegiListData>()
                .FromSqlInterpolated($@"
                    EXEC dbo.sp_GetStudentRegiListData 
                        @CollegeId        = {collegeId},
                        @FacultyId        = {facultyId},
                        @RegistrationMode = {mode},
                        @CategoryType     = {categoryType},
                        @StudentName      = {studentName}")
                .ToListAsync();

            return rows;
        }

        /// <summary>
        /// Example: faculty dropdown SP
        /// </summary>
        public async Task<IEnumerable<FacultyDto>> GetFacultyDropdownAsync()
        {
            return await _db.Set<FacultyDto>()
                .FromSqlRaw("EXEC sp_GetFacultyDropdown")
                .ToListAsync();
        }
    }
}
