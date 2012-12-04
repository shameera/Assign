using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseLayer;

namespace BusinessLayer
{
    public class clsStudentRegistration
    {
        string strCode;
        public string CreateCode()
        {
            try
            {
                strCode = SqlHelper.FindMaximumValue(1).ToString();               
            }

            catch (Exception)
            {
                throw new System.NotImplementedException();
            }
            return strCode;
        }
    }
}
