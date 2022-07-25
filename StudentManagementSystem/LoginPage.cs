using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void sizeBtn_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if(WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to exit!!", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" && textBoxPassword.Text == "")
            {
                MessageBox.Show("Username and Password are required", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxUsername.Text == "")
            {
                MessageBox.Show("Username is required", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Password is required", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                if (textBoxUsername.Text == "username" && textBoxPassword.Text == "password")
                {
                    WelcomePage welcomePage = new WelcomePage();
                    welcomePage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked == true)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
