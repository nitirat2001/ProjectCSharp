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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        string connectionDatabase = "datasource=127.0.0.1;port=3306;username=root;password=;database=dt_project;";

        private void addAccount()
        {
            string listSecret = comboBox1.SelectedItem.ToString();
            MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
            string sql = "INSERT INTO `account`(`Status`, `Username`, `Password`, `E-mail`,`Question`, `Secret`) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + listSecret + "','" + textBox5.Text + "')";
            databaseConnection.Open();
            MySqlCommand command = new MySqlCommand(sql, databaseConnection);
            command.ExecuteReader();
            
            MessageBox.Show("Added");           
            databaseConnection.Close();
            showAccount("SELECT * FROM account");
        }
        private void deleteAccount()
        {
            int selectRow = dataGridView1.CurrentCell.RowIndex;
            int dltAccount = Convert.ToInt32(dataGridView1.Rows[selectRow].Cells["No."].Value);

            MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
            string sql = "DELETE FROM `account` WHERE `No.` ='" + dltAccount + "'";
            MySqlCommand command = new MySqlCommand(sql, databaseConnection);
            databaseConnection.Open();
            command.ExecuteReader();

            MessageBox.Show("Deleted");
            databaseConnection.Close();
            showAccount("SELECT * FROM account");

        }
        private void showAccount(string args)
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

        private void editAaccount()
        {
            string listSecret = comboBox1.SelectedItem.ToString();
            int selectRow = dataGridView1.CurrentCell.RowIndex;
            int editACT = Convert.ToInt32(dataGridView1.Rows[selectRow].Cells["No."].Value);

            MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
            string sql = $"UPDATE `account` SET `Status`=\"{textBox1.Text}\", `Username`=\"{textBox2.Text}\", `Password`=\"{textBox3.Text}\",`E-mail`=\"{textBox4.Text}\",`Question`=\"{listSecret}\",`Secret`=\"{textBox5.Text}\" WHERE `No.` = '" + editACT + "' ";
            MySqlCommand command = new MySqlCommand(sql, databaseConnection);
            databaseConnection.Open();
            command.ExecuteReader();
            databaseConnection.Close();

            MessageBox.Show("Edited");
            showAccount("SELECT * FROM account");


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "--กรุณาเลิอกคำถาม--")
            {
                MessageBox.Show("กรุณากรอกให้ครบ");
            }
            else
            {
                addAccount();
            }           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            showAccount("SELECT * FROM account");
            comboBox1.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedIndex = 0;
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteAccount();
        }

        private void selectAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Status"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Username"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Password"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["E-mail"].FormattedValue.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Question"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Secret"].FormattedValue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            editAaccount();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                showAccount($"SELECT * FROM `account` WHERE `No.` like \"%{textBox6.Text}%\" or `Status` like \"%{textBox6.Text}%\" or `Username` like \"%{textBox6.Text}%\" or `Password` like \"%{textBox6.Text}%\" or `E-mail` like \"%{textBox6.Text}%\" or `Question` like \"%{textBox6.Text}%\"or `Secret` like \"%{textBox6.Text}%\"");
            }
            else
            {
                showAccount("SELECT * FROM account");
            }
        }
    }
}
