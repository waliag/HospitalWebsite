using System;
using System.Collections.Generic;
using System.Data;
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
            if(Session["DoctorSearched"] != null)
            {
                addTableEntries();
            }
            else
            {
                clearTable();
            }
            if(Session["UserId"] == null)
            {
                LogoutButton.Visible = false;
				MyAccountButton.Visible = false;
            }
            else
            {
                LoginButton.Visible = false;
                RegisterButton.Visible = false;
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Session["DoctorSearched"] = "true";
            Session["SearchString"] = SearchTextBox.Text;
            clearTable();
            addTableEntries();
            
        }
        private void addTableEntries()
        {
            DBAccess dbObj = new DBAccess();
            List<Doctor> doctors;

            String searchQueryString = Convert.ToString(Session["SearchString"]);
            doctors = dbObj.searchDoctors(searchQueryString);
            
            foreach (var doctor in doctors)
            {
                // Create a new row and add it to the table.
                TableRow tRow = new TableRow();
                DoctorTable.Rows.Add(tRow);

                TableCell tCellName = new TableCell();
                tRow.Cells.Add(tCellName);
                tCellName.Controls.Add(new LiteralControl(doctor.name));

                TableCell tCellQaulification = new TableCell();
                tRow.Cells.Add(tCellQaulification);
                tCellQaulification.Controls.Add(new LiteralControl(doctor.qualification));

                TableCell tCellSpeciality = new TableCell();
                tRow.Cells.Add(tCellSpeciality);
                tCellSpeciality.Controls.Add(new LiteralControl(doctor.speciality));

                TableCell tCellButton = new TableCell();
                tRow.Cells.Add(tCellButton);
                var button = new Button();
                button.Click += new EventHandler(makeAppointment);
                button.Text = "Make Appointment";
                button.CssClass = "btn btn-success";
                button.CommandArgument = doctor.userId.ToString();
                tCellButton.Controls.Add(button);
            }

        }
        private void clearTable()
        {
            DoctorTable.Rows.Clear();
        }

        private void makeAppointment(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var doctorId = Convert.ToInt32(button.CommandArgument);
            Session["DoctorId"] = doctorId;
            Response.Redirect("./Appointment.aspx");
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
            Session["DoctorSearched"] = null;
            Session["DoctorId"] = null;
            Response.Redirect("./Home.aspx");
        }
        protected void ViewAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("./PatientAccountPage.aspx");
        }
    }
}