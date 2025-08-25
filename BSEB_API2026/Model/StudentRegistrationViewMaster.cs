using System.Data;
using System.Globalization;

namespace BSEB_API2026.Model
{
    public class StudentRegistrationViewMaster
    {
        public string? StudentName { get; set; } = "";
        public string? FatherName { get; set; } = "";
        public string? MotherName { get; set; } = "";
        public DateTime? DOB { get; set; }
        public bool? FormDownloaded { get; set; }
        public string? CollegeCode { get; set; } = "";
        public string? CollegeName { get; set; } = "";
        public string? DistrictName { get; set; } = "";
        public string? AadharNumber { get; set; } = "";
        public string? AreaName { get; set; }
        public string? StudentBankAccountNo { get; set; }
        public string? IFSCCode { get; set; }
        public string? BankBranchName { get; set; }
        public string? IdentificationMark1 { get; set; }
        public string? IdentificationMark2 { get; set; }
        public bool? DifferentlyAbled { get; set; }
        public string? StudentPhotoPath { get; set; } = "";
        public string? StudentSignaturePath { get; set; } = "";
        public string? OFSSCAFNo { get; set; } = "";
        public string? CategoryName { get; set; } = "";
        public string? FacultyName { get; set; } = "";
        public int? MatricRollCode { get; set; }
        public string? MatricRollNumber { get; set; } = "";
        public string? MatricPassingYear { get; set; }
        public string? Gender { get; set; } = "";
        public string? MatricBoardName { get; set; } = "";
        public string? CasteCategory { get; set; } = "";
        public string? Religion { get; set; } = "";
        public string? Nationality { get; set; } = "";
        public string? MobileNo { get; set; } = "";
        public string? EmailId { get; set; } = "";
        public string? StudentAddress { get; set; } = "";
        public string? MediumName { get; set; } = "";
        public string? MaritalStatus { get; set; }
        public string? SubDivisionName { get; set; }
        public int? Fk_NationalityId { get; set; }

        public List<SubjectPaperResult> Subjects { get; set; } = new List<SubjectPaperResult>();
        //public CultureInfo? Language { get; set; }
    }

}
