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
    public partial class UserEdit : System.Web.UI.Page
    {
        Command command = new Command();
        static string kayitliSifre;
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
                    string UserId = Request.QueryString["UserId"];
                    UserList(UserId);
                }
            }
        }

        protected void UserList(string userId)
        {
            try
            {
                string query = "SELECT * FROM [Users] WHERE UserId='" + userId + "'";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    DataRow drIlk = dt.Rows[0];
                    txtHotelName.Text = drIlk["HotelName"].ToString();
                    txtEmail.Text = drIlk["Email"].ToString();
                    kayitliSifre = drIlk["Password"].ToString();
                    txtPassword.Text = "*********";

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

        protected void UserUpdate(string UserId)
        {
            try
            {
                string sifre = "";
                if (txtPassword.Text != "********")
                {
                    sifre = MD5Olustur(txtPassword.Text);
                }
                else
                {
                    sifre = kayitliSifre;
                }
                //string sqlk = "SELECT * FROM [Users] WHERE Email LIKE '%" + txtEmail.Text + "%' AND Status='1'";
                //sqlk += " ORDER BY UserId DESC";
                //DataTable dts = command.ReturnTableWithParameters(sqlk, null, "Table");

                //if (dts.Rows.Count > 1)
                //{
                //    lblIslemSonuc.Text = "Bu eposta adresi kullanılmaktadır. Lütfen farklı bir eposta adresi giriniz!";
                //    lblIslemSonuc.CssClass = "islemHatali";
                //    lblIslemSonuc.Visible = true;
                //}
                //else
                //{
                    string sql = @"UPDATE [Users] SET Password='" + sifre + "'";
                    sql += ",HotelName='" + txtHotelName.Text + "',Email='" + txtEmail.Text + "'";
                    sql += " WHERE UserId='" + UserId + "'";
                    DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");
                    UserList(UserId);
                    lblIslemSonuc.Text = "Kullanıcı başarılı bir şekilde güncellendi.";
                    lblIslemSonuc.CssClass = "islemBasarili";
                    lblIslemSonuc.Visible = true;
                //}
            }
            catch (Exception ex)
            {
                lblIslemSonuc.Text = ex.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string UserId = Request.QueryString["UserId"];
            UserUpdate(UserId);
        }
    }
}