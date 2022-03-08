using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRegister.Models.Tables
{
    public class Accounts
    {
        public Persons Persons { get; set; }

        [ForeignKey("Persons"), Column(TypeName = "varchar(36)"), Required]
        public string Id { get; set; }

        [Column(TypeName = "varchar(50)"), Required]
        public string LoginName { get; set; }

        [Column(TypeName = "varchar(50)"), Required]
        public string Password { get; set; }

        [DataType(DataType.Text), Required]
        public string Salt { get; set; }

        [Column(TypeName = "varchar(7)"), Required]
        public string Role { get; set; }
    }
}
