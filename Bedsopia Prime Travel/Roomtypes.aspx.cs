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
    public partial class Roomtypes : System.Web.UI.Page
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

                    DataLists();
                }
            }
        }

        protected void DataLists()
        {
            try
            {
                string query = "  SELECT DISTINCT(HotelName) FROM Users WHERE UserType=3";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    lvRoomTypes.DataSource = dt;
                    lvRoomTypes.DataBind();
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

        protected void lvRoomTypes_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void btnFiltre_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "  SELECT DISTINCT(HotelName) FROM Users WHERE UserType=3 AND HotelName LIKE '%"+txtRoomTypeFilter.Text+"%'";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    lvRoomTypes.DataSource = dt;
                    lvRoomTypes.DataBind();
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