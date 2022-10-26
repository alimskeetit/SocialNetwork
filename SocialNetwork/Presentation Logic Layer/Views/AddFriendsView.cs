using SocialNetwork.BLL.Models;
using SocialNetwork.Business_Logic_Layer.Exceptions;
using SocialNetwork.Business_Logic_Layer.Models;
using SocialNetwork.Business_Logic_Layer.Services;
using SocialNetwork.Data_Access_Layer.Repositories;
using SocialNetwork.Presentation_Logic_Layer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Presentation_Logic_Layer.Views
{
    public class AddFriendsView
    {
		FriendsService friendsService;
		IUserRepository userRepository;

		public void Show(User user)
        {
			friendsService = new FriendsService();
            var friends = friendsService.GetFriendsByUserId(user.Id);
            Console.WriteLine("Список друзей:");
            foreach (Friend friend in friends)
                Console.WriteLine(friend.FirstName + " " + friend.LastName + " " + friend.Email);

			AddFriendData addFriendData = new AddFriendData();
			addFriendData.User = user;

			try
			{
				Console.Write("Введите email нового друга: ");
				addFriendData.FriendEmail = Console.ReadLine();
				friendsService.AddFriendByEmail(addFriendData);
			}
			catch (UserNotFoundException)
			{
				AlertMessage.Show("Пользователь не найден");
			}
			catch (Exception)
			{
				AlertMessage.Show("Ошибка при добавлении в друзья");
			}
        }
    }
}
