using Microsoft.EntityFrameworkCore;

namespace BSEB_API2026.Model.DTO
{
#pragma warning disable 

    [Keyless] 
    public class GetStudentRegiListData
    {
        public string CollegeCode { get; set; }          
        public string StudentName { get; set; }         
     
        public string FatherName { get; set; }          
        public string MotherName { get; set; }          
       public string YearOfPassing { get; set; }          
     
    }
}
