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
    public partial class Form12 : Form
    {
        string user = Program.UserShow;
        public Form12()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionDatabase = "datasource=127.0.0.1;port=3306;username=root;password=;database=dt_project;";
            MySqlConnection conn = new MySqlConnection(connectionDatabase);
            return conn;
        }
        private void showHistory()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand command;

            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM ROVpurchase WHERE `Username` ='" + user + "'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(ds);

            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            showHistory();
        }


    }
}
