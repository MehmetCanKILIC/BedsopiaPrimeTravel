using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bedsopia_Prime_Travel
{
    public partial class Users : System.Web.UI.Page
    {

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
                    UserList();
                }
            }
        }

        protected void UserList()
        {
            try
            {
                string query = "  SELECT Users.UserId,Users.Username,Users.HotelName,Users.Email,UserType.UserType FROM [Users] Users LEFT JOIN UserType UserType ON Users.UserType=UserType.UserTypeId WHERE Status='1' AND Users.UserType!='1' Order BY UserId DESC";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    lvUserList.DataSource = dt;
                    Session["DTKAYIT"] = dt;
                    lvUserList.DataBind();
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

        protected void lvUserList_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void linkSil_Command(object sender, CommandEventArgs e)
        {
            string secilenId = e.CommandArgument.ToString();
            KayitSil(secilenId);
        }

        protected void KayitSil(string silinecekId)
        {
            try
            {
                string sql = @"UPDATE [Users] SET Status='0' WHERE UserId='" + silinecekId + "'";

                DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");

                UserList();
            }
            catch (Exception ex)
            {
                lblIslemSonuc.Text = ex.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }
        }


        protected void UserListFilter()
        {
            try
            {
                string query = "  SELECT Users.UserId,Users.Username,Users.HotelName,Users.Email,UserType.UserType FROM [Users] Users LEFT JOIN UserType UserType ON Users.UserType=UserType.UserTypeId WHERE Status='1' AND Users.UserType!='1' ";
                if (txtEmail.Text != "")
                {
                    query += " AND Email LIKE '%" + txtEmail.Text + "%'";
                }
                if (txtHotelname.Text != "")
                {
                    query += " AND HotelName LIKE '%" + txtHotelname.Text + "%'";
                }
                query += " ORDER BY UserId DESC ";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    lvUserList.DataSource = dt;
                    Session["DTKAYIT"] = dt;
                    lvUserList.DataBind();
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
            UserListFilter();
        }

        protected void linkExcel_Click(object sender, EventArgs e)
        {
            DataTable dtKayitlar = (DataTable)Session["DTKAYIT"];
            ExcelOlustur(dtKayitlar);
        }

        protected void ExcelOlustur(DataTable dtKayitlar)
        {
            try
            {
                List<String> sutunListe = new List<string>();//sütun listesini tut                

                string dosyaAd = "Bedsopia_Users";

                this.EnableViewState = false;
                Response.Clear();
                Response.Charset = "utf-8";
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "inline;filename=" + dosyaAd + ".xls");
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

                StringBuilder sbIcerik = new StringBuilder();

                sbIcerik.Append("<table>" + "<tr>");

                for (int i = 0; i < dtKayitlar.Columns.Count; i++)
                {
                    DataColumn dc = dtKayitlar.Columns[i];

                    string sutunAd = dc.ColumnName;

                    sutunListe.Add(sutunAd);
                    sbIcerik.Append("<td>" + sutunAd + "</td>");

                }

                sbIcerik.AppendLine("</tr>");

                for (int i = 0; i < dtKayitlar.Rows.Count; i++)
                {
                    sbIcerik.Append("<tr>");

                    DataRow dr = dtKayitlar.Rows[i];

                    for (int j = 0; j < sutunListe.Count; j++)
                    {
                        string sutunAd = sutunListe[j];

                        string satirIcerigi = dr[sutunAd].ToString();
                        sbIcerik.Append("<td>" + satirIcerigi + "</td>");

                    }

                    sbIcerik.Append("</tr>");
                }

                sbIcerik.Append("</table>");

                Response.Write(sbIcerik);
                Response.End();
                Response.Flush();
            }
            catch (Exception ex)
            {
                lblIslemSonuc.Text = ex.Message;
                lblIslemSonuc.CssClass = "islemHatali";
            }
        }
    }
}