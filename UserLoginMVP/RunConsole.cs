using System;
using System.Collections.Generic;
using System.Text;

namespace UserLoginMVP
{
    class RunConsole
    {
        static int Main(string[] args)
        {
            var view = new ConsoleView(new Presenter(new Model()));
            view.EnterCredentials();
        }
    }
}
