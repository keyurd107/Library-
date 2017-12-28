using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
   public class Registration
    {
        [Required]
        [MaxLength(16, ErrorMessage = "Username should  not be more then 16 characters"), MinLength(6, ErrorMessage = "Username should be atleast 6 characters")]

        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(16,ErrorMessage ="Password should  not be more then 16 characters"),MinLength(6,ErrorMessage ="Password should be atleast 6 characters")]
        public string Password { get; set; }
        [Required]
        [Display(Name ="Full Name")]

        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        
        public Address Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Contact { get; set; }


    }
}

  
