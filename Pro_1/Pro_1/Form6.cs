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
    public partial class Form6 : Form
    {
        string radioBT,path;
        string valoPoint;
        string connectionDatabase = "datasource=127.0.0.1;port=3306;username=root;password=;database=dt_project;";
        public Form6()
        {
            InitializeComponent();
            string userName = Program.UserShow;
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
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
                byte[] bytes = File.ReadAllBytes(path);
                MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
                MySqlCommand command = new MySqlCommand("INSERT INTO `purchase`(`Username`, `IDvalorant`, `E-mail`,`ValorantPoint`, `Price`,`Slip`,`Status`) VALUES (@User,@IDvalo,@email,@valopoint,@Price,@Slip,@Status)", databaseConnection);
                command.Parameters.Add("@User", MySqlDbType.VarChar).Value = Program.UserShow;
                command.Parameters.Add("@IDvalo", MySqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBox2.Text;
                command.Parameters.Add("@Price", MySqlDbType.Int32).Value = radioBT;
                command.Parameters.AddWithValue("@Slip", bytes);
                command.Parameters.Add("@Status", MySqlDbType.VarChar).Value = "Pending";
                command.Parameters.Add("@valopoint", MySqlDbType.VarChar).Value = valoPoint;
                databaseConnection.Open();
            
                command.ExecuteNonQuery();
            }
            catch (Exception )
            {
                MessageBox.Show("กรุณาแนบสลิปการโอน");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" )
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

        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioBT = radioButton1.Text;
            valoPoint = label1.Text;

        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioBT = radioButton2.Text;
            valoPoint = label2.Text;
        }


        private void radioButton3_Click(object sender, EventArgs e)
        {
            radioBT = radioButton3.Text;
            valoPoint = label3.Text;
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            radioBT = radioButton4.Text;
            valoPoint = label4.Text;
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            radioBT = radioButton5.Text;
            valoPoint = label5.Text;
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            radioBT = radioButton6.Text;
            valoPoint = label6.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog checkfile = new OpenFileDialog();
            checkfile.Filter = "Image Files(*.jpg;*.jpeg;*.png;*.gif;) | *.jpg;*.jpeg;*.png;*.gif; ";    
            if (checkfile.ShowDialog() == DialogResult.OK)
            {
                path = checkfile.FileName;
                pictureBox8.ImageLocation = path;
            }
        }
    }
}
