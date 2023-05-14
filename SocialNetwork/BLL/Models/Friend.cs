using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        int Id { get; set; }

        public string UserEmail { get; set; } 

        public string FriendEmail { get; set; }

        public Friend(int id, string userEmail, string friendEmail) 
        { 
            this.Id = id;
            this.UserEmail = userEmail;
            this.FriendEmail = friendEmail;
        }
    }
}
