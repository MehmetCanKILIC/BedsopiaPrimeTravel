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
    public partial class ActionDetail : System.Web.UI.Page
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
                    getSaleDetails(ActionId);
                    ReservationCheckDate(ActionId);
                }
            }
        }

        protected void getSaleDetails(string ActionId)
        {
            try
            {
                string query = " SELECT ActionType.ActionType AS ActionTypeName,* FROM Actions Actions LEFT JOIN ActionType ActionType ON Actions.ActionType=ActionType.ActionId ";
                query += " WHERE Actions.ActionId='" + ActionId + "'";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    DataRow drIlk = dt.Rows[0];
                    PanelVisible(drIlk["ActionType"].ToString());
                    ltrActionType.Text = drIlk["ActionTypeName"].ToString();
                    //Session["HotelName"] = drIlk["HotelName"].ToString();
                    ltrRoom.Text = drIlk["Room"].ToString();
                    ltrRoomUpgrade.Text = drIlk["RoomUpgrade"].ToString();
                    ltrBoard.Text = drIlk["Board"].ToString();
                    ltrBoardUpgrade.Text = drIlk["BoardUpgrade"].ToString();
                    ltrRelease.Text = drIlk["Release"].ToString();
                    ltrActionBeginDate.Text = drIlk["BeginDate"].ToString();
                    ltrActionCheckIn.Text = drIlk["CheckIn"].ToString();
                    ltrActionCheckOut.Text = drIlk["CheckOut"].ToString();
                    ltrActionEndDate.Text = drIlk["EndDate"].ToString();
                    ltrAge.Text = drIlk["AgeRange"].ToString();
                    ltrChild.Text = drIlk["Age"].ToString();
                    ltrDiscount.Text = drIlk["DiscountRate"].ToString();
                    ltrPromotionRequest.Text = drIlk["PromotionRequest"].ToString();
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

        protected void PanelVisible(string ActionType)
        {
            switch (ActionType)
            {
                case "1"://% SPO - EBD
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelChild.Visible = false;
                    panelRoom.Visible = false;
                    panelRoomUpgrade.Visible = false;
                    panelBoardUpgrade.Visible = false;
                    panelBoard.Visible = false;
                    panelChild.Visible = false;
                    break;
                case "2"://Rate SPO
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelAgeRange.Visible = false;
                    panelRoom.Visible = true;
                    panelRoomUpgrade.Visible = false;
                    panelBoardUpgrade.Visible = false;
                    panelBoard.Visible = false;
                    panelChild.Visible = false;
                    break;
                case "3"://Minimum Stay
                    panelDiscount.Visible = true;
                    panelRelease.Visible = false;
                    panelAgeRange.Visible = false;
                    panelRoom.Visible = false;
                    panelRoomUpgrade.Visible = false;
                    panelBoardUpgrade.Visible = false;
                    panelBoard.Visible = false;
                    panelChild.Visible = false;
                    break;
                case "4":// Day Promotion
                    panelDiscount.Visible = false;
                    panelRelease.Visible = true;
                    panelAgeRange.Visible = false;
                    panelRoom.Visible = false;
                    panelRoomUpgrade.Visible = false;
                    panelBoardUpgrade.Visible = false;
                    panelBoard.Visible = false;
                    panelChild.Visible = false;
                    break;
                case "5"://Free Room Upgrade
                    panelDiscount.Visible = false;
                    panelRelease.Visible = true;
                    panelAgeRange.Visible = false;
                    panelRoom.Visible = true;
                    panelRoomUpgrade.Visible = true;
                    panelBoardUpgrade.Visible = false;
                    panelBoard.Visible = false;
                    panelChild.Visible = false;
                    break;
                case "6"://Deal Of Week
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelAgeRange.Visible = false;
                    panelRoom.Visible = false;
                    panelRoomUpgrade.Visible = false;
                    panelBoardUpgrade.Visible = false;
                    panelBoard.Visible = false;
                    panelChild.Visible = false;
                    break;
                case "7"://Deal Of Weekend
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelAgeRange.Visible = false;
                    panelRoom.Visible = false;
                    panelRoomUpgrade.Visible = false;
                    panelBoardUpgrade.Visible = false;
                    panelBoard.Visible = false;
                    panelChild.Visible = false;
                    break;
                case "8"://Free Board Upgrade
                    panelDiscount.Visible = false;
                    panelRelease.Visible = true;
                    panelAgeRange.Visible = false;
                    panelRoom.Visible = false;
                    panelRoomUpgrade.Visible = false;
                    panelBoardUpgrade.Visible = true;
                    panelBoard.Visible = true;
                    panelChild.Visible = false;
                    break;
                case "9"://Senior Reduction
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelAgeRange.Visible = false;
                    panelRoom.Visible = false;
                    panelRoomUpgrade.Visible = false;
                    panelBoardUpgrade.Visible = false;
                    panelBoard.Visible = false;
                    panelChild.Visible = true;
                    break;
                case "10"://Free Child
                    panelDiscount.Visible = false;
                    panelRelease.Visible = true;
                    panelAgeRange.Visible = true;
                    panelRoom.Visible = false;
                    panelRoomUpgrade.Visible = false;
                    panelBoardUpgrade.Visible = false;
                    panelBoard.Visible = false;
                    panelChild.Visible = false;
                    break;
                case "11"://Rolling EB
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelAgeRange.Visible = false;
                    panelRoom.Visible = false;
                    panelRoomUpgrade.Visible = false;
                    panelBoardUpgrade.Visible = false;
                    panelBoard.Visible = false;
                    panelChild.Visible = false;
                    break;
                case "12"://Opaque Discount
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelAgeRange.Visible = false;
                    panelRoom.Visible = false;
                    panelRoomUpgrade.Visible = false;
                    panelBoardUpgrade.Visible = false;
                    panelBoard.Visible = false;
                    panelChild.Visible = false;
                    break;
                default:
                    break;
            }

        }


        protected void ReservationCheckDate(string SaleId)
        {
            try
            {
                string query = "  SELECT Booking.BookingId AS [Voucher Number],BookingDetail.HotelName AS [Hotel Name],BookingDetail.CheckIn as [Check In],BookingDetail.CheckOut as [Check Out],BookingDetail.HolderName + '  ' + BookingDetail.HolderLastName AS [Pessenger Name],'' AS Note,BookingDetail.HolderNacionalidad as [Nationality],Booking.Status,Booking.BookingDate,BookingDetail.AgencyGroupName as [Agency Name],Booking.BookingCode,'0' AS [Hotel Status] FROM BookingJuniper Booking ";
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
    }

}