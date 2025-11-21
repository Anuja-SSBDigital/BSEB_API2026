namespace BSEB_API2026.Model.DTO
{
    public class SeatSummaryDto
    {
        public int RemainingRegularSeats { get; set; }
        public int RemainingPrivateSeats { get; set; }
        public int TotalPaymentDone { get; set; }
        public int TotalFormSubmitted { get; set; }
        public int PaymentDoneFormNotSubmitted { get; set; }
    }

    public class FacultyDto2
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; } = string.Empty;
    }

    public class StudentDto2
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string CategoryType { get; set; } = "Regular";
        public string RegistrationMode { get; set; } = string.Empty;
    }
}