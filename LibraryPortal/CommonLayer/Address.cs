using System.ComponentModel.DataAnnotations;

namespace CommonLayer
{
    public class Address
    {
        [Display(Name ="Address Line 1")]
        public string AddressLineOne { get; set; }
        [Display(Name = "Address Line 2")]
        public string AddressLineTwo { get; set; }
        public string Landmark { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public int Pincode { get; set; }
    }
}