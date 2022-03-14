using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRegister.Models.Tables
{
    [Keyless]
    public class Enrollment
    {
        [ForeignKey("Courses"), Column("course_id")]
        public int CourseId { get; set; }
        
        [ForeignKey("Persons"), Column("student_id")]
        public string StudentId { get; set; }

        [DataType(DataType.Date), Column("enrollment_date")]
        public DateTime EnrollmentDate { get; set; }


        //Navigations
        public virtual Course Courses { get; set; }
        public virtual Person Persons { get; set; }
    }
}
