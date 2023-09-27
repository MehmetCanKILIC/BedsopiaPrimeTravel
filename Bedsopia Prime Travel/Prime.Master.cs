using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bedsopia_Prime_Travel
{
    public partial class Prime : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] == null || Session["UserType"].ToString() == "")
            {
                Response.Redirect("Login.Aspx");
            }
            else
            {
                ltrLoginUser.Text = Session["HotelName"].ToString();

            }
        }
    }
}