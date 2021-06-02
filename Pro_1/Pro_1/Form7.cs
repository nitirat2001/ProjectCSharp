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
    public partial class Form7 : Form
    {
        string user = Program.UserShow;
        string connectionDatabase = "datasource=127.0.0.1;port=3306;username=root;password=;database=dt_project;";

        public Form7()
        {
            InitializeComponent();
        }

        private void editAccount()
        {
            string listSecret = comboBox1.SelectedItem.ToString();
            string sql = $"UPDATE `account` SET `Password`=\"{textBox1.Text}\",`E-mail`=\"{textBox2.Text}\",`Question`=\"{listSecret}\",`Secret`=\"{textBox3.Text}\" WHERE `Username` = '" + user + "' ";
            MySqlConnection conn = new MySqlConnection(connectionDatabase);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Changed.");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string txtPass = textBox1.Text;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("กรุณากรอกให้ครบ");
            }
            else if (txtPass.Length < 6)
            {
                MessageBox.Show("กรุณากรอก password 6-15ตัว");
            }
            else
            {
                editAccount();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
            MySqlCommand command;
            MySqlDataReader reader;
            databaseConnection.Open();

            string query = "SELECT* FROM account WHERE Username = '" + Program.UserShow + "'";
            command = new MySqlCommand(query, databaseConnection);

            reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader.GetString("Password");
                textBox2.Text = reader.GetString("E-mail");
                comboBox1.Text = reader.GetString("Question");
                textBox3.Text = reader.GetString("Secret");
            }
        }
    }
}
