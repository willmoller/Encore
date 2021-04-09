using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encore
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        private string password;
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }



    }
}
