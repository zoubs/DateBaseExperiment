namespace StudentManager
{
    partial class MillonTest
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
            this.buttoninsert = new System.Windows.Forms.Button();
            this.buttondelete = new System.Windows.Forms.Button();
            this.textBoxSno = new System.Windows.Forms.TextBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonselect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttoninsert
            // 
            this.buttoninsert.Enabled = false;
            this.buttoninsert.Location = new System.Drawing.Point(81, 33);
            this.buttoninsert.Name = "buttoninsert";
            this.buttoninsert.Size = new System.Drawing.Size(100, 37);
            this.buttoninsert.TabIndex = 6;
            this.buttoninsert.Text = "导入";
            this.buttoninsert.UseVisualStyleBackColor = true;
            this.buttoninsert.Click += new System.EventHandler(this.buttoninsert_Click);
            // 
            // buttondelete
            // 
            this.buttondelete.Location = new System.Drawing.Point(528, 190);
            this.buttondelete.Name = "buttondelete";
            this.buttondelete.Size = new System.Drawing.Size(100, 42);
            this.buttondelete.TabIndex = 0;
            this.buttondelete.Text = "删除";
            this.buttondelete.UseVisualStyleBackColor = true;
            this.buttondelete.Click += new System.EventHandler(this.buttondelete_Click);
            // 
            // textBoxSno
            // 
            this.textBoxSno.Location = new System.Drawing.Point(148, 101);
            this.textBoxSno.Name = "textBoxSno";
            this.textBoxSno.Size = new System.Drawing.Size(213, 28);
            this.textBoxSno.TabIndex = 1;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(481, 101);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(213, 28);
            this.textBoxTime.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(411, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "耗时";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "学号";
            // 
            // buttonselect
            // 
            this.buttonselect.Location = new System.Drawing.Point(164, 190);
            this.buttonselect.Name = "buttonselect";
            this.buttonselect.Size = new System.Drawing.Size(100, 41);
            this.buttonselect.TabIndex = 5;
            this.buttonselect.Text = "查询";
            this.buttonselect.UseVisualStyleBackColor = true;
            this.buttonselect.Click += new System.EventHandler(this.buttonselect_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonselect);
            this.panel1.Controls.Add(this.buttondelete);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 415);
            this.panel1.TabIndex = 7;
            // 
            // MillonTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttoninsert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.textBoxSno);
            this.Controls.Add(this.panel1);
            this.Name = "MillonTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "百万数据测试";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttondelete;
        private System.Windows.Forms.TextBox textBoxSno;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonselect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttoninsert;
    }
}