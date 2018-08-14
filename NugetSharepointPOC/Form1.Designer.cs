namespace NugetSharepointPOC
{
    partial class Form1
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
            this.rb2010 = new System.Windows.Forms.RadioButton();
            this.rb2013 = new System.Windows.Forms.RadioButton();
            this.rbOnlineTest = new System.Windows.Forms.RadioButton();
            this.rbOnlineBizagi = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb2016 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.treeFolders = new System.Windows.Forms.TreeView();
            this.lblServerName = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.lblServerDesc = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.rb2007 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rb2010
            // 
            this.rb2010.AutoSize = true;
            this.rb2010.Location = new System.Drawing.Point(25, 54);
            this.rb2010.Name = "rb2010";
            this.rb2010.Size = new System.Drawing.Size(49, 17);
            this.rb2010.TabIndex = 1;
            this.rb2010.TabStop = true;
            this.rb2010.Text = "2010";
            this.rb2010.UseVisualStyleBackColor = true;
            this.rb2010.CheckedChanged += new System.EventHandler(this.rb2010_CheckedChanged);
            // 
            // rb2013
            // 
            this.rb2013.AutoSize = true;
            this.rb2013.Location = new System.Drawing.Point(25, 77);
            this.rb2013.Name = "rb2013";
            this.rb2013.Size = new System.Drawing.Size(49, 17);
            this.rb2013.TabIndex = 2;
            this.rb2013.TabStop = true;
            this.rb2013.Text = "2013";
            this.rb2013.UseVisualStyleBackColor = true;
            this.rb2013.CheckedChanged += new System.EventHandler(this.rb2013_CheckedChanged);
            // 
            // rbOnlineTest
            // 
            this.rbOnlineTest.AutoSize = true;
            this.rbOnlineTest.Location = new System.Drawing.Point(25, 123);
            this.rbOnlineTest.Name = "rbOnlineTest";
            this.rbOnlineTest.Size = new System.Drawing.Size(79, 17);
            this.rbOnlineTest.TabIndex = 3;
            this.rbOnlineTest.TabStop = true;
            this.rbOnlineTest.Text = "Online Test";
            this.rbOnlineTest.UseVisualStyleBackColor = true;
            this.rbOnlineTest.CheckedChanged += new System.EventHandler(this.rbOnlineTest_CheckedChanged);
            // 
            // rbOnlineBizagi
            // 
            this.rbOnlineBizagi.AutoSize = true;
            this.rbOnlineBizagi.Location = new System.Drawing.Point(25, 146);
            this.rbOnlineBizagi.Name = "rbOnlineBizagi";
            this.rbOnlineBizagi.Size = new System.Drawing.Size(86, 17);
            this.rbOnlineBizagi.TabIndex = 4;
            this.rbOnlineBizagi.TabStop = true;
            this.rbOnlineBizagi.Text = "Online Bizagi";
            this.rbOnlineBizagi.UseVisualStyleBackColor = true;
            this.rbOnlineBizagi.CheckedChanged += new System.EventHandler(this.rbOnlineBizagi_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "User:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password:";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(71, 54);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(217, 20);
            this.tbUser.TabIndex = 7;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(71, 85);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(217, 20);
            this.tbPass.TabIndex = 8;
            this.tbPass.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb2007);
            this.groupBox1.Controls.Add(this.rb2016);
            this.groupBox1.Controls.Add(this.rb2010);
            this.groupBox1.Controls.Add(this.rb2013);
            this.groupBox1.Controls.Add(this.rbOnlineBizagi);
            this.groupBox1.Controls.Add(this.rbOnlineTest);
            this.groupBox1.Location = new System.Drawing.Point(45, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 192);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sharepoint Versions:";
            // 
            // rb2016
            // 
            this.rb2016.AutoSize = true;
            this.rb2016.Location = new System.Drawing.Point(25, 100);
            this.rb2016.Name = "rb2016";
            this.rb2016.Size = new System.Drawing.Size(49, 17);
            this.rb2016.TabIndex = 5;
            this.rb2016.TabStop = true;
            this.rb2016.Text = "2016";
            this.rb2016.UseVisualStyleBackColor = true;
            this.rb2016.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbURL);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbPass);
            this.groupBox2.Controls.Add(this.tbUser);
            this.groupBox2.Location = new System.Drawing.Point(294, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 151);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Login:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(150, 111);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "URL:";
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(71, 26);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(217, 20);
            this.tbURL.TabIndex = 10;
            // 
            // treeFolders
            // 
            this.treeFolders.Location = new System.Drawing.Point(16, 82);
            this.treeFolders.Name = "treeFolders";
            this.treeFolders.Size = new System.Drawing.Size(521, 214);
            this.treeFolders.TabIndex = 11;
            this.treeFolders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFolders_NodeMouseClick);
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(13, 26);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(72, 13);
            this.lblServerName.TabIndex = 12;
            this.lblServerName.Text = "Server Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btnUpload);
            this.groupBox3.Controls.Add(this.lblServerDesc);
            this.groupBox3.Controls.Add(this.treeFolders);
            this.groupBox3.Controls.Add(this.lblServerName);
            this.groupBox3.Location = new System.Drawing.Point(45, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(552, 314);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server Info:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(399, 39);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 12;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lblServerDesc
            // 
            this.lblServerDesc.AutoSize = true;
            this.lblServerDesc.Location = new System.Drawing.Point(13, 49);
            this.lblServerDesc.Name = "lblServerDesc";
            this.lblServerDesc.Size = new System.Drawing.Size(97, 13);
            this.lblServerDesc.TabIndex = 13;
            this.lblServerDesc.Text = "Server Description:";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(624, 53);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(342, 471);
            this.textBoxLog.TabIndex = 14;
            // 
            // rb2007
            // 
            this.rb2007.AutoSize = true;
            this.rb2007.Location = new System.Drawing.Point(25, 31);
            this.rb2007.Name = "rb2007";
            this.rb2007.Size = new System.Drawing.Size(49, 17);
            this.rb2007.TabIndex = 6;
            this.rb2007.TabStop = true;
            this.rb2007.Text = "2007";
            this.rb2007.UseVisualStyleBackColor = true;
            this.rb2007.CheckedChanged += new System.EventHandler(this.rb2007_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 559);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb2010;
        private System.Windows.Forms.RadioButton rb2013;
        private System.Windows.Forms.RadioButton rbOnlineTest;
        private System.Windows.Forms.RadioButton rbOnlineBizagi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeFolders;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RadioButton rb2016;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblServerDesc;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.RadioButton rb2007;
    }
}

