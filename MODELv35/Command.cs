using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Collections;


using System.IO;
using Model;
using System.Data.OracleClient;

namespace MODEL
{
    public class Command : IDisposable
    {

        public static readonly string INSERT = "INSERT";
        public static readonly string UPDATE = "UPDATE";
        public static readonly string DELETE = "DELETE";
        public static OracleConnection conn =null;
        #region Tanımlamalar


        private string connectionString = null;
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }



        private string oracleConnectionString = null;
        public string OracleConnectionString
        {
            get { return oracleConnectionString; }
            set { oracleConnectionString = value; }
        }

        private SqlDataAdapter sqlDataAdapter;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlDataReader;

        #endregion


        public void Dispose()
        {
            if (sqlDataAdapter != null)
            {
                sqlDataAdapter.Dispose();
                sqlDataAdapter = null;
            }
            if (sqlCommand != null)
            {
                sqlCommand.Dispose();
                sqlCommand = null;
            }
            if (sqlDataReader != null)
            {
                sqlDataReader.Dispose();
                sqlDataReader = null;
            }
        } 
        public Command()
        {
            try
            {
                if (ConnectionInfo.ConnectionString == null)
                {
                    ConnectionString = "";
                }
                else
                {
                    ConnectionString = ConnectionInfo.ConnectionString;
                    oracleConnectionString = ConnectionInfo.OracleConnectionString; 
                } 
            }
            catch
            {
                throw;
            }
        }
         
