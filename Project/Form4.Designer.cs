
namespace Pro_1
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeThisProgrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("OCR A Extended", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(112, 118);
            this.textBox1.MaxLength = 30;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(393, 35);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "ENTER YOUR E-MAIL";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("OCR A Extended", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(210, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Change password";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("OCR A Extended", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Gray;
            this.textBox2.Location = new System.Drawing.Point(113, 241);
            this.textBox2.MaxLength = 15;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(393, 35);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "ENTER YOUR SECRET";
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("OCR A Extended", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Gray;
            this.textBox3.Location = new System.Drawing.Point(112, 305);
            this.textBox3.MaxLength = 15;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(393, 35);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "NEW PASSWORD";
            this.textBox3.Enter += new System.EventHandler(this.textBox3_Enter);
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("OCR A Extended", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.Gray;
            this.textBox4.Location = new System.Drawing.Point(112, 375);
            this.textBox4.MaxLength = 15;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(393, 35);
            this.textBox4.TabIndex = 0;
            this.textBox4.Text = "CONFIRM PASSWORD";
            this.textBox4.Enter += new System.EventHandler(this.textBox4_Enter);
            this.textBox4.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "--SELECT YOUR QUESTION--",
            "ชื่อนักฟุตบอลที่ชอบ",
            "ชื่อโรงเรียนมัธยม",
            "ชื่อแม่ของคุณ"});
            this.comboBox1.Location = new System.Drawing.Point(112, 182);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(393, 33);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "เลือกคำถามลับของคุณ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeThisProgrameToolStripMenuItem,
            this.backToLoginToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(620, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeThisProgrameToolStripMenuItem
            // 
            this.closeThisProgrameToolStripMenuItem.Name = "closeThisProgrameToolStripMenuItem";
            this.closeThisProgrameToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.closeThisProgrameToolStripMenuItem.Text = "Close this programe";
            this.closeThisProgrameToolStripMenuItem.Click += new System.EventHandler(this.closeThisProgrameToolStripMenuItem_Click);
            // 
            // backToLoginToolStripMenuItem
            // 
            this.backToLoginToolStripMenuItem.Name = "backToLoginToolStripMenuItem";
            this.backToLoginToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.backToLoginToolStripMenuItem.Text = "Back to login";
            this.backToLoginToolStripMenuItem.Click += new System.EventHandler(this.backToLoginToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(126, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(368, 41);
            this.label2.TabIndex = 5;
            this.label2.Text = "RESET PASSWORD";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(620, 537);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form4";
            this.Text = "Resetpassword";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeThisProgrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToLoginToolStripMenuItem;
        private System.Windows.Forms.Label label2;
    }
}