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
    public partial class Form3 : System.Windows.Forms.Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        
        
        string connectionDatabase = "datasource=127.0.0.1;port=3306;username=root;password=;database=dt_project;";
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;
            result = MessageBox.Show("Do you want to exit this program? ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
             
        }
        private void Register()
        {
            string txtUser = textboxUsername.Text;
            string txtPass = textboxPassword.Text;

            string listSecret = comboBox1.SelectedItem.ToString();
            MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
            MySqlCommand command = new MySqlCommand("INSERT INTO `account`(`Status`, `Username`, `Password`, `E-mail`,`Question`, `Secret`) VALUES (@status,@user,@pass,@email,@ques,@secret)", databaseConnection);

            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = "Guest";
            command.Parameters.Add("@user", MySqlDbType.VarChar).Value = textboxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textboxPassword.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textboxEmail.Text;
            command.Parameters.Add("@ques", MySqlDbType.VarChar).Value = listSecret;
            command.Parameters.Add("@secret", MySqlDbType.VarChar).Value = textboxSecret.Text;


            databaseConnection.Open();

            if (textboxPassword.Text.Equals(textboxConfirmpassword.Text))
            {
                if (textboxUsername.Text == "" || textboxPassword.Text == "" || textboxConfirmpassword.Text == "" || textboxEmail.Text == "" || textboxSecret.Text == "" || comboBox1.Text == "--กรุณาเลือกคำถาม--")
                {
                    MessageBox.Show("กรุณากรอกให้ครบ!");
                }
                else if (txtUser.Length < 6 || txtPass.Length < 6)
                {
                    MessageBox.Show("กรุณากรอก user,pass,secret 6-20 ตัว");
                }
                else if (checkUsername())
                {
                    MessageBox.Show("มีบัญชีผู้ใช้นี้อยู่แล้ว โปรดใช้'Username'อื่น!");
                }       
                else
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Account created");
                        this.Close();
                    }               
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }          
            else
            {
                MessageBox.Show("รหัสผ่านไม่ตรงกัน!");
            }
        }
        public Boolean checkUsername()
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
            string username = textboxUsername.Text;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `account` WHERE `Username` = @user", databaseConnection);
            
            command.Parameters.Add("@user", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {      
         Register();            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
