using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopas
{
    class User
    {
        private int Id { get; set; }
        private string Username { get; set; }
        private string Email { get; set; }
        public User(int Id, string Username, string Email) { this.Id = Id; this.Username = Username; this.Email = Email; }
        //public string ToString() { return string.Format("{0,10} | {1, 20} | {2, 20}", Id, Username, Email); }
        
    }
}
