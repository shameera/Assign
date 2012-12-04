using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseLayer
{
    public class SqlHelper
    {
        static string strConnection;
        private SqlConnection conn;

        public SqlHelper()
        {

        }

        public static string connectionstring()
        {
           strConnection = @"Data Source=home\sqlexpress;Initial Catalog=StudentRegistration;Integrated Security=True";
           return strConnection;
        }


        public void openconnection()
        {
            try
            {
                conn = new SqlConnection(connectionstring());
                conn.Open();
            }
            catch
            {
            }
        }

        public void closeconnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionstring());
                conn.Close();
            }
            catch
            {
            }
        }

        public static SqlParameter CreateParameter(string parameterName,SqlDbType sqlType)
        {
            SqlParameter parameter =new SqlParameter(parameterName,sqlType);
            return parameter;
        }

        public static void ExecuteNonQuery(string sql, CommandType type, List<SqlParameter> paramList)
        {
            SqlCommand cmd = new SqlCommand();           
            cmd = CreateCommand(sql, type, paramList);
            /*cmd.CommandType = type;
            cmd.CommandText = sql;
            cmd.Connection.Open();*/
            cmd.ExecuteNonQuery();
            //cmd.Connection.Close();

        }

        public static SqlCommand CreateCommand(string sql, CommandType type, List<SqlParameter> param)
        {
            //connectionstring();
            //SqlConnection con = new SqlConnection(strConnection);
            //con.Open(); 
            SqlHelper SH = new SqlHelper();
            SH.openconnection();

            SqlCommand cmd = new SqlCommand(sql,SH.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (param.Count > 0)
            {
                foreach (SqlParameter p in param)
                {
                    if (p != null)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
            }
           
            //sqlhelp.closeconnection();
            return cmd;
            SH.closeconnection();
        }

        public static string FindMaximumValue(int OperationValue)
        {
            string strMaxValue="";
            try
            {
                SqlHelper SH = new SqlHelper();
                SH.openconnection();

                SqlCommand cmdAuthors = new SqlCommand("sp_find_maximum", SH.conn);
                cmdAuthors.CommandType = CommandType.StoredProcedure;
                cmdAuthors.Parameters.Clear();
                
              
                cmdAuthors.Parameters.Add("@OutPutValue", SqlDbType.Int);
                cmdAuthors.Parameters["@OutPutValue"].Direction = ParameterDirection.Output;

                cmdAuthors.Parameters.Add("@Operation", SqlDbType.Int);
                cmdAuthors.Parameters["@Operation"].Value = OperationValue;

                cmdAuthors.ExecuteNonQuery();

                strMaxValue = cmdAuthors.Parameters["@OutPutValue"].Value.ToString();
                
                SH.closeconnection();
            }
            catch (Exception)
            {
                throw new System.NotImplementedException();
            }

            return strMaxValue;
        }
               
    }
}
