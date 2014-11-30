using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalWebsite
{
    public partial class Appointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                System.Web.Security.FormsAuthentication.RedirectToLoginPage();
            }
            else if (Session["DoctorId"] == null)
            {
                Response.Redirect("./ShowDoctors.aspx");
            }
            else if(Calendar1.SelectedDate.Date != DateTime.MinValue)
            {
                dateSelected(null, null);
            }
        }
        public void dateSelected(Object sender, EventArgs e)
        {
            SlotsTable.Rows.Clear();//clear old rows if present
            
            DateTime date = Calendar1.SelectedDate.Date;
            TextDate.Text = date.ToString("d");
            DBAccess dbObj = new DBAccess();
            List<String> filledSlots = dbObj.getFilledSlots(Convert.ToInt32(Session["DoctorId"]), date);

            //3 slots Morning,Afternoon,Evening
            List<String> availableSlots = new List<string> { "Morning", "Afternoon", "Evening" };
            foreach (var slot in availableSlots)
            {
                var available = !filledSlots.Contains(slot);
                int i=1;

                // Create a new row and add it to the table.
                TableRow tRow = new TableRow();
                SlotsTable.Rows.Add(tRow);

                TableCell tCellName = new TableCell();
                tRow.Cells.Add(tCellName);
                tCellName.Controls.Add(new LiteralControl(slot));

                TableCell tCellButton = new TableCell();
                tRow.Cells.Add(tCellButton);
                var button = new Button();
                button.Click += selectAppointment;
                button.Text = "Select";
                button.CommandArgument = slot;
                if (!available)
                {
                    button.Enabled = false;
                    button.Text = "Not Available";
                }
                tCellButton.Controls.Add(button);
                i++;
            }

        }

        private void selectAppointment(object sender, EventArgs e)
        {
            var button = (Button)sender;
            DBAccess dbObj = new DBAccess();
            AppointmentDetails appointmentObj = new AppointmentDetails();
            appointmentObj.doctorId = Convert.ToInt32(Session["DoctorId"]);
            appointmentObj.patientId = Convert.ToInt32(Session["UserId"]);
            appointmentObj.date = Calendar1.SelectedDate.Date;
            appointmentObj.Slot = button.CommandArgument;

            if (dbObj.addAppointment(appointmentObj) == true)
            {
                Response.Redirect("./Success.aspx");
            }
        }
    }
}