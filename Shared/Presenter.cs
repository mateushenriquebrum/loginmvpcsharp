using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class Presenter
    {
        public event EventHandler<bool> OnIsAbleToLogin;
        public event EventHandler<String> OnSuccessLogin;
        public event EventHandler<String> OnFailLogin;
        public Presenter(Model model)
        {
            this.model = model;
        }
        public void IsAbleToLogin(String user, String pass)
        {
            if (user?.Length >= 6 && pass?.Length >= 4)
            {
                OnIsAbleToLogin.Invoke(this, true);
            }
            else
            {
                OnIsAbleToLogin.Invoke(this, false);
            }
        }

        public void TryLogin(String user, String pass)
        {
            var wsResp = model.Login(user, pass);
            if (wsResp.error == null && wsResp.token != null)
            {
                OnSuccessLogin?.Invoke(this, wsResp.token);
            }
            else
            {
                OnFailLogin?.Invoke(this, wsResp.error);
            }
        }

        private Model model;
    }
}
