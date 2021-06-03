using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Pro_1
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("www.facebook.com");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("www.facebook.com/messages/t/100024327783442");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://mail.google.com/mail/u/0/#inbox");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://mail.google.com/mail/u/0/#inbox?compose=GTvVlcSDbvCBJdBqPKfHhFrswNnXzntVTJtGVHlXHMpjpBQQmmwsJjSsncmfFLKHTwVRkNrcrjNfr");
        }
    }
}
