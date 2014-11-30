using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalWebsite
{
    public partial class ShowDoctors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String searchQueryString = Convert.ToString(Session["SearchString"]);
            DBAccess dbObj = new DBAccess();
            List<Doctor> doctors  = dbObj.searchDoctors(searchQueryString);

            foreach(var doctor in doctors)
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
                button.Click += makeAppointment;
                button.Text = "Make Appointment";
                button.CommandArgument = doctor.userId.ToString();
                tCellButton.Controls.Add(button);
            }
        }

        private void makeAppointment(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var doctorId = Convert.ToInt32(button.CommandArgument);
            Session["DoctorId"] = doctorId;
            Response.Redirect("./Appointment.aspx");
        }
    }
}