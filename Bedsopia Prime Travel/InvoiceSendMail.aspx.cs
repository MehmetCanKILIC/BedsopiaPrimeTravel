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
    public partial class InvoiceSendMail : System.Web.UI.Page
    {
        Command command = new Command();
        string pdfYolu = "/upload/pdf/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserType"] == null || Session["UserType"] == "")
                {
                    Response.Redirect("Login.Aspx");
                }
                else
                {
                    string BookingCode = Request.QueryString["BookingCode"];
                    InvoiceMail(BookingCode);
                    //EmailLogListele(BookingCode);
                    //getSaleDetails(SaleId);
                    //ReservationCheckDate(SaleId);
                }
            }
        }

        protected void InvoiceMail(string BookingCode)
        {
            try
            {
                string query = "  SELECT	InvoiceDetail.MailHolder,Invoice.InvoiceNumber,InvoiceDetailLine.BookingCode FROM InvoiceJuniper Invoice LEFT JOIN InvoiceDetailJuniper InvoiceDetail ON InvoiceDetail.IdInvoice=Invoice.IdInvoice LEFT JOIN InvoiceDetailLineJuniper InvoiceDetailLine ON InvoiceDetailLine.IdInvoice=Invoice.IdInvoice  ";
                query += " WHERE InvoiceDetailLine.BookingCode='" + BookingCode + "'";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    DataRow drIlk = dt.Rows[0];
                    ltrInvoiceNumber.Text = drIlk["InvoiceNumber"].ToString();
                    ltrBookingCode.Text = drIlk["BookingCode"].ToString();
                    ltrEmail.Text = drIlk["MailHolder"].ToString();

                    if (drIlk["MailHolder"].ToString() == "" || drIlk["MailHolder"].ToString() == null)
                    {
                        lblIslemSonuc.Text = "Faturaya ait E-Mail adresi bulunamadı.";
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
            mailIcerik += "<span style=\"width:100%; border-top: 1px dotted #378b1a;   border-bottom: 1px dotted #378b1a;   background-color: #effee9;  line-height: 20px;  padding: 10px; font-size: 18px; text-shadow: #fff 1px 1px 1px;   color: #378b1a;  display: block;  margin-bottom: 14px;\">Faturanız Ektedir.</span>";
            mailIcerik += "</table>";
            mailIcerik += "<br /><br />";
            mailIcerik += "Bizi tercih ettiğiniz için teşekkür ederiz.";
            mailIcerik += "</div>";
            mailIcerik += "</body></html>";
            SendInvoiceMail(mailIcerik, BookingCode);
        }


        protected void SendInvoiceMail(string mailIcerik, string BookingCode)
        {
            //string[] aliciMailAdresleri = { "mehmet-ck@outlook.com" };
            string[] aliciMailAdresleri = txtEmail.Text.Split(';');
            for (int i = 0; i < aliciMailAdresleri.Length; i++)
            {
                string aliciMailAdresi = aliciMailAdresleri[i].ToString();
                string sonuc = MailGonder.SendOutlookMail("Reminder Booking Reservation!", mailIcerik, aliciMailAdresi, Server.MapPath(pdfYolu + Request.QueryString["BookingCode"] + ".pdf"));

                if (sonuc == "OK")
                {
                    //EmailLog(BookingCode, aliciMailAdresi);
                }
                else
                {

                }
                lblIslemSonuc.Text = "İşlem Başarılı";
                lblIslemSonuc.CssClass = "islemBasarili";
                lblIslemSonuc.Visible = true;
            }

            //EmailLogListele(BookingCode);
        }

        //protected void EmailLog(string bookingcode, string email)
        //{
        //    DateTime guncelTarih = DateTime.Now;
        //    int guncelGun = guncelTarih.Day;

        //    DateTime ilkTarih = guncelTarih;
        //    int ilkYil = ilkTarih.Year;
        //    int ilkAy = ilkTarih.Month;
        //    int ilkGun = ilkTarih.Day;
        //    int ilkGunSayisi = DateTime.DaysInMonth(ilkYil, ilkAy);

        //    string varsayilanIlkTarih = "";
        //    ilkTarih = DateTime.Now;
        //    ilkGun = ilkTarih.Day;
        //    ilkYil = ilkTarih.Year;
        //    ilkAy = ilkTarih.Month;
        //    ilkGunSayisi = DateTime.DaysInMonth(ilkYil, ilkAy);

        //    varsayilanIlkTarih = ilkGun + "." + ilkAy + "." + ilkYil;
        //    string sql2 = @"INSERT INTO BPT..BookingReminderEmailLog(BookingCode,Email,LogDate)";
        //    sql2 += "values ('" + bookingcode + "',";
        //    sql2 += "'" + email + "',";
        //    sql2 += "'" + Convert.ToDateTime(varsayilanIlkTarih) + "'";

        //    sql2 += ")";
        //    DataTable dt2 = command.ReturnTableWithParameters(sql2, null, "Table");
        //}


        //protected void EmailLogListele(string BookingCode)
        //{
        //    string sql2 = @"SELECT * FROM BPT..BookingReminderEmailLog ";
        //    sql2 += " WHERE BookingCode='" + BookingCode + "'";
        //    DataTable dt2 = command.ReturnTableWithParameters(sql2, null, "Table");

        //    if (dt2.Rows.Count > 0)
        //    {
        //        lvReservationEmailLog.DataSource = dt2;
        //        lvReservationEmailLog.DataBind();
        //    }
        //    dt2.Dispose();
        //}

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            MailInformation();
        }

    }
}