using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bedsopia_Prime_Travel
{
    public partial class BookingDetailEdit : System.Web.UI.Page
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
                lblIslemSonuc.Text = ex.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }
        }


        protected void BookingDetailFunction(string BookingCode)
        {

            try
            {
                string query = "SELECT Booking.BookingCode,BookingDetail.HotelName,BookingDetail.NonRefundable,BookingDetail.CheckIn,BookingDetail.CheckOut,Booking.BookingDate,BookingDetail.AgencyGroupName,Booking.AgencyRef,BookingDetail.HolderName + '  ' + BookingDetail.HolderLastName AS [Pessenger Name],BookingDetail.HolderNacionalidad,BookingDetail.RoomType,BookingDetail.BoardType,BookingDetail.AreaName,BookingDetail.SellingPrice,BookingDetail.SellCurrency,BookingDetail.Cost,BookingDetail.CostCurrency,Booking.Status,BookingDetail.Remarks FROM BookingJuniper Booking ";
                query += " LEFT JOIN BookingDetailJuniper BookingDetail ON Booking.BookingCode=BookingDetail.VoucherNumber ";
                query += " WHERE Booking.BookingCode='" + BookingCode + "'";

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


        protected void lvBookingsList_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void lvBookingsList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }

        protected void BookingUpdate(string BookingCode)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "UPDATE  PRIMETRAVEL_JUNIPER..BookingJuniper SET ";
            sqlcmd.CommandText += "BookingDate                  =@BookingDate       WHERE BookingCode=@BookingCode          ";
            sqlcmd.Parameters.AddWithValue("@BookingDate", ltrBookingDate.Text);
            sqlcmd.Parameters.AddWithValue("@BookingCode", BookingCode);
            try
            {
                command.ExecuteScalar(sqlcmd);
            }
            catch (Exception exp)
            {

                lblIslemSonuc.Text = "HATA : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }

            //sqlcmd.CommandText += ",AgencyGroupName              =@AgencyGroupName             ";
            //sqlcmd.CommandText += ",AgencyRef                    =@AgencyRef                   ";
            //sqlcmd.CommandText += ",HolderName                   =@HolderName                  ";
            //sqlcmd.CommandText += ",HolderLastName               =@HolderLastName              ";
            //sqlcmd.CommandText += ",HolderNacionalidad           =@HolderNacionalidad          ";
            //sqlcmd.CommandText += ",RoomType                     =@RoomType                    ";
            //sqlcmd.CommandText += ",BoardType                    =@BoardType                   ";
            //sqlcmd.CommandText += ",AreaName                     =@AreaName                    ";
            //sqlcmd.CommandText += ",SellingPrice                 =@SellingPrice                ";
            //sqlcmd.CommandText += ",SellCurrency                 =@SellCurrency                ";
            //sqlcmd.CommandText += ",Cost                         =@Cost                        ";
            //sqlcmd.CommandText += ",CostCurrency                 =@CostCurrency                ";
            //sqlcmd.CommandText += ",Status                       =@Status                      ";
            //sqlcmd.CommandText += ",Remarks                      =@Remarks                     ";
            //sqlcmd.CommandText += ",ProductGroupName             =@ProductGroupName            ";
            //sqlcmd.CommandText += ",ProductTypeName              =@ProductTypeName             ";
            //sqlcmd.CommandText += ",NonRefundable                =@NonRefundable               ";
            //sqlcmd.CommandText += ",AreaDescription              =@AreaDescription             ";
            //sqlcmd.CommandText += ",AreaState                    =@AreaState                   ";
            //sqlcmd.CommandText += ",CustomerId                   =@CustomerId                  ";
            //sqlcmd.CommandText += ",AgentId                      =@AgentId                     ";
            //sqlcmd.CommandText += ",Description                  =@Description                 ";
            //sqlcmd.CommandText += ",Commission                   =@Commission                  ";
            //sqlcmd.CommandText += ",OutStandingAmount            =@OutStandingAmount           ";
            //sqlcmd.CommandText += ",TPVTransactionIdTransaction  =@TPVTransactionIdTransaction ";
            //sqlcmd.CommandText += ",TPVTransactionPaymentType    =@TPVTransactionPaymentType   ";
            //sqlcmd.CommandText += ",Invoiced                     =@Invoiced                    ";
            //sqlcmd.CommandText += ",InRemarks                    =@InRemarks                   ";
            //sqlcmd.CommandText += ",FinancialNotes               =@FinancialNotes              ";
            //sqlcmd.CommandText += ",HolderName1                  =@HolderName1                 ";
            //sqlcmd.CommandText += ",HolderLastName1              =@HolderLastName1             ";
            //sqlcmd.CommandText += ",HolderNacionalidad1          =@HolderNacionalidad1         ";
            //sqlcmd.CommandText += ",HolderCity                   =@HolderCity                  ";
            //sqlcmd.CommandText += ",HolderCountry                =@HolderCountry               ";
            //sqlcmd.CommandText += ",HolderAddress                =@HolderAddress               ";
            //sqlcmd.CommandText += ",HolderPhone1                 =@HolderPhone1                ";
            //sqlcmd.CommandText += ",HolderEmail                  =@HolderEmail                 ";
            //sqlcmd.CommandText += ",HolderIdioma                 =@HolderIdioma                ";
            //sqlcmd.CommandText += ",ServiceName                  =@ServiceName                 ";





        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string BookingCode = Request.QueryString["BookingCode"];
            BookingUpdate(BookingCode);
        }
    }
}