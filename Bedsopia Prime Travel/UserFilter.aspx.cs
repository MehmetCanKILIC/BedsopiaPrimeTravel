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
    public partial class UserFilter : System.Web.UI.Page
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
                    string UserId = Request.QueryString["UserId"];
                    FilterDetay(UserId);
                    HotelReservationList(UserId);
                }
            }

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string UserId = Request.QueryString["UserId"];
            FilterAdd(UserId);
        }

        protected void FilterDetay(string UserId)
        {
            try
            {
                string query = " SELECT Users.HotelName,Users.UserId,Filter.FilterId,(CASE";
                query += " WHEN Filter.FilterType = '0' THEN 'Day Filter'";
                query += " WHEN Filter.FilterType = '1' THEN 'VisibleTitles Filter'";
                query += " WHEN Filter.FilterType = '2' THEN 'Date Filter'";
                query += " ELSE ''";
                query += " END ) AS FilterType,(CASE";
                query += " WHEN Filter.FilterType = '0' THEN 'Check In '+CONVERT(VarchaR,Filter.CheckInDay)+' Day' + ' - ' +  'Check Out '+Convert(varchar,Filter.CheckOutDay)+' Day'";
                query += " WHEN Filter.FilterType = '1' THEN Filter.VisibleTitles";
                query += " WHEN Filter.FilterType = '2' THEN  CONVERT(varchar,Filter.CheckIn,101) + ' - '+ CONVERT(varchar,Filter.CheckOut,101)";
                query += " ELSE ''";
                query += " END ) AS Filters, (CASE WHEN Filter.FilterStatus = '0' THEN 'Close'  WHEN Filter.FilterStatus = '1' THEN 'Open' ELSE ''";
                query += " END ) AS FilterStatus  FROM UserFilter Filter LEFT JOIN Users Users ON Users.UserId=Filter.UserId WHERE 1= 1 ";
                query += " AND Filter.UserId='" + UserId + "' ";

                query += " ORDER BY Filter.FilterDate DESC";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    ltrHotelBannerName.Text = dr["HotelName"].ToString();
                    ltrListHotelName.Text = dr["HotelName"].ToString();
                    lvHotelFilter.DataSource = dt;
                    lvHotelFilter.DataBind();
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

        protected void FilterAdd(string UserId)
        {
            try
            {
                DateTime guncelTarih = DateTime.Now;
                int ilkYil = guncelTarih.Year;
                int ilkAy = guncelTarih.Month;
                int ilkGun = guncelTarih.Day;
                string varsayilanIlkTarih = "";
                varsayilanIlkTarih = ilkGun + "." + ilkAy + "." + ilkYil;

                string VisibleTitle = "";
                foreach (ListItem item in dropTitles.Items)
                {
                    if (item.Selected)
                    {
                        VisibleTitle += item.Text + ",";
                    }
                }
                string query = " INSERT INTO UserFilter(UserId,FilterType,CheckIn,CheckOut,FilterDate,CheckInDay,CheckOutDay,VisibleTitles,FilterNote,FilterStatus)VALUES( ";
                query += "'" + UserId + "',";
                query += "'" + dropFilterType.SelectedValue + "',";
                query += "CONVERT(varchar(10), CONVERT(date,'" + txtIlkTarih.Text + "', 103), 120),";
                query += "CONVERT(varchar(10), CONVERT(date,'" + txtSonTarih.Text + "', 103), 120),";
                query += "CONVERT(varchar(10), CONVERT(date,'" + varsayilanIlkTarih + "', 103), 120),";
                query += "'" + dropCheckIn.SelectedValue + "',";
                query += "'" + dropCheckOut.SelectedValue + "',";
                query += "'" + VisibleTitle + "',";
                query += "'" + txtFilterNote.Text + "',";
                query += "'1'";
                query += ")";


                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");
                dt.Dispose();
                FilterDetay(UserId);

            }
            catch (Exception exp)
            {
                lblIslemSonuc.Text = "Hata : " + exp.Message;
                lblIslemSonuc.CssClass = "islemHatali";
                lblIslemSonuc.Visible = true;
            }
        }


        protected void HotelReservationList(string UserId)
        {
            try
            {
                string query = "  SELECT  Booking.BookingId AS [Voucher Number],(SELECT TOP 1 STATUS FROM Bookings WHERE BookingCode=Booking.BookingCode) as BookingConfirm,Booking.VisibleStatus,BookingDetail.HotelName AS [Hotel Name],BookingDetail.CheckIn as [Check In],BookingDetail.CheckOut as [Check Out],BookingDetail.HolderName + '  ' + BookingDetail.HolderLastName AS [Pessenger Name],'' AS Note,BookingDetail.HolderNacionalidad as [Nationality],Booking.Status,Booking.BookingDate,BookingDetail.AgencyGroupName as [Agency Name],Booking.BookingCode,'0' AS [Hotel Status] FROM BookingJuniper Booking ";
                query += " LEFT JOIN BookingDetailJuniper BookingDetail ON Booking.BookingCode=BookingDetail.VoucherNumber ";
                query += " WHERE (BookingDetail.ProductGroupName='Own Contracts' OR BookingDetail.ProductGroupName='Supplier Push' OR BookingDetail.ProductGroupName='CM-HR' OR BookingDetail.ProductGroupName='CM-HR0' OR  BookingDetail.ProductGroupName='Supplier Push0' OR " +
                    "BookingDetail.ProductTypeName='Own Contracts' OR BookingDetail.ProductTypeName='Supplier Push' OR BookingDetail.ProductTypeName='CM-HR' OR BookingDetail.ProductTypeName='CM-HR0' OR  BookingDetail.ProductTypeName='Supplier Push0')";

                query += " AND BookingDetail.HotelName=(SELECT HotelName FROM Users WHERE UserId='"+ UserId + "')";


                query += " ORDER BY Booking.BookingId DESC";
                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    lvHotelReservationList.DataSource = dt;
                    lvHotelReservationList.DataBind();
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

        protected void dropFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropFilterType.SelectedValue == "0")
            {
                panelFilterDay.Visible = true;
                panelFilterDate.Visible = false;
                panelFilterTitles.Visible = false;
            }
            else if (dropFilterType.SelectedValue == "1")
            {
                panelFilterDay.Visible = false;
                panelFilterDate.Visible = false;
                panelFilterTitles.Visible = true;
            }
            else if (dropFilterType.SelectedValue == "2")
            {
                panelFilterDay.Visible = false;
                panelFilterDate.Visible = true;
                panelFilterTitles.Visible = false;
            }
        }

        protected void linkSil_Command(object sender, CommandEventArgs e)
        {
            string secilenId = e.CommandArgument.ToString();
            FiltreSil(secilenId);
            string UserId = Request.QueryString["UserId"];
            FilterDetay(UserId);
        }

        protected void FiltreSil(string id)
        {
            try
            {

                string sql = "DELETE FROM  UserFilter  WHERE FilterId='" + id + "' ";

                DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");

            }
            catch (Exception ex)
            {
                lblIslemSonuc.Text = ex.Message;
            }
        }

        protected void cbDurum_CheckedChanged(object sender, EventArgs e)
        {
            var cbDurum = (CheckBox)sender;
            ListViewItem item = (ListViewItem)cbDurum.NamingContainer;
            HiddenField hfFilterId = (HiddenField)item.FindControl("hfFilterId");
            string id = hfFilterId.Value;

            string durum = "";

            if (cbDurum.Checked == true)
            {
                durum = "1";
            }
            else
            {
                durum = "0";
            }

            DurumDegistir(durum, id);
            
        }

        protected void DurumDegistir(string durum, string id)
        {
            try
            {

                string sql = "UPDATE UserFilter SET FilterStatus='" + durum + "' WHERE FilterId='" + id + "' ";

                DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");

            }
            catch (Exception ex)
            {
                lblIslemSonuc.Text = ex.Message;
            }
        }

        protected void lvHotelFilter_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {

                    string durum = DataBinder.Eval(e.Item.DataItem, "FilterStatus").ToString();
                    CheckBox cbDurum = (CheckBox)e.Item.FindControl("cbDurum");

                    if (durum == "Open")
                    {
                        cbDurum.Checked = true;
                    }
                    else
                    {
                        cbDurum.Checked = false;
                    }

                }
            }
            catch (Exception exp)
            {
                lblIslemSonuc.Text = exp.Message;
            }
        }
        protected void Visibility(string BookingCode)
        {
            try
            {

                string sql = "UPDATE BookingJuniper SET BedsopiaStatus='1' WHERE BookingCode='" + BookingCode + "' ";

                DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");

            }
            catch (Exception ex)
            {
                lblIslemSonuc.Text = ex.Message;
            }
        }

        protected void linkVisible_Command(object sender, CommandEventArgs e)
        {
            string BookingCode = e.CommandArgument.ToString();
            Visibility(BookingCode);
        }
    }
}