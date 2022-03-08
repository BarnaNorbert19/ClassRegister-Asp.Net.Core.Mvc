using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRegister.Models.Tables
{
    [Keyless]
    public class Enrollments
    {
        [ForeignKey("Courses")]
        public int CourseId { get; set; }
        
        [ForeignKey("Persons")]
        public string StudentId { get; set; }

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }


        //Navigations
        public virtual Courses Courses { get; set; }
        public virtual Persons Persons { get; set; }
    }
}
