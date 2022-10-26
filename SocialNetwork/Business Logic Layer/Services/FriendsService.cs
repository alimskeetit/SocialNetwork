using SocialNetwork.BLL.Models;
using SocialNetwork.Business_Logic_Layer.Exceptions;
using SocialNetwork.Business_Logic_Layer.Models;
using SocialNetwork.Data_Access_Layer.Entities;
using SocialNetwork.Data_Access_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business_Logic_Layer.Services
{
    public class FriendsService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendsService()
        {
            this.friendRepository = new FriendRepository();
            this.userRepository = new UserRepository();
        }

        public IEnumerable<Friend> GetFriendsByUserId(int userId)
        {
            return from user in friendRepository.FindAllByUserId(userId)
                   let friend = userRepository.FindById(user.friend_id)
                   select new Friend(friend.id, friend.id, friend.email, friend.firstname, friend.lastname);
        }

        public void AddFriendByEmail(AddFriendData addFriendData)
        {
            var friend = userRepository.FindByEmail(addFriendData.FriendEmail);
            if (friend is null) throw new UserNotFoundException();

            //создаем сущность в таблицу friends для пользователя добавившего
            var friendEntity = new FriendEntity()
            {
                id = addFriendData.User.Id,
                user_id = addFriendData.User.Id,
                friend_id = friend.id,
            };

            friendRepository.Create(friendEntity);

            //создаем сущность в таблицу friends для пользователя добавляемого
            friendEntity = new FriendEntity()
            {
                id = friend.id,
                user_id = friend.id,
                friend_id = addFriendData.User.Id
            };
            friendRepository.Create(friendEntity);
        }
    }
}
