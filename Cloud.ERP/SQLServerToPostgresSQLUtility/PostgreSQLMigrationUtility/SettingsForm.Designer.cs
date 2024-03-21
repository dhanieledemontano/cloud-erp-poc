﻿namespace PostgreSQLMigrationUtility
{
    partial class SettingsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPostgresPort = new System.Windows.Forms.TextBox();
            this.btnPostgresCon = new System.Windows.Forms.Button();
            this.txtPostgreSQLPassword = new System.Windows.Forms.TextBox();
            this.txtPostgreSQLUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPostgresSQL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSQLPort = new System.Windows.Forms.TextBox();
            this.btnSQLTest = new System.Windows.Forms.Button();
            this.txtSQLPassword = new System.Windows.Forms.TextBox();
            this.txtSQLUsername = new System.Windows.Forms.TextBox();
            this.txtSQLServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMigrationLocation = new System.Windows.Forms.TextBox();
            this.btnFolderBrowser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.simpleButton2);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 348);
            this.panel1.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(307, 317);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "&Close";
            this.simpleButton2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(226, 317);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "&Save";
            this.simpleButton1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPostgresPort);
            this.groupBox3.Controls.Add(this.btnPostgresCon);
            this.groupBox3.Controls.Add(this.txtPostgreSQLPassword);
            this.groupBox3.Controls.Add(this.txtPostgreSQLUsername);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtPostgresSQL);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(11, 200);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(373, 111);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PostgreSQL - Target";
            // 
            // txtPostgresPort
            // 
            this.txtPostgresPort.Location = new System.Drawing.Point(306, 22);
            this.txtPostgresPort.Name = "txtPostgresPort";
            this.txtPostgresPort.Size = new System.Drawing.Size(57, 20);
            this.txtPostgresPort.TabIndex = 2;
            this.txtPostgresPort.Text = "5432";
            this.txtPostgresPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPostgresCon
            // 
            this.btnPostgresCon.Location = new System.Drawing.Point(306, 46);
            this.btnPostgresCon.Name = "btnPostgresCon";
            this.btnPostgresCon.Size = new System.Drawing.Size(57, 23);
            this.btnPostgresCon.TabIndex = 4;
            this.btnPostgresCon.Text = "Test";
            this.btnPostgresCon.UseVisualStyleBackColor = true;
            this.btnPostgresCon.Click += new System.EventHandler(this.btnPostgresCon_Click);
            // 
            // txtPostgreSQLPassword
            // 
            this.txtPostgreSQLPassword.Location = new System.Drawing.Point(123, 74);
            this.txtPostgreSQLPassword.Name = "txtPostgreSQLPassword";
            this.txtPostgreSQLPassword.PasswordChar = '-';
            this.txtPostgreSQLPassword.Size = new System.Drawing.Size(177, 20);
            this.txtPostgreSQLPassword.TabIndex = 5;
            // 
            // txtPostgreSQLUsername
            // 
            this.txtPostgreSQLUsername.Location = new System.Drawing.Point(123, 48);
            this.txtPostgreSQLUsername.Name = "txtPostgreSQLUsername";
            this.txtPostgreSQLUsername.Size = new System.Drawing.Size(177, 20);
            this.txtPostgreSQLUsername.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Server";
            // 
            // txtPostgresSQL
            // 
            this.txtPostgresSQL.Location = new System.Drawing.Point(123, 22);
            this.txtPostgresSQL.Name = "txtPostgresSQL";
            this.txtPostgresSQL.Size = new System.Drawing.Size(177, 20);
            this.txtPostgresSQL.TabIndex = 1;
            this.txtPostgresSQL.Text = "localhost";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Password";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSQLPort);
            this.groupBox2.Controls.Add(this.btnSQLTest);
            this.groupBox2.Controls.Add(this.txtSQLPassword);
            this.groupBox2.Controls.Add(this.txtSQLUsername);
            this.groupBox2.Controls.Add(this.txtSQLServer);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(11, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 106);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SQL Server  - Source";
            // 
            // txtSQLPort
            // 
            this.txtSQLPort.Location = new System.Drawing.Point(306, 24);
            this.txtSQLPort.Name = "txtSQLPort";
            this.txtSQLPort.Size = new System.Drawing.Size(57, 20);
            this.txtSQLPort.TabIndex = 2;
            this.txtSQLPort.Text = "1433";
            this.txtSQLPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSQLTest
            // 
            this.btnSQLTest.Location = new System.Drawing.Point(306, 48);
            this.btnSQLTest.Name = "btnSQLTest";
            this.btnSQLTest.Size = new System.Drawing.Size(57, 23);
            this.btnSQLTest.TabIndex = 4;
            this.btnSQLTest.Text = "Test";
            this.btnSQLTest.UseVisualStyleBackColor = true;
            this.btnSQLTest.Click += new System.EventHandler(this.btnSQLTest_Click);
            // 
            // txtSQLPassword
            // 
            this.txtSQLPassword.Location = new System.Drawing.Point(123, 76);
            this.txtSQLPassword.Name = "txtSQLPassword";
            this.txtSQLPassword.PasswordChar = '-';
            this.txtSQLPassword.Size = new System.Drawing.Size(177, 20);
            this.txtSQLPassword.TabIndex = 5;
            // 
            // txtSQLUsername
            // 
            this.txtSQLUsername.Location = new System.Drawing.Point(123, 50);
            this.txtSQLUsername.Name = "txtSQLUsername";
            this.txtSQLUsername.Size = new System.Drawing.Size(177, 20);
            this.txtSQLUsername.TabIndex = 3;
            // 
            // txtSQLServer
            // 
            this.txtSQLServer.Location = new System.Drawing.Point(123, 24);
            this.txtSQLServer.Name = "txtSQLServer";
            this.txtSQLServer.Size = new System.Drawing.Size(177, 20);
            this.txtSQLServer.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Server";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMigrationLocation);
            this.groupBox1.Controls.Add(this.btnFolderBrowser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // txtMigrationLocation
            // 
            this.txtMigrationLocation.Location = new System.Drawing.Point(123, 29);
            this.txtMigrationLocation.Name = "txtMigrationLocation";
            this.txtMigrationLocation.Size = new System.Drawing.Size(177, 20);
            this.txtMigrationLocation.TabIndex = 1;
            // 
            // btnFolderBrowser
            // 
            this.btnFolderBrowser.Location = new System.Drawing.Point(306, 27);
            this.btnFolderBrowser.Name = "btnFolderBrowser";
            this.btnFolderBrowser.Size = new System.Drawing.Size(57, 23);
            this.btnFolderBrowser.TabIndex = 2;
            this.btnFolderBrowser.Text = "...";
            this.btnFolderBrowser.UseVisualStyleBackColor = true;
            this.btnFolderBrowser.Click += new System.EventHandler(this.btnFolderBrowser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Migration Location";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(398, 348);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Source Migration Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMigrationLocation;
        private System.Windows.Forms.Button btnFolderBrowser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPostgreSQLPassword;
        private System.Windows.Forms.TextBox txtPostgreSQLUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPostgresSQL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSQLPassword;
        private System.Windows.Forms.TextBox txtSQLUsername;
        private System.Windows.Forms.TextBox txtSQLServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPostgresCon;
        private System.Windows.Forms.Button btnSQLTest;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtSQLPort;
        private System.Windows.Forms.TextBox txtPostgresPort;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}