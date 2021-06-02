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
    public partial class Form2 : System.Windows.Forms.Form
    {
        string connectionDatabase = "datasource=127.0.0.1;port=3306;username=root;password=;database=dt_project;";
        public Form2()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing()
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panel3.Visible == true)
                panel3.Visible = false;
            if (panel4.Visible == true)
                panel4.Visible = false;
            if (panel5.Visible == true)
                panel5.Visible = false;
            if (panel6.Visible == true)
                panel6.Visible = false;
        }
        
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

       private void checkAdmin()
        {
            string query = "SELECT * FROM account WHERE `Username` ='" +label1.Text + "'AND Status='" + "Admin" + "'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionDatabase);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            if (reader.HasRows)
            {
                button7.Visible = true;
            }
            else
            {
                button7.Visible = false;
            }
        }

        private Form activeForm = null;
        private void openSplitForm(Form SplitForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = SplitForm;
            SplitForm.TopLevel = false;
            SplitForm.FormBorderStyle = FormBorderStyle.None;
            SplitForm.Dock = DockStyle.Fill;
            panelScreenForm.Controls.Add(SplitForm);
            panelScreenForm.Tag = SplitForm;
            SplitForm.BringToFront();
            SplitForm.Show();
        }

        
        private void Form2_Load(object sender, EventArgs e)
        {
           
            label1.Text = Program.UserShow;
            checkAdmin();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openSplitForm(new Form9());
        }

        private void button11_Click(object sender, EventArgs e)
        {

            DialogResult result = DialogResult.No;
            result = MessageBox.Show("Do you want to logout? ", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login_Admin f1 = new Login_Admin();
                f1.Show();
            }       
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;
            result = MessageBox.Show("Do you want to exit this program? ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panel3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showSubMenu(panel4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            showSubMenu(panel5);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            showSubMenu(panel6);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openSplitForm(new Form6());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openSplitForm(new Form7());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openSplitForm(new Form8());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openSplitForm(new Form10());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }
    }
}
