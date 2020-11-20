using System;

namespace ConsoleUserLoginMVP
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new ConsoleView(new Shared.Presenter(new Shared.Model()));
            view.EnterCredentials();
        }
    }
}
