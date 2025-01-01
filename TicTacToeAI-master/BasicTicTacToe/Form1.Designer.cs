namespace TicTacToeAI
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            button10 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button10);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.ForeColor = Color.Cyan;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 426);
            panel1.TabIndex = 0;
            // 
            // button10
            // 
            button10.ForeColor = Color.Black;
            button10.Location = new Point(22, 279);
            button10.Name = "button10";
            button10.Size = new Size(160, 71);
            button10.TabIndex = 9;
            button10.Text = "Solve";
            button10.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.ForeColor = Color.Black;
            button7.Location = new Point(22, 177);
            button7.Name = "button7";
            button7.Size = new Size(77, 71);
            button7.TabIndex = 8;
            button7.Text = "h";
            button7.UseVisualStyleBackColor = true;
            button7.Click += Button_Click;
            // 
            // button8
            // 
            button8.ForeColor = Color.Black;
            button8.Location = new Point(105, 177);
            button8.Name = "button8";
            button8.Size = new Size(77, 71);
            button8.TabIndex = 7;
            button8.Text = "h";
            button8.UseVisualStyleBackColor = true;
            button8.Click += Button_Click;
            // 
            // button9
            // 
            button9.ForeColor = Color.Black;
            button9.Location = new Point(188, 177);
            button9.Name = "button9";
            button9.Size = new Size(77, 71);
            button9.TabIndex = 6;
            button9.Text = "h";
            button9.UseVisualStyleBackColor = true;
            button9.Click += Button_Click;
            // 
            // button4
            // 
            button4.ForeColor = Color.Black;
            button4.Location = new Point(22, 100);
            button4.Name = "button4";
            button4.Size = new Size(77, 71);
            button4.TabIndex = 5;
            button4.Text = "h";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Button_Click;
            // 
            // button5
            // 
            button5.ForeColor = Color.Black;
            button5.Location = new Point(105, 100);
            button5.Name = "button5";
            button5.Size = new Size(77, 71);
            button5.TabIndex = 4;
            button5.Text = "h";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Button_Click;
            // 
            // button6
            // 
            button6.ForeColor = Color.Black;
            button6.Location = new Point(188, 100);
            button6.Name = "button6";
            button6.Size = new Size(77, 71);
            button6.TabIndex = 3;
            button6.Text = "h";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Button_Click;
            // 
            // button3
            // 
            button3.ForeColor = Color.Black;
            button3.Location = new Point(188, 23);
            button3.Name = "button3";
            button3.Size = new Size(77, 71);
            button3.TabIndex = 2;
            button3.Text = "h";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button_Click;
            // 
            // button2
            // 
            button2.ForeColor = Color.Black;
            button2.Location = new Point(105, 23);
            button2.Name = "button2";
            button2.Size = new Size(77, 71);
            button2.TabIndex = 1;
            button2.Text = "h";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button_Click;
            // 
            // button1
            // 
            button1.ForeColor = Color.Black;
            button1.Location = new Point(22, 23);
            button1.Name = "button1";
            button1.Size = new Size(77, 71);
            button1.TabIndex = 0;
            button1.Text = "h";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(308, 450);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button10;
        private Button button7;
        private Button button8;
        private Button button9;
        private System.Windows.Forms.Timer timer1;
    }
}
