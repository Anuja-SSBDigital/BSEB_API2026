using BSEB_API2026.Model.DTO;
using System.Data;
using Microsoft.Data.SqlClient;

#pragma warning disable
namespace BSEB_API2026.Services
{
    public class PracticaladmitcardService:IPracticaladmitcardService
    {
        private readonly IConfiguration _config;

        public PracticaladmitcardService(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnString()
        {
            var cs = _config.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(cs))
                throw new InvalidOperationException("Connection string 'dbcs' not found or empty.");
            return cs;
        }

        public async Task<IEnumerable<FacultyDto>> GetFacultiesAsync()
        {
            var faculties = new List<FacultyDto>();
            using var conn = new SqlConnection(GetConnString());
            await conn.OpenAsync();

            // Adjust schema/table name if different
            const string sql = @"SELECT Pk_FacultyId, FacultyName FROM dbo.Faculty_Mst";

            using var cmd = new SqlCommand(sql, conn) { CommandType = CommandType.Text };
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                faculties.Add(new FacultyDto
                {
                    FacultyId = reader["Pk_FacultyId"] is DBNull ? null : Convert.ToString(reader["Pk_FacultyId"]),
                    FacultyName = reader["FacultyName"] is DBNull ? null : Convert.ToString(reader["FacultyName"])
                });
            }
            return faculties;
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync(string collegeId, string facultyId)
        {
            // Defensive trims
            collegeId = string.IsNullOrWhiteSpace(collegeId) ? null : collegeId.Trim();
            facultyId = string.IsNullOrWhiteSpace(facultyId) ? null : facultyId.Trim();

            var students = new List<StudentDto>();
            using var conn = new SqlConnection(GetConnString());
            await conn.OpenAsync();

            const string sql = @"
SELECT 
    stu.Pk_StudentId      AS StudentId,
    stu.StudentFullName,
    stu.FatherName,
    stu.MotherName,
    CONVERT(VARCHAR(10), stu.DOB, 103) AS DOB,
    stu.Fk_CollegeId      AS CollegeId,
    col.CollegeName,
    stu.Fk_FacultyId      AS FacultyId,
    fac.FacultyName,
    stu.Fk_ExamTypeId     AS ExamTypeId,
    CAST(CASE 
         WHEN ISNULL(stu.RegistrationNo, '') <> '' THEN 1 
         ELSE 0 
    END AS bit)            AS IsRegCardUploaded
FROM dbo.Student_Mst stu
LEFT JOIN dbo.College_Mst col ON stu.Fk_CollegeId = col.Pk_CollegeId
LEFT JOIN dbo.Faculty_Mst fac ON stu.Fk_FacultyId = fac.Pk_FacultyId
WHERE (@CollegeId IS NULL OR stu.Fk_CollegeId = @CollegeId)
  AND (@FacultyId IS NULL OR stu.Fk_FacultyId = @FacultyId)
ORDER BY stu.Pk_StudentId DESC;
";

            using var cmd = new SqlCommand(sql, conn) { CommandType = CommandType.Text };
            cmd.Parameters.Add("@CollegeId", SqlDbType.VarChar, 50).Value = (object?)collegeId ?? DBNull.Value;
            cmd.Parameters.Add("@FacultyId", SqlDbType.VarChar, 50).Value = (object?)facultyId ?? DBNull.Value;

            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                students.Add(new StudentDto
                {
                    StudentId = reader["StudentId"]?.ToString(),
                    StudentFullName = reader["StudentFullName"]?.ToString(),
                    FatherName = reader["FatherName"]?.ToString(),
                    MotherName = reader["MotherName"]?.ToString(),
                    DOB = reader["DOB"]?.ToString(),
                    CollegeId = reader["CollegeId"]?.ToString(),

                    //CollegeName = reader["CollegeName"]?.ToString(),
                    //FacultyId = reader["FacultyId"]?.ToString(),
                    //FacultyName = reader["FacultyName"]?.ToString(),
                    //ExamTypeId = reader["ExamTypeId"]?.ToString(),
                    //IsRegCardUploaded = reader["IsRegCardUploaded"] is not DBNull &&
                    //                    Convert.ToBoolean(reader["IsRegCardUploaded"])


                    CollegeName = reader["CollegeName"]?.ToString(),
                    FacultyId = reader["FacultyId"]?.ToString(),
                    FacultyName = reader["FacultyName"]?.ToString(),
                    ExamTypeId = reader["ExamTypeId"]?.ToString(),
                    IsRegCardUploaded = reader["IsRegCardUploaded"] is not DBNull &&
                                        Convert.ToBoolean(reader["IsRegCardUploaded"])
                });
            }

            return students;
        }

    }
}

