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
using System.Net;
using System.Net.Mail;

namespace Pro_1
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        string connectionDatabase = "datasource=127.0.0.1;port=3306;username=root;password=;database=dt_project;";
        private void showPurchase(string args)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
            DataSet ds = new DataSet();
            databaseConnection.Open();         
            MySqlCommand command;

            command = databaseConnection.CreateCommand();
            command.CommandText = args;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(ds);        

            databaseConnection.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;         
        }

        private void editPurchase()
        {
            string listStatus = comboBox1.SelectedItem.ToString();
            int selectRow = dataGridView1.CurrentCell.RowIndex;
            int editACT = Convert.ToInt32(dataGridView1.Rows[selectRow].Cells["no."].Value);

            MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
            string sql = $"UPDATE `purchase` SET `Status`=\"{listStatus}\", `Username`=\"{textBox2.Text}\", `IDvalorant`=\"{textBox3.Text}\",`E-mail`=\"{textBox4.Text}\",`ValorantPoint`=\"{textBox5.Text}\" WHERE `No.` = '" + editACT + "' ";
            MySqlCommand command = new MySqlCommand(sql, databaseConnection);
            databaseConnection.Open();
            command.ExecuteReader();
            databaseConnection.Close();

            MessageBox.Show("Edited");
            showPurchase("SELECT * FROM purchase");
        }

        private void deletePurchase()
        {
            int selectRow = dataGridView1.CurrentCell.RowIndex;
            int dltAccount = Convert.ToInt32(dataGridView1.Rows[selectRow].Cells["no."].Value);

            MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
            string sql = "DELETE FROM `purchase` WHERE `no.` ='" + dltAccount + "'";
            MySqlCommand command = new MySqlCommand(sql, databaseConnection);
            databaseConnection.Open();
            command.ExecuteReader();

            MessageBox.Show("Deleted");
            databaseConnection.Close();
            showPurchase("SELECT * FROM purchase");

        }


        private void Form10_Load(object sender, EventArgs e)
        {
            showPurchase("SELECT * FROM purchase");
            comboBox1.SelectedIndex = 0;
            txtMail.Text = ("ดำเนินการเติม " + " Username: " + textBox2.Text + " \nIDvalorant: " + textBox3.Text + " \nValorantPoint: " + textBox5.Text + " \nStatus: " + comboBox1.SelectedItem.ToString() + " \n ขอบคุณที่ใช้บริการครับ");
        }

        private void selectPurchase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.CurrentRow.Selected = true;
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Status"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Username"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["IDvalorant"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["E-mail"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["ValorantPoint"].FormattedValue.ToString();

                var data = (Byte[])(dataGridView1.Rows[e.RowIndex].Cells["Slip"].Value);
                var stream = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "") 
            { 
                showPurchase($"SELECT * FROM `purchase` WHERE `Username` like \"%{textBox1.Text}%\" or `IDvalorant` like \"%{textBox1.Text}%\" or `E-mail` like \"%{textBox1.Text}%\" or `Status` like \"%{textBox1.Text}%\" or `ValorantPoint` like \"%{textBox1.Text}%\" or `Price` like \"%{textBox1.Text}%\"or `no.` like \"%{textBox1.Text}%\"or `DateTime` like \"%{textBox1.Text}%\""); 
            }
            else 
            { 
                showPurchase("SELECT * FROM purchase"); 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editPurchase();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            deletePurchase();
        }

        private void sendEmail()
        {
            string to, from, pass, mail;
            to = (textBox4.Text).ToString();
            from = ("noahzhs01@gmail.com").ToString();
            mail = (txtMail.Text).ToString();
            pass = ("noahz0777").ToString();

            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = mail;
            message.Subject = "TOXIC VALOSHOP";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Email send successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("กรุณากรอกอีเมล");
            }
            else
            {
                sendEmail();
            }
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMail.Text = ("ดำเนินการเติม " + " Username: " + textBox2.Text + " \nIDvalorant: " + textBox3.Text + " \nValorantPoint: " + textBox5.Text + " \nStatus: " + comboBox1.SelectedItem.ToString() + " \n ขอบคุณที่ใช้บริการครับ");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            txtMail.Text = ("ดำเนินการเติม " + " Username: " + textBox2.Text + " \nIDvalorant: " + textBox3.Text + " \nValorantPoint: " + textBox5.Text + " \nStatus: " + comboBox1.SelectedItem.ToString() + " \n ขอบคุณที่ใช้บริการครับ");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            txtMail.Text = ("ดำเนินการเติม " + " Username: " + textBox2.Text + " \nIDvalorant: " + textBox3.Text + " \nValorantPoint: " + textBox5.Text + " \nStatus: " + comboBox1.SelectedItem.ToString() + " \n ขอบคุณที่ใช้บริการครับ");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            txtMail.Text = ("ดำเนินการเติม " + " Username: " + textBox2.Text + " \nIDvalorant: " + textBox3.Text + " \nValorantPoint: " + textBox5.Text + " \nStatus: " + comboBox1.SelectedItem.ToString() + " \n ขอบคุณที่ใช้บริการครับ");
        }
    }
}
