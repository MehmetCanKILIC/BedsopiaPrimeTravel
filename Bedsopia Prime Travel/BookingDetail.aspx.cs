using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Bedsopia_Prime_Travel
{
    public partial class BookingDetail : System.Web.UI.Page
    {

        private string ServiceUser = "XMLKodSedna";
        private string ServicePass = "rH4sFaxq+";
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
                    BookingDetailFunction(BookingCode);
                    VisibleStatus(BookingCode);
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


        protected void BookingDetailFunction(string BookingCode)
        {






            //using (ServiceReference1.wsBookingsSoapClient soapClient = new ServiceReference1.wsBookingsSoapClient())
            //{
            //    string RoomType = "", Remarks = "", BoardType = "", AgencyGroupName = "", CheckIn = "", CheckOut = "", AreaName = "",
            //        HotelName = "", bookingdate = "", AgencyRef = "", VoucherNumber = "", SellingPrice = "", SellCurrency = "", Cost = "", HolderName = "",
            //        HolderLastName = "", HolderPhone1 = "", CostCurrency = "", Status = "", HolderNacionalidad = "";
            //    System.Xml.XmlNode node = soapClient.getBookings(ServiceUser, ServicePass, "", "", "", "", "", "", "", "", "", "", BookingCode, "", "", "", "", "", "", "", "", "", "", "", "", "");
            //    XmlDocument doc = new XmlDocument();
            //    XmlNodeList items = node.SelectNodes("Bookings/Booking");
            //    XmlNodeList Holder = node.SelectNodes("Bookings/Booking/Holder");
            //    XmlNodeList Linelist = node.SelectNodes("Bookings/Booking/Lines/Line");
            //    XmlNodeList DescriptionList = node.SelectNodes("Bookings/Booking/Lines/Line/Zone");
            //    XmlNodeList Paxes = node.SelectNodes("Bookings/Booking/Lines/Line/Paxes/Pax");
            //    XmlNodeList Roomlist = node.SelectNodes("Bookings/Booking/Lines/Line/roomlist/room");
            //    //DataTable dataTable = new DataTable();
            //    DataSet dataset = new DataSet();
            //    XmlNodeList BookingXml = node.SelectNodes("Bookings/Booking[@BookingCode='" + BookingCode + "']");

            //    //dataTable.Columns.Add("Voucher Number");
            //    //dataTable.Columns.Add("Hotel Name");
            //    //dataTable.Columns.Add("Check In");
            //    //dataTable.Columns.Add("Check Out");
            //    //dataTable.Columns.Add("BookingDate");
            //    //dataTable.Columns.Add("Agency Name");
            //    //dataTable.Columns.Add("Agency Reference Number");
            //    //dataTable.Columns.Add("Pessenger Name");//Müşteri Adı
            //    //dataTable.Columns.Add("Nationality");//Ülke
            //    //dataTable.Columns.Add("Room Type");
            //    //dataTable.Columns.Add("Board Type");
            //    //dataTable.Columns.Add("Area Name");
            //    DataTable dataTableLine = new DataTable();//Rezervasyon satır bilgileri
            //    dataTableLine.Columns.Add("Name");
            //    dataTableLine.Columns.Add("LastName");
            //    dataTableLine.Columns.Add("TipPax");
            //    dataTableLine.Columns.Add("Age");
            //    dataTableLine.Columns.Add("Born");
            //    dataTableLine.Columns.Add("City");
            //    dataTableLine.Columns.Add("Country");
            //    dataTableLine.Columns.Add("Email");
            //    dataTableLine.Columns.Add("ReferenceNumber");



            //    //foreach (XmlNode description in DescriptionList)
            //    //{
            //    //    AreaName = description["description"].InnerText;

            //    //}
            //    foreach (XmlNode item in BookingXml)
            //    {
            //        bookingdate = item.Attributes["BookingDate"].Value;
            //        AgencyRef = item.Attributes["AgencyRef"].Value;
            //        VoucherNumber = item.Attributes["BookingCode"].Value;
            //        Status = item.Attributes["Status"].Value;
            //        Cost = item["Cost"].InnerText;
            //        SellingPrice = item["SellingPrice"].InnerText;
            //    }
            //    foreach (XmlNode holder in Holder)
            //    {
            //        HolderName = holder["NameHolder"].InnerText;
            //        HolderLastName = holder["LastName"].InnerText;
            //        HolderNacionalidad = holder["Nacionalidad"].InnerText;
            //    }

            //    foreach (XmlNode room in Roomlist)
            //    {
            //        HotelName = room["namehotel"].InnerText;
            //        RoomType = room["typeroomname"].InnerText;
            //        BoardType = room["boardtype"].InnerText;
            //    }


            //    foreach (XmlNode line in Linelist)
            //    {
            //        CheckIn = line["BeginTravelDate"].InnerText;
            //        CheckOut = line["EndTravelDate"].InnerText;
            //        AgencyGroupName = line["AgencyGroupName"].InnerText;
            //        CostCurrency = line["CostCurrency"].InnerText;
            //        SellCurrency = line["SellCurrency"].InnerText;
            //        Remarks = line["Remarks"].InnerText;

            //    }

            //    foreach (XmlNode page in Paxes)
            //    {
            //        dataTableLine.Rows.Add(page["Name"].InnerText, page["LastName"].InnerText, page["TipPax"].InnerText,
            //            page["Age"].InnerText, page["Born"].InnerText, page["City"].InnerText, page["Country"].InnerText,
            //            page["Email"].InnerText, page["ReferenceNumber"].InnerText);
            //        AreaName = page["Country"].InnerText;

            //    }
            //    lvBookingsList.DataSource = dataTableLine;
            //    lvBookingsList.DataBind();



            try
            {
                //string query = "SELECT Booking.BookingCode,BookingDetail.HotelName,BookingDetail.NonRefundable,BookingDetail.CheckIn,BookingDetail.CheckOut,Booking.BookingDate,BookingDetail.AgencyGroupName,Booking.AgencyRef,BookingDetail.HolderName + '  ' + BookingDetail.HolderLastName AS [Pessenger Name],BookingDetail.HolderNacionalidad,BookingDetail.RoomType,BookingDetail.BoardType,BookingDetail.AreaName,BookingDetail.SellingPrice,BookingDetail.SellCurrency,BookingDetail.Cost,BookingDetail.CostCurrency,Booking.Status,BookingDetail.Remarks FROM BookingJuniper Booking ";
                //query += " LEFT JOIN BookingDetailJuniper BookingDetail ON Booking.BookingCode=BookingDetail.VoucherNumber ";
                //query += " WHERE Booking.BookingCode='" + BookingCode + "'";




                string query = "EXEC PRIMETRAVEL_JUNIPER.dbo.BOOKINGDETAIL @BookingCode='" + BookingCode + "'";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {

                    DataRow dr = dt.Rows[0];
                    ltrVoucherNumber.Text = dr["BookingCode"].ToString();
                    ltrHotelName.Text = dr["HotelName"].ToString();
                    ltrCheckIn.Text = dr["CheckIn"].ToString();
                    ltrCheckOut.Text = dr["CheckOut"].ToString();
                    ltrBookingDate.Text = dr["bookingdate"].ToString();
                    ltrAgencyName.Text = dr["AgencyGroupName"].ToString();
                    ltrAgencyRef.Text = dr["AgencyRef"].ToString();
                    ltrPessengerName.Text = dr["Pessenger Name"].ToString();
                    ltrNationality.Text = dr["HolderNacionalidad"].ToString();
                    ltrRoomType.Text = dr["RoomType"].ToString();
                    ltrBoardType.Text = dr["BoardType"].ToString();
                    ltrAreaName.Text = dr["AreaName"].ToString();
                    ltrSellingPrice.Text = dr["SellingPrice"].ToString();
                    ltrSellCurrency.Text = dr["SellCurrency"].ToString();
                    ltrCost.Text = dr["Cost"].ToString();
                    ltrCostCurrency.Text = dr["CostCurrency"].ToString();
                    ltrNonRefundable.Text = dr["NonRefundable"].ToString();
                    ltrStatus.Text = dr["Status"].ToString();
                    ltrRemarks.Text = dr["Remarks"].ToString();


                    ltrVoucherNumberHotel.Text = dr["BookingCode"].ToString();
                    ltrHotelNameHotel.Text = dr["HotelName"].ToString();
                    ltrCheckInHotel.Text = dr["CheckIn"].ToString();
                    ltrCheckOutHotel.Text = dr["CheckOut"].ToString();
                    ltrBookingDateHotel.Text = dr["bookingdate"].ToString();
                    //ltrAgencyNameHotel.Text = dr["AgencyGroupName"].ToString();
                    ltrAgencyRefHotel.Text = dr["AgencyRef"].ToString();
                    ltrPessengerNameHotel.Text = dr["Pessenger Name"].ToString();
                    ltrNationalityHotel.Text = dr["HolderNacionalidad"].ToString();
                    ltrRoomTypeHotel.Text = dr["RoomType"].ToString();
                    ltrBoardTypeHotel.Text = dr["BoardType"].ToString();
                    ltrAreaNameHotel.Text = dr["AreaName"].ToString();
                    //ltrSellingPriceHotel.Text = dr["SellingPrice"].ToString();
                    //ltrSellCurrencyHotel.Text = dr["SellCurrency"].ToString();
                    ltrCostHotel.Text = dr["Cost"].ToString();
                    ltrCostCurrencyHotel.Text = dr["CostCurrency"].ToString();
                    ltrNonRefundableHotel.Text = dr["NonRefundable"].ToString();
                    ltrStatusHotel.Text = dr["Status"].ToString();
                    ltrRemarksHotel.Text = dr["Remarks"].ToString();

                }

                dt.Dispose();

                DataTable dataTableLine = new DataTable();//Rezervasyon satır bilgileri
                dataTableLine.Columns.Add("Name");
                dataTableLine.Columns.Add("LastName");
                dataTableLine.Columns.Add("TipPax");
                dataTableLine.Columns.Add("Age");
                dataTableLine.Columns.Add("Born");
                dataTableLine.Columns.Add("City");
                dataTableLine.Columns.Add("Country");
                dataTableLine.Columns.Add("Email");
                dataTableLine.Columns.Add("ReferenceNumber");

                string query2 = " SELECT BookingDetailLine.* FROM BookingJuniper Booking  ";
                query2 += " LEFT JOIN BookingDetailLineJuniper BookingDetailLine ON Booking.BookingCode=BookingDetailLine.BookingCode ";
                query2 += " WHERE Booking.BookingCode='" + BookingCode + "'";

                DataTable dt2 = command.ReturnTableWithParameters(query2, null, "Table");

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    DataRow dr = dt2.Rows[i];
                    dataTableLine.Rows.Add(dr["Name"].ToString(), dr["LastName"].ToString(), dr["TipPax"].ToString(),
                   dr["Age"].ToString(), dr["Born"].ToString(), dr["City"].ToString(), dr["Country"].ToString(),
                   dr["Email"].ToString(), dr["ReferenceNumber"].ToString());
                }
                lvBookingsList.DataSource = dataTableLine;
                lvBookingsList.DataBind();

            }
            catch (Exception exp)
            {
                lblIslemSonuc.Text = "Hata : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;

            }


        }


        protected void DataList()
        {

        }

        protected void lvBookingsList_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void lvBookingsList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
    }
}