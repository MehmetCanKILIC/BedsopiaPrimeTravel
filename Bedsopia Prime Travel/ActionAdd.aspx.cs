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
    public partial class ActionAdd : System.Web.UI.Page
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
                    GetBoardType();
                    GetRoomType();
                    TarihIslemleri();
                    DataLists();
                    GetActionType();
                }
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

                varsayilanIlkTarih = ilkGun + "." + ilkAy + "." + ilkYil;

                //txtIlkTarih.Text = varsayilanIlkTarih;

                string varsayilanSonTarih = "";

                DateTime sonTarih = DateTime.Now.AddDays(0);

                int sonYil = sonTarih.Year;
                int sonAy = sonTarih.Month;
                int sonGun = sonTarih.Day;

                varsayilanSonTarih = sonGun + "." + sonAy + "." + sonYil;

                //txtSonTarih.Text = varsayilanSonTarih;
            }
            catch (Exception ex)
            {
                lblIslemSonuc.Text = ex.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }
        }

        protected void GetRoomType()
        {
            try
            {
                string query = "SELECT * FROM [RoomTypes] WHERE HotelName='" + Session["HotelName"].ToString() + "'";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];

                        string id = dr["RoomId"].ToString();
                        string ad = dr["RoomType"].ToString();

                        dropRoom.Items.Add(new System.Web.UI.WebControls.ListItem(ad, id));
                        dropRoomUprage.Items.Add(new System.Web.UI.WebControls.ListItem(ad, id));
                        
                    }
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
        protected void GetActionType()
        {
            try
            {
                string query = "SELECT * FROM [ActionType]";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];

                        string id = dr["ActionId"].ToString();
                        string ad = dr["ActionType"].ToString();

                        dropActionType.Items.Add(new System.Web.UI.WebControls.ListItem(ad, id));

                    }
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
        protected void GetBoardType()
        {
            try
            {
                string query = "SELECT * FROM [BoardTypes]";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];

                        string id = dr["BoardId"].ToString();
                        string ad = dr["BoardType"].ToString();

                        dropBoard.Items.Add(new System.Web.UI.WebControls.ListItem(ad, id));
                        dropBoardUpgrade.Items.Add(new System.Web.UI.WebControls.ListItem(ad, id));

                    }
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

      

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {

                var query = "DECLARE @new_identity INT;";
                query += " EXEC dbo.AddAction ";//TYPE = 1 OPENSALE TYPE=2 STOPSALE
                query += "@ActionType		 = " + dropActionType.SelectedValue + ", ";
                query += "@BeginDate		 = '" + txtActionBeginDate.Text + "', ";
                query += "@EndDate			 = '" + txtActionEndDate.Text + "',";
                query += "@CheckIn			 = '" + txtCheckInDate.Text + "', ";
                query += "@CheckOut			 = '" + txtCheckOutDate.Text + "',";
                query += "@DiscountRate		 = '" + txtDiscountRate.Text + "', ";
                query += "@Release			 = '" + txtRelease.Text + "', ";
                query += "@Age				 = '" + dropChild.SelectedItem.Text + "', ";
                query += "@Room				 = '" + dropRoom.SelectedItem.Text + "', ";
                query += "@RoomUpgrade		 = '" + dropRoomUprage.SelectedItem.Text + "', ";
                query += "@Board			 = '" + dropBoard.SelectedItem.Text + "', ";
                query += "@BoardUpgrade		 = '" + dropBoardUpgrade.SelectedItem.Text + "', ";
                query += "@AgeRange			 = '" + txtAge.Text + "', ";
                query += "@PromotionRequest  = '" + txtPromotionRequest.Text + "', ";
                query += "@Status  = 0, ";
                query += "@UserId = " + Convert.ToInt32(Session["UserId"].ToString()) + ", ";
                query += "@new_identity = @new_identity OUTPUT;";
                query += " SELECT @new_identity; ";


                string ActionId = "";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    ActionId = dr["Column1"].ToString();
                }

                dropChild.SelectedIndex = -1;
                dropRoom.SelectedIndex = -1;
                dropRoomUprage.SelectedIndex = -1;
                dropBoard.SelectedIndex = -1;
                dropBoardUpgrade.SelectedIndex = -1;
                txtAge.Text = "";
                txtRelease.Text = "";
                txtDiscountRate.Text = "";
                txtPromotionRequest.Text = "";
                txtActionBeginDate.Text = "";
                txtActionEndDate.Text = "";
                txtCheckInDate.Text = "";
                txtCheckOutDate.Text = "";
                TarihIslemleri();
                lblIslemSonuc.Text = "İşlem Başarılı.";
                lblIslemSonuc.CssClass = "islemBasarili";
                lblIslemSonuc.Visible = true;
                MailInformation(ActionId);

            }
            catch (Exception exp)
            {
                lblIslemSonuc.Text = "Hata : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }
            DataLists();
        }


        protected void MailInformation(string ActionId)
        {
            string mailIcerik = "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
            mailIcerik += "<head>";
            mailIcerik += "</head>";
            mailIcerik += "<body>";
            mailIcerik += "<div>";
            mailIcerik += "<span style=\"width:100%; border-top: 1px dotted #378b1a;   border-bottom: 1px dotted #378b1a;   background-color: #effee9;  line-height: 20px;  padding: 10px; font-size: 18px; text-shadow: #fff 1px 1px 1px;   color: #378b1a;  display: block;  margin-bottom: 14px;\">Actions Information!</span>";

            mailIcerik += "<br />";
            mailIcerik += "<table style=\"background-color: #fff; width: 100%; border-radius: 2px; border-spacing: 0;\">";
            mailIcerik += "<tr style=\"line-height: 26px;\">";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">Action Type</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 10%; text-align: center;\">Action Date</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">Begin Date</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">End Date</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">Check In</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">Check Out</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">Promotion Request</th>";
            mailIcerik += "</tr>";
            try
            {

                string query = " SELECT ActionType.ActionType AS ActionTypeName,* FROM Actions Actions LEFT JOIN ActionType ActionType ON Actions.ActionType=ActionType.ActionId ";
                query += " WHERE Actions.ActionId='" + ActionId + "'";

                DataTable dtSepetIcerik = command.ReturnTableWithParameters(query, null, "Table");

                for (int i = 0; i < dtSepetIcerik.Rows.Count; i++)
                {
                    DataRow drIcerik = dtSepetIcerik.Rows[i];

                    string ActionTypeName = drIcerik["ActionTypeName"].ToString();
                    string ActionDate = drIcerik["ActionDate"].ToString();
                    string BeginDate = drIcerik["BeginDate"].ToString();
                    string EndDate = drIcerik["EndDate"].ToString();
                    string CheckIn = drIcerik["CheckIn"].ToString();
                    string CheckOut = drIcerik["CheckOut"].ToString();
                    string PromotionRequest = drIcerik["PromotionRequest"].ToString();
                    mailIcerik += "<tr style=\"line-height: 26px;\">";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: left;\">" + ActionTypeName + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: left;\">" + ActionDate + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + BeginDate + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + EndDate + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + CheckIn + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + CheckOut + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + PromotionRequest + "</td>";
                    mailIcerik += "</tr>";
                }
            }
            catch (Exception exp)
            {

                lblIslemSonuc.Text = "Hata : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }


            mailIcerik += "</table>";
            mailIcerik += "<br /><br />";
            mailIcerik += "Bilgilerin işleme alınması 24 saati bulmaktadır.  /    It takes 24 hours for the information to be processed.";
            mailIcerik += "<br /><br />";
            mailIcerik += "</div>";
            mailIcerik += "</body></html>";
            SendReminderMail(mailIcerik);
        }


        protected void SendReminderMail(string mailIcerik)
        {
            //string[] aliciMailAdresleri = { "mehmet-ck@outlook.com" };
            string mail = Session["HotelEmail"].ToString();
            mail += ";" + "product@primetravel.com.tr";
            //string aliciMailAdresi = aliciMailAdresleri[i].ToString();
            string sonuc = MailGonder.SendOutlookMail("Prime Travel Action Information", mailIcerik, mail);

            if (sonuc == "OK")
            {
                lblIslemSonuc.Text = "İşlem Başarılı";
                lblIslemSonuc.CssClass = "islemBasarili";
                lblIslemSonuc.Visible = true;
            }
            else
            {

            }

        }

        protected void DataLists()
        {
            try
            {
                string query = " SELECT ActionType.ActionType AS ActionTypeName,* FROM Actions Actions LEFT JOIN ActionType ActionType ON Actions.ActionType=ActionType.ActionId ";
                query += " WHERE UserId=" + Session["UserId"] + "  ORDER BY ActionDate DESC ";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    lvActionList.DataSource = dt;
                    lvActionList.DataBind();
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

        protected void lvOpenSaleList_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void dropActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (dropActionType.SelectedValue)
            {
                case "1"://% SPO - EBD
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelAge.Visible = false;
                    panelRoom.Visible = false;
                    panelFreeRoom.Visible = false;
                    panelFreeBoard.Visible = false;
                    panelBoard.Visible = false;
                    panelAgeRange.Visible = false;
                    break;
                case "2"://Rate SPO
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelAge.Visible = false;
                    panelRoom.Visible = true;
                    panelFreeRoom.Visible = false;
                    panelFreeBoard.Visible = false;
                    panelBoard.Visible = false;
                    panelAgeRange.Visible = false;
                    break;
                case "3"://Minimum Stay
                    panelDiscount.Visible = true;
                    panelRelease.Visible = false;
                    panelAge.Visible = false;
                    panelRoom.Visible = false;
                    panelFreeRoom.Visible = false;
                    panelFreeBoard.Visible = false;
                    panelBoard.Visible = false;
                    panelAgeRange.Visible = false;
                    break;
                case "4":// Day Promotion
                    panelDiscount.Visible = false;
                    panelRelease.Visible = true;
                    panelAge.Visible = false;
                    panelRoom.Visible = false;
                    panelFreeRoom.Visible = false;
                    panelFreeBoard.Visible = false;
                    panelBoard.Visible = false;
                    panelAgeRange.Visible = false;
                    break;
                case "5"://Free Room Upgrade
                    panelDiscount.Visible = false;
                    panelRelease.Visible = true;
                    panelAge.Visible = false;
                    panelRoom.Visible = true;
                    panelFreeRoom.Visible = true;
                    panelFreeBoard.Visible = false;
                    panelBoard.Visible = false;
                    panelAgeRange.Visible = false;
                    break;
                case "6"://Deal Of Week
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelAge.Visible = false;
                    panelRoom.Visible = false;
                    panelFreeRoom.Visible = false;
                    panelFreeBoard.Visible = false;
                    panelBoard.Visible = false;
                    panelAgeRange.Visible = false;
                    break;
                case "7"://Deal Of Weekend
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelAge.Visible = false;
                    panelRoom.Visible = false;
                    panelFreeRoom.Visible = false;
                    panelFreeBoard.Visible = false;
                    panelBoard.Visible = false;
                    panelAgeRange.Visible = false;
                    break;
                case "8"://Free Board Upgrade
                    panelDiscount.Visible = false;
                    panelRelease.Visible = true;
                    panelAge.Visible = false;
                    panelRoom.Visible = false;
                    panelFreeRoom.Visible = false;
                    panelFreeBoard.Visible = true;
                    panelBoard.Visible = true;
                    panelAgeRange.Visible = false;
                    break;
                case "9"://Senior Reduction
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelAge.Visible = false;
                    panelRoom.Visible = false;
                    panelFreeRoom.Visible = false;
                    panelFreeBoard.Visible = false;
                    panelBoard.Visible = false;
                    panelAgeRange.Visible = true;
                    break;
                case "10"://Free Child
                    panelDiscount.Visible = false;
                    panelRelease.Visible = true;
                    panelAge.Visible = true;
                    panelRoom.Visible = false;
                    panelFreeRoom.Visible = false;
                    panelFreeBoard.Visible = false;
                    panelBoard.Visible = false;
                    panelAgeRange.Visible = false;
                    break;
                case "11"://Rolling EB
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelAge.Visible = false;
                    panelRoom.Visible = false;
                    panelFreeRoom.Visible = false;
                    panelFreeBoard.Visible = false;
                    panelBoard.Visible = false;
                    panelAgeRange.Visible = false;
                    break;
                case "12"://Opaque Discount
                    panelDiscount.Visible = true;
                    panelRelease.Visible = true;
                    panelAge.Visible = false;
                    panelRoom.Visible = false;
                    panelFreeRoom.Visible = false;
                    panelFreeBoard.Visible = false;
                    panelBoard.Visible = false;
                    panelAgeRange.Visible = false;
                    break;
                default:
                    break;
            }
        }
    }
}