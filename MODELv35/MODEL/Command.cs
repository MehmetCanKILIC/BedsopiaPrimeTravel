using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
 
using System.IO;

namespace MODEL
{
    public class Command : IDisposable
    {

        public static readonly string INSERT = "INSERT";
        public static readonly string UPDATE = "UPDATE";
        public static readonly string DELETE = "DELETE";

        #region Tanımlamalar

            private string connectionString=null;
            public string ConnectionString 
            {
                get {return connectionString;}
                set { connectionString = value;}
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
                ConnectionString = ConnectionInfo.ConnectionString;
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
                    sqlDataAdapter.Fill(ds);
                }
                catch 
                {

                    throw;

                }
                return ds;
            }
        }
 
        public SqlDataReader ReturnDataReader(string query,SqlParameter[] Prm,CommandType Type)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlCommand = new SqlCommand(query, cn);
                    sqlCommand.CommandType = Type;
                    if (Prm != null) sqlCommand.Parameters.AddRange(Prm);
                    cn.Open();
                    sqlDataReader = sqlCommand.ExecuteReader();
                    return sqlDataReader;
                }
                catch  
                {
                    throw;
                }
            }
            
           
        }

        public  SqlDataAdapter ReturnAdapter(string Query)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(Query, cn);
                return da;
            }
        }

        public  DataSet ReturnDataset(string sql,string tablename)
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
        
        public DataTable ReturnTable(string query,string tablename)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                DataTable dt = new DataTable(tablename);
                try
                {
                    sqlDataAdapter = new SqlDataAdapter(query, cn);
                    sqlDataAdapter.Fill(dt);
                }
                catch 
                {

                    throw;

                }
                return dt;
            }
        }
    
        public DataTable ReturnTable(string query, SqlParameter[] Prm, CommandType Type)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                DataTable dt = new DataTable();
                try
                {
                    sqlCommand = new SqlCommand(query, cn);
                    sqlCommand.CommandType = Type;
                    if (Prm != null) sqlCommand.Parameters.AddRange(Prm);
                    cn.Open();
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dt);
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
        public  object ReturnObject(string sql)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
            object Result = 0;
            try
            {
                cn.Open();
                sqlCommand = new SqlCommand(sql, cn);
                Result = sqlCommand.ExecuteScalar();
            }
            catch 
            {

                throw;

            }
            finally { cn.Close(); }
            return Result;
            }
        }
        public object ExecuteScalar(SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                object Result = 0;
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
        public   object ReturnObject(SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                object Result = 0;
                try
                {
                    cmd.Connection = cn;
                    cn.Open();
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

        public int ReturnScalar(string query, SqlParameter[] Prm, CommandType Type)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                int Result = 0;
                try
                {
                    sqlCommand = new SqlCommand(query, cn);
                    sqlCommand.CommandType = Type;
                    if (Prm != null) sqlCommand.Parameters.AddRange(Prm);
                    cn.Open();
                    Result = (int)sqlCommand.ExecuteScalar();
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

        public  int ReturnScalar(string sql)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                int Result = 0;
                try
                {
                    cn.Open();
                    sqlCommand = new SqlCommand(sql, cn);
                    Result = (int)sqlCommand.ExecuteScalar();
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
        public object ReturnScalarObject(string sql)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                object Result = 0;
                try
                {
                    cn.Open();
                    sqlCommand = new SqlCommand(sql, cn);
                    Result =  sqlCommand.ExecuteScalar();
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

        public  ArrayList ReturnArray(string sql)
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
 
        public void ExecuteNonQuery(string query, SqlParameter[] Prm, CommandType Type)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlCommand = new SqlCommand(query, cn);
                    sqlCommand.CommandType = Type;
                    if (Prm != null) sqlCommand.Parameters.AddRange(Prm);
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


        public void ExecuteNonQuery(string query)
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

       
        public int ExecuteScalar(string query, SqlParameter[] Prm, CommandType Type)
        {
            object result;
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlCommand = new SqlCommand(query, cn);
                    sqlCommand.CommandType = Type;
                    if (Prm != null) sqlCommand.Parameters.AddRange(Prm);
                    cn.Open();
                    result = sqlCommand.ExecuteScalar();
                    cn.Close();
                }
                catch  
                {

                    throw;

                }
            }
            if (result == null || result == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToInt32(result);
        }

       

        public  int InsertDataTabletoSql(DataTable masterTable)
        {
            string insertqueryprefix = "";
            string insertquerysuffix = "";
            int masterref = 0;
            foreach (DataRow targetRow in masterTable.Rows)
            {



                insertqueryprefix = "INSERT INTO " + masterTable.TableName + " (";
                insertquerysuffix = "VALUES ( ";
                List<SqlParameter> parameterList = new List<SqlParameter>();
                foreach (DataColumn colDemand in targetRow.Table.Columns)
                {
                    if (colDemand.ExtendedProperties["INSERT"].ToString() == "0")
                    {
                        continue;
                    }
                    insertqueryprefix = insertqueryprefix + colDemand.ColumnName + ",";
                    insertquerysuffix = insertquerysuffix + "@" + colDemand.ColumnName + ",";
                    parameterList.Add(new SqlParameter("@" + colDemand.ColumnName, targetRow[colDemand.ColumnName]));
                }
                insertqueryprefix = insertqueryprefix.Remove(insertqueryprefix.Count() - 1, 1) + ")";
                insertquerysuffix = insertquerysuffix.Remove(insertquerysuffix.Count() - 1, 1) + ") ;SELECT SCOPE_IDENTITY()";
                string query = insertqueryprefix + insertquerysuffix;
                SqlCommand insertCommand = new SqlCommand(query);
                insertCommand.Parameters.AddRange(parameterList.ToArray());
                Command command = new Command();
                masterref = Convert.ToInt32(command.ExecuteScalar(insertCommand));

            }

            return masterref;
        }




        public  void SetColumnProperties(DataTable dt, string key, object value)
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
     
        public  void SetTableForeignKey(DataTable dt, string keyFieldName, object value)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr[keyFieldName] = value;
            }

        }
        public  void SetColumnProperties(DataTable dt, string key, object value, List<DataColumn> selectedColumnList)
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
        public  void InsertDataTabletoSql(DataTable detailTable, string masterFieldName, int masterref)
        {
            string insertqueryprefix = "";
            string insertquerysuffix = "";

            foreach (DataRow targetRow in detailTable.Rows)
            {
                insertqueryprefix = "INSERT INTO " + detailTable.TableName + " (";
                insertquerysuffix = "VALUES ( ";
                List<SqlParameter> parameterList = new List<SqlParameter>();
                targetRow.SetField(masterFieldName, masterref);

                foreach (DataColumn colDemand in targetRow.Table.Columns)
                {
                    if (colDemand.ExtendedProperties["INSERT"].ToString() == "0")
                    {
                        continue;
                    }
                    insertqueryprefix = insertqueryprefix + colDemand.ColumnName + ",";
                    insertquerysuffix = insertquerysuffix + "@" + colDemand.ColumnName + ",";
                    parameterList.Add(new SqlParameter("@" + colDemand.ColumnName, targetRow[colDemand.ColumnName]));
                }
                insertqueryprefix = insertqueryprefix.Remove(insertqueryprefix.Count() - 1, 1) + ")";
                insertquerysuffix = insertquerysuffix.Remove(insertquerysuffix.Count() - 1, 1) + ") ;SELECT SCOPE_IDENTITY()";
                string query = insertqueryprefix + insertquerysuffix;
                SqlCommand insertCommand = new SqlCommand(query);
                insertCommand.Parameters.AddRange(parameterList.ToArray());
                Command command = new Command();
                int detailref = Convert.ToInt32(command.ExecuteScalar(insertCommand));

            }
        }

        public  void UpdateDataTabletoSql(DataTable masterTable, string keyFieldName)
        {
            string insertqueryprefix = "";
            string insertquerysuffix = "";

            foreach (DataRow targetRow in masterTable.Rows)
            {
                insertqueryprefix = "UPDATE " + masterTable.TableName + " SET ";
                insertquerysuffix = " WHERE    " + keyFieldName + " = " + targetRow[keyFieldName];
                List<SqlParameter> parameterList = new List<SqlParameter>();
                //targetRow.SetField(keyFieldName, keyref);

                foreach (DataColumn colDemand in targetRow.Table.Columns)
                {
                    if (colDemand.ExtendedProperties["UPDATE"].ToString() == "0")
                    {
                        continue;
                    }
                    insertqueryprefix = insertqueryprefix + colDemand.ColumnName + " = @" + colDemand.ColumnName + ",";

                    parameterList.Add(new SqlParameter("@" + colDemand.ColumnName, targetRow[colDemand.ColumnName]));
                }
                insertqueryprefix = insertqueryprefix.Remove(insertqueryprefix.Count() - 1, 1) + "";
                //insertquerysuffix = insertquerysuffix.Remove(insertquerysuffix.Count() - 1, 1) + ") ;SELECT SCOPE_IDENTITY()";
                string query = insertqueryprefix + insertquerysuffix;
                SqlCommand insertCommand = new SqlCommand(query);
                insertCommand.Parameters.AddRange(parameterList.ToArray());
                Command command = new Command();
                int detailref = Convert.ToInt32(command.ExecuteScalar(insertCommand));

            }
        }
        public  void DeleteDataTabletoSql(DataTable masterTable, string keyFieldName)
        {
            string insertqueryprefix = "";
            string insertquerysuffix = "";

            foreach (DataRow targetRow in masterTable.Rows)
            {
                insertqueryprefix = "DELETE FROM " + masterTable.TableName + "   ";
                insertquerysuffix = " WHERE    " + keyFieldName + " = " + targetRow[keyFieldName];
                List<SqlParameter> parameterList = new List<SqlParameter>();
                //targetRow.SetField(keyFieldName, keyref);

                //foreach (DataColumn colDemand in targetRow.Table.Columns)
                //{
                //    if (colDemand.ExtendedProperties["UPDATE"].ToString() == "0")
                //    {
                //        continue;
                //    }
                //    insertqueryprefix = insertqueryprefix + colDemand.ColumnName + " = @" + colDemand.ColumnName + ",";

                //    parameterList.Add(new SqlParameter("@" + colDemand.ColumnName, targetRow[colDemand.ColumnName]));
                //}
                //insertqueryprefix = insertqueryprefix.Remove(insertqueryprefix.Count() - 1, 1) + "";
                //insertquerysuffix = insertquerysuffix.Remove(insertquerysuffix.Count() - 1, 1) + ") ;SELECT SCOPE_IDENTITY()";
                string query = insertqueryprefix + insertquerysuffix;
                SqlCommand deleteCommand = new SqlCommand(query);
                deleteCommand.Parameters.AddRange(parameterList.ToArray());
                Command command = new Command();
                int detailref = Convert.ToInt32(command.ExecuteScalar(deleteCommand));

            }
        }

 

 
       

    }
}
