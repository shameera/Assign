using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;
using BusinessLayer.propertyLayer;
using DatabaseLayer;

namespace Student_Registration
{
    public partial class frmStudentRegistration : Form
    {
        DataTable tblGlobleData;
        int maxId=0;
        public frmStudentRegistration()
        {
            InitializeComponent();
        }

        public frmStudentRegistration(DataTable tblStudentDetails,int id)
        {
            InitializeComponent();
            tblGlobleData = tblStudentDetails;
            maxId = id;
        }
      
        private void btnCancel_Click(object sender, EventArgs e)
        {            
            this.Hide();
            frmStudent_Details studentDtl = new frmStudent_Details(tblGlobleData, (maxId - 1));
            studentDtl.Show();            
        }

        private void frmStudentRegistration_Load(object sender, EventArgs e)
        {
            if (maxId == 0)
            {                
                clsStudentRegistration cStudent = new clsStudentRegistration();
                string strCreateCode = "0000" + cStudent.CreateCode();
                this.txtStudentId.Text = ("S" + strCreateCode.Substring((strCreateCode.Length - 5), 5)).ToString();
                maxId = Convert.ToInt32(cStudent.CreateCode())+1;
            }
            else
            {
                string strCreateCode = "0000" + maxId.ToString();
                this.txtStudentId.Text = ("S" + strCreateCode.Substring((strCreateCode.Length - 5), 5)).ToString();
                maxId += 1;
            }
        }

        private void AddToGrid()
        {
            try
            {
                errorName.Clear();
                errorGrade.Clear();
                this.Hide();
                DataRow drow = tblGlobleData.NewRow();
                drow["Student Id"] = this.txtStudentId.Text;
                drow["Name"] = this.txtStudentName.Text.ToUpper();
                drow["Date Of Birth"] = this.cmbDateOfBirth.Text;
                drow["GradePointAvg"] = this.txtGradePointAvg.Text;

                if (this.chkStatus.Checked)
                {
                    drow["Active"] = true;
                }
                else
                {
                    drow["Active"] = false;
                }

                tblGlobleData.Rows.Add(drow);
                frmStudent_Details studentDtl = new frmStudent_Details(tblGlobleData, maxId);
                studentDtl.Show();
            }
            catch
            {

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Boolean studentName = false;
            Boolean gradePoint = false;

            if (this.txtStudentName.Text == "")
            {
                errorName.Clear();
                errorName.SetError(this.txtStudentName, "Student Name Can't Be Blank");
            }
            else
            {
                errorName.Clear();
                clsCommon cCommon = new clsCommon();
                string returnString = cCommon.TextValidation(this.txtStudentName.Text, "String", "Student Name");
                if (returnString != "")
                {
                    errorName.SetError(this.txtStudentName, returnString);
                }
                else
                {
                    studentName = true;
                }
            }

            if (this.txtGradePointAvg.Text == "")
            {
                errorGrade.Clear();
                errorGrade.SetError(this.txtGradePointAvg, "Grade Point Can't Be Blank");
            }
            else
            {
                errorGrade.Clear();
                clsCommon cCommon = new clsCommon();
                string returnString = cCommon.TextValidation(this.txtGradePointAvg.Text, "Decimal", "Grade Point");
                if (returnString != "")
                {
                    errorGrade.SetError(this.txtGradePointAvg, returnString);
                }
                else
                {
                    gradePoint = true;                    
                }
            }

           if ((gradePoint == true) & (studentName == true))
           {
               AddToGrid();
           }

            
        }   
        
    }
}
