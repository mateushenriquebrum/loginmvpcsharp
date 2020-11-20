using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUserLoginMVP
{
    class ConsoleView
    {
        private Shared.Presenter presenter;
        private String user;
        private String pass;
        public ConsoleView(Shared.Presenter presenter)
        {
            this.presenter = presenter;
            this.presenter.OnIsAbleToLogin += (s, able) =>
            {
                if (!able)
                {
                    System.Console.WriteLine("You didn't provide enought information in order to login");
                    System.Console.WriteLine("Ensure user and password policies are satisfied");
                    EnterCredentials();
                } else
                {
                    this.presenter.TryLogin(user, pass);
                }
            };
            this.presenter.OnSuccessLogin += (s, token) =>
            {
                System.Console.WriteLine($"This is your token for future requests: {token}");
                System.Console.WriteLine("======================================================================");
            };
            this.presenter.OnFailLogin += (s, error) =>
            {
                System.Console.WriteLine($"{error}");
                EnterCredentials();
            };
        }

        public void EnterCredentials()
        {
            System.Console.WriteLine("======================================================================");
            System.Console.WriteLine("Please enter your user");
            this.user = System.Console.ReadLine();
            System.Console.WriteLine("Please enter your password");
            this.pass = System.Console.ReadLine();
            this.presenter.IsAbleToLogin(user, pass);
        }
    }
}
