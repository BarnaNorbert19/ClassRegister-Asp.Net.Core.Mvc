using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRegister.Models.Tables
{
    public class Courses
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan Duration { get; set; }


        //Navigations

        [ForeignKey("Subjects")]
        public int SubjectId { get; set; }
        public virtual Subjects Subjects { get; set; }

        [ForeignKey("Persons")]
        public string TeacherId { get; set; }
        public virtual Persons Persons { get; set; }
    }
}
