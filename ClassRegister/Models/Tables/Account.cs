using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRegister.Models.Tables
{
    public class Account
    {
        public Person Persons { get; set; }

        [ForeignKey("Persons"), Column("id", TypeName = "varchar(36)"), Required]
        public string Id { get; set; }

        [Column("login_name", TypeName = "varchar(50)"), Required]
        public string LoginName { get; set; }

        [Column("password", TypeName = "varchar(50)"), Required]
        public string Password { get; set; }

        [DataType(DataType.Text), Column("salt"),Required]
        public string Salt { get; set; }

        [Column("role", TypeName = "varchar(7)"), Required]
        public string Role { get; set; }
    }
}
