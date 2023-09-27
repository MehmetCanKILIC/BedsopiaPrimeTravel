using Bedsopia_Prime_Travel.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bedsopia_Prime_Travel
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string TestMethod(string message)
        {
            return "The message" + message;
        }



        [System.Web.Services.WebMethod]
        public static string GetEmployeeById(int employeeId)
        {

            //string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(cs))
            //{
            //    SqlCommand cmd = new SqlCommand("spGetEmployeeById", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Add(new SqlParameter()
            //    {
            //        ParameterName = "@Id",
            //        Value = employeeId
            //    });
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        employee.ID = Convert.ToInt32(rdr["Id"]);
            //        employee.Name = rdr["Name"].ToString();
            //        employee.Gender = rdr["Gender"].ToString();
            //        employee.Salary = Convert.ToInt32(rdr["Salary"]);
            //    }
            //}

            return "";
        }
    }
}