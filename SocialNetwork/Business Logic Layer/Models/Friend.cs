using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business_Logic_Layer.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Friend(int id, int userId,string email, string firstName, string lastName)
        {
            Id = id;
            UserId = userId;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
