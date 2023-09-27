using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bedsopia_Prime_Travel
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserType"]=="" || Session["UserType"] ==  null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            BilgiDoldur();
        }

        protected void BilgiDoldur()
        {
            try
            {
                //lblUser.Text = Session["BedUser"].ToString();
                //lblUserLeftMenu.Text = Session["BedUser"].ToString();
            }
            catch (Exception)
            {
                Response.Redirect("Login.aspx");
            }
        
        }
    }
}