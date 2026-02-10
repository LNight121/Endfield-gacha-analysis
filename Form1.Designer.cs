namespace Endfield
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            maskedTextBox2 = new MaskedTextBox();
            maskedTextBox3 = new MaskedTextBox();
            maskedTextBox4 = new MaskedTextBox();
            maskedTextBox5 = new MaskedTextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 3;
            label1.Text = "当前抽数";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 93);
            label2.Name = "label2";
            label2.Size = new Size(136, 24);
            label2.TabIndex = 4;
            label2.Text = "当前小保底水位";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 139);
            label3.Name = "label3";
            label3.Size = new Size(110, 24);
            label3.TabIndex = 5;
            label3.Text = "目标UP数量";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 177);
            label4.Name = "label4";
            label4.Size = new Size(154, 24);
            label4.TabIndex = 7;
            label4.Text = "当前卡池赠送抽数";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("萝莉体 第二版", 18F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label5.Location = new Point(166, 252);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(0, 49);
            label5.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 51);
            label6.Name = "label6";
            label6.Size = new Size(136, 24);
            label6.TabIndex = 10;
            label6.Text = "当前大保底水位";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(166, 9);
            maskedTextBox1.Mask = "99";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(150, 32);
            maskedTextBox1.TabIndex = 11;
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Location = new Point(166, 47);
            maskedTextBox2.Mask = "999";
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(150, 32);
            maskedTextBox2.TabIndex = 12;
            // 
            // maskedTextBox3
            // 
            maskedTextBox3.Location = new Point(166, 90);
            maskedTextBox3.Mask = "99";
            maskedTextBox3.Name = "maskedTextBox3";
            maskedTextBox3.Size = new Size(150, 32);
            maskedTextBox3.TabIndex = 13;
            // 
            // maskedTextBox4
            // 
            maskedTextBox4.Location = new Point(166, 131);
            maskedTextBox4.Mask = "9";
            maskedTextBox4.Name = "maskedTextBox4";
            maskedTextBox4.Size = new Size(150, 32);
            maskedTextBox4.TabIndex = 14;
            // 
            // maskedTextBox5
            // 
            maskedTextBox5.Location = new Point(166, 174);
            maskedTextBox5.Mask = "99";
            maskedTextBox5.Name = "maskedTextBox5";
            maskedTextBox5.Size = new Size(150, 32);
            maskedTextBox5.TabIndex = 15;
            // 
            // button1
            // 
            button1.Location = new Point(166, 215);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 16;
            button1.Text = "开始计算";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(maskedTextBox5);
            Controls.Add(maskedTextBox4);
            Controls.Add(maskedTextBox3);
            Controls.Add(maskedTextBox2);
            Controls.Add(maskedTextBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox2;
        private MaskedTextBox maskedTextBox3;
        private MaskedTextBox maskedTextBox4;
        private MaskedTextBox maskedTextBox5;
        private Button button1;
    }
}
