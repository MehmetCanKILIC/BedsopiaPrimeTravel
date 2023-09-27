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
    public partial class ProductGroup : System.Web.UI.Page
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
                    DataList();
                }
            }
        }

        protected void DataList()
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                string query = @"SELECT * FROM ProductGroupJuniper ";

                DataTable dt = command.ReturnTableWithParameters(query.ToString(), null, "Table");

                if (dt.Rows.Count > 0)
                {
                    lvProductGroupNameList.DataSource = dt;
                    lvProductGroupNameList.DataBind();
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

  


    

        protected void lvProductGroupNameList_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }

        protected void btnProductDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string query = "  DELETE FROM ProductGroupJuniper WHERE Logicalref='" + e.CommandArgument.ToString() + "'";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                DataList();


            }
            catch (Exception exp)
            {
                lblIslemSonuc.Text = "Hata : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;

            }
        }

        protected void btnProductAdd_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "INSERT INTO  ProductGroupJuniper ( ";
            sqlcmd.CommandText += " ProductGroupName,UserId,InsertDate )VALUES(@ProductGroupName,@UserId,@InsertDate)";


            sqlcmd.Parameters.AddWithValue("@ProductGroupName", txtProductGroupName.Text);
            sqlcmd.Parameters.AddWithValue("@UserId", Session["UserId"].ToString());
            sqlcmd.Parameters.AddWithValue("@InsertDate", DateTime.Now);
            try
            {
                command.ExecuteScalar(sqlcmd);
                DataList();
            }
            catch (Exception exp)
            {

                lblIslemSonuc.Text = "HATA : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }
        }
    }
}