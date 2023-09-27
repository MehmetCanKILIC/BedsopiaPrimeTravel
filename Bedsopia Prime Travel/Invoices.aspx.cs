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
    public partial class Invoices : System.Web.UI.Page
    {

        Command command = new Command();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                    TarihIslemleri();
                    //InvoiceList();
                
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
                    lvInvoicesList.DataSource = dt;
                    lvInvoicesList.DataBind();
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

        protected void TarihIslemleri()
        {
            try
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

                varsayilanIlkTarih = "1" + "." + "1" + "." + ilkYil;



                txtSonTarih1.Text = varsayilanIlkTarih;
                txtIlkTarih1.Text = varsayilanIlkTarih;
                //txtBookingDate.Text = varsayilanIlkTarih;
                string varsayilanSonTarih = "";

                //varsayilanSonTarih = ilkGunSayisi + "." + ilkAy + "." + ilkYil;

                DateTime sonTarih = DateTime.Now.AddDays(0);

                int sonYil = sonTarih.Year;
                int sonAy = sonTarih.Month;
                int sonGun = sonTarih.Day;

                varsayilanSonTarih = "31" + "." + "12" + "." + sonYil;

                txtSonTarih2.Text = varsayilanSonTarih;
                txtIlkTarih2.Text = varsayilanSonTarih;

            }
            catch (Exception ex)
            {
                lblIslemSonuc.Text = ex.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }
        }


        protected void Filtreleme()
        {
            try
            {
                string query = " SELECT Invoice.InvoiceNumber,BookingDetail.SaleCompanyName,BookingDetail.SellingPrice,BookingDetail.SellCurrency, Booking.BookingCode,Booking.BookingDate,BookingDetail.ServiceName,BookingDetail.NetCostLine,BookingDetail.BeginTravelDate,BookingDetail.EndTravelDate,BookingDetail.CostCurrency,BookingDetail.ServiceName,BookingDetail.AgencyGroupName  ";
                query += " FROM JP_PRIME..JP_CustomerInvoice Invoice LEFT JOIN JP_PRIME..JP_CustomerInvoiceLine InvoiceDetailLine ON Invoice.IdInvoice=InvoiceDetailLine.IdInvoice    RIGHT JOIN JP_PRIME..JP_Booking Booking ON Booking.BookingCode=InvoiceDetailLine.BookingCode    INNER JOIN JP_PRIME..JP_BookingDetailLine BookingDetail ON Booking.BookingCode=BookingDetail.BookingCode    ";

                //query += " WHERE (BookingDetail.ProductGroupName='Own Contracts' OR BookingDetail.ProductGroupName='Supplier Push' OR BookingDetail.ProductGroupName='CM-HR' OR BookingDetail.ProductGroupName='CM-HR0' OR  BookingDetail.ProductGroupName='Supplier Push0' OR " +
                //    "BookingDetail.ProductTypeName='Own Contracts' OR BookingDetail.ProductTypeName='Supplier Push' OR BookingDetail.ProductTypeName='CM-HR' OR BookingDetail.ProductTypeName='CM-HR0' OR  BookingDetail.ProductTypeName='Supplier Push0')";

                query += " WHERE 1=1 ";
                if (txtInvoiceNumber.Text != "")
                {
                    query += " AND Invoice.InvoiceNumber='" + txtInvoiceNumber.Text + "'";
                }
                if (txtHotelName.Text != "")
                {
                    query += " AND InvoiceDetailLine.Service LIKE '%" + txtHotelName.Text + "%'";
                }
                if (txtSaleCompany.Text != "")
                {
                    query += " AND BookingDetail.SaleCompanyName LIKE '%" + txtSaleCompany.Text + "%'";
                }
                if (txtBookingCode.Text != "")
                {
                    query += " AND Booking.BookingCode='" + txtBookingCode.Text + "'";
                }
                if (txtCustomerName.Text != "")
                {
                    query += " AND Invoice.CustomerName='" + txtCustomerName.Text + "'";
                }


               

                if (txtBookingDate.Text!="")
                {
                    query += " AND Booking.BookingDate = CONVERT(datetime,'" + txtBookingDate.Text + "',103)";

                }

                query += " ORDER BY Invoice.InvoiceDate	DESC";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {

                    lvInvoicesList.DataSource = dt;
                    lvInvoicesList.DataBind();
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

        protected void btnFiltre_Click(object sender, EventArgs e)
        {
            Filtreleme();
        }

        protected void lvInvoicesList_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void lvInvoicesList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
    }
}