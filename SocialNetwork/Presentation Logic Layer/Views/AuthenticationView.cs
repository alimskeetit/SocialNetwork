﻿using SocialNetwork.Business_Logic_Layer.Exceptions;
using SocialNetwork.Business_Logic_Layer.Models;
using SocialNetwork.Business_Logic_Layer.Services;
using SocialNetwork.Business_Logic_Layer.Exceptions;
using SocialNetwork.Business_Logic_Layer.Models;
using SocialNetwork.Business_Logic_Layer.Services;
using SocialNetwork.Presentation_Logic_Layer.Helpers;
using SocialNetwork.Presentation_Logic_Layer.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class AuthenticationView
    {
        UserService userService;
        public AuthenticationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var authenticationData = new UserAuthenticationData();

            Console.WriteLine("Введите почтовый адрес:");
            authenticationData.Email = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            authenticationData.Password = Console.ReadLine();

            try
            {
                var user = this.userService.Authenticate(authenticationData);

                SuccessMessage.Show("Вы успешно вошли в социальную сеть!");
                SuccessMessage.Show("Добро пожаловать " + user.FirstName);

                Program.userMenuView.Show(user);
            }

            catch (WrongPasswordException)
            {
                AlertMessage.Show("Пароль не корректный!");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

        }
    }
}