using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalWebsite
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserId"] == null)
            {
                LogoutButton.Visible = false;
            }
            else
            {
                LoginButton.Visible = false;
                RegisterButton.Visible = false;
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Session["SearchString"] = SearchTextBox.Text;
            Response.Redirect("./ShowDoctors.aspx");
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Register.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Login.aspx");
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session["UserId"] = null;
            Response.Redirect("./Home.aspx");
        }
    }
}