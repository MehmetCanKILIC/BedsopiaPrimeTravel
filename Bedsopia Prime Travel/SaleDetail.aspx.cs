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
    public partial class SaleDetail : System.Web.UI.Page
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
                    string SaleId = Request.QueryString["SaleId"];
                    getSaleDetails(SaleId);
                    ReservationCheckDate(SaleId);
                }
            }
        }

        protected void getSaleDetails(string SaleId)
        {
            try
            {
                string query = "  SELECT sale.SaleId,users.HotelName,sale.BeginDate,Sale.EndDate,Sale.Date,Sale.NationalityId,sale.Status,Sale.RoomId,Sale.BoardId FROM Sales Sale ";
                query += "  ";
                query += " LEFT JOIN[Users] users on users.UserId = Sale.UserId WHERE sale.saleId=" + SaleId + " ORDER BY sale.SaleId DESC ";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    DataRow drIlk = dt.Rows[0];
                    ltrHotelName.Text= drIlk["HotelName"].ToString();
                    Session["HotelName"]= drIlk["HotelName"].ToString();
                    //ltrilktarih.Text= drIlk["BeginDate"].ToString();
                    //ltrsontarih.Text= drIlk["EndDate"].ToString();
                    ltrInsertDate.Text= drIlk["Date"].ToString();
                    ltrNationality.Text= drIlk["NationalityId"].ToString();
                    ltrRoom.Text= drIlk["RoomId"].ToString();
                    ltrBoard.Text= drIlk["BoardId"].ToString();
                    getSalesDate(SaleId);
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
        protected void getSalesDate(string SaleId)
        {
            try
            {
                string query = "  SELECT DISTINCT(BeginDate),EndDate FROM SalesDate ";
                query += "  ";
                query += "  WHERE SalesId=" + SaleId + " ";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    lvSaleDate.DataSource = dt;
                    lvSaleDate.DataBind();

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

        protected void ReservationCheckDate(string SaleId)
        {
            try
            {
                string query = "  SELECT Booking.BookingCode AS [Voucher Number],BookingDetail.HotelName AS [Hotel Name],BookingDetail.CheckIn as [Check In],BookingDetail.CheckOut as [Check Out],BookingDetail.HolderName + '  ' + BookingDetail.HolderLastName AS [Pessenger Name],'' AS Note,BookingDetail.HolderNacionalidad as [Nationality],Booking.Status,Booking.BookingDate,BookingDetail.AgencyGroupName as [Agency Name],Booking.BookingCode,'0' AS [Hotel Status] FROM BookingJuniper Booking ";
                query += " LEFT JOIN BookingDetailJuniper BookingDetail ON Booking.BookingCode=BookingDetail.VoucherNumber ";
                query += " WHERE (BookingDetail.ProductGroupName='Own Contracts' OR BookingDetail.ProductGroupName='Supplier Push' OR BookingDetail.ProductGroupName='CM-HR' OR BookingDetail.ProductGroupName='CM-HR0' OR  BookingDetail.ProductGroupName='Supplier Push0' OR " +
                    "BookingDetail.ProductTypeName='Own Contracts' OR BookingDetail.ProductTypeName='Supplier Push' OR BookingDetail.ProductTypeName='CM-HR' OR BookingDetail.ProductTypeName='CM-HR0' OR  BookingDetail.ProductTypeName='Supplier Push0')";
          
                string sql = "SELECT * FROM [SalesDate] WHERE SalesId='" + SaleId + "'";
                DataTable dts = command.ReturnTableWithParameters(sql, null, "Table");

                if (dts.Rows.Count > 0)
                {
                    query += " AND (";
                    int say = dts.Rows.Count;
                    for (int i = 0; i < dts.Rows.Count; i++)
                    {
                        say--;
                        DataRow dr = dts.Rows[i];
                        string SalesDateId = dr["SalesDateId"].ToString();
                        query += "((BookingDetail.CheckIn BETWEEN (SELECT BeginDate FROM SalesDate WHERE SalesDateId='" + SalesDateId + "') AND (SELECT BeginDate FROM SalesDate WHERE SalesDateId='" + SalesDateId + "')) OR ";
                        query += "   (BookingDetail.CheckOut BETWEEN (SELECT EndDate FROM SalesDate WHERE SalesDateId='" + SalesDateId + "') AND (SELECT EndDate FROM SalesDate WHERE SalesDateId='" + SalesDateId + "')))";
                        if (say > 0)
                        {
                            query += " OR ";
                        }
                    }
                    query += ") ";
                }

                dts.Dispose();

                if (Session["UserId"].ToString() == "1")
                {
                    query += " AND BookingDetail.HotelName='" + Session["HotelName"].ToString() + "'";
                }
                else
                {
                    query += " AND BookingDetail.HotelName='" + Session["HotelName"].ToString() + "'";
                }

                query += " ORDER BY Booking.BookingId DESC";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    lvReservation.DataSource = dt;
                    lvReservation.DataBind();
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

        protected void lvReservation_PagePropertiesChanged(object sender, EventArgs e)
        {

        }
    }
}