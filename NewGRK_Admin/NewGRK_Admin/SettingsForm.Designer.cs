namespace NewGRK_Admin
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.edtUserName = new System.Windows.Forms.TextBox();
            this.lblDevDirectory = new System.Windows.Forms.Label();
            this.edtDevDirectory = new System.Windows.Forms.TextBox();
            this.btnSelDevDirectory = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(14, 16);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(103, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Имя пользователя";
            // 
            // edtUserName
            // 
            this.edtUserName.Location = new System.Drawing.Point(208, 13);
            this.edtUserName.Name = "edtUserName";
            this.edtUserName.Size = new System.Drawing.Size(133, 20);
            this.edtUserName.TabIndex = 1;
            // 
            // lblDevDirectory
            // 
            this.lblDevDirectory.AutoSize = true;
            this.lblDevDirectory.Location = new System.Drawing.Point(14, 43);
            this.lblDevDirectory.Name = "lblDevDirectory";
            this.lblDevDirectory.Size = new System.Drawing.Size(187, 13);
            this.lblDevDirectory.TabIndex = 2;
            this.lblDevDirectory.Text = "Директория сохранения доработок";
            // 
            // edtDevDirectory
            // 
            this.edtDevDirectory.Location = new System.Drawing.Point(208, 40);
            this.edtDevDirectory.Name = "edtDevDirectory";
            this.edtDevDirectory.Size = new System.Drawing.Size(133, 20);
            this.edtDevDirectory.TabIndex = 3;
            // 
            // btnSelDevDirectory
            // 
            this.btnSelDevDirectory.Location = new System.Drawing.Point(348, 40);
            this.btnSelDevDirectory.Name = "btnSelDevDirectory";
            this.btnSelDevDirectory.Size = new System.Drawing.Size(25, 20);
            this.btnSelDevDirectory.TabIndex = 4;
            this.btnSelDevDirectory.Text = "...";
            this.btnSelDevDirectory.UseVisualStyleBackColor = true;
            this.btnSelDevDirectory.Click += new System.EventHandler(this.btnSelDevDirectory_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(309, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(228, 87);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 122);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelDevDirectory);
            this.Controls.Add(this.edtDevDirectory);
            this.Controls.Add(this.lblDevDirectory);
            this.Controls.Add(this.edtUserName);
            this.Controls.Add(this.lblUserName);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox edtUserName;
        private System.Windows.Forms.Label lblDevDirectory;
        private System.Windows.Forms.TextBox edtDevDirectory;
        private System.Windows.Forms.Button btnSelDevDirectory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}