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
    public partial class ActionAdmin : System.Web.UI.Page
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
                    string ActionId = Request.QueryString["ActionId"];
                    if (ActionId != null)
                    {
                        SalesCheck(ActionId);
                    }
                    DataLists();
                }
            }
        }


        protected void DataLists()
        {
            try
            {
                string query = " SELECT Users.HotelName,ActionType.ActionType AS ActionTypeName,* FROM Actions Actions LEFT JOIN ActionType ActionType ON Actions.ActionType=ActionType.ActionId   LEFT JOIN Users Users ON Users.UserId=Actions.UserId";
                query+= " ORDER BY Actions.ActionId DESC ";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    lvActions.DataSource = dt;
                    lvActions.DataBind();
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


        protected void SalesCheck(string ActionId)
        {
            string sql = @"UPDATE Actions SET Status='1'";
            sql += " WHERE ActionId='" + ActionId + "'";
            DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");

            Response.Redirect("ActionAdmin.aspx");
        }

        protected void lvOpenSaleList_PagePropertiesChanged(object sender, EventArgs e)
        {

        }


        protected void lvActions_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                Literal ltrSaleCount = (Literal)e.Item.FindControl("ltrSaleCount");
                Literal ltrUyari = (Literal)e.Item.FindControl("ltrUyari");

                //if (e.Item.ItemType == ListViewItemType.DataItem)
                //{
                //    string SaleId = DataBinder.Eval(e.Item.DataItem, "SaleId").ToString();
                //    string HotelName = DataBinder.Eval(e.Item.DataItem, "HotelName").ToString();
                //    try
                //    {
                //        string query = "  SELECT Count(Booking.BookingCode) AS [Booking] FROM BookingJuniper Booking ";
                //        query += " LEFT JOIN BookingDetailJuniper BookingDetail ON Booking.BookingCode=BookingDetail.VoucherNumber ";
                //        query += " WHERE (BookingDetail.ProductGroupName='Own Contracts' OR BookingDetail.ProductGroupName='Supplier Push' OR BookingDetail.ProductGroupName='CM-HR' OR BookingDetail.ProductGroupName='CM-HR0' OR  BookingDetail.ProductGroupName='Supplier Push0' OR " +
                //            "BookingDetail.ProductTypeName='Own Contracts' OR BookingDetail.ProductTypeName='Supplier Push' OR BookingDetail.ProductTypeName='CM-HR' OR BookingDetail.ProductTypeName='CM-HR0' OR  BookingDetail.ProductTypeName='Supplier Push0')";

                //        string sql = "SELECT * FROM [SalesDate] WHERE SalesId='" + SaleId + "'";
                //        DataTable dts = command.ReturnTableWithParameters(sql, null, "Table");

                //        if (dts.Rows.Count > 0)
                //        {
                //            query += " AND (";
                //            int say = dts.Rows.Count;
                //            for (int i = 0; i < dts.Rows.Count; i++)
                //            {
                //                say--;
                //                DataRow dr = dts.Rows[i];
                //                string SalesDateId = dr["SalesDateId"].ToString();
                //                string sql2 = "SELECT DATEDIFF(day,EndDate,BeginDate) as Date FROM SalesDate WHERE SalesDateId='" + SalesDateId + "'";
                //                DataTable dtsql2 = command.ReturnTableWithParameters(sql2, null, "Table");
                //                if (dtsql2.Rows.Count > 0)
                //                {
                //                    DataRow dr2 = dtsql2.Rows[0];
                //                    int uyari = Convert.ToInt32(dr2["Date"].ToString()) < 0 ? Convert.ToInt32(dr2["Date"].ToString()) * -1 : Convert.ToInt32(dr2["Date"].ToString());
                //                    if (uyari > 7)
                //                    {
                //                        ltrUyari.Text = "<i class=\"material-icons\">priority_high</i>";
                //                    }
                //                }
                //                query += "((BookingDetail.CheckIn BETWEEN (SELECT BeginDate FROM SalesDate WHERE SalesDateId='" + SalesDateId + "') AND (SELECT BeginDate FROM SalesDate WHERE SalesDateId='" + SalesDateId + "')) OR ";
                //                query += "   (BookingDetail.CheckOut BETWEEN (SELECT EndDate FROM SalesDate WHERE SalesDateId='" + SalesDateId + "') AND (SELECT EndDate FROM SalesDate WHERE SalesDateId='" + SalesDateId + "')))";
                //                if (say > 0)
                //                {
                //                    query += " OR ";
                //                }
                //            }
                //            query += ") ";
                //        }

                //        dts.Dispose();


                //        if (Session["UserId"].ToString() == "1")
                //        {
                //            query += " AND BookingDetail.HotelName='" + HotelName + "'";
                //        }
                //        else
                //        {
                //            query += " AND BookingDetail.HotelName='" + HotelName + "'";
                //        }

                //        //query += " ORDER BY Booking.BookingId DESC";
                //        DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                //        if (dt.Rows.Count > 0)
                //        {
                //            DataRow drIlk = dt.Rows[0];
                //            int count = Convert.ToInt32(drIlk["Booking"].ToString());
                //            if (count > 0)
                //            {
                //                ltrSaleCount.Text = "<i class=\"material-icons\">notifications_active</i>";
                //            }


                //        }
                //        dt.Dispose();

                //    }
                //    catch (Exception exp)
                //    {
                //        lblIslemSonuc.Text = "Hata : " + exp.Message;
                //        lblIslemSonuc.CssClass = "islemHatali";
                //        lblIslemSonuc.Visible = true;
                //    }

                //}


            }
            catch (Exception ex)
            {
                lblIslemSonuc.Text = "Hata : " + ex.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }
        }
    }
}