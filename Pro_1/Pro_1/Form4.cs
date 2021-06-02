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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        string connectionDatabase = "datasource=127.0.0.1;port=3306;username=root;password=;database=dt_project;";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            if (email.Equals("ENTER YOUR E-MAIL"))
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            if (email.ToLower().Trim().Equals("ENTER YOUR E-MAIL") || email.Trim().Equals(""))
            {
               textBox1.Text = "ENTER YOUR E-MAIL";
               textBox1.ForeColor = Color.Gray;

            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {

            string secret = textBox2.Text;
            if (secret.Equals("ENTER YOUR SECRET"))
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            string secret = textBox2.Text;
            if (secret.ToLower().Trim().Equals("ENTER YOUR SECRET") || secret.Trim().Equals(""))
            {
                textBox2.Text = "ENTER YOUR SECRET";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            string newpass = textBox3.Text;
            if (newpass.Equals("NEW PASSWORD"))
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            string newpass = textBox3.Text;
            if (newpass.ToLower().Trim().Equals("NEW PASSWORD") || newpass.Trim().Equals(""))
            {
                textBox3.Text = "NEW PASSWORD";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            string conpass = textBox4.Text;
            if (conpass.Equals("CONFIRM PASSWORD"))
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            string conpass = textBox4.Text;
            if (conpass.ToLower().Trim().Equals("CONFIRM PASSWORD") || conpass.Trim().Equals(""))
            {
                textBox4.Text = "CONFIRM PASSWORD";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            comboBox1.SelectedIndex = 0;
        }

        private void ResetPassword()
        {
            try
            {
                string listSecret = comboBox1.SelectedItem.ToString();
                string query = "SELECT * FROM account WHERE `E-mail` ='" + textBox1.Text + "'AND Question ='" + listSecret + "'AND Secret ='" + textBox2.Text+"'"; 
                MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);          
                MySqlDataReader reader;         
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string sql = $"UPDATE account  SET Password = \"{textBox3.Text}\" WHERE `E-mail` = '" + textBox1.Text + "' ";
                        MySqlConnection conn = new MySqlConnection(connectionDatabase);
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Password has been changed.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error!.Please try again.");
                    }
                  
                }
                else
                {
                    MessageBox.Show("Error!.Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void closeThisProgrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;
            result = MessageBox.Show("Do you want to exit this program? ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void backToLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {       
            string txtPass = textBox3.Text;
            
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "--SELECT YOUR QUESTION--")
            {
                MessageBox.Show("กรุณากรอกให้ครบ!");
            }
            else if (textBox1.Text == "ENTER YOUR E-MAIL" && textBox2.Text == "ENTER YOUR SECRET" && textBox3.Text == "NEW PASSWORD" && textBox4.Text == "CONFIRM PASSWORD" && comboBox1.Text == "")
            {
                MessageBox.Show("กรุณากรอกให้ครบ!");
            }
            else if (txtPass.Length < 6 )
            {
                MessageBox.Show("กรุณากรอก password 6-15ตัว ");  
            }
            else if (textBox3.Text.Equals(textBox4.Text))
            {
                ResetPassword();
            }
            else
            {
                MessageBox.Show("รหัสผ่านไม่ตรงกัน!");
            }

        }
    }
        
}
