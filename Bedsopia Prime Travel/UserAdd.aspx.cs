using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bedsopia_Prime_Travel
{
    public partial class UserAdd : System.Web.UI.Page
    {
        Command command = new Command();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserType"].ToString() == null || Session["UserType"].ToString() == "")
                {
                    Response.Redirect("Login.Aspx");
                }
                else
                {
                    UserTypeList();
                }
            }
        }

        protected void UserTypeList()
        {
            try
            {
                string query = "SELECT * FROM UserType WHERE UserTypeId!='1'";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];

                        string id = dr["UserTypeId"].ToString();
                        string ad = dr["UserType"].ToString();

                        dropUserType.Items.Add(new System.Web.UI.WebControls.ListItem(ad, id));

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

        public string MD5Olustur(string donusturulecekVeri)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(donusturulecekVeri));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        protected void UserInsert()
        {
            try
            {
                string sifre = "";

                sifre = MD5Olustur(txtPassword.Text);

                string sqlk = "SELECT * FROM [Users] WHERE Email LIKE '%" + txtEmail.Text + "%' AND Status='1'";
                sqlk += " ORDER BY UserId DESC";
                DataTable dts = command.ReturnTableWithParameters(sqlk, null, "Table");

                if (dts.Rows.Count > 1)
                {
                    lblIslemSonuc.Text = "Bu eposta adresi kullanılmaktadır. Lütfen farklı bir eposta adresi giriniz!";
                    lblIslemSonuc.CssClass = "islemHatali";
                    lblIslemSonuc.Visible = true;
                }
                else
                {
                    string sql = @"INSERT INTO [Users] (Username,Password,HotelName,Email,Status,UserType) VALUES(";
                    sql += "'" + txtUsername.Text + "',";
                    sql += "'" + sifre + "',";
                    sql += "'" + txtHotelName.Text + "',";
                    sql += "'" + txtEmail.Text + "',";
                    sql += "'1',";
                    if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2")
                    {
                        sql += "'" + dropUserType.SelectedValue + "'";

                    }
                    else
                    {
                        sql += "'3'";
                    }
                    sql += ")";
                    DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");
                    lblIslemSonuc.Text = "Kullanıcı başarılı bir şekilde güncellendi.";
                    lblIslemSonuc.CssClass = "islemBasarili";
                    lblIslemSonuc.Visible = true;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);

                }
            }
            catch (Exception ex)
            {
                lblIslemSonuc.Text = ex.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserInsert();
        }
    }
}