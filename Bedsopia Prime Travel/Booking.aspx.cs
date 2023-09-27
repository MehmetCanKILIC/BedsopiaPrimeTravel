using MODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
namespace Bedsopia_Prime_Travel
{
    public partial class Booking : System.Web.UI.Page
    {
        DataTable dtMailListe;
        private string ServiceUser = "XMLKodSedna";
        private string ServicePass = "rH4sFaxq+";
        static string desc = "";
        Command command = new Command();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BookingList();

                if (Session["UserType"].ToString() == null || Session["UserType"].ToString() == "")
                {
                    Response.Redirect("Login.Aspx");
                }
                else
                {
                    Session["TitleFilter"] = "";

                    Session["SIRALAMA"] = String.Empty;

                    if (Request.QueryString["sirala"] == null || Request.QueryString["sirala"] == String.Empty)
                    {
                        ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                        ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                        ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                        ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                        ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                        ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                        ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                        ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                        ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                        ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                        ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";
                        ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                        ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                        ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                        ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                        ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                        ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                        ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                        ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";
                        //ltrAgencyName.Text = "<a href=\"?sirala=AgencyName_asc\">AGENCY NAME</a>";
                        ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                    }
                    else
                    {
                        DataTable dtListe = (DataTable)Session["BookingList"];
                        DataView dv = new DataView(dtListe);
                        switch (Request.QueryString["sirala"])
                        {
                            case "no_asc":
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_desc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrVoucher.Text = "<a href=\"?sirala=no_desc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Voucher Number ASC";
                                dtListe = dv.ToTable();
                                break;
                            case "no_desc":
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Voucher Number DECS";
                                dtListe = dv.ToTable();
                                break;
                            case "HotelNameAdmin_asc":
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_desc\">HOTEL NAME</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_desc\">HOTEL NAME</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Hotel Name ASC";
                                dtListe = dv.ToTable();
                                break;
                            case "HotelNameAdmin_desc":
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Hotel Name DESC";
                                dtListe = dv.ToTable();
                                break;
                            case "CheckInAdmin_asc":
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_desc\">CHECK IN</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_desc\">CHECK IN</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Check In ASC";
                                dtListe = dv.ToTable();
                                break;
                            case "CheckInAdmin_desc":
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Check In DESC";
                                dtListe = dv.ToTable();
                                break;
                            case "CheckOutAdmin_asc":
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_desc\">CHECK OUT</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_desc\">CHECK OUT</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Check Out ASC";
                                dtListe = dv.ToTable();
                                break;
                            case "CheckOutAdmin_desc":
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Check Out DESC";
                                dtListe = dv.ToTable();
                                break;
                            case "PessengerName_asc":
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_desc\">PESSENGER NAME</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_desc\">PESSENGER NAME</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Pessenger Name ASC";
                                dtListe = dv.ToTable();
                                break;
                            case "PessengerName_desc":
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESSENGER NAME</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESSENGER NAME</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Pessenger Name DESC";
                                dtListe = dv.ToTable();
                                break;
                            case "NationalityAdmin_asc":
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_desc\">NATIONALITY</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrNationality.Text = "<a href=\"?sirala=Nationality_desc\">NATIONALITY</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Nationality ASC";
                                dtListe = dv.ToTable();
                                break;
                            case "NationalityAdmin_desc":
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Nationality DESC";
                                dtListe = dv.ToTable();
                                break;
                            case "StatusAdmin_asc":
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_desc\">STATUS</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrStatus.Text = "<a href=\"?sirala=Status_desc\">STATUS</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Status ASC";
                                dtListe = dv.ToTable();
                                break;
                            case "StatusAdmin_desc":
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Status DESC";
                                dtListe = dv.ToTable();
                                break;
                            case "BookingDateAdmin_asc":
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_desc\">BOOKING DATE</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_desc\">BOOKING DATE</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "BookingDate ASC";
                                dtListe = dv.ToTable();
                                break;
                            case "BookingDateAdmin_desc":
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "BookingDate DESC";
                                dtListe = dv.ToTable();
                                break;
                            case "AgencyNameAdmin_asc":
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_desc\">AGENCY NAME</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_desc\">AGENCY NAME</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";
                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Agency Name ASC";
                                dtListe = dv.ToTable();
                                break;
                            case "AgencyNameAdmin_desc":
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";


                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";
                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                dv.Sort = "Agency Name DESC";
                                dtListe = dv.ToTable();
                                break;
                            case "BookingCodeAdmin_asc":
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_desc\">BOOKING CODE</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_desc\">BOOKING CODE</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                dv.Sort = "BookingCode ASC";
                                dtListe = dv.ToTable();
                                break;
                            case "BookingCodeAdmin_desc":
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";

                                ltrBookingCode.Text = "<a href=\"?sirala=BookingCode_asc\">BOOKING CODE</a>";
                                ltrVoucher.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelName.Text = "<a href=\"?sirala=HotelName_asc\">HOTEL NAME</a>";
                                ltrCheckIn.Text = "<a href=\"?sirala=CheckIn_asc\">CHECK IN</a>";
                                ltrCheckOut.Text = "<a href=\"?sirala=CheckOut_asc\">CHECK OUT</a>";
                                ltrPessenger.Text = "<a href=\"?sirala=Pessenger_asc\">PESENGER NAME</a>";
                                ltrNationality.Text = "<a href=\"?sirala=Nationality_asc\">NATIONALITY</a>";
                                ltrStatus.Text = "<a href=\"?sirala=Status_asc\">STATUS</a>";
                                ltrBookingDate.Text = "<a href=\"?sirala=BookingDate_asc\">BOOKING DATE</a>";

                                dv.Sort = "BookingCode DESC";
                                dtListe = dv.ToTable();
                                break;
                            case "ConfirmeDateAdmin_asc":
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_desc\">CONFIRME DATE</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";

                                dv.Sort = "BookingConfirmeDate ASC";
                                dtListe = dv.ToTable();
                                break;
                            case "ConfirmeDateAdmin_desc":
                                ltrConfirmeDateAdmin.Text = "<a href=\"?sirala=ConfirmeDateAdmin_asc\">CONFIRME DATE</a>";
                                ltrVoucheradmin.Text = "<a href=\"?sirala=no_asc\">VOUCHER NUMBER</a>";
                                ltrHotelNameAdmin.Text = "<a href=\"?sirala=HotelNameAdmin_asc\">HOTEL NAME</a>";
                                ltrCheckInAdmin.Text = "<a href=\"?sirala=CheckInAdmin_asc\">CHECK IN</a>";
                                ltrCheckOutAdmin.Text = "<a href=\"?sirala=CheckOutAdmin_asc\">CHECK OUT</a>";
                                ltrPessengerName.Text = "<a href=\"?sirala=PessengerName_asc\">PESENGER NAME</a>";
                                ltrNationalityAdmin.Text = "<a href=\"?sirala=NationalityAdmin_asc\">NATIONALITY</a>";
                                ltrStatusAdmin.Text = "<a href=\"?sirala=StatusAdmin_asc\">STATUS</a>";
                                ltrBookingDateAdmin.Text = "<a href=\"?sirala=BookingDateAdmin_asc\">BOOKING DATE</a>";
                                ltrAgencyNameAdmin.Text = "<a href=\"?sirala=AgencyNameAdmin_asc\">AGENCY NAME</a>";
                                ltrBookingCodeAdmin.Text = "<a href=\"?sirala=BookingCodeAdmin_asc\">BOOKING CODE</a>";
                                dv.Sort = "BookingConfirmeDate DESC";
                                dtListe = dv.ToTable();
                                break;
                            default:
                                break;
                        }
                        lvBookingsList.DataSource = dtListe;
                        lvBookingsList.DataBind();
                        Session["SIRALAMA"] = "filter";
                    }
                    TarihIslemleri();
                    //BookingAdd();
                }



            }

        }

        protected void lvBookingsList_PagePropertiesChanged(object sender, EventArgs e)
        {
            BookingList();
        }


        public void SecilenleriAl(string Description, string type)
        {
            try
            {

                foreach (ListViewDataItem item in lvBookingsList.Items)
                {
                    var cbSecim = item.FindControl("cbSecim") as CheckBox;

                    if (cbSecim != null && cbSecim.Checked)
                    {
                        string secilenId = cbSecim.CssClass;
                        if (type == "2")
                        {

                        }
                        else
                        {
                            BookingControl(secilenId, type);
                        }
                    }
                }
                BookingList();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "", "Toasts()", true);

            }
            catch (Exception ex)
            {
            }
        }


        protected string SonId()
        {
            try
            {
                string query = "SELECT top 1 BookingId FROM BookingJuniper  ORDER BY BookingId DESC";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    return dr["BookingId"].ToString();
                    //return "1";
                }
                else
                {
                    return "0";
                }
                dt.Dispose();

            }
            catch (Exception exp)
            {
                lblIslemSonuc.Text = "Hata : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
                return "0";
            }
        }

        protected string SonIdLine(string BookingCode)
        {
            try
            {
                string query = "SELECT top 1 VoucherNumber FROM BookingDetailJuniper WHERE VoucherNumber='" + BookingCode + "' ";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    //DataRow dr = dt.Rows[0];
                    //return dr["BookingId"].ToString();
                    return "1";
                }
                else
                {
                    return "0";
                }
                dt.Dispose();

            }
            catch (Exception exp)
            {
                lblIslemSonuc.Text = "Hata : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
                return "0";
            }
        }

        protected void BookingAdd()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (ServiceReference1.wsBookingsSoapClient soapClient = new ServiceReference1.wsBookingsSoapClient())
            {
                System.Xml.XmlNode nodetrue = soapClient.getBookingList(ServiceUser, ServicePass, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", null, "", "");
                //System.Xml.XmlNode nodefalse = soapClient.getBookingList(ServiceUser, ServicePass, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",false, "", "");
                XmlDocument doc = new XmlDocument();
                var BookingList = nodetrue.SelectNodes("BookingList/Booking").Cast<XmlElement>().ToList();
                //var BookingList2 = nodefalse.SelectNodes("BookingList/Booking").Cast<XmlElement>().ToList();
                //var booking = BookingList + BookingList2;

                int BookingIdOk = Convert.ToInt32(SonId());


                for (int i = 0; i < BookingList.Count; i++)
                {
                    int BookingId = Convert.ToInt32(BookingList[i].GetAttribute("Id").ToString());

                    if (BookingId > BookingIdOk)
                    {
                        int value = BookingsSearch(BookingList[i].GetAttribute("BookingCode").ToString());
                        if (value == 0)
                        {
                            try
                            {
                                string sql = @"INSERT INTO BPT..BookingJuniper(BookingId,Status,BookingCode,BookingDate,LastModifiedDate,AgencyRef,TimeZone,Note)";
                                sql += "values ('" + BookingList[i].GetAttribute("Id").ToString() + "',";
                                sql += "'" + BookingList[i].GetAttribute("Status").ToString() + "',";
                                sql += "'" + BookingList[i].GetAttribute("BookingCode").ToString() + "',";
                                sql += "'" + BookingList[i].GetAttribute("BookingDate").ToString() + "',";
                                sql += "'" + BookingList[i].GetAttribute("LastModifiedDate").ToString() + "',";
                                sql += "'" + BookingList[i].GetAttribute("AgencyRef").ToString() + "',";
                                sql += "'" + BookingList[i].GetAttribute("TimeZone").ToString() + "',";
                                sql += "'')";
                                DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");
                                string BookingCode = BookingList[i].GetAttribute("BookingCode").ToString();
                                int BookingDetailIdOk = Convert.ToInt32(SonIdLine(BookingCode));
                                if (BookingDetailIdOk == 0)
                                {
                                    BookingDetailAdd(BookingList[i].GetAttribute("BookingCode").ToString());
                                }
                            }
                            catch (Exception exp)
                            {

                                lblIslemSonuc.Text = "HATA : " + exp.Message;
                                lblIslemSonuc.CssClass = "islemHatali";
                                lblIslemSonuc.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        //string BookingCode = BookingList[i].GetAttribute("BookingCode").ToString();
                        //int BookingDetailIdOk = Convert.ToInt32(SonIdLine(BookingCode));
                        //if (BookingDetailIdOk==0)
                        //{
                        //    BookingDetailAdd(BookingList[i].GetAttribute("BookingCode").ToString());
                        //}
                    }

                }
            }
        }


        protected void BookingDetailAdd(string BookingCode)
        {
            using (ServiceReference1.wsBookingsSoapClient soapClient = new ServiceReference1.wsBookingsSoapClient())
            {
                string RoomType = "", Remarks = "", BoardType = "", AreaDescription = "", AreaState = "", ProductGroupName = "", ProductTypeName = "", AgencyGroupName = "", CheckIn = "", CheckOut = "", AreaName = "",
                   HotelName = "", bookingdate = "", NonRefundable = "", AgencyRef = "", VoucherNumber = "", SellingPrice = "", SellCurrency = "", Cost = "", HolderName = "",
                   HolderLastName = "", CostCurrency = "", Status = "", HolderNacionalidad = "";
                System.Xml.XmlNode node = soapClient.getBookings(ServiceUser, ServicePass, "", "", "", "", "", "", "", "", "", "", BookingCode, "", "", "", "", "", "", "", "", "", "", "", "", "");
                XmlDocument doc = new XmlDocument();
                XmlNodeList items = node.SelectNodes("Bookings/Booking");
                XmlNodeList Holder = node.SelectNodes("Bookings/Booking/Holder");
                XmlNodeList Linelist = node.SelectNodes("Bookings/Booking/Lines/Line");
                XmlNodeList DescriptionList = node.SelectNodes("Bookings/Booking/Lines/Line/Zone");
                XmlNodeList Paxes = node.SelectNodes("Bookings/Booking/Lines/Line/Paxes/Pax");
                XmlNodeList Roomlist = node.SelectNodes("Bookings/Booking/Lines/Line/roomlist/room");
                DataSet dataset = new DataSet();
                XmlNodeList BookingXml = node.SelectNodes("Bookings/Booking[@BookingCode='" + BookingCode + "']");

                foreach (XmlNode item in BookingXml)
                {
                    bookingdate = item.Attributes["BookingDate"].Value;
                    AgencyRef = item.Attributes["AgencyRef"].Value;
                    VoucherNumber = item.Attributes["BookingCode"].Value;
                    Status = item.Attributes["Status"].Value;
                    Cost = item["Cost"].InnerText;
                    SellingPrice = item["SellingPrice"].InnerText;
                }
                foreach (XmlNode holder in Holder)
                {
                    HolderName = holder["NameHolder"].InnerText;
                    HolderLastName = holder["LastName"].InnerText;
                    HolderNacionalidad = holder["Nacionalidad"].InnerText;
                }

                foreach (XmlNode room in Roomlist)
                {
                    HotelName = room["namehotel"].InnerText;
                    RoomType = room["typeroomname"].InnerText;
                    BoardType = room["boardtype"].InnerText;
                }

                foreach (XmlNode description in DescriptionList)
                {
                    AreaName = description["country"].InnerText;
                    AreaDescription = description["description"].InnerText;
                    AreaState = description["state"].InnerText;
                }


                foreach (XmlNode line in Linelist)
                {
                    NonRefundable = line.Attributes["NonRefundable"].Value;
                    CheckIn = line["BeginTravelDate"].InnerText;
                    CheckOut = line["EndTravelDate"].InnerText;
                    AgencyGroupName = line["AgencyGroupName"].InnerText;
                    CostCurrency = line["CostCurrency"].InnerText;
                    SellCurrency = line["SellCurrency"].InnerText;
                    Remarks = line["Remarks"].InnerText;
                    ProductGroupName = line["ProductGroupName"].InnerText;
                    ProductTypeName = line["ProductTypeName"].InnerText;

                }



                try
                {
                    string sql = @"INSERT INTO BPT..BookingDetailJuniper(VoucherNumber,HotelName,CheckIn,CheckOut,BookingDate,AgencyGroupName,AgencyRef,HolderName,HolderLastName,HolderNacionalidad,RoomType,BoardType,AreaName,AreaDescription,AreaState,SellingPrice,SellCurrency,Cost,CostCurrency,Status,Remarks,ProductGroupName,ProductTypeName,NonRefundable)";
                    sql += "values ('" + VoucherNumber + "',";
                    sql += "'" + HotelName.Replace("'", "") + "',";
                    sql += "'" + CheckIn + "',";
                    sql += "'" + CheckOut + "',";
                    sql += "'" + bookingdate + "',";
                    sql += "'" + AgencyGroupName.Replace("'", "") + "',";
                    sql += "'" + AgencyRef.Replace("'", "") + "',";
                    sql += "'" + HolderName.Replace("'", "") + "',";
                    sql += "'" + HolderLastName.Replace("'", "") + "',";
                    sql += "'" + HolderNacionalidad.Replace("'", "") + "',";
                    sql += "'" + RoomType.Replace("'", "") + "',";
                    sql += "'" + BoardType.Replace("'", "") + "',";
                    sql += "'" + AreaName.Replace("'", "") + "',";
                    sql += "'" + AreaDescription.Replace("'", "") + "',";
                    sql += "'" + AreaState.Replace("'", "") + "',";
                    sql += "'" + SellingPrice.Replace("'", "") + "',";
                    sql += "'" + SellCurrency.Replace("'", "") + "',";
                    sql += "'" + Cost.Replace("'", "") + "',";
                    sql += "'" + CostCurrency.Replace("'", "") + "',";
                    sql += "'" + Status.Replace("'", "") + "',";
                    sql += "'" + Remarks.Replace("'", "") + "',";
                    sql += "'" + ProductGroupName.Replace("'", "") + "',";
                    sql += "'" + ProductTypeName.Replace("'", "") + "',";
                    sql += "'" + NonRefundable.Replace("'", "") + "'";
                    sql += ")";
                    DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");


                    foreach (XmlNode page in Paxes)
                    {
                        string sql2 = @"INSERT INTO BPT..BookingDetailLineJuniper(BookingCode,Name,LastName,TipPax,Age,Born,City,Country,Email,ReferenceNumber)";
                        sql2 += "values ('" + VoucherNumber + "',";
                        sql2 += "'" + page["Name"].InnerText + "',";
                        sql2 += "'" + page["LastName"].InnerText + "',";
                        sql2 += "'" + page["TipPax"].InnerText + "',";
                        sql2 += "'" + page["Age"].InnerText + "',";
                        sql2 += "'" + page["Born"].InnerText + "',";
                        sql2 += "'" + page["City"].InnerText + "',";
                        sql2 += "'" + page["Country"].InnerText + "',";
                        sql2 += "'" + page["Email"].InnerText + "',";
                        sql2 += "'" + page["ReferenceNumber"].InnerText + "'";
                        sql2 += ")";
                        DataTable dt2 = command.ReturnTableWithParameters(sql2, null, "Table");
                    }
                }
                catch (Exception exp)
                {

                    lblIslemSonuc.Text = "HATA : " + exp.Message;
                    lblIslemSonuc.CssClass = "islemHatali";
                    lblIslemSonuc.Visible = true;
                }
            }

        }


        protected void UserFilter()
        {
            try
            {
                string query = "SELECT * FROM UserFilter WHERE UserId='" + Session["UserId"] + "'";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        if (dr["FilterType"].ToString() == "0")
                        {

                        }
                        else if (dr["FilterType"].ToString() == "1")
                        {

                        }
                        else if (dr["FilterType"].ToString() == "2")
                        {

                        }
                    }
                }
                else
                {
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
        protected void BookingList()
        {


            try
            {
                object siralama = null;

                if (Session["SIRALAMA"] != null && Session["SIRALAMA"].ToString() != String.Empty)
                {
                    siralama = Session["SIRALAMA"].ToString();
                }
                string query = "  SELECT  Booking.BookingId AS [Voucher Number],(SELECT TOP 1 STATUS FROM Bookings WHERE BookingCode=Booking.BookingCode) as BookingConfirm,(SELECT TOP 1 BookingConfirmeDate FROM Bookings WHERE BookingCode=Booking.BookingCode) as BookingConfirmeDate,Booking.VisibleStatus,BookingDetail.HotelName AS [Hotel Name],BookingDetail.CheckIn as [Check In],BookingDetail.CheckOut as [Check Out],BookingDetail.HolderName + '  ' + BookingDetail.HolderLastName AS [Pessenger Name],'' AS Note,BookingDetail.HolderNacionalidad as [Nationality],( SELECT top 1 Status FROM  PRIMETRAVEL_JUNIPER..BookingJuniper WHERE BookingCode = Booking.BookingCode) As Status,Booking.BookingDate,BookingDetail.AgencyGroupName as [Agency Name],Booking.BookingCode,'0' AS [Hotel Status] FROM BookingJuniper Booking ";
                query += " LEFT JOIN BookingDetailJuniper BookingDetail ON Booking.BookingCode=BookingDetail.VoucherNumber ";
                query += " WHERE (BookingDetail.ProductGroupName IN (SELECT ProductGroupName FROM ProductGroupJuniper)  OR BookingDetail.ProductGroupName IN (SELECT ProductGroupName FROM ProductGroupJuniper) )";


                //query += " WHERE (BookingDetail.ProductGroupName='Own Contracts' OR BookingDetail.ProductGroupName='Supplier Push' AND  BookingDetail.ProductGroupName='+14 VCC/ c-out' OR BookingDetail.ProductGroupName = 'HR- VCC 0 c-in' OR BookingDetail.ProductGroupName = 'HR- VCC 0 c-out' OR BookingDetail.ProductGroupName = 'HR- VCC 5 c-in' OR BookingDetail.ProductGroupName = 'HR- VCC 5 c-out' OR BookingDetail.ProductGroupName = 'Reseliva- VCC 0 c-in' OR BookingDetail.ProductGroupName = 'Reseliva- VCC 0 c-out' OR BookingDetail.ProductGroupName = 'Reseliva- VCC 5 c-in' OR BookingDetail.ProductGroupName = 'Reseliva- VCC 5 c-out' OR BookingDetail.ProductGroupName = 'SP- VCC 0 c-in' OR BookingDetail.ProductGroupName = 'SP- VCC 0 c-out' OR BookingDetail.ProductGroupName = 'SP- VCC 3 c-in' OR BookingDetail.ProductGroupName = 'SP- VCC 3 c-out' OR BookingDetail.ProductGroupName = 'SP- VCC 5 c-in' OR BookingDetail.ProductGroupName = 'SP- VCC 5 c-out' OR BookingDetail.ProductGroupName = '+7 VCC/ c-out' OR BookingDetail.ProductGroupName = '-5 VCC/ c-in' OR BookingDetail.ProductGroupName = 'VCC / c-in' OR BookingDetail.ProductGroupName = 'VCC / c-out' OR  BookingDetail.ProductGroupName='CM-HR'  OR BookingDetail.ProductGroupName='CM-HR0' OR  BookingDetail.ProductGroupName='Supplier Push0' OR " +
                //    "BookingDetail.ProductTypeName='Own Contracts' OR BookingDetail.ProductTypeName='Supplier Push' OR BookingDetail.ProductTypeName='CM-HR' OR BookingDetail.ProductTypeName='CM-HR0' OR  BookingDetail.ProductTypeName='Supplier Push0')";
                
                if (Session["UserId"].ToString() == "1")
                {

                }
                else
                {
                    query += " AND BookingDetail.HotelName='" + Session["HotelName"].ToString() + "'";
                    try
                    {
                        string query2 = "SELECT Convert(varchar,CheckIn,121) as CheckIn,Convert(varchar,CheckOut,121) as CheckOut,* FROM UserFilter WHERE UserId='" + Session["UserId"] + "'";

                        DataTable dt2 = command.ReturnTableWithParameters(query2, null, "Table");


                        if (dt2.Rows.Count > 0)
                        {
                            query += " AND (1=1 ";

                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                DataRow dr = dt2.Rows[i];
                                if (dr["FilterType"].ToString() == "1")//Title filter
                                {
                                    Session["TitleFilter"] = dr["VisibleTitles"].ToString();
                                }
                                else
                                {
                                    if (dr["FilterType"].ToString() == "0")//Day filter
                                    {
                                        query += "AND (BookingDetail.CheckIn BETWEEN dateadd(DD, " + Convert.ToInt32(dr["CheckInDay"].ToString()) * -1 + ", cast(getdate() as date)) AND dateadd(DD, " + Convert.ToInt32(dr["CheckInDay"].ToString()) + ", cast(getdate() as date))) ";
                                        query += "AND (BookingDetail.CheckIn BETWEEN dateadd(DD, " + Convert.ToInt32(dr["CheckOutDay"].ToString()) * -1 + ", cast(getdate() as date)) AND dateadd(DD, " + Convert.ToInt32(dr["CheckOutDay"].ToString()) + ", cast(getdate() as date))) ";
                                    }


                                    if (dr["FilterType"].ToString() == "2")//Date filter
                                    {
                                        query += " AND (BookingDetail.CheckIn BETWEEN '" + dr["CheckIn"].ToString() + "' AND '" + dr["CheckOut"].ToString() + "')";
                                    }

                                }

                            }
                            query += " OR (Booking.BedsopiaStatus='1'))";

                        }
                        dt2.Dispose();

                    }
                    catch (Exception exp)
                    {
                        lblIslemSonuc.Text = "Hata : " + exp.Message;
                        lblIslemSonuc.CssClass = "islemHatali";
                        lblIslemSonuc.Visible = true;
                    }
                }
                query += " ORDER BY Booking.BookingDate DESC";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");
                Session["BookingList"] = dt;
                if (dt.Rows.Count > 0)
                {
                    lvBookingsList.DataSource = dt;
                    lvBookingsList.DataBind();
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

        protected void lvBookingsList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

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

                int ekstreKapamaGun = Convert.ToInt32(Session["EKSTREKAPAMAGUN"]);


                ilkTarih = DateTime.Now;
                ilkGun = ilkTarih.Day;
                ilkYil = ilkTarih.Year;
                ilkAy = ilkTarih.Month;
                ilkGunSayisi = DateTime.DaysInMonth(ilkYil, ilkAy);

                varsayilanIlkTarih = "1" + "." + "1" + "." + ilkYil;


                txtIlkTarih.Text = varsayilanIlkTarih;

                string varsayilanSonTarih = "";

                //varsayilanSonTarih = ilkGunSayisi + "." + ilkAy + "." + ilkYil;

                DateTime sonTarih = DateTime.Now.AddDays(0);

                int sonYil = sonTarih.Year;
                int sonAy = sonTarih.Month;
                int sonGun = sonTarih.Day;

                varsayilanSonTarih = "31" + "." + "12" + "." + sonYil;

                txtSonTarih.Text = varsayilanSonTarih;
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

                string query = "  SELECT  Booking.BookingId AS [Voucher Number],(SELECT TOP 1 STATUS FROM Bookings WHERE BookingCode=Booking.BookingCode) as BookingConfirm,(SELECT TOP 1 BookingConfirmeDate FROM Bookings WHERE BookingCode=Booking.BookingCode) as BookingConfirmeDate,Booking.VisibleStatus,BookingDetail.HotelName AS [Hotel Name],BookingDetail.CheckIn as [Check In],BookingDetail.CheckOut as [Check Out],BookingDetail.HolderName + '  ' + BookingDetail.HolderLastName AS [Pessenger Name],'' AS Note,BookingDetail.HolderNacionalidad as [Nationality],( SELECT top 1 Status FROM  PRIMETRAVEL_JUNIPER..BookingJuniper WHERE BookingCode = Booking.BookingCode) As Status,Booking.BookingDate,BookingDetail.AgencyGroupName as [Agency Name],Booking.BookingCode,'0' AS [Hotel Status] FROM BookingJuniper Booking ";
                query += " LEFT JOIN BookingDetailJuniper BookingDetail ON Booking.BookingCode=BookingDetail.VoucherNumber ";
                query += " WHERE (BookingDetail.ProductGroupName IN (SELECT ProductGroupName FROM ProductGroupJuniper)  OR BookingDetail.ProductGroupName IN (SELECT ProductGroupName FROM ProductGroupJuniper) )";



                //query += " WHERE (BookingDetail.ProductGroupName='Own Contracts' OR BookingDetail.ProductGroupName='Supplier Push' AND  BookingDetail.ProductGroupName='+14 VCC/ c-out' OR BookingDetail.ProductGroupName = 'HR- VCC 0 c-in' OR BookingDetail.ProductGroupName = 'HR- VCC 0 c-out' OR BookingDetail.ProductGroupName = 'HR- VCC 5 c-in' OR BookingDetail.ProductGroupName = 'HR- VCC 5 c-out' OR BookingDetail.ProductGroupName = 'Reseliva- VCC 0 c-in' OR BookingDetail.ProductGroupName = 'Reseliva- VCC 0 c-out' OR BookingDetail.ProductGroupName = 'Reseliva- VCC 5 c-in' OR BookingDetail.ProductGroupName = 'Reseliva- VCC 5 c-out' OR BookingDetail.ProductGroupName = 'SP- VCC 0 c-in' OR BookingDetail.ProductGroupName = 'SP- VCC 0 c-out' OR BookingDetail.ProductGroupName = 'SP- VCC 3 c-in' OR BookingDetail.ProductGroupName = 'SP- VCC 3 c-out' OR BookingDetail.ProductGroupName = 'SP- VCC 5 c-in' OR BookingDetail.ProductGroupName = 'SP- VCC 5 c-out' OR BookingDetail.ProductGroupName = '+7 VCC/ c-out' OR BookingDetail.ProductGroupName = '-5 VCC/ c-in' OR BookingDetail.ProductGroupName = 'VCC / c-in' OR BookingDetail.ProductGroupName = 'VCC / c-out' OR  BookingDetail.ProductGroupName='CM-HR'  OR BookingDetail.ProductGroupName='CM-HR0' OR  BookingDetail.ProductGroupName='Supplier Push0' OR " +
                //    "BookingDetail.ProductTypeName='Own Contracts' OR BookingDetail.ProductTypeName='Supplier Push' OR BookingDetail.ProductTypeName='CM-HR' OR BookingDetail.ProductTypeName='CM-HR0' OR  BookingDetail.ProductTypeName='Supplier Push0')";



                //string query = "  SELECT  Booking.BookingId AS [Voucher Number],(SELECT TOP 1 STATUS FROM Bookings WHERE BookingCode=Booking.BookingCode) as BookingConfirm,(SELECT TOP 1 BookingConfirmeDate FROM Bookings WHERE BookingCode=Booking.BookingCode) as BookingConfirmeDate,Booking.VisibleStatus,BookingDetail.HotelName AS [Hotel Name],BookingDetail.CheckIn as [Check In],BookingDetail.CheckOut as [Check Out],BookingDetail.HolderName + '  ' + BookingDetail.HolderLastName AS [Pessenger Name],'' AS Note,BookingDetail.HolderNacionalidad as [Nationality],Booking.Status,Booking.BookingDate,BookingDetail.AgencyGroupName as [Agency Name],Booking.BookingCode,'0' AS [Hotel Status] FROM BookingJuniper Booking ";
                //query += " LEFT JOIN BookingDetailJuniper BookingDetail ON Booking.BookingCode=BookingDetail.VoucherNumber ";
                //query += " WHERE (BookingDetail.ProductGroupName='Own Contracts' OR BookingDetail.ProductGroupName='Supplier Push' OR BookingDetail.ProductGroupName='CM-HR' OR BookingDetail.ProductGroupName='CM-HR0' OR  BookingDetail.ProductGroupName='Supplier Push0' OR " +
                //    "BookingDetail.ProductTypeName='Own Contracts' OR BookingDetail.ProductTypeName='Supplier Push' OR BookingDetail.ProductTypeName='CM-HR' OR BookingDetail.ProductTypeName='CM-HR0' OR  BookingDetail.ProductTypeName='Supplier Push0')";
                if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2")
                {

                }
                else
                {
                    query += " AND BookingDetail.HotelName='" + Session["HotelName"].ToString() + "'";
                }
                if (txtArananKelime.Text != "")
                {
                    query += " AND Booking.BookingCode='" + txtArananKelime.Text + "'";
                }
                if (txtHotelName.Text != "")
                {
                    query += " AND BookingDetail.HotelName LIKE '%" + txtHotelName.Text + "%'";
                }
                if (txtVoucherNumber.Text != "")
                {
                    query += " AND Booking.BookingId='" + txtVoucherNumber.Text + "'";
                }
                if (txtBookingDate.Text != "")
                {
                    query += " AND (Booking.BookingDate BETWEEN CONVERT(datetime,'" + txtBookingDate.Text + "', 103) AND CONVERT(datetime,'" + txtBookingDate.Text + "', 103)+1)";
                }
                if (txtIlkTarih.Text != "")
                {
                    query += " AND (BookingDetail.CheckIn BETWEEN CONVERT(datetime,'" + txtIlkTarih.Text + "', 103) AND CONVERT(datetime,'" + txtSonTarih.Text + "', 103)+1)";
                }
                if (txtSonTarih.Text != "")
                {
                    query += " AND (BookingDetail.CheckOut BETWEEN CONVERT(datetime,'" + txtIlkTarih.Text + "', 103) AND CONVERT(datetime,'" + txtSonTarih.Text + "', 103)+1)";
                }
                if (txtAreaName.Text != "")
                {
                    query += " AND BookingDetail.AreaName='" + txtAreaName.Text + "'";
                }
                switch (dropFilter.SelectedValue)
                {
                    case "0":
                        break;
                    case "1":
                        query += " AND Booking.BookingCode IN(SELECT BookingCode FROM Bookings WHERE Status='1')";
                        break;
                    case "2":
                        query += " AND Booking.BookingCode IN(SELECT BookingCode FROM Bookings WHERE Status='-1')";
                        break;
                    default:
                        break;
                }


                query += " ORDER BY Booking.BookingId DESC";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");
                Session["BookingList"] = dt;

                if (dt.Rows.Count > 0)
                {

                    lvBookingsList.DataSource = dt;
                    lvBookingsList.DataBind();
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

        protected int BookingsSearch(string BookingCode)
        {
            try
            {
                string query = "SELECT * FROM BookingJuniper WHERE BookingCode='" + BookingCode + "'";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
                dt.Dispose();

            }
            catch (Exception exp)
            {
                lblIslemSonuc.Text = "Hata : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
                return 0;
            }
        }


        [System.Web.Services.WebMethod]
        static public int GetEmployeeById(string Description)
        {
            desc = Description;
            return 1;
        }


        protected void linkConfirm_Command(object sender, CommandEventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "OnayAlert(this,event)", true);
        }



        protected void BookingConfirme(string BookingCode, string type)
        {
            try
            {
                string sql = @"INSERT INTO BPT..Bookings(BookingCode,Status,Note)";
                sql += "values ('" + BookingCode + "','" + type + "','" + desc + "')";
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

            //Response.Redirect("OpenSAleAdmin.aspx");
        }

        protected void BookingUpdate(string BookingCode, string type)
        {
            try
            {
                string sql = @"UPDATE BPT..Bookings SET Status = '" + type + "' WHERE BookingCode='" + BookingCode + "'";
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


        protected void BookingControl(string BookingCode, string type)
        {
            try
            {
                string sql = @"SELECT * FROM  BPT..Bookings WHERE BookingCode='" + BookingCode + "'";
                DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");
                if (dt.Rows.Count > 0)
                {
                    BookingUpdate(BookingCode, type);
                }
                else
                {
                    BookingConfirme(BookingCode, type);

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

        protected void linkConfirme_Command(object sender, CommandEventArgs e)
        {
            SecilenleriAl(desc, "1");

        }

        protected void linkNotConfirme_Command(object sender, CommandEventArgs e)
        {
            SecilenleriAl(desc, "-1");

        }

        protected void linkReminder_Command(object sender, CommandEventArgs e)
        {
            SecilenleriAl(desc, "2");
        }

    }
}