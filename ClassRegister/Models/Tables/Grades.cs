using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRegister.Models.Tables
{
    [Keyless]
    public class Grades
    {
        [ForeignKey("Courses")]
        public int CourseId { get; set; }
        
        [ForeignKey("Student"), Column(TypeName = "varchar(150)")]
        public string StudentId { get; set; }

        [Column(TypeName = "int(1)"), Range(1, 5, ErrorMessage = "Mark must be between 1 and 5")]
        public int Mark { get; set; }



        //Navigations
        
        public virtual Courses Courses { get; set; }
        public virtual Persons Student { get; set; }
    }
}
