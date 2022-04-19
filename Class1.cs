using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class user
    {
        public string name { get; set; }
        public string password { get; set; }
        public user (string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public user ()
        {

        }
    }
}
