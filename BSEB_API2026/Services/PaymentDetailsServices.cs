using BSEB_API2026.Data;
using BSEB_API2026.Model;
using BSEB_API2026.Model.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BSEB_API2026.Services
{
    public class PaymentDetailsServices : IPaymentDetails
    {
        private readonly AppDbContext _context;
        private List<REGPaymentTransactionSummary> paymentModel;

        public PaymentDetailsServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<REGPaymentTransactionSummary>> GetREGPaymentDetails(int collegeId, string collegeCode, string ClientTxnId)
        {
            try
            {
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@CollegeId", (object)collegeId ?? DBNull.Value),
            new SqlParameter("@CollegeCode", (object?)collegeCode ?? DBNull.Value),
            new SqlParameter("@ClientTxnId", (object?)ClientTxnId ?? DBNull.Value),
            
        };

                //var paymentdetails = await _context.REGPaymentTransactionSummary
                //    .FromSqlRaw("EXEC sp_GetStudentPaymentDetails @CollegeId, @CollegeCode, @ClientTxnId",
                //        parameters.ToArray())
                //    .ToListAsync();

                //var paymentModel = paymentdetails.Select(s => new REGPaymentTransactionSummary
                //{
                //    CollegeCode = s.CollegeCode,
                //    ClientTxnId = s.ClientTxnId ?? "",
                //    StudentsPerTransaction = s.StudentsPerTransaction,
                //    AmountPaid = s.AmountPaid,
                //    PaymentInitiateDate = s.PaymentInitiateDate,
                //    PaymentUpdatedDate = s.PaymentUpdatedDate,
                //    PaymentStatus = s.PaymentStatus
                   

                //}).ToList();

                return paymentModel;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching student data", ex);
            }
        }
    }
}
