using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BusinessLayer;
using BusinessLayer.propertyLayer;
using DatabaseLayer;

namespace BusinessLayer
{
    public class clsStudentDetails
    {
        public void InsertRecord(objStudentDetails oStudent)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                List<SqlParameter> paramList = new List<SqlParameter>();

                param = SqlHelper.CreateParameter("@StudentId",SqlDbType.VarChar);
                param.Value = oStudent.StudentId.ToString();
                paramList.Add(param);

                param = SqlHelper.CreateParameter("@StudentName", SqlDbType.VarChar);
                param.Value = oStudent.Name.ToString();
                paramList.Add(param);

                param = SqlHelper.CreateParameter("@Dob", SqlDbType.DateTime);
                param.Value = Convert.ToDateTime(oStudent.dob);
                paramList.Add(param);

                param = SqlHelper.CreateParameter("@GradePoint", SqlDbType.Decimal);
                param.Value = oStudent.gradePoint;
                paramList.Add(param);

                param = SqlHelper.CreateParameter("@Status", SqlDbType.Bit);
                param.Value = oStudent.status;
                paramList.Add(param);

                SqlHelper.ExecuteNonQuery("sp_InsertStudentDetails", CommandType.StoredProcedure, paramList);
            }

            catch (Exception)
            {
                throw new System.NotImplementedException();
            }

        }
    }
}
