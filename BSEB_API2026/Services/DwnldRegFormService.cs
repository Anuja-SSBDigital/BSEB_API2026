using BSEB_API2026.Data;
using BSEB_API2026.Model.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BSEB_API2026.Services
{
    public class DwnldRegFormService : IDwnldRegFormService
    {
        private readonly AppDbContext _context;

        public DwnldRegFormService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<StudentDTO>> GetStudentDataAsync(string? collegeId, string? collegeCode, string? studentName, int facultyId)
        {
            try
            {
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@CollegeId", (object)collegeId ?? DBNull.Value),
            new SqlParameter("@CollegeCode", (object?)collegeCode ?? DBNull.Value),
            new SqlParameter("@StudentName", (object?)studentName ?? DBNull.Value),
            new SqlParameter("@FacultyId", (object)facultyId ?? DBNull.Value),
            new SqlParameter("@SubCategory", "")
        };

                var students = await _context.StudentMaster
                    .FromSqlRaw("EXEC sp_GetStudentDetails @CollegeId, @CollegeCode, @StudentName, @FacultyId, @SubCategory",
                        parameters.ToArray())
                    .ToListAsync();

                var studentDtos = students.Select(s => new StudentDTO
                {
                    StudentID = s.StudentID,
                    StudentName = s.StudentName ?? "",
                    Faculty = s.Faculty ?? "",
                    College = s.College ?? "",
                    FatherName = s.FatherName ?? "",
                    MotherName = s.MotherName ?? "",
                    DOB = s.DOB ?? DateTime.MinValue,
                    FormDownloaded = s.FormDownloaded ?? false,
                    FacultyId = s.FacultyId ?? 0,
                    CollegeId = s.CollegeId ?? 0
   
                }).ToList();


                return studentDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching student data", ex);
            }
        }



        public async Task<List<StudentExtendedDTO>> GetStudentDataforPayment(int collegeId, string? collegeCode, string? studentName, int facultyId, string? subCategory)
        {
            try
            {
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@CollegeId", (object)collegeId ?? DBNull.Value),
            new SqlParameter("@CollegeCode", (object?)collegeCode ?? DBNull.Value),
            new SqlParameter("@StudentName", (object?)studentName ?? DBNull.Value),
            new SqlParameter("@FacultyId", (object)facultyId ?? DBNull.Value),
            new SqlParameter("@SubCategory", (object?)subCategory ?? DBNull.Value)
        };

                var students = await _context.StudentPaymentMaster
                    .FromSqlRaw("EXEC sp_GetStudentDetails @CollegeId, @CollegeCode, @StudentName, @FacultyId, @SubCategory",
                        parameters.ToArray())
                    .ToListAsync();

                var studentDtos = students.Select(s => new StudentExtendedDTO
                {
                    StudentID = s.StudentID,
                    Name = s.Name ?? "",
                    Faculty = s.Faculty ?? "",
                    College = s.College ?? "",
                    FatherName = s.FatherName ?? "",
                    MotherName = s.MotherName ?? "",
                    DOB = s.DOB ?? DateTime.MinValue,
               
               

                    BoardName = s.BoardName ?? "",
                    CategoryName = s.CategoryName ?? "",

                    FeeAmount = s.FeeAmount
                }).ToList();


                return studentDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching student data", ex);
            }
        }

    }
}
