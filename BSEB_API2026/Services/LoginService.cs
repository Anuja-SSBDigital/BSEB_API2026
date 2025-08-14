using BSEB_API2026.Data;
using BSEB_API2026.Model;
using BSEB_API2026.Model.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace BSEB_API2026.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(List<CollegeMaster> data, string message)> GetStudentData(string username, string password)
        {
            string hashedPassword = ComputeSha256Hash(password);
            string message = "";

            var usernameParam = new SqlParameter("@Username", username);
            var passwordParam = new SqlParameter("@Password", hashedPassword);

            var isSuccessParam = new SqlParameter("@IsSuccess", System.Data.SqlDbType.Bit)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            var messageParam = new SqlParameter("@Message", System.Data.SqlDbType.NVarChar, 100)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            try
            {
                var data = await _context.CollegeMaster.FromSqlRaw("EXEC sp_LoginUser @Username, @Password, @IsSuccess OUT, @Message OUT", usernameParam, passwordParam, isSuccessParam, messageParam).ToListAsync();

                message = messageParam.Value?.ToString() ?? "No message";
                return (data, message);
            }
            catch (Exception ex)
            {

                throw new Exception("Error during login: " + ex.Message, ex);
            }
        }


        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    }
}
