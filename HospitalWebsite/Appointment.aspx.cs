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
        }
        public void dateSelected(Object sender, EventArgs e)
        {
            DateTime date = Calendar1.SelectedDate.Date;
            TextDate.Text = date.ToString("d");
            DBAccess dbObj = new DBAccess();
            List<String> filledSlots = dbObj.getFilledSlots(Convert.ToInt32(Session["DoctorId"]), date);

            //3 slots Morning,Afternoon,Evening
            List<String> availableSlots = new List<string> { "Morning", "Afternoon", "Evening" };
            foreach (var slot in availableSlots)
            {
                var available = !filledSlots.Contains(slot);

                // Create a new row and add it to the table.
                TableRow tRow = new TableRow();
                SlotsTable.Rows.Add(tRow);

                TableCell tCellName = new TableCell();
                tRow.Cells.Add(tCellName);
                tCellName.Controls.Add(new LiteralControl(slot));

                TableCell tCellButton = new TableCell();
                tRow.Cells.Add(tCellButton);
                var button = new Button();
                button.Click += selectappointment;
                button.Text = "Select";
                button.CommandArgument = slot;
                if (!available)
                {
                    button.Enabled = false;
                    button.Text = "Not Available";
                }
                tCellButton.Controls.Add(button);
            }

        }

        private void selectappointment(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}