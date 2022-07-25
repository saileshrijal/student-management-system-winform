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
    public partial class LoadingPage : Form
    {
        public LoadingPage()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            loaderPanel.Width += 3;

            if (loaderPanel.Width >= 800)
            {
                timer.Stop();
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Hide();
            }
        }
    }
}
