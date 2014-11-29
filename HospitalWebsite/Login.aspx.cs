using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalWebsite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AuthenticateUser(object sender, EventArgs e)
        {
            int userId = 0;
            DBAccess dbObj = new DBAccess();
            userId = dbObj.AuthenticateUser(Login1.UserName, Login1.Password);
            if (userId == 0)
            {
                Login1.FailureText = "Username and/or password is incorrect.";
            }
            else
            {
                Session["UserId"] = userId;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
            }
        }
    }
}