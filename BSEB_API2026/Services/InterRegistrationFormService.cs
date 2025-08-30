using BSEB_API2026.Data;
using BSEB_API2026.Model.DTO;
using BSEB_API2026.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSEB_API2026.Services
{
    public class InterRegistrationFormService : _InterRegistrationFormService
    {
        private readonly AppDbContext _context;

        public InterRegistrationFormService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<StudentRegistrationDTo>> GetStudentRegistrationViewData(string studentId, string? collegeId, int facultyId)
        {
            try
            {
                // Fetch subjects once
                var subjects = await _context.SubjectPapers
                    .FromSqlRaw("EXEC sp_GetSubjectPapersByFacultyAndGroup @FacultyId",
                        new SqlParameter("@FacultyId", facultyId))
                    .ToListAsync();

                var studentIds = studentId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var allStudents = new List<StudentRegistrationDTo>();

                foreach (var id in studentIds)        
                {   
                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@StudentID", id.Trim()),
                        new SqlParameter("@CollegeId", (object?)collegeId ?? DBNull.Value),
                        new SqlParameter("@FacultyId", (object)facultyId ?? DBNull.Value),
                    };


                    var students = await _context.StudentRegistrationViewMaster
                        .FromSqlRaw("EXEC GetStudentInterRegiFormData @StudentID, @CollegeId, @FacultyId",
                            parameters.ToArray())
                        .ToListAsync();


                    var studentRegDtos = students.Select(s => new StudentRegistrationDTo
                    {
                        StudentName = s.StudentName ?? "",
                        FatherName = s.FatherName ?? "",
                        MotherName = s.MotherName ?? "",
                        DOB = s.DOB,
                        FormDownloaded = s.FormDownloaded,
                        CollegeCode = s.CollegeCode ?? "",
                        CollegeName = s.CollegeName ?? "",
                        DistrictName = s.DistrictName ?? "",
                        AadharNumber = s.AadharNumber ?? "",
                        AreaName = s.AreaName,
                        StudentBankAccountNo = s.StudentBankAccountNo,
                        IFSCCode = s.IFSCCode,
                        BankBranchName = s.BankBranchName,
                        IdentificationMark1 = s.IdentificationMark1,
                        IdentificationMark2 = s.IdentificationMark2,
                        DifferentlyAbled = s.DifferentlyAbled,
                        StudentPhotoPath = s.StudentPhotoPath,
                        StudentSignaturePath = s.StudentSignaturePath,
                        OFSSCAFNo = s.OFSSCAFNo ?? "",
                        CategoryName = s.CategoryName ?? "",
                        FacultyName = s.FacultyName ?? "",
                        MatricRollCode = s.MatricRollCode,
                        MatricRollNumber = s.MatricRollNumber ?? "",
                        MatricPassingYear = s.MatricPassingYear,
                        Gender = s.Gender ?? "",
                        MatricBoardName = s.MatricBoardName ?? "",
                        CasteCategory = s.CasteCategory ?? "",
                        Religion = s.Religion ?? "",
                        Nationality = s.Nationality ?? "",
                        MobileNo = s.MobileNo ?? "",
                        EmailId = s.EmailId ?? "",
                        StudentAddress = s.StudentAddress ?? "",
                        MediumName = s.MediumName ?? "",
                        MaritalStatus = s.MaritalStatus,
                        SubDivisionName = s.SubDivisionName,
                        Fk_NationalityId = s.Fk_NationalityId,
                        Subjects = subjects // Assign list directly
                    }).ToList();


                    allStudents.AddRange(studentRegDtos);
                }

                return allStudents;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching student data", ex);
            }
        }
    }
}