        public DataSet ReturnDataSet(string query)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    sqlDataAdapter = new SqlDataAdapter(query, cn);
                    cn.Open();
                    sqlDataAdapter.Fill(ds);
                }
                catch
                {

                    throw;

                }
                return ds;
            }
        }
        public string OpenOracleConnection()
        {
            string info = "";
            try
            { 
                conn = new OracleConnection(OracleConnectionString); 
                conn.Open();
                info = "OK";
            }
            catch (Exception ex)
            {
                info = ex.Message;
            }

            return info;


        }
        public string CloseOracleConnection()
        {
            string info = "";
            try
            {
                conn.Close();
                info = "OK";
            }
            catch (Exception ex)
            {
                info = ex.Message;
            }

            return info;


        }

        public DataSet ReturnOracleDataSet(string sqlquery)
        { 
            DataSet dataSet = new DataSet();

            OracleCommand cmd = new OracleCommand(sqlquery);

            cmd.CommandType = CommandType.Text;

            cmd.Connection = conn;

            using (OracleDataAdapter dataAdapter = new OracleDataAdapter())
            {
                dataAdapter.SelectCommand = cmd;
              
                dataAdapter.Fill(dataSet);
            }
            return dataSet;
        }



        public DataTable ReturnOracleDataTable(string sqlquery, string tableName)
        { 
            DataTable dt = new DataTable(tableName);

            OracleCommand cmd = new OracleCommand(sqlquery);

            cmd.CommandType = CommandType.Text;

            cmd.Connection = conn;

            using (OracleDataAdapter dataAdapter = new OracleDataAdapter())
            {
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dt);
            }
            return dt;
        }
        public DataTable ReturnOracleTableWithParameters(string sql, List<OracleParameter> paramList, string TableName)
        {

            
            DataTable dt = new DataTable(TableName);

            OracleCommand cmd = new OracleCommand(sql);

            cmd.CommandType = CommandType.Text;

            cmd.Connection = conn;

            using (OracleDataAdapter dataAdapter = new OracleDataAdapter())
            {
                foreach (OracleParameter param in paramList)
                {
                    dataAdapter.SelectCommand.Parameters.Add(param);
                }

                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dt);
            }
            return dt;

             
        }

        public object OracleExecuteScalar(string sqlquery)
        {


            object obj = null;

            OracleTransaction dbTransaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);


            OracleCommand cmd = new OracleCommand(sqlquery, conn, dbTransaction);

            cmd.CommandType = CommandType.Text;

            cmd.Connection = conn;

            obj = cmd.ExecuteScalar();
            dbTransaction.Commit();
            return obj;
        }




        public SqlDataReader ReturnDataReader(string query, SqlParameter[] Prm, CommandType cm, SqlConnection cn)
        {

            try
            {

                sqlCommand = new SqlCommand(query, cn);
                sqlCommand.CommandType = cm;
                if (Prm != null) sqlCommand.Parameters.AddRange(Prm);

                sqlDataReader = sqlCommand.ExecuteReader();
                return sqlDataReader;
            }
            catch
            {
                throw;
            }
            finally
            {


            }


        }


        public MemoryStream ReturnMemoryStream(string query, SqlParameter[] Prm = null)
        {
            MemoryStream memoryStream = new MemoryStream();

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {

                    sqlCommand = new SqlCommand(query, cn);
                    cn.Open();
                    if (Prm != null) sqlCommand.Parameters.AddRange(Prm);


                    using (SqlDataReader sqlQueryResult = sqlCommand.ExecuteReader())
                        if (sqlQueryResult != null)
                        {
                            while (sqlQueryResult.Read())
                            {
                                var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                                sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                                memoryStream.Write(blob, 0, blob.Length);
                            }
                        }
                }
                //Connection.Open();
            }
            catch
            {
                throw;
            }
            finally
            {
                //Connection.Close();
            }
            return memoryStream;
        }

        public SqlDataAdapter ReturnAdapter(string Query)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(Query, cn);
                return da;
            }
        }

        public DataSet ReturnDataset(string sql, string tablename)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlDataAdapter Adap = new SqlDataAdapter(sql, cn);
                    Adap.Fill(ds, tablename);
                }
                catch
                {
                    throw;
                }

                return ds;
            }
        }
        public DataTable ReturnDTableWithParameters(string sql, SqlParameter param1, SqlParameter param2, SqlParameter param3 ,string TableName)
        {

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                DataTable dt = new DataTable(TableName);
                try
                {
                    SqlDataAdapter Adap = new SqlDataAdapter(sql, cn);
                    Adap.SelectCommand.Parameters.Add(param1);
                    Adap.SelectCommand.Parameters.Add(param2);
                    Adap.SelectCommand.Parameters.Add(param3);  
                    Adap.SelectCommand.CommandTimeout = 0;
                    Adap.Fill(dt);
                }
                catch
                {
                    throw;
                }
                return dt;

            }

        }

        public DataTable ReturnTableWithParameters(string sql, List<SqlParameter> paramList, string TableName)
        { 
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                DataTable dt = new DataTable(TableName);
                try
                {
                    SqlDataAdapter Adap = new SqlDataAdapter(sql, cn);
                    if(paramList!=null)
                    {
                        foreach (SqlParameter param in paramList)
                        {
                            Adap.SelectCommand.Parameters.Add(param);
                        }
                    }
                   
                    Adap.SelectCommand.CommandTimeout = 0;
                    Adap.Fill(dt); 
                }
                catch(Exception exp)
                {
                    throw;
                }
                return dt; 
            }

        }
        public DataTable ReturnDTableWithParameters(string sql, SqlParameter param1, SqlParameter param2, SqlParameter param3, SqlParameter param4, string TableName)
        {

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                DataTable dt = new DataTable(TableName);
                try
                {
                    SqlDataAdapter Adap = new SqlDataAdapter(sql, cn);
                    Adap.SelectCommand.Parameters.Add(param1);
                    Adap.SelectCommand.Parameters.Add(param2);
                    Adap.SelectCommand.Parameters.Add(param3);
                    Adap.SelectCommand.Parameters.Add(param4);
                    Adap.SelectCommand.CommandTimeout = 0;
                    Adap.Fill(dt);
                }
                catch 
                {
                    throw;
                }
                return dt;

            }

        }
        public DataTable ReturnDTableWithParameters(string sql, SqlParameter param, string TableName)
        {

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {

                DataTable dt = new DataTable(TableName);
                try
                {
                    SqlDataAdapter Adap = new SqlDataAdapter(sql, cn);
                    Adap.SelectCommand.Parameters.Add(param);
                    Adap.SelectCommand.CommandTimeout = 0;
                    cn.Open();
                    Adap.Fill(dt);
                }
                catch
                { throw; }
                return dt;

            }
        }
        public DataTable ReturnDTableWithParameters(string sql, List<SqlParameter> paramList, string TableName)
        {

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {

                DataTable dt = new DataTable(TableName);
                try
                {
                    SqlDataAdapter Adap = new SqlDataAdapter(sql, cn);
                    foreach (SqlParameter param in paramList)
                    {
                        Adap.SelectCommand.Parameters.Add(param);
                    }
                    Adap.SelectCommand.CommandTimeout = 0;
                    cn.Open();
                    Adap.Fill(dt);
                }
                catch
                {
                    throw;
                }
                return dt;

            }
        }
        public DataTable ReturnDTableWithParameters(string sql, FilterDictionary filterdictionary, string TableName)
        {

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter Adap = new SqlDataAdapter(sql, cn);
                DataTable dt = new DataTable(TableName);
                try
                { //Convert.ToDateTime( filterparameters.Value)
                    Adap = new SqlDataAdapter(sql, cn);
                    Adap.SelectCommand.CommandTimeout = 0;
                    foreach (KeyValuePair<string, FilterParameter> filter in filterdictionary)
                    {
                        if (filter.Value.Condition != "" && filter.Value.HasSqlParameter)
                        {


                            if (filter.Value.Value1 != null)
                            {
                                SqlParameter param = Adap.SelectCommand.CreateParameter();
                                param.DbType = filter.Value.DbType;

                                param.ParameterName = "@param" + filter.Value.index + "_1";
                                if (filter.Value.Condition.Contains("LIKE"))
                                {
                                    param.Value = "%" + filter.Value.Value1 + "%";

                                }
                                else
                                {
                                    param.Value = filter.Value.Value1;

                                }


                                Adap.SelectCommand.Parameters.Add(param);
                            }
                            if (filter.Value.Value2 != null)
                            {
                                SqlParameter param = Adap.SelectCommand.CreateParameter();
                                param.DbType = filter.Value.DbType;

                                if (filter.Value.Condition.Contains("LIKE"))
                                {
                                    param.Value = "%" + filter.Value.Value2 + "%";

                                }
                                else
                                {
                                    param.Value = filter.Value.Value2;

                                }

                                param.ParameterName = "@param" + filter.Value.index + "_2";
                                Adap.SelectCommand.Parameters.Add(param);
                            }
                        }
                    }
                    cn.Open();
                    Adap.Fill(dt);
                }
                catch
                {
                    throw;
                }
                return dt;

            }
        }
        public DataTable ReturnTable(string query, string tablename)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {

                DataTable dt = new DataTable(tablename);
                try
                {
                    cn.Open();
                    sqlDataAdapter = new SqlDataAdapter(query, cn);
                    sqlDataAdapter.SelectCommand.CommandTimeout = 0;
                    sqlDataAdapter.Fill(dt);
                }
                catch
                {
                    throw;
                }
                return dt;
            }
        }
        public DataTable ReturnTable(string query, string tablename, CommandType ctype)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                DataTable dt = new DataTable(tablename);
                try
                { 
                    sqlDataAdapter = new SqlDataAdapter(query, cn);
                    sqlDataAdapter.SelectCommand.CommandTimeout = 0;
                    sqlDataAdapter.SelectCommand.CommandType = ctype;
                    sqlDataAdapter.Fill(dt);
                }
                catch
                {
                    throw;
                }
                return dt;
            }
        }


        public DataTable ReturnTable(string query, SqlParameter[] Prm, string TableName, CommandType ctype)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionInfo.ConnectionString))
            {
                cn.Open();
                DataTable dt = new DataTable();
                try
                {

                    dt.TableName = TableName;
                    sqlDataAdapter = new SqlDataAdapter(query, cn);
                    sqlDataAdapter.SelectCommand.CommandTimeout = 0;
                    sqlDataAdapter.SelectCommand.CommandType = ctype;

                    if (Prm != null) sqlDataAdapter.SelectCommand.Parameters.AddRange(Prm);

                    sqlDataAdapter.Fill(dt);

                }
                catch
                {
                    throw;
                }

                return dt;
            }
        }

        public DataTable ReturnTable(string query, SqlParameter[] Prm, string TableName)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionInfo.ConnectionString))
            {
                cn.Open();
                DataTable dt = new DataTable();
                try
                {


                    dt.TableName = TableName;
                    sqlDataAdapter = new SqlDataAdapter(query, cn);
                    sqlDataAdapter.SelectCommand.CommandTimeout = 0;
                    if (Prm != null) sqlDataAdapter.SelectCommand.Parameters.AddRange(Prm);

                    sqlDataAdapter.Fill(dt);

                }
                catch
                {
                    throw;
                }

                return dt;
            }
        }
        public string InsertDataTabletoSql(DataTable masterTable, string database = "")
        {

            if (database != "")
            {
                database = database + ".dbo.";
            }
            object objmasterref = null;
            string strobjmasterref = "";
            string query = "0";
            string insertqueryprefix = "";
            // string insertquerysuffix = "";
            int masterref = 0;
            string strcheckPrimary = "";
            string strrowexistcheck = "";
            int rowexist = 0;
            string primarywhere = "";
            DataTable dtPrimaryColName = new DataTable();
            List<SqlParameter> parameterList = new List<SqlParameter>();
            foreach (DataRow targetRow in masterTable.Rows)
            {
                string insertquerysuffix = "";//YERİ DEĞİŞTİ
                parameterList = new List<SqlParameter>();
                primarywhere = "";
                rowexist = 0;
                strcheckPrimary = "SELECT column_name as PRIMARY_KEY \r\n" +
                "FROM " + database.Replace(".dbo.", "") + ".INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC  \r\n" +
                "INNER JOIN  \r\n" +
                "" + database.Replace(".dbo.", "") + ".INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU  \r\n" +
                "ON TC.CONSTRAINT_TYPE = 'PRIMARY KEY' AND  \r\n" +
                "TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME  \r\n" +
                "and ku.table_name = '" + masterTable.TableName + "'  \r\n";

                dtPrimaryColName = ReturnTable(strcheckPrimary, masterTable.TableName);
                foreach (DataRow rowPrimaryKey in dtPrimaryColName.Rows)
                {
                    if (primarywhere == "")
                    {
                        primarywhere = "[" + rowPrimaryKey["PRIMARY_KEY"].ToString() + "]" + " = '" + targetRow[rowPrimaryKey["PRIMARY_KEY"].ToString()] + "'";
                    }
                    else
                    {
                        primarywhere = primarywhere + " and " + "[" + rowPrimaryKey["PRIMARY_KEY"].ToString() + "]" + " = '" + targetRow[rowPrimaryKey["PRIMARY_KEY"].ToString()] + "'";
                    }

                }
                if (primarywhere == "")
                {
                    primarywhere = "1=0";
                }
                strrowexistcheck = "SELECT COUNT(*) from " + database + "[" + masterTable.TableName + "] where " + primarywhere;
                rowexist = Convert.ToInt32(ExecuteScalar(strrowexistcheck));
                bool flag = false;
                if (rowexist > 0)
                {
                    int paramcount = 0;
                    insertqueryprefix = "UPDATE   " + database + "[" + masterTable.TableName + "] SET ";
                    foreach (DataColumn colDemand in targetRow.Table.Columns)
                    {
                        for (int i = 0; i < dtPrimaryColName.Rows.Count; i++)//BU KISIM EKLENDİ
                        {
                            if (colDemand.ColumnName == dtPrimaryColName.Rows[i]["PRIMARY_KEY"].ToString() || colDemand.ColumnName == "ID")
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag == true)
                        {
                            flag = false;
                            continue;
                        }
                        paramcount++;
                        //if (targetRow[colDemand.ColumnName] == null || targetRow[colDemand.ColumnName] == DBNull.Value)
                        //{
                        //    continue;
                        //}

                        insertqueryprefix = insertqueryprefix + "[" + colDemand.ColumnName + "]" + " = ";
                        //string parametername = "@" + colDemand.ColumnName.Replace("[", "").Replace("]", "").Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("#", "").Replace("/", "");
                        string parametername = "@param" + paramcount;

                        //"@" + colDemand.ColumnName.Replace("[", "").Replace("]", "").Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("#", "").Replace("/","")
                        insertqueryprefix = insertqueryprefix + parametername + ",";
                        parameterList.Add(new SqlParameter(parametername, targetRow[colDemand.ColumnName]));
                    }

                    insertqueryprefix = insertqueryprefix.Remove(insertqueryprefix.Count() - 1, 1);
                    insertquerysuffix = insertquerysuffix + " WHERE " + primarywhere;
                    query = insertqueryprefix + insertquerysuffix;
                    SqlCommand insertCommand = new SqlCommand(query);
                    insertCommand.Parameters.AddRange(parameterList.ToArray());
                    objmasterref = ExecuteScalar(insertCommand);

                }
                else
                {
                    insertqueryprefix = "INSERT INTO " + database + "[" + masterTable.TableName + "] (";
                    insertquerysuffix = "VALUES ( ";
                    int paramcount = 0;
                    foreach (DataColumn colDemand in targetRow.Table.Columns)
                    {
                        query = "10";
                        if (colDemand.ExtendedProperties.ContainsKey("INSERT"))
                        {
                            if (colDemand.ExtendedProperties["INSERT"].ToString() == "0")
                            {
                                continue;
                            }
                        }
                        else if (colDemand.ColumnName.StartsWith("_"))
                        {
                            continue;
                        }
                        if (targetRow[colDemand.ColumnName] == null || targetRow[colDemand.ColumnName] == DBNull.Value)
                        {
                            continue;
                        }
                        paramcount++;
                        string parametername = "@param" + paramcount;
                        insertqueryprefix = insertqueryprefix + "[" + colDemand.ColumnName + "]" + ",";
                        // "@" + colDemand.ColumnName.Replace("[", "").Replace("]", "").Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("#", "").Replace("/", "")
                        insertquerysuffix = insertquerysuffix + parametername + ",";
                        parameterList.Add(new SqlParameter(parametername, targetRow[colDemand.ColumnName]));
                    }

                    query = "20";
                    insertqueryprefix = insertqueryprefix.Remove(insertqueryprefix.Count() - 1, 1) + ")";
                    query = "30";
                    insertquerysuffix = insertquerysuffix.Remove(insertquerysuffix.Count() - 1, 1) + ") ;SELECT SCOPE_IDENTITY()";
                    query = insertqueryprefix + insertquerysuffix;
                    SqlCommand insertCommand = new SqlCommand(query);
                    insertCommand.Parameters.AddRange(parameterList.ToArray());
                    objmasterref = ExecuteScalar(insertCommand);
                }




                if (objmasterref != null && objmasterref != DBNull.Value)
                {
                    masterref = Convert.ToInt32(objmasterref);
                    strobjmasterref = objmasterref.ToString();
                }


            }

            return strobjmasterref;

        }

        public DataTable S(string query, SqlParameter[] Prm, CommandType commandtype)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                DataTable dt = new DataTable();
                try
                {
                    dt.TableName = "A";
                    sqlDataAdapter = new SqlDataAdapter(query, cn);
                    sqlDataAdapter.SelectCommand.CommandType = commandtype;
                    sqlDataAdapter.SelectCommand.CommandTimeout = 0;
                    if (Prm != null) sqlDataAdapter.SelectCommand.Parameters.AddRange(Prm);
                    cn.Open();
                    sqlDataAdapter.Fill(dt);

                }
                catch
                {
                    throw;


                }

                return dt;
            }
        }
        public DataTable ReturnDTableWithProcedure(SqlCommand cmd, string TableName)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cmd.Connection = cn;

                DataTable dt = new DataTable(TableName);
                SqlDataAdapter Adap = new SqlDataAdapter(cmd);
                try
                {
                    Adap = new SqlDataAdapter(cmd);

                    Adap.SelectCommand.CommandTimeout = 0;
                    cn.Open();
                    Adap.Fill(dt);
                }
                catch
                {
                    throw;
                }
                return dt;
            }
        }
        public ArrayList ReturnArrayList(string query)
        {

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                ArrayList arr = new ArrayList();
                cn.Open();
                sqlCommand = new SqlCommand(query, cn);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                int Colum = dr.FieldCount;
                while (dr.Read())
                {
                    for (int i = 0; i < Colum; i++)
                    {
                        arr.Add(dr[i]);
                    }
                }
                cn.Close();
                return arr;
            }
        }

        public MemoryStream ReturnMemoryStream(SqlCommand cmd)
        {


            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    cn.Open();
                    cmd.Connection = cn;
                    using (var sqlQueryResult = cmd.ExecuteReader())
                        if (sqlQueryResult != null)
                        {
                            sqlQueryResult.Read();
                            var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                            sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                            //using (var fs = new MemoryStream(memoryStream, FileMode.Create, FileAccess.Write)) {
                            memoryStream.Write(blob, 0, blob.Length);
                            //}
                        }
                    return memoryStream;
                }
                //Connection.Open();
            }
            catch
            {
                throw;
            }


        }
        public object ExecuteScalar(SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                object Result = null;
                try
                {
                    cn.Open();
                    cmd.Connection = cn;
                    Result = cmd.ExecuteScalar();
                }
                catch
                {
                    throw;
                }
                finally { cn.Close(); }
                return Result;
            }
        }

        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                int Result = -1;
                try
                {
                    sqlCommand = new SqlCommand(query, cn);
                    cn.Open();
                    sqlCommand.Connection = cn;
                    Result = sqlCommand.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally { cn.Close(); }
                return Result;
            }
        }
        public int ExecuteNonQuery(SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                int Result = -1;
                try
                {
                    cn.Open();
                    cmd.Connection = cn;
                    Result = cmd.ExecuteNonQuery();
                }
                catch
                {

                    throw;

                }
                finally { cn.Close(); }
                return Result;
            }
        }
        public object ExecuteScalar(string query)
        {
            object Result = null;
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlCommand = new SqlCommand(query, cn);
                    cn.Open();
                    sqlCommand.CommandTimeout = 0;
                    Result = sqlCommand.ExecuteScalar();
                    cn.Close();
                }
                catch
                {

                    throw;

                }
            }
            return Result;
        }

        public object ExecuteScalar(string query, SqlParameter[] Prm, CommandType Type)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                object Result = 0;
                try
                {
                    sqlCommand = new SqlCommand(query, cn);
                    sqlCommand.CommandType = Type;
                    if (Prm != null) sqlCommand.Parameters.AddRange(Prm);
                    cn.Open();
                    Result = sqlCommand.ExecuteScalar();
                }
                catch
                {

                    throw;

                }
                finally
                {
                    cn.Close();
                }
                return Result;
            }
        }


        public ArrayList ReturnArray(string sql)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                ArrayList arr = new ArrayList();
                try
                {
                    cn.Open();
                    sqlCommand = new SqlCommand(sql, cn);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    int Colum = sqlDataReader.FieldCount;
                    while (sqlDataReader.Read())
                    {
                        for (int i = 0; i < Colum; i++)
                        {
                            arr.Add(sqlDataReader[i]);
                        }
                    }
                }
                catch
                {

                    throw;

                }
                finally { cn.Close(); }
                return arr;
            }
        }

        public int ExecuteNonQuery(string query, SqlParameter[] Prm, CommandType Type)
        {
            int result = -1;
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlCommand = new SqlCommand(query, cn);
                    sqlCommand.CommandType = Type;
                    if (Prm != null) sqlCommand.Parameters.AddRange(Prm);
                    cn.Open();
                    result = sqlCommand.ExecuteNonQuery();
                    cn.Close();
                }
                catch
                {

                    throw;

                }
            }
            return result;
        }


        public void ExecuteNoneQuery(string query)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                try
                {

                    sqlCommand = new SqlCommand(query, cn);

                    cn.Open();
                    sqlCommand.ExecuteNonQuery();
                    cn.Close();
                }
                catch
                {

                    throw;

                }
            }
        }





        //public  int InsertDataTabletoSql(DataTable masterTable)
        //{
        //    string insertqueryprefix = "";
        //    string insertquerysuffix = "";
        //    int masterref = 0;
        //    foreach (DataRow targetRow in masterTable.Rows)
        //    {



        //        insertqueryprefix = "INSERT INTO " + masterTable.TableName + " (";
        //        insertquerysuffix = "VALUES ( ";
        //        List<SqlParameter> parameterList = new List<SqlParameter>();
        //        foreach (DataColumn colDemand in targetRow.Table.Columns)
        //        {
        //            if (colDemand.ExtendedProperties["INSERT"].ToString() == "0")
        //            {
        //                continue;
        //            }
        //            insertqueryprefix = insertqueryprefix + colDemand.ColumnName + ",";
        //            insertquerysuffix = insertquerysuffix + "@" + colDemand.ColumnName + ",";
        //            parameterList.Add(new SqlParameter("@" + colDemand.ColumnName, targetRow[colDemand.ColumnName]));
        //        }
        //        insertqueryprefix = insertqueryprefix.Remove(insertqueryprefix.Count() - 1, 1) + ")";
        //        insertquerysuffix = insertquerysuffix.Remove(insertquerysuffix.Count() - 1, 1) + ") ;SELECT SCOPE_IDENTITY()";
        //        string query = insertqueryprefix + insertquerysuffix;
        //        SqlCommand insertCommand = new SqlCommand(query);
        //        insertCommand.Parameters.AddRange(parameterList.ToArray());
        //        Command command = new Command();
        //        masterref = Convert.ToInt32(command.ExecuteScalar(insertCommand));

        //    }

        //    return masterref;
        //}

        public string SaveChanges(DataTable datatable, string insertquery, string updatequery, string deletequery)
        {

            int result = -1;
            using (SqlConnection cn = new SqlConnection(ConnectionInfo.ConnectionString))
            {

                try
                {
                    int rowcount = datatable.Rows.Count;
                    object rowvalue;
                    SqlCommand sqlitecommand = new SqlCommand(updatequery, cn);
                    sqlitecommand.CommandTimeout = 0;
                    cn.Open();
                    using (var transaction = cn.BeginTransaction())
                    {
                        sqlitecommand.Transaction = transaction;
                        foreach (DataRow drow in datatable.Rows)
                        {
                            sqlitecommand.Parameters.Clear();
                            foreach (DataColumn dcolumn in datatable.Columns)
                            {
                                if (drow.RowState == DataRowState.Deleted)
                                {
                                    rowvalue = drow[dcolumn, DataRowVersion.Original];
                                }
                                else
                                {
                                    rowvalue = drow[dcolumn];
                                }
                                sqlitecommand.Parameters.AddWithValue("@" + dcolumn.ColumnName, rowvalue);
                            }
                            if (drow.RowState == DataRowState.Deleted)
                            {
                                sqlitecommand.CommandText = deletequery;
                                result = sqlitecommand.ExecuteNonQuery();
                            }
                            else if (drow.RowState != DataRowState.Unchanged)
                            {
                                sqlitecommand.CommandText = updatequery;
                                result = sqlitecommand.ExecuteNonQuery();
                                if (result < 1)
                                {
                                    sqlitecommand.CommandText = insertquery;
                                    sqlitecommand.ExecuteNonQuery();
                                }
                            }
                            else if (drow.RowState == DataRowState.Detached)
                            {
                                throw new Exception("Uygylama hatası: " + datatable.TableName + " tablosunda eklenmemiş satır tespit edildi.");
                            }
                        }
                        transaction.Commit();
                        // datatable.AcceptChanges();
                        return rowcount.ToString();
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                    //  throw;
                }
            }

        }




        public void SetColumnProperties(DataTable dt, string key, object value)
        {
            foreach (DataColumn column in dt.Columns)
            {
                if (!column.ExtendedProperties.ContainsKey(key))
                {
                    column.ExtendedProperties.Add(key, value);
                }
                else
                {
                    column.ExtendedProperties[key] = value;

                }
            }

        }

        public void SetTableForeignKey(DataTable dt, string keyFieldName, object value)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr[keyFieldName] = value;
            }

        }
        public void SetColumnProperties(DataTable dt, string key, object value, List<DataColumn> selectedColumnList)
        {
            foreach (DataColumn column in dt.Columns)
            {
                foreach (DataColumn ignoreColumn in selectedColumnList)
                {
                    if (ignoreColumn.ColumnName == column.ColumnName)
                    {
                        if (!column.ExtendedProperties.ContainsKey(key))
                        {
                            column.ExtendedProperties.Add(key, value);
                        }
                        else
                        {
                            column.ExtendedProperties[key] = value;

                        }
                        break;
                    }

                }

            }

        }







    }
}
