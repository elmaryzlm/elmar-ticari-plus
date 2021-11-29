using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServiceTicariPlus
{
    public class DbManager : IDisposable
    {
        #region Global Variable
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader dr;
        SqlTransaction transaction;
        DataTable dt;
        DataSet ds;
        #endregion

        #region Constructor
        public DbManager(string connStr)
        {
            conn = new SqlConnection();
            conn.ConnectionString = connStr;
            ConnOpen();
            cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            cmd.Connection = conn;
            adp = new System.Data.SqlClient.SqlDataAdapter();
            adp.SelectCommand = cmd;
        }
        #endregion

        #region Property
        public SqlCommand DataCommand
        {
            get { return cmd; }
            set { cmd = value; }
        }

        public SqlDataAdapter SqlDataAdapter
        {
            get { return adp; }
            set { adp = value; }
        }
        #endregion

        #region Connection Functions

        public enum ConnType
        {
            webConfigFile,
            connectionStringText
        }

        public string GetConnectionString()
        {
            return conn.ConnectionString;
        }

        /// <summary>
        /// Open SQL Connection
        /// </summary>
        /// <returns>If open connection return true, else return false</returns>
        public bool ConnOpen()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Close SQL Connection
        /// </summary>
        /// <returns>If close connection return true, else return false</returns>
        public bool ConnClose()
        {
            try
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Test SQL connection and get the table names.
        /// This function return List<string>
        /// </summary>
        /// <returns>string text</returns>
        // SqlDataReader dr;
        public List<string> TestDatabase()
        {
            List<string> result = new List<string>();

            if (ConnOpen())
            {
                dr = GetDataReader("SELECT name FROM sys.Tables");
                while (dr.Read()) result.Add(dr["name"].ToString());
                ConnClose();
            }
            return result;
        }
        #endregion

        #region Functions
        #region Get

        public SqlDataReader GetDataReader(string sqlCode)
        {
            return GetDataReader(sqlCode, CommandType.Text);
        }
        public SqlDataReader GetDataReader(string sqlCode, CommandType commandType)
        {
            try
            {
                cmd.CommandType = commandType;
                cmd.CommandText = sqlCode;
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                if (dr != null)
                {
                    dr.Close();
                    dr.Dispose();
                }
                AddError(ex.Message, sqlCode);
                return null;
            }
        }

        public DataTable GetDataTable(string sqlCode)
        {
            return GetDataTable(sqlCode, CommandType.Text);
        }
        public DataTable GetDataTable(string sqlCode, CommandType commandType)
        {
            dt = new DataTable();
            cmd.CommandType = commandType;
            cmd.CommandText = sqlCode;
            adp.Fill(dt);
            return dt;
        }

        public DataSet GetDataSet(string sqlCode)
        {
            return GetDataSet(sqlCode, CommandType.Text);
        }
        public DataSet GetDataSet(string sqlCode, CommandType commandType)
        {
            ds = new DataSet();
            cmd.CommandText = sqlCode;
            cmd.CommandType = commandType;
            DataTable dt = new DataTable();
            try
            {
                adp.Fill(dt);
                ds.Tables.Add(dt);
            }
            catch (Exception ex)
            {
                AddError(ex.Message, sqlCode);
            }
            return ds;
        }
        public DataSet GetDataSet(string sqlCode, CommandType commandType, DataSet dataSet, string tableName)
        {
            ds = new DataSet();
            cmd.CommandText = sqlCode;
            cmd.CommandType = commandType;
            try
            {
                adp.Fill(dataSet, tableName);
            }
            catch (Exception ex)
            {
                AddError(ex.Message, sqlCode);
            }
            return dataSet;
        }

        public DataRow GetDataRow(string sqlCode)
        {
            return GetDataRow(sqlCode, CommandType.Text);
        }
        public DataRow GetDataRow(string sqlCode, CommandType commandType)
        {
            DataRow dRow;
            if (GetDataTable(sqlCode, commandType).Rows.Count > 0) dRow = GetDataTable(sqlCode, commandType).Rows[0];
            else dRow = GetDataTable(sqlCode, commandType).NewRow();
            return dRow;
        }

        public object GetExecuteScalar(string sqlCode)
        {
            return GetExecuteScalar(sqlCode, CommandType.Text);
        }
        public object GetExecuteScalar(string sqlCode, CommandType commandType)
        {
            object objValue;
            cmd.CommandType = commandType;
            cmd.CommandText = sqlCode;
            try
            {
                if (!sqlCode.Contains("@")) cmd.Parameters.Clear();
                objValue = DataCommand.ExecuteScalar();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                AddError(ex.Message, sqlCode);
                objValue = null;
            }
            return objValue;
        }
        #endregion

        public bool BeginTransaction()
        {
            try { transaction = conn.BeginTransaction(); return true; }
            catch (Exception ex) { AddError(ex.Message, "BeginTransaction"); return false; }
        }

        public bool CommitTransaction()
        {
            if (transaction == null) return false;
            try { transaction.Commit(); return true; }
            catch (Exception ex) { AddError(ex.Message, "CommitTransaction"); return false; }
        }

        public int RunCommand(string sqlCode)
        {
            return RunCommand(sqlCode, CommandType.Text);
        }
        public int RunCommand(string sqlCode, CommandType commandType)
        {
            cmd.Transaction = transaction;
            int identityID = -1;
            try
            {
                cmd.CommandText = sqlCode;
                cmd.CommandType = commandType;
                cmd.ExecuteNonQuery();
                if (!sqlCode.ToLower().StartsWith("update") &&
                    !sqlCode.ToLower().StartsWith("delete"))
                    identityID = Convert.ToInt32(GetExecuteScalar("select @@IDENTITY"));
            }
            catch (Exception ex)
            {
                if (transaction != null) transaction.Rollback();
                AddError(ex.Message, sqlCode);
                return -1;
            }
            return identityID;
        }

        public bool IsThereRow(string sqlCode)
        {
            return GetDataTable(sqlCode).Rows.Count > 0;
        }

        public int AddError(string message, string sqlCode)
        {
            string sql = @"Insert Into tblHata(Mesaj, Sql)
                           Values (@Mesaj, @Sql)";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@Mesaj", SqlDbType.VarChar).Value = message;
            cmd.Parameters.Add("@Sql", SqlDbType.VarChar).Value = sqlCode;
            return RunCommand(sql);
        }
        #endregion

        public void Dispose()
        {
            ConnClose();
            if (conn != null) conn.Dispose();
            if (cmd != null) cmd.Dispose();
            if (adp != null) adp.Dispose();
            if (dt != null) dt.Dispose();
            if (dr != null) dr.Close();
            if (ds != null) ds.Dispose();
            if (transaction != null) transaction.Dispose();
        }
    }
}