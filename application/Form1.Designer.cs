namespace Non_Existent_Data_LLM_Stress_Testing
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
            button1 = new Button();
            comboBox1 = new ComboBox();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            textBox1 = new TextBox();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            button3 = new Button();
            comboBox2 = new ComboBox();
            label5 = new Label();
            richTextBox2 = new RichTextBox();
            label6 = new Label();
            checkBox1 = new CheckBox();
            richTextBox3 = new RichTextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            comboBox3 = new ComboBox();
            checkBox2 = new CheckBox();
            numericUpDown2 = new NumericUpDown();
            label7 = new Label();
            button4 = new Button();
            numericUpDown3 = new NumericUpDown();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(713, 357);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Run";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(450, 62);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(450, 91);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(320, 96);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(358, 65);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 3;
            label1.Text = "Thinking Level:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(394, 94);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 4;
            label2.Text = "Prompt:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(468, 357);
            numericUpDown1.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(88, 415);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(700, 23);
            textBox1.TabIndex = 11;
            // 
            // button2
            // 
            button2.Location = new Point(7, 414);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 12;
            button2.Text = "Output";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(468, 383);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 1000003;
            label3.Text = "Current Test:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(547, 383);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 1000004;
            label4.Text = "0";
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(713, 386);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 10;
            button3.Text = "Stop";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(450, 33);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 1000005;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(400, 36);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 1000006;
            label5.Text = "Model:";
            // 
            // richTextBox2
            // 
            richTextBox2.Enabled = false;
            richTextBox2.Location = new Point(450, 193);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(320, 96);
            richTextBox2.TabIndex = 1000007;
            richTextBox2.Text = "";
            richTextBox2.TextChanged += richTextBox2_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(353, 196);
            label6.Name = "label6";
            label6.Size = new Size(91, 15);
            label6.TabIndex = 1000008;
            label6.Text = "System Prompt:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(450, 295);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(152, 19);
            checkBox1.TabIndex = 1000009;
            checkBox1.Text = "System Prompt Enabled";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(12, 91);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.ReadOnly = true;
            richTextBox3.Size = new Size(320, 198);
            richTextBox3.TabIndex = 1000012;
            richTextBox3.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(591, 65);
            label8.Name = "label8";
            label8.Size = new Size(52, 15);
            label8.TabIndex = 1000014;
            label8.Text = "Persona:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 73);
            label9.Name = "label9";
            label9.Size = new Size(85, 15);
            label9.TabIndex = 1000015;
            label9.Text = "Template Data:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(396, 359);
            label10.Name = "label10";
            label10.Size = new Size(66, 15);
            label10.TabIndex = 1000016;
            label10.Text = "Test Count:";
            // 
            // comboBox3
            // 
            comboBox3.Enabled = false;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(649, 62);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 1000010;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(12, 295);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(140, 19);
            checkBox2.TabIndex = 1000017;
            checkBox2.Text = "Persona Shift Enabled";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 1;
            numericUpDown2.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown2.Location = new Point(468, 328);
            numericUpDown2.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 1000018;
            numericUpDown2.Value = new decimal(new int[] { 7, 0, 0, 65536 });
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(386, 330);
            label7.Name = "label7";
            label7.Size = new Size(76, 15);
            label7.TabIndex = 1000019;
            label7.Text = "Temperature:";
            // 
            // button4
            // 
            button4.Location = new Point(12, 12);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 1000020;
            button4.Text = "Converse";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Increment = new decimal(new int[] { 1024, 0, 0, 0 });
            numericUpDown3.Location = new Point(668, 328);
            numericUpDown3.Maximum = new decimal(new int[] { 262144, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(120, 23);
            numericUpDown3.TabIndex = 1000021;
            numericUpDown3.Value = new decimal(new int[] { 1024, 0, 0, 0 });
            numericUpDown3.ValueChanged += numericUpDown3_ValueChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(610, 330);
            label11.Name = "label11";
            label11.Size = new Size(52, 15);
            label11.TabIndex = 1000022;
            label11.Text = "Context:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label11);
            Controls.Add(numericUpDown3);
            Controls.Add(button4);
            Controls.Add(label7);
            Controls.Add(numericUpDown2);
            Controls.Add(checkBox2);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(richTextBox3);
            Controls.Add(comboBox3);
            Controls.Add(checkBox1);
            Controls.Add(label6);
            Controls.Add(richTextBox2);
            Controls.Add(label5);
            Controls.Add(comboBox2);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox comboBox1;
        private RichTextBox richTextBox1;
        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private TextBox textBox1;
        private Button button2;
        private Label label3;
        private Label label4;
        private Button button3;
        private ComboBox comboBox2;
        private Label label5;
        private RichTextBox richTextBox2;
        private Label label6;
        private CheckBox checkBox1;
        private RichTextBox richTextBox3;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox comboBox3;
        private CheckBox checkBox2;
        private NumericUpDown numericUpDown2;
        private Label label7;
        private Button button4;
        private NumericUpDown numericUpDown3;
        private Label label11;
    }
}
