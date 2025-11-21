namespace BSEB_API2026.Model.DTO

#pragma warning disable
{
    public class FacultyDto
    {
        public string FacultyId { get; set; }
        public string FacultyName { get; set; }
    }
    public class StudentDto
    {
       
        public string StudentId { get; set; }
        public string CollegeId { get; set; }
        public string CollegeName { get; set; }
        public string FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string ExamTypeId { get; set; }
        public bool IsRegCardUploaded { get; set; }

        public string StudentFullName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string DOB { get; set; }   // keep as


    }
}
