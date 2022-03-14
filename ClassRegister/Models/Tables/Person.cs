using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRegister.Models.Tables
{
    public class Person
    {

        [Key, Column("id", TypeName = "varchar(36)"), Required]
        public string Id { get; set; }

        [Required, Column("firstname", TypeName = "varchar(30)")]
        public string Firstname { get; set; }

        [Required, Column("lastname", TypeName = "varchar(30)")]
        public string Lastname { get; set; }

        [Column("email", TypeName = "varchar(100)"), RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Invalid email")]
        public string? Email { get; set; }

        [Column("phone", TypeName = "varchar(20)")]
        public string? Phone { get; set; }

        public Account Accounts { get; set; }
    }
}
