using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class EntryPage : Form
    {
        public EntryPage()
        {
            InitializeComponent();
        }

        public int id;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StudentManagementSystemDatabase.mdf;Integrated Security=True");

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Show();
            this.Hide();
        }

        private void sizeBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (textBoxFname.Text == string.Empty || textBoxLname.Text == string.Empty || textBoxAddress.Text == string.Empty || textBoxGender.Text == string.Empty || textBoxPname.Text == string.Empty || textBoxPhone.Text == string.Empty || textBoxSem.Text == string.Empty || textBoxFaculty.Text == string.Empty)
            {
                MessageBox.Show("Something is missing!!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentEntryTable VALUES (@FirstName, @LastName, @Address, @Gender, @ParentsName, @ContactNumber, @Semester, @Faculty)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FirstName", textBoxFname.Text);
                cmd.Parameters.AddWithValue("@LastName", textBoxLname.Text);
                cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                cmd.Parameters.AddWithValue("@Gender", textBoxGender.Text);
                cmd.Parameters.AddWithValue("@ParentsName", textBoxPname.Text);
                cmd.Parameters.AddWithValue("@ContactNumber", textBoxPhone.Text);
                cmd.Parameters.AddWithValue("@Semester", textBoxSem.Text);
                cmd.Parameters.AddWithValue("@Faculty", textBoxFaculty.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(textBoxFname.Text + " is successfully added!!", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getStudentsRecord();
                reset();
            }
        }

        private void EntryPage_Load(object sender, EventArgs e)
        {
            getStudentsRecord();
        }

        private void getStudentsRecord()
        {
            SqlCommand cmd = new SqlCommand("select * from StudentEntryTable", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridViewEntry.DataSource = dt;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void reset()
        {
            id = 0;
            textBoxFname.Text = string.Empty;
            textBoxLname.Text = string.Empty;
            textBoxAddress.Text = string.Empty;
            textBoxGender.Text = string.Empty;
            textBoxPname.Text = string.Empty;
            textBoxPhone.Text = string.Empty;
            textBoxSem.Text = string.Empty;
            textBoxFaculty.Text = string.Empty;
            textBoxFname.Focus();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE StudentEntryTable SET FirstName = @FirstName, LastName = @LastName, Address = @Address, Gender = @Gender,ParentsName =  @ParentsName, ContactNumber = @ContactNumber, Semester = @Semester, Faculty = @Faculty WHERE id =@id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@FirstName", textBoxFname.Text);
                cmd.Parameters.AddWithValue("@LastName", textBoxLname.Text);
                cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                cmd.Parameters.AddWithValue("@Gender", textBoxGender.Text);
                cmd.Parameters.AddWithValue("@ParentsName", textBoxPname.Text);
                cmd.Parameters.AddWithValue("@ContactNumber", textBoxPhone.Text);
                cmd.Parameters.AddWithValue("@Semester", textBoxSem.Text);
                cmd.Parameters.AddWithValue("@Faculty", textBoxFaculty.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(textBoxFname.Text + " is successfully updated!!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getStudentsRecord();
                reset();
            }
            else
            {
                MessageBox.Show("Select data to update!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM StudentEntryTable WHERE id =@id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(textBoxFname.Text + " is successfully deleted!!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getStudentsRecord();
                reset();
            }
            else
            {
                MessageBox.Show("Select data to delete!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewEntry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridViewEntry.SelectedRows[0].Cells[0].Value);
            textBoxFname.Text = dataGridViewEntry.SelectedRows[0].Cells[1].Value.ToString();
            textBoxLname.Text = dataGridViewEntry.SelectedRows[0].Cells[2].Value.ToString();
            textBoxAddress.Text = dataGridViewEntry.SelectedRows[0].Cells[3].Value.ToString();
            textBoxGender.Text = dataGridViewEntry.SelectedRows[0].Cells[4].Value.ToString();
            textBoxPname.Text = dataGridViewEntry.SelectedRows[0].Cells[5].Value.ToString();
            textBoxPhone.Text = dataGridViewEntry.SelectedRows[0].Cells[6].Value.ToString();
            textBoxSem.Text = dataGridViewEntry.SelectedRows[0].Cells[7].Value.ToString();
            textBoxFaculty.Text = dataGridViewEntry.SelectedRows[0].Cells[8].Value.ToString();
        }
    }
}
