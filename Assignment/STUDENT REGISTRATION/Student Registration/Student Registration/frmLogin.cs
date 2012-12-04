using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Student_Registration
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
                
        private void btnReset_Click(object sender, EventArgs e)
        {
            clearControls();
            this.errorUser.Clear();
            this.errorPwd.Clear();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if ((this.txtUserName.Text != "") & (this.txtPassword.Text != ""))
            {
                this.errorUser.Clear();
                this.errorPwd.Clear();

                if ((this.txtUserName.Text == "ramesh") & (this.txtPassword.Text == "welcome"))
                {
                    frmMainMenu mainMenu = new frmMainMenu();
                    this.Hide();
                    mainMenu.Show();
                }
                else
                {
                    MessageBox.Show("Your UserName or Passwork Incorrect", Resource1.Customer_Name.ToString());
                    clearControls();
                }
            }
            else
            {
                if ((this.txtUserName.Text == "") & (this.txtPassword.Text == ""))
                {
                    this.errorUser.SetError(this.txtUserName, "User Name Cant be Blank");
                    this.errorPwd.SetError(this.txtPassword, "Password Cant be Blank");
                }
                else if (this.txtUserName.Text == "")                {
                    
                    this.errorUser.SetError(this.txtUserName, "User Name Cant be Blank");
                    this.errorPwd.Clear();
                }
                else if (this.txtPassword.Text == "")
                {
                    this.errorPwd.SetError(this.txtPassword, "Password Cant be Blank");
                    this.errorUser.Clear();
                }

            }
        }

        private void clearControls()
        {
            this.txtUserName.Text = "";
            this.txtPassword.Text = "";
            this.txtUserName.Focus();
        }

        

       
    }
}
