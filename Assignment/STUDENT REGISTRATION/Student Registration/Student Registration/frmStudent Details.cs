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

namespace Student_Registration
{
    public partial class frmStudent_Details : Form
    {
        DataTable bindingTable;
        int maxId=0;
        public frmStudent_Details()
        {
            InitializeComponent();
            this.GridViewStudent.DataSource = CreateTable();
        }

        public frmStudent_Details(DataTable dt,int Id)
        {
            InitializeComponent();
            bindingTable = dt;
            maxId = Id;
            this.GridViewStudent.DataSource = CreateTable();
        }

        
        private void frmStudent_Details_Load(object sender, EventArgs e)
        {
            if (bindingTable != null)
            {
                if (bindingTable.Rows.Count > 0)
                {
                    this.GridViewStudent.DataSource = bindingTable;
                }
            }
           
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataTable detailTable = (DataTable)this.GridViewStudent.DataSource;
           
            frmStudentRegistration studentReg = new frmStudentRegistration(detailTable,maxId);
            studentReg.Show();
        }

        private DataTable CreateTable()
        {
            DataTable dtable = new DataTable();
            dtable.Columns.Add("Student Id");
            dtable.Columns.Add("Name");
            dtable.Columns.Add("Date Of Birth");
            dtable.Columns.Add("GradePointAvg");
            dtable.Columns.Add("Active");
            return dtable;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable sourseTable = (DataTable)this.GridViewStudent.DataSource;
            objStudentDetails oStudent = new objStudentDetails();
            clsStudentDetails cStudent = new clsStudentDetails();

            if (sourseTable.Rows.Count > 0)
            {
                for (int i = 0; i < sourseTable.Rows.Count; i++)
                {
                    oStudent.StudentId = sourseTable.Rows[i]["Student Id"].ToString();
                    oStudent.Name = sourseTable.Rows[i]["Name"].ToString();
                    oStudent.dob = sourseTable.Rows[i]["Date Of Birth"].ToString();
                    oStudent.gradePoint = Convert.ToDecimal(sourseTable.Rows[i]["GradePointAvg"]);
                    oStudent.status = Convert.ToBoolean(sourseTable.Rows[i]["Active"]);
                    cStudent.InsertRecord(oStudent);
                    MessageBox.Show("Successfully Inserted", Resource1.Customer_Name.ToString());                   
            
                    this.GridViewStudent.DataSource = CreateTable();
                }
            }
            else
            {
                MessageBox.Show("Please Enter Student Details and Try to Save", Resource1.Customer_Name.ToString());                   
            }
        }



    }
}
