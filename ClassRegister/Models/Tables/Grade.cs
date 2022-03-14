using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRegister.Models.Tables
{
    [Keyless]
    public class Grade
    {
        [ForeignKey("Courses"), Column("course_id")]
        public int CourseId { get; set; }
        
        [ForeignKey("Student"), Column("student_id", TypeName = "varchar(150)")]
        public string StudentId { get; set; }

        [Column("mark", TypeName = "int(1)"), Range(1, 5, ErrorMessage = "Mark must be between 1 and 5")]
        public int Mark { get; set; }



        //Navigations
        
        public virtual Course Courses { get; set; }
        public virtual Person Student { get; set; }
    }
}
