using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserLoginMVP
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
            presenter = new Presenter(new Model());
            presenter.OnIsAbleToLogin += (s, isAble) =>
            {
                loginButton.Enabled = isAble;
            };
            presenter.OnSuccessLogin += (s, token) =>
            {
                // save token for future web services invocations
                // invoke the main form
                Dispose();
            };
            presenter.OnFailLogin += (s, errors) =>
            {
                loginButton.Enabled = false;
                passwordText.Text = "";
                MessageBox.Show(errors, "Error");
            };
        }

        private void userText_TextChanged(object sender, EventArgs e)
        {
            presenter.IsAbleToLogin(userText.Text, passwordText.Text);
        }

        private void passwordText_TextChanged(object sender, EventArgs e)
        {
            presenter.IsAbleToLogin(userText.Text, passwordText.Text);

        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            presenter.TryLogin(userText.Text, passwordText.Text);
        }
        private Presenter presenter;
    }

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
            if(user?.Length >= 6 && pass?.Length >= 4)
            {
                OnIsAbleToLogin.Invoke(this, true);
            } else
            {
                OnIsAbleToLogin.Invoke(this, false);
            }
        }

        public void TryLogin(String user, String pass)
        {
            var wsResp = model.Login(user, pass);
            if(wsResp.error == null && wsResp.token != null)
            {
                OnSuccessLogin?.Invoke(this, wsResp.token);
            } else
            {
                OnFailLogin?.Invoke(this, wsResp.error);
            }
        }

        private Model model;
    }

    public class Model
    {
        public struct WebServiceRespose
        {
            public String token;
            public String error;
        }
        public WebServiceRespose Login(String user, String pass)
        {
            // all your web service integratio goes here
            if (user == "mateus" && pass == "brum")
            {
                // JWT or Server token
                return new WebServiceRespose() { token = "secret.brum.token" };
            } else {
                return new WebServiceRespose() { error = "Incorrect user or password" };
            }
        }
    }

}
