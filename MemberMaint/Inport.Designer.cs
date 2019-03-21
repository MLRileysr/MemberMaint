namespace MemberMaint
{
    partial class Inport
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
            this.btnStartInp = new System.Windows.Forms.Button();
            this.lablCount = new System.Windows.Forms.Label();
            this.btnEnd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartInp
            // 
            this.btnStartInp.Location = new System.Drawing.Point(45, 21);
            this.btnStartInp.Name = "btnStartInp";
            this.btnStartInp.Size = new System.Drawing.Size(161, 54);
            this.btnStartInp.TabIndex = 0;
            this.btnStartInp.Text = "Start Inport";
            this.btnStartInp.UseVisualStyleBackColor = true;
            this.btnStartInp.Click += new System.EventHandler(this.btnStartInp_Click);
            // 
            // lablCount
            // 
            this.lablCount.AutoSize = true;
            this.lablCount.Location = new System.Drawing.Point(422, 247);
            this.lablCount.Name = "lablCount";
            this.lablCount.Size = new System.Drawing.Size(0, 13);
            this.lablCount.TabIndex = 1;
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(45, 97);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(161, 54);
            this.btnEnd.TabIndex = 2;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Count of Records loaded";
            // 
            // Inport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.lablCount);
            this.Controls.Add(this.btnStartInp);
            this.Name = "Inport";
            this.Text = "Inport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartInp;
        private System.Windows.Forms.Label lablCount;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Label label1;
    }
}