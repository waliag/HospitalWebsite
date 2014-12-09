using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalWebsite
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("Appointment made successfully. An email has been sent to you.");
			Page prevpage = (Page)Context.Handler;
            if (Session["UserId"] !=null && Session["DoctorId"] != null)
            {
                Button2.Visible = false;
                Label1.Visible = false;
                Label2.Visible = true;
            }
            else
                Label2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["DoctorSearched"] = null;
            Session["DoctorId"] = null;

            Response.Redirect("./Home.aspx");
        }
		protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Login.aspx");
        }
    }
}