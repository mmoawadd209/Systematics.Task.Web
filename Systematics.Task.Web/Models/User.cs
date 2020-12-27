using System.ComponentModel.DataAnnotations;

namespace Systematics.Task.Web.Models
{
    public class User
    {
        [StringLength(50)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [StringLength(50)]
        [Required]
        public string Password { get; set; }

        [StringLength(50)]
        public string Role { get; set; }
    }
}