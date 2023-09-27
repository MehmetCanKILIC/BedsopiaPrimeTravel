using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL;

namespace Bedsopia_Prime_Travel
{
    public partial class InvoicePdf : System.Web.UI.Page
    {
        string pdfYolu = "/upload/pdf/";
        Command command = new Command();


        protected void Page_Load(object sender, EventArgs e)
        {
            string BookingCode = Request.QueryString["BookingCode"];
            getdtInvoice(BookingCode);
            Response.Redirect(pdfYolu + BookingCode + ".pdf");
        }


        protected void getdtInvoice(string BookingCode)
        {
            DataTable data = new DataTable();
            try
            {
                string sql = "SELECT	Booking.BookingCode as [Booking Code],";
                sql += " BookingDetail.HotelName,";
                sql += " Customer.CompanyName,";
                sql += " Customer.Address,";
                sql += " Customer.AccountRefNumber";
                sql += " ,Invoice.InvoiceNumber,";
                sql += " Invoice.InvoiceDate,";
                sql += " Invoice.DueDate,";
                sql += " (SELECT TOP 1 name + ' ' + LastName FROM BookingDetailLineJuniper WHERE BookingCode = Booking.BookingCode) as Holder";
                sql += " ,(SELECT Count(*) FROM BookingDetailLineJuniper WHERE BookingCode = Booking.BookingCode) as Pax";
                sql += " ,Convert(nvarchar, InvoiceDetailLine.BeginTravelDate, 103) + ' - ' + convert(nvarchar, InvoiceDetailLine.EndTravelDate, 103) as [Service Date]";
                sql += " ,BookingDetail.SellingPrice as Price";
                sql += " ,InvoiceDetailLine.Taxes as Taxes";
                sql += " ,BookingDetail.SellingPrice AS Total";
                sql += " ,Invoice.TotalBaseAmount as SUBTOTAL";
                sql += " ,Invoice.TotalCommissionTaxes As Taxes";
                sql += " ,Invoice.TotalNetAmount AS Total";
                sql += " ,Invoice.Currency AS Doviz";
                sql += " ,Booking.AgencyRef AS AgencyReference";
                sql += " FROM InvoiceJuniper Invoice";
                sql += " LEFT JOIN InvoiceDetailJuniper InvoiceDetail ON InvoiceDetail.IdInvoice = Invoice.IdInvoice";
                sql += " LEFT JOIN InvoiceDetailLineJuniper InvoiceDetailLine ON InvoiceDetailLine.IdInvoice = Invoice.IdInvoice";
                sql += " RIGHT JOIN BookingJuniper Booking ON Booking.BookingCode = InvoiceDetailLine.BookingCode";
                sql += " INNER JOIN BookingDetailJuniper BookingDetail ON Booking.BookingCode = BookingDetail.VoucherNumber";
                sql += " LEFT JOIN CustomerInvoicingDetailsJuniper Customer ON Customer.CustomerId = BookingDetail.CustomerId ";
                sql += " where BookingDetail.VoucherNumber  = '" + BookingCode + "'";
                DataTable dt = command.ReturnTableWithParameters(sql, null, "Table");
                string AgencyReference = "", Customer = "", CustomerAddress = "", CustomerRef = "", EmissionDate = "", DueDate = "", InvoiceNumber = "", subtotal = "", taxes = "", total = "", doviz = "";
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    AgencyReference = dr["AgencyReference"].ToString();
                    Customer = dr["CompanyName"].ToString();
                    CustomerAddress = dr["Address"].ToString();
                    CustomerRef = dr["AccountRefNumber"].ToString();
                    subtotal = dr["SUBTOTAL"].ToString();
                    InvoiceNumber = dr["InvoiceNumber"].ToString();
                    EmissionDate = dr["InvoiceDate"].ToString();
                    DueDate = dr["DueDate"].ToString();
                    taxes = dr["Taxes"].ToString();
                    total = dr["Total"].ToString();
                    doviz = dr["Doviz"].ToString();
                    PdfOlustur(InvoiceNumber, EmissionDate, DueDate, BookingCode, dt, AgencyReference, Customer, CustomerAddress, CustomerRef, subtotal, taxes, total, doviz);
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

        protected void PdfOlustur(string InvoiceNumber, string EmissionDate, string DueDate, string BookingCode, DataTable data, string AgencyReference, string Customer, string CustomerAddres, string CustomerRef, string subtotal, string taxes, string total, string doviz)
        {

            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        StringBuilder sb = new StringBuilder();
                        var path = Server.MapPath(@"~/Images/logo.jpeg");
                        sb.Append("<!DOCTYPE html><html xmlns = 'http://www.w3.org/1999/xhtml'><head><title></title></head> ");
                        sb.Append("<body  style='padding:50px;'>");
                        sb.Append("<table width='100%' height='500px'   cellspacing='0' cellpadding='2'>");
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append("<img src=\"");
                        sb.Append(path);
                        sb.Append("\" width =\"150\" height=\"50\" style='text-align:left;padding:5px;' />");
                        sb.Append("</td>");
                        sb.Append("<td style='text-align:right;padding:5px;font-size:9pt;'><b>Customer<br />");
                        sb.Append(Customer);
                        sb.Append("</b><br />");
                        sb.Append(CustomerAddres);
                        sb.Append("<br />");
                        sb.Append(CustomerRef);
                        sb.Append("</td ></tr>");
                        sb.Append("<tr><td colspan = '2'><b>Prime Travel Service</b><br />");
                        sb.Append("Sirinyali mah. 1539 sok Atahan Apt No:2 / 7 <br />");
                        sb.Append("Muratpaşa / Antalya , 7160 <br />");
                        sb.Append("Turkey , Turkey <br />");
                        sb.Append("<b>Phone.:</b> +902423394445 <br />");
                        sb.Append("<b>Tax Registration No.:</b> 7330437711 <br />");
                        sb.Append("</td></tr>");


                        sb.Append("</table>");
                        sb.Append("<br />");
                        sb.Append("<table width='100%' height='50px' style='margin: 15px 15px 15px 15px;'>");
                        if (InvoiceNumber == "")
                        {
                            sb.Append("<tr bgcolor='#EFEBE9'><td colspan='2'><b>Proforma invoice</b></td></tr>");
                            sb.Append("<tr><td>Booking Code</td><td style='font-size:9pt;'><b>");
                            sb.Append(BookingCode);
                            sb.Append("</b></td></tr>");
                            sb.Append("<tr><td>Agency Booking Reference</td><td style='font-size:9pt;'><b>");
                            sb.Append(AgencyReference);
                            sb.Append("</b></td></tr>");
                        }
                        else
                        {
                            sb.Append("<tr bgcolor='#EFEBE9'><td colspan='2'><b>Invoice</b></td></tr>");
                            sb.Append("<tr><td width='10%' >Invoice number</td><td width='90%'  style='font-size:9pt;float:left;text-align=left;'><b>");
                            sb.Append(InvoiceNumber);
                            sb.Append("</b></td></tr>");
                            sb.Append("<tr><td>Emission date </td><td style='font-size:9pt;'><b>");
                            sb.Append(EmissionDate);
                            sb.Append("</b></td></tr>");
                            sb.Append("<tr><td>Due date </td><td style='font-size:9pt;'><b>");
                            sb.Append(DueDate);
                            sb.Append("</b></td></tr>");
                            sb.Append("<tr><td>Agency booking reference</td><td style='font-size:9pt;'><b>");
                            sb.Append(AgencyReference);
                            sb.Append("</b></td></tr>");
                        }
                        sb.Append("</table>");
                        sb.Append("<br />");
                        sb.Append("<br />");
                        sb.Append("<table>");
                        sb.Append("<tr bgcolor='#14DCFF'>");

                        foreach (DataColumn column in data.Columns)
                        {
                            if (column.ColumnName == "CustomerName" || column.ColumnName == "CompanyName" || column.ColumnName == "Address" ||
                                column.ColumnName == "AccountRefNumber" || column.ColumnName == "InvoiceNumber" || column.ColumnName == "InvoiceDate" ||
                                column.ColumnName == "DueDate" || column.ColumnName == "AgencyReference" || column.ColumnName == "Doviz" ||
                                column.ColumnName == "Total" || column.ColumnName == "Taxes" || column.ColumnName == "SUBTOTAL")
                            {

                            }
                            else
                            {
                                sb.Append("<th>");
                                sb.Append(column.ColumnName);
                                sb.Append("</th>");
                            }


                        }

                        sb.Append("</tr>");

                        foreach (DataRow row in data.Rows)
                        {
                            sb.Append("<tr>");
                            foreach (DataColumn column in data.Columns)
                            {


                                if (column.ColumnName == "CustomerName" || column.ColumnName == "CompanyName" || column.ColumnName == "Address" ||
                                column.ColumnName == "AccountRefNumber" || column.ColumnName == "InvoiceNumber" || column.ColumnName == "InvoiceDate" ||
                                column.ColumnName == "DueDate" || column.ColumnName == "AgencyReference" || column.ColumnName == "Doviz" ||
                                column.ColumnName == "Total" || column.ColumnName == "Taxes" || column.ColumnName == "SUBTOTAL")
                                {
                                    //sb.Append(row[column] + " " + "TL");
                                }

                                else
                                {
                                    sb.Append("<td>");

                                    sb.Append(row[column]);
                                    sb.Append("</td>");

                                }

                            }
                            sb.Append("</tr>");
                        }
                        sb.Append("<br />");
                        sb.Append("<br />");
                        sb.Append("<tr style='font-size:9pt;' ><td align = 'left' colspan = '");
                        sb.Append(data.Columns.Count - 12);
                        sb.Append("'>SUBTOTAL (without taxes) </td>");
                        sb.Append("<td align='right'>");
                        sb.Append(subtotal + " " + doviz);
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<br />");

                        sb.Append("<tr style='font-size:9pt;' ><td align = 'left' colspan = '");
                        sb.Append(data.Columns.Count - 12);
                        sb.Append("'>Taxes</td>");
                        sb.Append("<td align='right'>");
                        sb.Append(taxes + " " + doviz);
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<br />");

                        sb.Append("<tr style='font-size:9pt;' ><td align = 'left' colspan = '");
                        sb.Append(data.Columns.Count - 12);
                        sb.Append("'><b>Total</b></td>");
                        sb.Append("<td align='right'><b>");
                        sb.Append(total + " " + doviz);
                        sb.Append("</b></td>");
                        sb.Append("</tr>");

                        sb.Append("</table>");

                        sb.Append("<table width='100%' height='50px' style='margin: 15px 15px 15px 15px;'>");
                        sb.Append("<tr><td colspan='2'><b>In case the selected payment type was a bank transfer, please perform the payment to the following account:</b></td></tr>");
                        sb.Append("<tr><td>Bank:</td><td><b>");
                        sb.Append("CITI BANK DUBAI");
                        sb.Append("</b></td></tr>");
                        sb.Append("<tr><td>Bank Number:</td><td><b>");
                        sb.Append("140847852");
                        sb.Append("</b></td></tr>");
                        sb.Append("<tr><td>IBAN Code:</td><td><b>");
                        sb.Append("AE490211000000140847852");
                        sb.Append("</b></td></tr>");
                        sb.Append("<tr><td>SWIFT Code:</td><td><b>");
                        sb.Append("CITIAEAD");
                        sb.Append("</b></td></tr>");
                        sb.Append("<tr><td>Bank address 1:</td><td><b>");
                        sb.Append("Citibank N.A. P.O. Box 749, Dubai");
                        sb.Append("</b></td></tr>");
                        sb.Append("<br /><br />");

                        sb.Append("</table>");
                        sb.Append("<br /><br />");
                        sb.Append("</body>");



                        StyleSheet stil = new StyleSheet();
                        FontFactory.Register("C:\\Windows\\Fonts\\Arial.ttf", "ArialFont");
                        stil.LoadTagStyle("body", "face", "ArialFont");
                        stil.LoadTagStyle("body", "encoding", "Identity-H");
                        stil.LoadTagStyle("body", "size", "7pt");

                        StringReader sr = new StringReader(sb.ToString());
                        Document pdfDoc = new Document(PageSize.A4, 5f, 5f, 5f, 5f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc, null, stil);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);



                        //pdf kaydet
                        PdfWriter.GetInstance(pdfDoc, new FileStream(Server.MapPath(pdfYolu + BookingCode + ".pdf"), FileMode.Create));
                        pdfDoc.Open();
                        //iTextSharp.text.Image gorsel = iTextSharp.text.Image.GetInstance(Server.MapPath("images/ascimentologo.png"));
                        ////gorsel.ScaleToFit(224, 67);

                        //gorsel.ScaleToFit(152f, 43f);
                        //gorsel.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_RIGHT;
                        ////gorsel.IndentationLeft = 9f;
                        ////gorsel.SpacingAfter = 9f;
                        ////gorsel.BorderWidthTop = 36f;
                        ////gorsel.BorderColorTop = Color.WHITE;

                        //pdfDoc.Add(gorsel);

                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //lblIslemSonuc.Text = ex.Message;
                //lblIslemSonuc.CssClass = "islemHatali";
                //lblIslemSonuc.Visible = true;
            }
        }

    }
}