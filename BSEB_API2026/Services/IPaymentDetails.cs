using BSEB_API2026.Model;


namespace BSEB_API2026.Services
{
    public interface IPaymentDetails
    {

        Task<List<REGPaymentTransactionSummary>> GetREGPaymentDetails(int collegeId, string collegeCode, string ClientTxnId);
		

    }


}
