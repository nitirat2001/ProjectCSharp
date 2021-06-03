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
using System.Data.SqlClient;
using System.IO;

namespace Pro_1
{
    public partial class Form11 : Form
    {
        string RadioBT,Path;
        string Coupon;
        string connectionDatabase = "datasource=127.0.0.1;port=3306;username=root;password=;database=dt_project;";
        public Form11()
        {
            InitializeComponent();
            string userName = Program.UserShow;
        }

        private void Form11_Load(object sender, EventArgs e)
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
                textBox2.Text = reader.GetString("E-mail");
            }
            radioButton1.Focus();
        }
        private void insertPurchase()
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(Path);
                MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
                MySqlCommand command = new MySqlCommand("INSERT INTO `rovpurchase`(`Username`, `OpenID`, `E-mail`,`Coupon`, `Price`,`Slip`,`Status`) VALUES (@User,@openid,@email,@coupon,@Price,@Slip,@Status)", databaseConnection);
                command.Parameters.Add("@User", MySqlDbType.VarChar).Value = Program.UserShow;
                command.Parameters.Add("@openid", MySqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBox2.Text;
                command.Parameters.Add("@Price", MySqlDbType.Int32).Value = RadioBT;
                command.Parameters.AddWithValue("@Slip", bytes);
                command.Parameters.Add("@Status", MySqlDbType.VarChar).Value = "Pending";
                command.Parameters.Add("@coupon", MySqlDbType.VarChar).Value = Coupon;
                databaseConnection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("กรุณาแนบสลิปการโอน");
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioBT = radioButton1.Text;
            Coupon = label2.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioBT = radioButton2.Text;
            Coupon = label3.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioBT = radioButton3.Text;
            Coupon = label4.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            RadioBT = radioButton4.Text;
            Coupon = label5.Text;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            RadioBT = radioButton5.Text;
            Coupon = label6.Text;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            RadioBT = radioButton6.Text;
            Coupon = label7.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog checkfile = new OpenFileDialog();
            checkfile.Filter = "Image Files(*.jpg;*.jpeg;*.png;*.gif;) | *.jpg;*.jpeg;*.png;*.gif; ";
            if (checkfile.ShowDialog() == DialogResult.OK)
            {
                Path = checkfile.FileName;
                pictureBox9.ImageLocation = Path;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ");
            }
            else
            {
                insertPurchase();
                MessageBox.Show("รอแอดมินดำเนินการ");
                this.Close();
            }
        }  
        
    }
}
