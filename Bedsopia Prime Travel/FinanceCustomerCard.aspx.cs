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
    public partial class FinanceCustomerCard : System.Web.UI.Page
    {
        Command command = new Command();

        protected void Page_Load(object sender, EventArgs e)
        {
            InvoiceList();
        }

        protected void InvoiceList()
        {


            try
            {
                string query = " SELECT      Logicalref,CustomerId,CustomerName,Bank,ContractFile,CreditAmount,Depozit,WorkPeriotType,PaymentType,PaymentMethod,Email FROM PRIMETRAVEL_JUNIPER..FinanceCustomerCard";

                //query += " ORDER BY Name DESC";

                DataTable dt = command.ReturnTableWithParameters(query, null, "Table");

                if (dt.Rows.Count > 0)
                {
                    FinanceCustomerList.DataSource = dt;
                    FinanceCustomerList.DataBind();
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