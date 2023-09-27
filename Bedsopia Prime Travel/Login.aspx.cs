using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bedsopia_Prime_Travel
{
    public partial class Login : System.Web.UI.Page
    {

        Command command = new Command();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KriptoOlustur();

            }
        }


        public static string MD5Sifrele(string sifrelenecekVeri)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] b1 = System.Text.Encoding.UTF8.GetBytes(sifrelenecekVeri);

            byte[] hash = md5.ComputeHash(b1);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        protected void KriptoOlustur()
        {
            string gun = DateTime.Now.Day.ToString();
            string ay = DateTime.Now.Month.ToString();
            string yil = DateTime.Now.Year.ToString();

            if (gun.Length < 2)
            {
                gun = "0" + gun;
            }

            if (ay.Length < 2)
            {
                ay = "0" + ay;
            }

            string gununTarihi = gun + "." + ay + "." + yil;

            string kripto = MD5Sifrele(gununTarihi);
            Session["KRIPTO"] = kripto;
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {

            try
            {
                string sifre = Server.HtmlEncode(txtSifre.Text);

                string sifreMD5 = MD5Sifrele(sifre);
                string SQL = "SELECT * FROM JP_PRIME..[JP_User] WHERE Username='" + txtKullaniciAd.Text + "' AND Password='" + sifreMD5 + "' AND Status='1'";
                DataTable dt = command.ReturnTableWithParameters(SQL, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    DataRow drIlk = dt.Rows[0];
                    Session["Login"] = "1";
                    Session["UserId"] = drIlk["UserId"].ToString();
                    Session["UserType"] = drIlk["UserType"].ToString();
                    Session["BedUser"] = drIlk["Username"].ToString();
                    Session["HotelName"] = drIlk["HotelName"].ToString();
                    Session["HotelEmail"] = drIlk["Email"].ToString();
                    Response.Redirect("Default.aspx",false);
                }
                else
                {
                    lblIslemSonuc.Text = "Hatalı kullanıcı adı veya şifre!";
                }

            }
            catch (Exception exp)
            {
                lblIslemSonuc.Text = "HATA -> " + exp.Message;
            }



        }
    }
}