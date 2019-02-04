namespace NewGRK_Admin
{
    partial class ChangeSettingsForm
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
            this.gbBD = new System.Windows.Forms.GroupBox();
            this.lblDBType = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.cmbDBType = new System.Windows.Forms.ComboBox();
            this.edtServer = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.edtLogin = new System.Windows.Forms.TextBox();
            this.edtPassword = new System.Windows.Forms.TextBox();
            this.gbDescription = new System.Windows.Forms.GroupBox();
            this.gbBD.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBD
            // 
            this.gbBD.Controls.Add(this.edtPassword);
            this.gbBD.Controls.Add(this.edtLogin);
            this.gbBD.Controls.Add(this.lblPassword);
            this.gbBD.Controls.Add(this.lblLogin);
            this.gbBD.Controls.Add(this.edtServer);
            this.gbBD.Controls.Add(this.cmbDBType);
            this.gbBD.Controls.Add(this.lblServer);
            this.gbBD.Controls.Add(this.lblDBType);
            this.gbBD.Location = new System.Drawing.Point(12, 12);
            this.gbBD.Name = "gbBD";
            this.gbBD.Size = new System.Drawing.Size(232, 143);
            this.gbBD.TabIndex = 0;
            this.gbBD.TabStop = false;
            this.gbBD.Text = "БД";
            // 
            // lblDBType
            // 
            this.lblDBType.AutoSize = true;
            this.lblDBType.Location = new System.Drawing.Point(6, 22);
            this.lblDBType.Margin = new System.Windows.Forms.Padding(3);
            this.lblDBType.Name = "lblDBType";
            this.lblDBType.Size = new System.Drawing.Size(45, 13);
            this.lblDBType.TabIndex = 0;
            this.lblDBType.Text = "Тип БД";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(6, 50);
            this.lblServer.Margin = new System.Windows.Forms.Padding(3);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(37, 13);
            this.lblServer.TabIndex = 1;
            this.lblServer.Text = "Стенд";
            // 
            // cmbDBType
            // 
            this.cmbDBType.FormattingEnabled = true;
            this.cmbDBType.Location = new System.Drawing.Point(57, 19);
            this.cmbDBType.Name = "cmbDBType";
            this.cmbDBType.Size = new System.Drawing.Size(121, 21);
            this.cmbDBType.TabIndex = 2;
            // 
            // edtServer
            // 
            this.edtServer.Location = new System.Drawing.Point(57, 47);
            this.edtServer.Name = "edtServer";
            this.edtServer.Size = new System.Drawing.Size(121, 20);
            this.edtServer.TabIndex = 3;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(54, 77);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(3);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(38, 13);
            this.lblLogin.TabIndex = 4;
            this.lblLogin.Text = "Логин";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(54, 104);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(3);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(45, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Пароль";
            // 
            // edtLogin
            // 
            this.edtLogin.Location = new System.Drawing.Point(106, 74);
            this.edtLogin.Name = "edtLogin";
            this.edtLogin.Size = new System.Drawing.Size(100, 20);
            this.edtLogin.TabIndex = 6;
            // 
            // edtPassword
            // 
            this.edtPassword.Location = new System.Drawing.Point(106, 101);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.PasswordChar = '*';
            this.edtPassword.Size = new System.Drawing.Size(100, 20);
            this.edtPassword.TabIndex = 7;
            this.edtPassword.UseSystemPasswordChar = true;
            // 
            // gbDescription
            // 
            this.gbDescription.Location = new System.Drawing.Point(12, 161);
            this.gbDescription.Name = "gbDescription";
            this.gbDescription.Size = new System.Drawing.Size(232, 100);
            this.gbDescription.TabIndex = 1;
            this.gbDescription.TabStop = false;
            this.gbDescription.Text = "Описание";
            // 
            // ChangeSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbDescription);
            this.Controls.Add(this.gbBD);
            this.Name = "ChangeSettingsForm";
            this.Text = "Настройки изменения";
            this.gbBD.ResumeLayout(false);
            this.gbBD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBD;
        private System.Windows.Forms.TextBox edtPassword;
        private System.Windows.Forms.TextBox edtLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox edtServer;
        private System.Windows.Forms.ComboBox cmbDBType;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblDBType;
        private System.Windows.Forms.GroupBox gbDescription;
    }
}