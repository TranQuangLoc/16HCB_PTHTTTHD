namespace APP_VANTAY
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
            this.btn_quet = new System.Windows.Forms.Button();
            this.txt_ma = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_quet
            // 
            this.btn_quet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quet.Location = new System.Drawing.Point(370, 253);
            this.btn_quet.Name = "btn_quet";
            this.btn_quet.Size = new System.Drawing.Size(309, 85);
            this.btn_quet.TabIndex = 0;
            this.btn_quet.Text = "QUÉT";
            this.btn_quet.UseVisualStyleBackColor = true;
            this.btn_quet.Click += new System.EventHandler(this.btn_quet_Click);
            // 
            // txt_ma
            // 
            this.txt_ma.Location = new System.Drawing.Point(154, 131);
            this.txt_ma.Name = "txt_ma";
            this.txt_ma.Size = new System.Drawing.Size(708, 38);
            this.txt_ma.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 465);
            this.Controls.Add(this.txt_ma);
            this.Controls.Add(this.btn_quet);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_quet;
        private System.Windows.Forms.TextBox txt_ma;
    }
}

