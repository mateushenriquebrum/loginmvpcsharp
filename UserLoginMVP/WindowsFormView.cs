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
        public View(Presenter presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
            this.presenter.OnIsAbleToLogin += (s, isAble) =>
            {
                loginButton.Enabled = isAble;
            };
            this.presenter.OnSuccessLogin += (s, token) =>
            {
                // save token for future web services invocations
                // invoke the main form
                Dispose();
            };
            this.presenter.OnFailLogin += (s, errors) =>
            {
                loginButton.Enabled = false;
                passwordText.Text = "";
                MessageBox.Show(errors, "Error");
            };
        }

        private void userText_TextChanged(object sender, EventArgs e)
        {
            this.presenter.IsAbleToLogin(userText.Text, passwordText.Text);
        }
        private void passwordText_TextChanged(object sender, EventArgs e)
        {
            this.presenter.IsAbleToLogin(userText.Text, passwordText.Text);
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            this.presenter.TryLogin(userText.Text, passwordText.Text);
        }
        private Presenter presenter;
    }
}
