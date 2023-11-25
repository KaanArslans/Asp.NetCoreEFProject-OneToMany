using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace DataAccess.Entitites
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

        public int GradeId { get; set; }
        public Grade Grade { get; set; }


    }
}
