using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KDC.DESKTOP.DO;

namespace KDC.DESKTOP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                this.tStripStatLblMessage.Text = "Please Enter Name.";
                this.tStripStatLblMessage.Visible = true;
            }
            if (txtPassword.Text == "")
            {
                this.tStripStatLblMessage.Text = "Please Enter Password.";
                this.tStripStatLblMessage.Visible = true;
            }
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            SC_User user = DA.UserDA.CheckUserExists(userName, password);
            if (user != null)
            {    
                UserSession.UserId = user.UserId;
                UserSession.FullName = user.FullName;
                UserSession.UserName = user.UserName;
                UserSession.Email = user.Email;
                UserSession.UserType = user.UserType;

                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.Show();
                
            }
            else
            {
                this.tStripStatLblMessage.Text = "Invalid Username or Password";
                this.tStripStatLblMessage.Visible = true;
            }                    
        }
    }
}
