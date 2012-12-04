using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseLayer;

namespace BusinessLayer
{
    public class clsCommon
    {
        public string TextValidation(string passingText, string type,string Field)
        {
            string returnString = "";
            decimal value;
            switch (type)
            {
                case "Decimal":
                    bool isDecimal = decimal.TryParse(passingText, out value);
                    if (isDecimal == false)
                    {
                        returnString = "Please Enter Valid Decimal Value for "+Field;
                    }
                    break;
               
                case "String":

                    System.Text.RegularExpressions.Regex stringCheck = new System.Text.RegularExpressions.Regex("^[a-zA-Z][a-zA-Z\\s]+$");
                    if (!stringCheck.IsMatch(passingText))
                    {
                        returnString = "Please Enter Valid "+Field;
                    }
                    break;
                
            }
            return returnString;
        }
    }
}
