using System.ComponentModel.DataAnnotations;

namespace BSEB_API2026.Model.DTO
{
    public class SeatSummary
    {
        
        public int Id { get; set; }                  
        public int RemainingRegularSeats { get; set; }
        public int RemainingPrivateSeats { get; set; }
        public int TotalPaymentDone { get; set; }
        public int TotalFormSubmitted { get; set; }
        public int PaymentDoneFormNotSubmitted { get; set; }
    }

    public class Student
    {
       
        public int Id { get; set; } 
        public string StudentName { get; set; } = string.Empty;
        public string CategoryType { get; set; } = "Regular";
        public string RegistrationMode { get; set; } = string.Empty;

        public int CollegeId { get; set; }
        public int FacultyId { get; set; }
    }

    public class StudentDetails
    {
     
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string CategoryType { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
      
    }
}