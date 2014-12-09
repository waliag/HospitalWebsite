using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalWebsite
{
    public partial class PatientDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBAccess obj = new DBAccess();
            Patient objpatient;
            Patient objnext;
            objpatient = obj.getPatients(Convert.ToInt32(Session["UserId"]));
           
            LbName.Text = objpatient.name;
            LbDOB.Text = objpatient.dob;
            Lbheight.Text = objpatient.height;
            Lbweight.Text = objpatient.weight;
            Lballergies.Text = objpatient.allergies;
            objnext = obj.getAppointment(Convert.ToInt32(Session["UserId"]));
            if(objnext == null)
            {
                Lbheading.Visible = false;
                Lbdoctor.Visible = false;
                Lbdocdetails.Visible = false;
                Lbdate.Visible = false;
                Lbdatedetails.Visible = false;
                LbSlot.Visible = false;
                Lbslotdetails.Visible = false;
            }
            else
            {
                Lbdocdetails.Text  = objnext.doctor;
                Lbdatedetails.Text = objnext.date;
                Lbslotdetails.Text = objnext.slot;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Home.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["UserId"] = null;
            Response.Redirect("./Home.aspx");
        }
    }
}