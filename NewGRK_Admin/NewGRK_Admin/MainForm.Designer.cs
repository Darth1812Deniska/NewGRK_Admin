namespace NewGRK_Admin
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateObject = new System.Windows.Forms.Button();
            this.btnEditObject = new System.Windows.Forms.Button();
            this.btnEtc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateObject
            // 
            this.btnCreateObject.Location = new System.Drawing.Point(12, 12);
            this.btnCreateObject.Name = "btnCreateObject";
            this.btnCreateObject.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCreateObject.Size = new System.Drawing.Size(100, 100);
            this.btnCreateObject.TabIndex = 0;
            this.btnCreateObject.Text = "Создать объект";
            this.btnCreateObject.UseVisualStyleBackColor = true;
            // 
            // btnEditObject
            // 
            this.btnEditObject.Location = new System.Drawing.Point(118, 12);
            this.btnEditObject.Name = "btnEditObject";
            this.btnEditObject.Size = new System.Drawing.Size(100, 100);
            this.btnEditObject.TabIndex = 1;
            this.btnEditObject.Text = "Изменить объект";
            this.btnEditObject.UseVisualStyleBackColor = true;
            // 
            // btnEtc
            // 
            this.btnEtc.Location = new System.Drawing.Point(224, 12);
            this.btnEtc.Name = "btnEtc";
            this.btnEtc.Size = new System.Drawing.Size(100, 100);
            this.btnEtc.TabIndex = 2;
            this.btnEtc.Text = "Прочее";
            this.btnEtc.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 386);
            this.Controls.Add(this.btnEtc);
            this.Controls.Add(this.btnEditObject);
            this.Controls.Add(this.btnCreateObject);
            this.Name = "MainForm";
            this.Text = "New GRK_Admin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateObject;
        private System.Windows.Forms.Button btnEditObject;
        private System.Windows.Forms.Button btnEtc;
    }
}

