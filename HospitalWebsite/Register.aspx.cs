using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalWebsite
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Create_Account(object sender, EventArgs e)
        {
            DBAccess dbObj = new DBAccess();
            if (dbObj.CreateUserAccount(TxtName.Text, TxtEmail.Text, TxtPassword.Text) == false)
            {
                Response.Write("User already exists");
            }
            else
            {
                Server.Transfer("./AddDetails.aspx");
            }
        } 

        public string LB1
        {
            get
            {
                return TxtName.Text;
            }
    }

            
    }
}