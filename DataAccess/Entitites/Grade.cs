using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#nullable disable

namespace DataAccess.Entitites
{
    public class Grade
    {

        public int Id { get; set; }
        [Required, MaxLength(11)]
        public string Year { get; set; }

        
        


        public List<Student>Students { get; set; }
    }
}
