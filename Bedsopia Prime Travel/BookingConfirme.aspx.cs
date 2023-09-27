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
    public partial class BookingConfirme : System.Web.UI.Page
    {
        Command command = new Command();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserType"].ToString() == null || Session["UserType"].ToString() == "")
                {
                    Response.Redirect("Login.Aspx");
                }
                else
                {
                    string BookingCode = Request.QueryString["BookingCode"];
                    if (BookingCode != null)
                    {
                        ltrVoucherNumber.Text = BookingCode;
                        VisibleStatus(BookingCode);
                    }
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

        protected void BookingConfirmed(string BookingCode)
        {
            try
            {
                string sql = @"INSERT INTO BPT..Bookings(BookingCode,Status,Note,BookingConfirmeDate)";
                sql += "values ('" + BookingCode + "','1','" + txtConfirmeNote.Text + "',GETDATE())";
                DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");

                lblIslemSonuc.Text = "İşlem Başarılı.";
                lblIslemSonuc.CssClass = "islemBasarili";
                lblIslemSonuc.Visible = true;

            }
            catch (Exception exp)
            {

                lblIslemSonuc.Text = "HATA : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }

        }

        protected void BookingUpdate(string BookingCode)
        {
            try
            {
                string sql = @"UPDATE BPT..Bookings SET Status = '1',BookingConfirmeDate= GETDATE() WHERE BookingCode='" + BookingCode + "'";
                DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");

                lblIslemSonuc.Text = "İşlem Başarılı.";
                lblIslemSonuc.CssClass = "islemBasarili";
                lblIslemSonuc.Visible = true;

            }
            catch (Exception exp)
            {

                lblIslemSonuc.Text = "HATA : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }

        }


        protected void BookingControl(string BookingCode)
        {
            try
            {
                string sql = @"SELECT * FROM  BPT..Bookings WHERE BookingCode='" + BookingCode + "'";
                DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");
                if (dt.Rows.Count > 0)
                {
                    BookingUpdate(BookingCode);
                }
                else
                {
                    BookingConfirmed(BookingCode);

                }
                lblIslemSonuc.Text = "İşlem Başarılı.";
                lblIslemSonuc.CssClass = "islemBasarili";
                lblIslemSonuc.Visible = true;

            }
            catch (Exception exp)
            {

                lblIslemSonuc.Text = "HATA : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }

        }




        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string BookingCode = Request.QueryString["BookingCode"];
            BookingControl(BookingCode);
        }
    }
}