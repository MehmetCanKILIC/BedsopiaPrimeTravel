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
    public partial class FinancePayments : System.Web.UI.Page
    {
        Command command = new Command();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["UserType"].ToString() == null || Session["UserType"].ToString() == "")
                //{
                //    Response.Redirect("Login.Aspx");
                //}
                //else
                //{
                //    TarihIslemleri(); 
                //    InvoiceList();
                //}
            }

        }

        protected void InvoiceList()
        {


            try
            {
                string query = " SELECT Invoice.InvoiceNumber,BookingDetail.SaleCompanyName,BookingDetail.SellingPrice,BookingDetail.SellCurrency, Booking.BookingCode,Booking.BookingDate,BookingDetail.HotelName,BookingDetail.Cost,BookingDetail.CheckIn,BookingDetail.CheckOut,BookingDetail.CostCurrency,BookingDetail.ServiceName,BookingDetail.AgencyRef ";
                query += " FROM InvoiceJuniper Invoice LEFT JOIN InvoiceDetailJuniper InvoiceDetail ON InvoiceDetail.IdInvoice=Invoice.IdInvoice ";
                query += " LEFT JOIN InvoiceDetailLineJuniper InvoiceDetailLine ON Invoice.IdInvoice=InvoiceDetailLine.IdInvoice  ";
                query += "  RIGHT JOIN BookingJuniper Booking ON Booking.BookingCode=InvoiceDetailLine.BookingCode ";
                query += "  INNER JOIN BookingDetailJuniper BookingDetail ON Booking.BookingCode=BookingDetail.VoucherNumber  ";

                //query += " WHERE (BookingDetail.ProductGroupName='Own Contracts' OR BookingDetail.ProductGroupName='Supplier Push' OR BookingDetail.ProductGroupName='CM-HR' OR BookingDetail.ProductGroupName='CM-HR0' OR  BookingDetail.ProductGroupName='Supplier Push0' OR " +
                //    "BookingDetail.ProductTypeName='Own Contracts' OR BookingDetail.ProductTypeName='Supplier Push' OR BookingDetail.ProductTypeName='CM-HR' OR BookingDetail.ProductTypeName='CM-HR0' OR  BookingDetail.ProductTypeName='Supplier Push0')";


                query += " ORDER BY Invoice.InvoiceDate	DESC";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    //lvInvoicesList.DataSource = dt;
                    //lvInvoicesList.DataBind();
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




        protected void lvInvoicesList_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void lvInvoicesList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
    }
}