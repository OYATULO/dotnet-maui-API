using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workWithApi
{
    public class Contact
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Contact> GetContacts()
        {
            var post = new List<Contact>(){
                 new Contact{id=1, name = "ok"},
                 new Contact{id=1, name = "ok"},
                 new Contact{id = 1, name = "ok"}
                };
            return post;
        }
    }
}
