using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business_Logic_Layer.Models
{
    public class AddFriendData
    {
        public string FriendEmail { get; set; }
        public User User { get; set; } 
    }
}
