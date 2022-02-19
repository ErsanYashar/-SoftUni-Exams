using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

//    •	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email – a string, which holds only valid email(required)
//•	Has a Password – a string with min length 6 and max length 20 - hashed in the database(required)
//•	Has a Cart – a Cart object (required)


}
