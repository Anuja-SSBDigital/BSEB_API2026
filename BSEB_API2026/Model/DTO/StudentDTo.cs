namespace BSEB_API2026.Model.DTO
{
    public class StudentDTo
    {
        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public DateTime? DOB { get; set; }
        public string? Faculty { get; set; }
        public string? College { get; set; }
        public bool? FormDownloaded { get; set; }

        public int? FacultyId { get; set; }
        public int? CollegeId { get; set; }
    }
}
