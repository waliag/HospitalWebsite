using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalWebsite
{
    public partial class AddDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBAccess dbObj = new DBAccess();
            Page prevPage = (Page)Context.Handler;  // this . previousPage -- cross page postback

            if (prevPage is Register)
            {
                Register test = (Register)Context.Handler;
                Label2.Text = test.LB1;

            }
            Session["UserId"] = dbObj.getUserId(Label2.Text);

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime date = CdDOB.SelectedDate.Date;
            TbDOB.Text = date.ToString("d");
        }

        protected void BFinish_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            DBAccess dbObj = new DBAccess();
            dbObj.addPatientDetails(userid, Label2.Text, TbDOB.Text, Tbheight.Text, Tbweight.Text, Tballergies.Text);
            Response.Redirect("./Success.aspx");
        }
    }
}