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
    public partial class RoomTypeAdd : System.Web.UI.Page
    {
        Command command = new Command();
        public string HotelName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            HotelName = Request.QueryString["HotelName"];

            if (!IsPostBack)
            {
                if (Session["UserType"].ToString() == null || Session["UserType"].ToString() == "")
                {
                    Response.Redirect("Login.Aspx");
                }
                else
                {
                    DataList(HotelName);
                }
            }
        }

        protected void DataList(string HotelName)
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                string query = @"SELECT * FROM RoomTypes WHERE HotelName=@HotelName";
                sqlcmd.Parameters.AddWithValue("@HotelName", HotelName);
                SqlParameter sqlParameter = new SqlParameter("@HotelName", HotelName);
                //string query = "  SELECT * FROM RoomTypes WHERE HotelName='"+HotelName+"'";

                DataTable dt = command.ReturnDTableWithParameters(query.ToString(), sqlParameter, "Table");

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

        protected void btnRoomsAdd_Click(object sender, EventArgs e)
        {

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "INSERT INTO  RoomTypes ( ";
            sqlcmd.CommandText += " HotelName ,RoomType ,RoomCode,InsertDate)VALUES(@HotelName,@RoomType,@RoomCode,@InsertDate)";
          

            sqlcmd.Parameters.AddWithValue("@RoomType", txtRooms.Text);
            sqlcmd.Parameters.AddWithValue("@RoomCode", txtRoomsCode.Text);
            sqlcmd.Parameters.AddWithValue("@HotelName", HotelName);
            sqlcmd.Parameters.AddWithValue("@InsertDate", DateTime.Now);
            try
            {
                command.ExecuteScalar(sqlcmd);
                DataList(HotelName);
            }
            catch (Exception exp)
            {

                lblIslemSonuc.Text = "HATA : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }
        }


        protected void btnRoomDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string query = "  DELETE FROM RoomTypes WHERE RoomId='" + e.CommandArgument.ToString()+"'";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                DataList(HotelName);


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

        }
    }
}