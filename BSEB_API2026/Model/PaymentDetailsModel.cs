namespace BSEB_API2026.Model
{
    public class REGPaymentTransactionSummary
    {
        public int Pk_PaymentId { get; set; }
        public int Fk_CollegeId { get; set; }
        public int Fk_FeeTypeId { get; set; }
        public string? BankGateway { get; set; }
        public string? PaymentMode { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public string? ClientTxnId { get; set; }
        public string? GatewayTxnId { get; set; }
        public string? BankTxnId { get; set; }
        public string? PaymentStatus { get; set; }
        public string? PaymentStatusCode { get; set; }
        public DateTime? PaymentInitiateDate { get; set; }
        public DateTime? PaymentUpdatedDate { get; set; }
        public DateTime PaymentCreatedOn { get; set; }
        public int StudentsPerTransaction { get; set; }
        public string? CollegeName { get; set; }
        public string? CollegeCode { get; set; }
    }

    public class REGPaymentStudentDetail
    {
        public int Pk_StudentPaymentId { get; set; }
        public int Fk_StudentId { get; set; }
        public int Fk_PaymentId { get; set; }
        public DateTime StudentPaymentCreatedOn { get; set; }
        public string? CategoryName { get; set; }
        public int Fk_FacultyId { get; set; }
        public string? StudentFullName { get; set; }
        public DateTime DOB { get; set; }
        public string? FacultyName { get; set; }
        public string? BoardName { get; set; }
        public string? ClientTxnId { get; set; }
        public string? CollegeName { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
    }
}
