using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonLayer;

namespace LibraryPortal.ViewModel
{
    public class RegisterFormViewModel
    {
        public IEnumerable<Address> Address { get; set; }
        public Registration Registration{ get; set; }
    }
}