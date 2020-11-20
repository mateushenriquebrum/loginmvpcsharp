using System;
using System.Collections.Generic;
using System.Text;

namespace UserLoginMVP
{
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
            }
            else
            {
                return new WebServiceRespose() { error = "Incorrect user or password" };
            }
        }
    }
}
