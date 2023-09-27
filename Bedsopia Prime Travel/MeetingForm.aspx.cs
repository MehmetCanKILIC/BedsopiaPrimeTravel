using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bedsopia_Prime_Travel.Information
{
    public partial class MeetingForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            //string sonuc = MailGonder.SendOutlookMail("Contacs Prime Travel", txtCompanyName.Text, "contracts@primetravel.com.tr");
            MailInformation();
        }

        protected void SendReminderMail(string mailIcerik)
        {
            //string[] aliciMailAdresleri = { "mehmet-ck@outlook.com" };
            string mail = "contracts@primetravel.com.tr;a.yasar@primetravel.com.tr;a.kucuk@primetravel.com.tr;o.borucu@primetravel.com.tr;f.muku@primetravel.com.tr;h.kayhan@primetravel.com.tr";
            //string mail = "mehmet-ck@outlook.com;mehmetcan@bosforbilisim.com.tr";


            //string aliciMailAdresi = aliciMailAdresleri[i].ToString();
            string sonuc = MailGonder.SendOutlookMail("Contacts", mailIcerik, mail);

            if (sonuc == "OK")
            {
               
                lblIslemSonuc.Text = "Your meeting request has been received. We thank you.";
                lblIslemSonuc.CssClass = "islemBasarili";
                lblIslemSonuc.Visible = true;
                txtCompanyName.Text = null;
                txtEmail.Text = null;
                txtFullName.Text = null;
                txtMessages.Text = null;
                txtPhone.Text = null;
                txtPreferredDate.Text = null;
                txtPreferredTime.Text = null;
            }
            else
            {
                lblIslemSonuc.Text = "İşlem Hatalı!" + sonuc;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }

        }


        protected void MailInformation()
        {
            string mailIcerik = "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
            mailIcerik += "<head>";
            mailIcerik += "</head>";
            mailIcerik += "<body>";
            mailIcerik += "<div>";
            mailIcerik += "<span style=\"width:100%; border-top: 1px dotted #378b1a;   border-bottom: 1px dotted #378b1a;   background-color: #effee9;  line-height: 20px;  padding: 10px; font-size: 18px; text-shadow: #fff 1px 1px 1px;   color: #378b1a;  display: block;  margin-bottom: 14px;\">Meeting</span>";

            mailIcerik += "<br />";
            mailIcerik += "<table style=\"background-color: #fff; width: 100%; border-radius: 2px; border-spacing: 0;\">";

            mailIcerik += "<tr style=\"line-height: 26px;\">";
            mailIcerik += "<td style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: center;\">Company Name</td>";
            mailIcerik += "<td colspan=3 style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: left;\">";
            mailIcerik += txtCompanyName.Text;
            mailIcerik += "</td>";
            mailIcerik += "</tr>";

            mailIcerik += "<tr style=\"line-height: 26px;\">";
            mailIcerik += "<td style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: center;\">Full Name</td>";
            mailIcerik += "<td colspan=3 style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: left;\">";
            mailIcerik += txtFullName.Text;
            mailIcerik += "</td>";
            mailIcerik += "</tr>";

            mailIcerik += "<tr style=\"line-height: 26px;\">";
            mailIcerik += "<td style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: center;\">Email</td>";
            mailIcerik += "<td colspan=3 style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: left;\">";
            mailIcerik += txtEmail.Text;
            mailIcerik += "</td>";
            mailIcerik += "</tr>";

            mailIcerik += "<tr style=\"line-height: 26px;\">";
            mailIcerik += "<td style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: center;\">Preferred Date</td>";
            mailIcerik += "<td style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: left;\">";
            mailIcerik += txtPreferredDate.Text;
            mailIcerik += "</td>";
            mailIcerik += "<td style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: center;\">Time</td>";
            mailIcerik += "<td style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: left;\">";
            mailIcerik += txtPreferredTime.Text;
            mailIcerik += "</td>";
            mailIcerik += "</tr>";

            mailIcerik += "<tr style=\"line-height: 26px;\">";
            mailIcerik += "<td style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: center;\">Phone</td>";
            mailIcerik += "<td colspan=3 style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: left;\">";
            mailIcerik += txtPhone.Text;
            mailIcerik += "</td>";
            mailIcerik += "</tr>";

            mailIcerik += "<tr style=\"line-height: 26px;\">";
            mailIcerik += "<td style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: center;\">Message</td>";
            mailIcerik += "<td colspan=3 style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: left;\">";
            mailIcerik += txtMessages.Text;
            mailIcerik += "</td>";
            mailIcerik += "</tr>";

            mailIcerik += "<tr style=\"line-height: 26px;\">";
            mailIcerik += "<td style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: center;\">Already a Prime Travel customer?</td>";
            mailIcerik += "<td colspan=3 style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: left;\">";
            mailIcerik += radiobutton.SelectedItem.Text;
            mailIcerik += "</td>";
            mailIcerik += "</tr>";

            mailIcerik += "</table>";
            mailIcerik += "<br /><br />";
   
            mailIcerik += "</body></html>";
            SendReminderMail(mailIcerik);
        }

        protected void radiobutton_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}