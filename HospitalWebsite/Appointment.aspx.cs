using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
                Response.Redirect("./Home.aspx");
            }
            else if(Calendar1.SelectedDate.Date != DateTime.MinValue)
            {
                dateSelected(null, null);
            }
            else
            {
                SlotsLabel.Visible = false;
            }
        }
        public void dateSelected(Object sender, EventArgs e)
        {
            SlotsTable.Rows.Clear();//clear old rows if present
            SlotsLabel.Visible = true;
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
                button.CssClass = "btn btn-success";
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
        public void Calendar1_DayRender(object o, DayRenderEventArgs e)
        {


            e.Cell.BackColor = System.Drawing.Color.Empty;
            e.Cell.ForeColor = System.Drawing.Color.DarkRed;

            //Previous days should be disabled
            if (e.Day.Date < DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
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
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("hospitalwebsitegsu@gmail.com", "gsu@1234");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage message = new MailMessage();

                //Setting From , To and mail message
                message.From = new MailAddress("hospitalwebsitegsu@gmail.com", "MyWeb Site");
                message.To.Add(new MailAddress(Convert.ToString(Session["UserEmail"])));

                message.Subject = "Appointment has been made.";
                message.From = new System.Net.Mail.MailAddress("hospitalwebsitegsu@gmail.com");
                String appointmentDate = appointmentObj.date.Date.ToString("dd/MM/yyyy");
                message.Body = "Your appointment is on " + appointmentDate;
                smtpClient.Send(message);

                Response.Redirect("./Success.aspx");
            }
        }
    }
}