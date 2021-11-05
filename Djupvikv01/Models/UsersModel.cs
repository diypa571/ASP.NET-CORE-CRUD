using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Djupvikv01.Models
{


    public class UsersModel
    {
        public int id { get; set; }
        public string anvandarnamn { get; set; }
        public string namn { get; set; }
        public string losenord { get; set; }
        public string email { get; set; }
        public string datum { get; set; }

         


 
    public UsersModel()
    {
         
    }

    public UsersModel(int id, string anvandarnamn, string namn, string losenord, string email, string datum)
    {
        this.id = id;
        this.anvandarnamn = anvandarnamn;
        this.namn = namn;
        this.losenord = losenord;
        this.email = email;
        this.datum = datum;
 
    }



 




}
}




