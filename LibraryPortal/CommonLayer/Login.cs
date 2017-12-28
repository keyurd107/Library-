using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class Login
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(16,ErrorMessage ="Username should be not more then 16 characters"),MinLength(5,ErrorMessage ="Username should be greater then 5 characters ")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        public string Roles { get; set; }
    }
}
