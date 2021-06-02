using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pro_1
{
    public partial class Login_Admin : System.Windows.Forms.Form
    {
        public Login_Admin()
        {
            InitializeComponent();
        }
        public string Username;
        string status;
        string connectionDatabase = "datasource=127.0.0.1;port=3306;username=root;password=;database=dt_project;";
        private void Login()
        {
            string query = "SELECT * FROM account WHERE Username ='" + textBox1.Text + "'AND Password='" + textBox2.Text + "'"; 
            MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        status = reader.GetString("Status");
                        MessageBox.Show("Login success");                   
                    }
                    if (status == "Admin")
                    {
                        this.Hide();
                        Form2 f2 = new Form2();
                        f2.Show();
                        
                    }
                    else
                    {
                        this.Hide();
                        Form2 f2 = new Form2();
                        f2.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Error!.Please try again.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;
            result =  MessageBox.Show("Do you want to exit this program? ","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
 
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {                
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Please enter your username and password.");
            }            
            else if (textBox2.Text == "" )
            {
                MessageBox.Show("Please enter your password.");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter your username.");
            }
            else
            {
                Program.UserShow = textBox1.Text;
                Login();               
            }
        
        }

        private void Login_Admin_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }
    }
}
