using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bedsopia_Prime_Travel
{
    public partial class FinanceSupplierCardDetail : System.Web.UI.Page
    {
        Command command = new Command();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {

        }

        protected void SupplierCardSave()
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandText = "UPDATE PRIMETRAVEL_JUNIPER..PaymentErrorLog SET Bank=@Bank,ContractFile=@ContractFile,CreditAmount=@CreditAmount,Depozit=@Depozit,WorkPeriotType=@WorkPeriotType,PaymentType=@PaymentType," +
                "PaymentMethod=@PaymentMethod,Note=@Note,Email=@Email,DueDate=@DueDate WHERE Supplier SupplierId=@SupplierId";
            cmdInsert.Parameters.AddWithValue("@Bank", txtBank.Text);
            cmdInsert.Parameters.AddWithValue("@ContractFile", fileContractFile.FileContent);
            cmdInsert.Parameters.AddWithValue("@CreditAmount", txtCreditAmount.Text);
            cmdInsert.Parameters.AddWithValue("@Depozit", txtDepozit.Text);
            cmdInsert.Parameters.AddWithValue("@WorkPeriotType", dropWorkPeriotType.SelectedValue);
            cmdInsert.Parameters.AddWithValue("@PaymentType", dropPaymentType.SelectedValue);
            cmdInsert.Parameters.AddWithValue("@PaymentMethod", dropPaymentMethod.SelectedValue);
            cmdInsert.Parameters.AddWithValue("@Note", txtNote.Text);
            cmdInsert.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmdInsert.Parameters.AddWithValue("@DueDate", dropDueDate.SelectedValue);
            cmdInsert.Parameters.AddWithValue("@SupplierId", txtSupplierId.Text);
            int VariantParamref = Convert.ToInt32(command.ExecuteScalar(cmdInsert));
        }
    }
}