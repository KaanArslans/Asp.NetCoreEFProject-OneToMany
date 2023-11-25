using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace Business.Models
{
    public class Student
    {


        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Surname { get; set; }
        public int? UniversityExamRank { get; set; }
        public decimal? CumulativeGpa { get; set; }
        [DisplayName("Grade")]
        public int GradeId { get; set; }



        [DisplayName("Grade")]
        public string GradeOutput { get; set; }


        [DisplayName("FullName")]
        public string FullNameOutput { get; set; }






    }
}
