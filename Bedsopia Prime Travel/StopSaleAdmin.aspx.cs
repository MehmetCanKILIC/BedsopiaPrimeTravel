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
    public partial class StopSaleAdmin : System.Web.UI.Page
    {
        Command command = new Command();

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
                    string SaleId = Request.QueryString["SaleId"];
                    if (SaleId != null)
                    {
                        SalesCheck(SaleId);
                    }
                    DataLists();
                }
            }
        }


        protected void DataLists()
        {
            try
            {
                string query = "  SELECT  sale.SaleId,users.HotelName,(SELECT TOP 1 BeginDate FROM SalesDate WHERE SalesId=Sale.SaleId) AS BeginDate,(SELECT TOP 1 EndDate FROM SalesDate WHERE SalesId=Sale.SaleId) AS EndDate ,(SELECT COUNT(*) FROM SalesDate WHERE SalesId=Sale.SaleId) as SalesDateCount,Sale.Date,Sale.NationalityId,sale.Status FROM Sales Sale";
                query += " ";
                query += " LEFT JOIN[Users] users on users.UserId = Sale.UserId   WHERE sale.Type=2 ORDER BY sale.SaleId DESC ";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    lvOpenSaleList.DataSource = dt;
                    lvOpenSaleList.DataBind();
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


        protected void SalesCheck(string saleId)
        {
            string sql = @"UPDATE BPT..Sales SET Status='1'";
            sql += " WHERE SaleId='" + saleId + "'";
            DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");

            Response.Redirect("StopSaleAdmin.aspx");
        }

        protected void lvOpenSaleList_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void lvOpenSaleList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //try
            //{
            //    Literal ltrSaleCount = (Literal)e.Item.FindControl("ltrSaleCount");
            //    Literal ltrUyari = (Literal)e.Item.FindControl("ltrUyari");

            //    if (e.Item.ItemType == ListViewItemType.DataItem)
            //    {
            //        string SaleId = DataBinder.Eval(e.Item.DataItem, "SaleId").ToString();
            //        string HotelName = DataBinder.Eval(e.Item.DataItem, "HotelName").ToString();
            //        try
            //        {
            //            string query = "  SELECT Count(Booking.BookingCode) AS [Booking] FROM BookingJuniper Booking ";
            //            query += " LEFT JOIN BookingDetailJuniper BookingDetail ON Booking.BookingCode=BookingDetail.VoucherNumber ";
            //            query += " WHERE (BookingDetail.ProductGroupName='Own Contracts' OR BookingDetail.ProductGroupName='Supplier Push' OR BookingDetail.ProductGroupName='CM-HR' OR BookingDetail.ProductGroupName='CM-HR0' OR  BookingDetail.ProductGroupName='Supplier Push0' OR " +
            //                "BookingDetail.ProductTypeName='Own Contracts' OR BookingDetail.ProductTypeName='Supplier Push' OR BookingDetail.ProductTypeName='CM-HR' OR BookingDetail.ProductTypeName='CM-HR0' OR  BookingDetail.ProductTypeName='Supplier Push0')";

            //            string sql = "SELECT * FROM [SalesDate] WHERE SalesId='" + SaleId + "'";
            //            DataTable dts = command.ReturnTableWithParameters(sql, null, "Table");

            //            if (dts.Rows.Count > 0)
            //            {
            //                query += " AND (";
            //                int say = dts.Rows.Count;
            //                for (int i = 0; i < dts.Rows.Count; i++)
            //                {
            //                    say--;
            //                    DataRow dr = dts.Rows[i];
            //                    string SalesDateId = dr["SalesDateId"].ToString();
            //                    string sql2 = "SELECT DATEDIFF(day,EndDate,BeginDate) as Date FROM SalesDate WHERE SalesDateId='" + SalesDateId + "'";
            //                    DataTable dtsql2 = command.ReturnTableWithParameters(sql2, null, "Table");
            //                    if (dtsql2.Rows.Count > 0)
            //                    {
            //                        DataRow dr2 = dtsql2.Rows[0];
            //                        int uyari = Convert.ToInt32(dr2["Date"].ToString()) < 0 ? Convert.ToInt32(dr2["Date"].ToString()) * -1 : Convert.ToInt32(dr2["Date"].ToString());
            //                        if (uyari > 7)
            //                        {
            //                            ltrUyari.Text = "<i class=\"material-icons\">priority_high</i>";
            //                        }
            //                    }
            //                    query += "((BookingDetail.CheckIn BETWEEN (SELECT BeginDate FROM SalesDate WHERE SalesDateId='" + SalesDateId + "') AND (SELECT BeginDate FROM SalesDate WHERE SalesDateId='" + SalesDateId + "')) OR ";
            //                    query += "   (BookingDetail.CheckOut BETWEEN (SELECT EndDate FROM SalesDate WHERE SalesDateId='" + SalesDateId + "') AND (SELECT EndDate FROM SalesDate WHERE SalesDateId='" + SalesDateId + "')))";
            //                    if (say > 0)
            //                    {
            //                        query += " OR ";
            //                    }
            //                }
            //                query += ") ";
            //            }

            //            dts.Dispose();


            //            if (Session["UserId"].ToString() == "1")
            //            {
            //                query += " AND BookingDetail.HotelName='" + HotelName + "'";
            //            }
            //            else
            //            {
            //                query += " AND BookingDetail.HotelName='" + HotelName + "'";
            //            }

            //            //query += " ORDER BY Booking.BookingId DESC";
            //            DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

            //            if (dt.Rows.Count > 0)
            //            {
            //                DataRow drIlk = dt.Rows[0];
            //                int count = Convert.ToInt32(drIlk["Booking"].ToString());
            //                if (count > 0)
            //                {
            //                    ltrSaleCount.Text = "<i class=\"material-icons\">notifications_active</i>";
            //                }


            //            }
            //            dt.Dispose();

            //        }
            //        catch (Exception exp)
            //        {
            //            lblIslemSonuc.Text = "Hata : " + exp.Message;
            //            lblIslemSonuc.CssClass = "islemHatali";
            //            lblIslemSonuc.Visible = true;
            //        }

            //    }


            //}
            //catch (Exception ex)
            //{
            //    lblIslemSonuc.Text = "Hata : " + ex.Message;
            //    lblIslemSonuc.CssClass = "islemHatali";
            //    lblIslemSonuc.Visible = true;
            //}

        }
    }
}