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
    public partial class BoardTypes : System.Web.UI.Page
    {
        Command command = new Command();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataLists();
        }

        protected void DataLists()
        {
            try
            {
                string query = "  SELECT * FROM BPT..BoardTypes";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    lvBoardTypes.DataSource = dt;
                    lvBoardTypes.DataBind();
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
        protected void lvBoardTypes_PagePropertiesChanged(object sender, EventArgs e)
        {

        }
    }
}