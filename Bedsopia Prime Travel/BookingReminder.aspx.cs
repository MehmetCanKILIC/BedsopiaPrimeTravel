using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bedsopia_Prime_Travel
{
    public partial class BookingReminder : System.Web.UI.Page
    {
        Command command = new Command();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserType"] == null || Session["UserType"].ToString() == "")
                {
                    Response.Redirect("Login.Aspx");
                }
                else
                {
                    string BookingCode = Request.QueryString["BookingCode"];
                    HotelMail(BookingCode);
                    EmailLogListele(BookingCode);
                    //getSaleDetails(SaleId);
                    //ReservationCheckDate(SaleId);
                }
            }
        }

        protected void VisibleStatus(string BookingCode)
        {
            try
            {
                string sql = @"UPDATE BookingJuniper SET VisibleStatus='0' WHERE BookingCode='" + BookingCode + "'";

                DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");
            }
            catch (Exception ex)
            {
                //lblIslemSonuc.Text = ex.Message;
                //lblIslemSonuc.CssClass = "islemHatali";
                //lblIslemSonuc.Visible = true;
            }
        }

        protected void HotelMail(string BookingCode)
        {
            try
            {
                string query = "  SELECT Users.*,BookingDetail.VoucherNumber FROM BPT..BookingDetailJuniper BookingDetail INNER JOIN BPT..[Users] Users ON Users.HotelName=BookingDetail.HotelName ";
                query += " WHERE BookingDetail.VoucherNumber='" + BookingCode + "'";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    DataRow drIlk = dt.Rows[0];
                    ltrHotelName.Text = drIlk["HotelName"].ToString();
                    ltrBookingCode.Text = drIlk["VoucherNumber"].ToString();
                    ltrEmail.Text = drIlk["Email"].ToString();

                    if (drIlk["Email"].ToString() == "" || drIlk["Email"].ToString() == null)
                    {
                        lblIslemSonuc.Text = "Otele ait email adresi bulunamadı.";
                        lblIslemSonuc.CssClass = "islemHatali";
                        lblIslemSonuc.Visible = true;
                    }
                }
                dt.Dispose();

            }
            catch (Exception exp)
            {
                lblIslemSonuc.Text = "Hata : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }
        }



        protected void MailInformation()
        {
            string BookingCode = Request.QueryString["BookingCode"];

            string mailIcerik = "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
            mailIcerik += "<head>";
            mailIcerik += "</head>";
            mailIcerik += "<body>";
            mailIcerik += "<div>";
            mailIcerik += "<span style=\"width:100%; border-top: 1px dotted #378b1a;   border-bottom: 1px dotted #378b1a;   background-color: #effee9;  line-height: 20px;  padding: 10px; font-size: 18px; text-shadow: #fff 1px 1px 1px;   color: #378b1a;  display: block;  margin-bottom: 14px;\">Rezervasyon Hatırlatma.</span>";

            mailIcerik += "<br />";
            mailIcerik += "<table style=\"background-color: #fff; width: 100%; border-radius: 2px; border-spacing: 0;\">";
            mailIcerik += "<tr style=\"line-height: 26px;\">";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 20%; text-align: left;\">Voucher Number</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 35%; text-align: left;\">Hotel Name</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">Check In</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">Check Out</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">Pessenger Name</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">BookingCode</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">Note</th>";
            mailIcerik += "</tr>";
            try
            {

                string query = "  SELECT Booking.BookingId AS [Voucher Number],BookingDetail.HotelName AS [Hotel Name],BookingDetail.CheckIn as [Check In],BookingDetail.CheckOut as [Check Out],BookingDetail.HolderName + '  ' + BookingDetail.HolderLastName AS [Pessenger Name],'' AS Note,BookingDetail.HolderNacionalidad as [Nationality],Booking.Status,Booking.BookingDate,BookingDetail.AgencyGroupName as [Agency Name],Booking.BookingCode,'0' AS [Hotel Status] FROM BookingJuniper Booking ";
                query += " LEFT JOIN BookingDetailJuniper BookingDetail ON Booking.BookingCode=BookingDetail.VoucherNumber ";
                query += " WHERE (BookingDetail.ProductGroupName='Own Contracts' OR BookingDetail.ProductGroupName='Supplier Push' OR BookingDetail.ProductGroupName='CM-HR' OR BookingDetail.ProductGroupName='CM-HR0' OR  BookingDetail.ProductGroupName='Supplier Push0' OR " +
                    "BookingDetail.ProductTypeName='Own Contracts' OR BookingDetail.ProductTypeName='Supplier Push' OR BookingDetail.ProductTypeName='CM-HR' OR BookingDetail.ProductTypeName='CM-HR0' OR  BookingDetail.ProductTypeName='Supplier Push0')";

                query += " AND Booking.BookingCode='" + BookingCode + "'";

                DataTable dtSepetIcerik = command.ReturnTableWithParameters(query, null, "Table");

                for (int i = 0; i < dtSepetIcerik.Rows.Count; i++)
                {
                    DataRow drIcerik = dtSepetIcerik.Rows[i];

                    string Voucher = drIcerik["Voucher Number"].ToString();
                    string HotelName = drIcerik["Hotel Name"].ToString();
                    string CheckIn = drIcerik["Check In"].ToString();
                    string CheckOut = drIcerik["Check Out"].ToString();
                    string PessengerName = drIcerik["Pessenger Name"].ToString();
                    string BookingCodemail = drIcerik["BookingCode"].ToString();
                    string Note = drIcerik["Note"].ToString();
                    mailIcerik += "<tr style=\"line-height: 26px;\">";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: left;\">" + Voucher + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: left;\">" + HotelName + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + CheckIn + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + CheckOut + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + PessengerName + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + BookingCodemail + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + Note + "</td>";
                    mailIcerik += "</tr>";
                }
            }
            catch (Exception exp)
            {

                lblIslemSonuc.Text = "Hata : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }
           

            mailIcerik += "</table>";
            mailIcerik += "<br /><br />";
            mailIcerik += "Bizi tercih ettiğiniz için teşekkür ederiz.";
            mailIcerik += "</div>";
            mailIcerik += "</body></html>";
            SendReminderMail(mailIcerik, BookingCode);
        }


        protected void SendReminderMail(string mailIcerik,string BookingCode)
        {
            //string[] aliciMailAdresleri = { "mehmet-ck@outlook.com" };
            string mail = ltrEmail.Text + ";" + txtEmail.Text;
            string[] aliciMailAdresleri = txtEmail.Text.Split(';');

            //string aliciMailAdresi = aliciMailAdresleri[i].ToString();
            string sonuc = MailGonder.SendOutlookMail("Reminder Booking Reservation!", mailIcerik, mail);

            if (sonuc == "OK")
            {
                EmailLog(BookingCode, mail);
                lblIslemSonuc.Text = "İşlem Başarılı";
                lblIslemSonuc.CssClass = "islemBasarili";
                lblIslemSonuc.Visible = true;
            }
            else
            {

            }

            EmailLogListele(BookingCode);
        }

        protected void EmailLog(string bookingcode,string email)
        {
            DateTime guncelTarih = DateTime.Now;
            int guncelGun = guncelTarih.Day;

            DateTime ilkTarih = guncelTarih;
            int ilkYil = ilkTarih.Year;
            int ilkAy = ilkTarih.Month;
            int ilkGun = ilkTarih.Day;
            int ilkGunSayisi = DateTime.DaysInMonth(ilkYil, ilkAy);

            string varsayilanIlkTarih = "";
            ilkTarih = DateTime.Now;
            ilkGun = ilkTarih.Day;
            ilkYil = ilkTarih.Year;
            ilkAy = ilkTarih.Month;
            ilkGunSayisi = DateTime.DaysInMonth(ilkYil, ilkAy);

            varsayilanIlkTarih = ilkGun + "." + ilkAy + "." + ilkYil;
            string sql2 = @"INSERT INTO BPT..BookingReminderEmailLog(BookingCode,Email,LogDate)";
            sql2 += "values ('" + bookingcode + "',";
            sql2 += "'" + email + "',";
            sql2 += "'" + Convert.ToDateTime(varsayilanIlkTarih) + "'";
            
            sql2 += ")";
            DataTable dt2 = command.ReturnTableWithParameters(sql2, null, "Table");
        }


        protected void EmailLogListele(string BookingCode)
        {
            string sql2 = @"SELECT * FROM BPT..BookingReminderEmailLog ";
            sql2 += " WHERE BookingCode='" + BookingCode + "'";
            DataTable dt2 = command.ReturnTableWithParameters(sql2, null, "Table");

            if (dt2.Rows.Count > 0)
            {
                lvReservationEmailLog.DataSource = dt2;
                lvReservationEmailLog.DataBind();
            }
            dt2.Dispose();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            MailInformation();
        }

        protected void lvReservation_PagePropertiesChanged(object sender, EventArgs e)
        {

        }
    }
}