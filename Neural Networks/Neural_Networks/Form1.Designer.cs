namespace Neural_Networks
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSLSN = new System.Windows.Forms.Button();
            this.btnSLMN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSLSN
            // 
            this.btnSLSN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSLSN.Location = new System.Drawing.Point(12, 54);
            this.btnSLSN.Name = "btnSLSN";
            this.btnSLSN.Size = new System.Drawing.Size(241, 58);
            this.btnSLSN.TabIndex = 0;
            this.btnSLSN.Text = "Single Layer Single Neuron";
            this.btnSLSN.UseVisualStyleBackColor = true;
            this.btnSLSN.Click += new System.EventHandler(this.btnSLSN_Click);
            // 
            // btnSLMN
            // 
            this.btnSLMN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSLMN.Location = new System.Drawing.Point(259, 54);
            this.btnSLMN.Name = "btnSLMN";
            this.btnSLMN.Size = new System.Drawing.Size(241, 58);
            this.btnSLMN.TabIndex = 1;
            this.btnSLMN.Text = "Single Layer Multi Neuron";
            this.btnSLMN.UseVisualStyleBackColor = true;
            this.btnSLMN.Click += new System.EventHandler(this.btnSLMN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 174);
            this.Controls.Add(this.btnSLMN);
            this.Controls.Add(this.btnSLSN);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neural Networks";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnSLSN;
        private Button btnSLMN;
    }
}