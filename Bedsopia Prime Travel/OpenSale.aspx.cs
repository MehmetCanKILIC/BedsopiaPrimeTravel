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
    public partial class OpenSale : System.Web.UI.Page
    {
        Command command = new Command();
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=APLICATION;initial Catalog=BPT;Integrated Security=True;");
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
                    GetNationality("");
                    TarihIslemleri();
                    DataLists();
                    FirstListViewRow();
                    GetNationalityArea();
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
                //sqlCon.Open();
                string query = "SELECT * FROM [RoomTypes]  WHERE HotelName='" + Session["HotelName"].ToString() + "'";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];

                        string id = dr["RoomId"].ToString();
                        string ad = dr["RoomType"].ToString();

                        dropRoom.Items.Add(new System.Web.UI.WebControls.ListItem(ad, id));

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

        protected void GetNationality(string Area)
        {
            try
            {
                dropNationality.Items.Clear();
                //sqlCon.Open();
                string query = "SELECT * FROM [Nationality]";
                if (Area != "" && Area != "1")
                {
                    query += " WHERE Area='" + Area + "'";
                }
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");
                dropNationality.Items.Add(new System.Web.UI.WebControls.ListItem("All", "500"));

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];

                        string id = dr["NationalityId"].ToString();
                        string ad = dr["Nationality"].ToString();

                        dropNationality.Items.Add(new System.Web.UI.WebControls.ListItem(ad, id));

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

        protected void GetNationalityArea()
        {
            try
            {
                //sqlCon.Open();
                string query = "SELECT * FROM [NationalityArea]";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];

                        string id = dr["Logicalref"].ToString();
                        string ad = dr["Area"].ToString();

                        dropNationalityArea.Items.Add(new System.Web.UI.WebControls.ListItem(ad, id));

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

                string rooms = "";
                string Boards = "";
                string Nationalitys = "";
                foreach (ListItem item in dropRoom.Items)
                {
                    if (item.Selected)
                    {
                        rooms += item.Text + ",";
                    }
                }
                foreach (ListItem item in dropBoard.Items)
                {
                    if (item.Selected)
                    {
                        Boards += item.Text + ",";
                    }
                }
                foreach (ListItem item in dropNationality.Items)
                {
                    if (item.Selected)
                    {
                        Nationalitys += item.Text + ",";
                    }
                }

                var query = "DECLARE @new_identity INT;";
                query += " EXEC dbo.AddAsset @Type = 1, ";//TYPE = 1 OPENSALE TYPE=2 STOPSALE
                query += "@RoomId = '" + rooms + "', ";
                query += "@BoardId = '" + Boards + "', ";
                query += "@NationalityId = '" + Nationalitys + "', ";
                query += "@UserId = " + Convert.ToInt32(Session["UserId"]) + ", ";
                query += "@Status = 0, ";
                query += "@Note = '" + txtSalesNote.Text + "', ";
                query += "@new_identity = @new_identity OUTPUT;";
                query += " SELECT @new_identity; ";


                string SaleId = "";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    SaleId = dr["Column1"].ToString();
                    foreach (ListViewDataItem item in listview1.Items)
                    {
                        var txtCheckIn = item.FindControl("txtCheckIn") as TextBox;
                        var txtCheckOut = item.FindControl("txtCheckOut") as TextBox;
                        var sql = "INSERT INTO SalesDate(SalesId,BeginDate,EndDate)";
                        sql += "VALUES(";
                        sql += "'" + dr["Column1"].ToString() + "',";
                        sql += "CONVERT(varchar(10), CONVERT(date,'" + txtCheckIn.Text + "', 103), 120),";
                        sql += "CONVERT(varchar(10), CONVERT(date,'" + txtCheckOut.Text + "', 103), 120)";
                        sql += ")";

                        DataTable dts = command.ReturnTableWithParameters(sql, null, "Table");
                        lblIslemSonuc.Text = "İşlem Başarılı.";
                        lblIslemSonuc.CssClass = "islemBasarili";
                        lblIslemSonuc.Visible = true;

                    }
                }
                lblIslemSonuc.Text = "İşlem Başarılı.";
                lblIslemSonuc.CssClass = "islemBasarili";
                lblIslemSonuc.Visible = true;

                dropRoom.SelectedIndex = -1;
                dropNationality.SelectedIndex = -1;
                dropBoard.SelectedIndex = -1;
                txtSalesNote.Text = "";
                listview1.DataSource = null;
                listview1.DataBind();
                FirstListViewRow();
                TarihIslemleri();
                lblIslemSonuc.Text = "İşlem Başarılı.";
                lblIslemSonuc.CssClass = "islemBasarili";
                lblIslemSonuc.Visible = true;
                MailInformation(SaleId);
            }
            catch (Exception exp)
            {
                lblIslemSonuc.Text = "Hata : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }


            DataLists();
        }


        protected void MailInformation(string saleId)
        {
            string mailIcerik = "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
            mailIcerik += "<head>";
            mailIcerik += "</head>";
            mailIcerik += "<body>";
            mailIcerik += "<div>";
            mailIcerik += "<span style=\"width:100%; border-top: 1px dotted #378b1a;   border-bottom: 1px dotted #378b1a;   background-color: #effee9;  line-height: 20px;  padding: 10px; font-size: 18px; text-shadow: #fff 1px 1px 1px;   color: #378b1a;  display: block;  margin-bottom: 14px;\">Open/Stop Sale Information!</span>";
            mailIcerik += "<br />";
            mailIcerik += "<table style=\"background-color: #fff; width: 100%; border-radius: 2px; border-spacing: 0;\">";
            mailIcerik += "<tr style=\"line-height: 26px;\">";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: left;\">Sale Date</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 10%; text-align: left;\">Sale Type</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">Room Type</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">Board Type</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">Nationality</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">Begin Date</th>";
            mailIcerik += "<th style=\"line-height: 30px; background-color:#ddd; width: 15%; text-align: center;\">End Date</th>";
            mailIcerik += "</tr>";
            try
            {

                string query = "  SELECT SALE.Date as SaleDate,CASE WHEN SALE.Type='1' THEN 'Open Sale' WHEN SALE.Type='2' THEN 'Stop Sale' END AS Types,SALE.RoomId,SALE.BoardId,SALE.NationalityId,SALEDATE.BeginDate,SALEDATE.EndDate FROM BPT.dbo.Sales SALE LEFT JOIN  BPT.dbo.SalesDate SALEDATE ON SALE.SaleId=SALEDATE.SalesId ";
                query += " WHERE SALE.SaleId='" + saleId + "'";

                DataTable dtSepetIcerik = command.ReturnTableWithParameters(query, null, "Table");

                for (int i = 0; i < dtSepetIcerik.Rows.Count; i++)
                {
                    DataRow drIcerik = dtSepetIcerik.Rows[i];

                    string SaleDate = drIcerik["SaleDate"].ToString();
                    string Types = drIcerik["Types"].ToString();
                    string RoomId = drIcerik["RoomId"].ToString();
                    string BoardId = drIcerik["BoardId"].ToString();
                    string NationalityId = drIcerik["NationalityId"].ToString();
                    string BeginDate = drIcerik["BeginDate"].ToString();
                    string EndDate = drIcerik["EndDate"].ToString();
                    mailIcerik += "<tr style=\"line-height: 26px;\">";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: left;\">" + SaleDate + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: left;\">" + Types + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + RoomId + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + BoardId + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + NationalityId + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + BeginDate + "</td>";
                    mailIcerik += "<td style=\"border-bottom:1px solid #ddd; text-align: center;\">" + EndDate + "</td>";
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
            mail += ";" + "reservations@primetravel.com.tr";
            //string aliciMailAdresi = aliciMailAdresleri[i].ToString();
            string sonuc = MailGonder.SendOutlookMail("Prime Travel Open/Stop Sale Information", mailIcerik, mail);
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
                string query = "  SELECT TOP 1 sale.SaleId,users.HotelName,SalesDate.BeginDate,SalesDate.EndDate,(SELECT COUNT(*) FROM SalesDate WHERE SalesId=Sale.SaleId) as SalesDateCount,Sale.Date,Sale.NationalityId,sale.Status FROM Sales Sale";
                query += "  ";
                query += " LEFT JOIN[Users] users on users.UserId = Sale.UserId  LEFT  JOIN SalesDate SalesDate On SalesDate.SalesId=Sale.SaleId  WHERE sale.UserId=" + Session["UserId"] + "  AND sale.Type=1 ORDER BY sale.SaleId DESC ";

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

        protected void lvOpenSaleList_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();

        }


        private void FirstListViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("CheckIn", typeof(string)));
            dt.Columns.Add(new DataColumn("CheckOut", typeof(string)));

            dr = dt.NewRow();

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;


            listview1.DataSource = dt;
            listview1.DataBind();

        }

        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox txtCheckIn = (TextBox)listview1.Items[rowIndex].FindControl("txtCheckIn");
                        TextBox txtCheckOut = (TextBox)listview1.Items[rowIndex].FindControl("txtCheckOut");

                        drCurrentRow = dtCurrentTable.NewRow();

                        dtCurrentTable.Rows[i - 1]["CheckIn"] = txtCheckIn.Text;
                        dtCurrentTable.Rows[i - 1]["CheckOut"] = txtCheckOut.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    listview1.DataSource = dtCurrentTable;
                    listview1.DataBind();

                    TextBox txn = (TextBox)listview1.Items[rowIndex].FindControl("txtCheckIn");
                    txn.Focus();
                    // txn.Focus;
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
        }

        protected void dropNationalityArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNationality(dropNationalityArea.SelectedValue.ToString());
        }
    }
}