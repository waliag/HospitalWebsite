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
            Account userDetails;
            DBAccess dbObj = new DBAccess();
            userDetails = dbObj.AuthenticateUser(Login1.UserName, Login1.Password);
            if (userDetails.userId == 0)
            {
                Login1.FailureText = "Username and/or password is incorrect.";
            }
            else
            {
                Session["UserId"] = userDetails.userId;
                Session["UserEmail"] = userDetails.email;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
            }
        }
		public int TB1
        {
            get
            {
                return Convert.ToInt32(Session["UserId"]);
            }
        }

    }
}