using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class FriendData
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FriendEmail { get; set; }
    }
}
