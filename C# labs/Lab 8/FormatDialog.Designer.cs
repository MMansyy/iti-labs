namespace Lab_8
{
    partial class FormatDialog
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox1 = new GroupBox();
            rbCourier = new RadioButton();
            rbArial = new RadioButton();
            rbTimes = new RadioButton();
            tabPage2 = new TabPage();
            btnSelectColor = new Button();
            tabPage3 = new TabPage();
            groupBox2 = new GroupBox();
            rbSize16 = new RadioButton();
            rbSize20 = new RadioButton();
            rbSize24 = new RadioButton();
            tabPage4 = new TabPage();
            label2 = new Label();
            label1 = new Label();
            txtNewValue = new TextBox();
            txtOldValue = new TextBox();
            button1 = new Button();
            button2 = new Button();
            colorDialog1 = new ColorDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(0, -1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(584, 258);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(576, 225);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Font";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbCourier);
            groupBox1.Controls.Add(rbArial);
            groupBox1.Controls.Add(rbTimes);
            groupBox1.Location = new Point(37, 34);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(530, 114);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Font Style";
            // 
            // rbCourier
            // 
            rbCourier.AutoSize = true;
            rbCourier.Location = new Point(393, 54);
            rbCourier.Name = "rbCourier";
            rbCourier.Size = new Size(78, 24);
            rbCourier.TabIndex = 1;
            rbCourier.TabStop = true;
            rbCourier.Text = "Courier";
            rbCourier.UseVisualStyleBackColor = true;
            // 
            // rbArial
            // 
            rbArial.AutoSize = true;
            rbArial.Location = new Point(280, 54);
            rbArial.Name = "rbArial";
            rbArial.Size = new Size(61, 24);
            rbArial.TabIndex = 0;
            rbArial.TabStop = true;
            rbArial.Text = "Arial";
            rbArial.UseVisualStyleBackColor = true;
            // 
            // rbTimes
            // 
            rbTimes.AutoSize = true;
            rbTimes.Checked = true;
            rbTimes.Location = new Point(65, 54);
            rbTimes.Name = "rbTimes";
            rbTimes.Size = new Size(154, 24);
            rbTimes.TabIndex = 0;
            rbTimes.TabStop = true;
            rbTimes.Text = "Times New Roman";
            rbTimes.UseVisualStyleBackColor = true;
            rbTimes.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnSelectColor);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(576, 225);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Color";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSelectColor
            // 
            btnSelectColor.Location = new Point(179, 92);
            btnSelectColor.Name = "btnSelectColor";
            btnSelectColor.Size = new Size(194, 37);
            btnSelectColor.TabIndex = 0;
            btnSelectColor.Text = "Change Color";
            btnSelectColor.UseVisualStyleBackColor = true;
            btnSelectColor.Click += btnSelectColor_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox2);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(576, 225);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Size";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbSize16);
            groupBox2.Controls.Add(rbSize20);
            groupBox2.Controls.Add(rbSize24);
            groupBox2.Location = new Point(34, 28);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(530, 114);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Font Size";
            // 
            // rbSize16
            // 
            rbSize16.AutoSize = true;
            rbSize16.Location = new Point(207, 54);
            rbSize16.Name = "rbSize16";
            rbSize16.Size = new Size(46, 24);
            rbSize16.TabIndex = 1;
            rbSize16.TabStop = true;
            rbSize16.Text = "16";
            rbSize16.UseVisualStyleBackColor = true;
            // 
            // rbSize20
            // 
            rbSize20.AutoSize = true;
            rbSize20.Location = new Point(142, 54);
            rbSize20.Name = "rbSize20";
            rbSize20.Size = new Size(46, 24);
            rbSize20.TabIndex = 0;
            rbSize20.TabStop = true;
            rbSize20.Text = "20";
            rbSize20.UseVisualStyleBackColor = true;
            // 
            // rbSize24
            // 
            rbSize24.AutoSize = true;
            rbSize24.Checked = true;
            rbSize24.Location = new Point(65, 54);
            rbSize24.Name = "rbSize24";
            rbSize24.Size = new Size(46, 24);
            rbSize24.TabIndex = 0;
            rbSize24.TabStop = true;
            rbSize24.Text = "24";
            rbSize24.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(label2);
            tabPage4.Controls.Add(label1);
            tabPage4.Controls.Add(txtNewValue);
            tabPage4.Controls.Add(txtOldValue);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(576, 225);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Text";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 104);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 3;
            label2.Text = "New Text";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 11);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 2;
            label1.Text = "Old Text";
            // 
            // txtNewValue
            // 
            txtNewValue.Location = new Point(62, 127);
            txtNewValue.Multiline = true;
            txtNewValue.Name = "txtNewValue";
            txtNewValue.Size = new Size(438, 59);
            txtNewValue.TabIndex = 1;
            txtNewValue.TextChanged += txtNewValue_TextChanged;
            // 
            // txtOldValue
            // 
            txtOldValue.Location = new Point(62, 34);
            txtOldValue.Multiline = true;
            txtOldValue.Name = "txtOldValue";
            txtOldValue.ReadOnly = true;
            txtOldValue.Size = new Size(438, 54);
            txtOldValue.TabIndex = 0;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(199, 263);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "ok";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(299, 263);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // FormatDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 306);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormatDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormatDialog";
            Load += FormatDialog_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
        private RadioButton rbTimes;
        private RadioButton rbCourier;
        private RadioButton rbArial;
        private GroupBox groupBox2;
        private RadioButton rbSize16;
        private RadioButton rbSize20;
        private RadioButton rbSize24;
        private Button btnSelectColor;
        private TextBox txtNewValue;
        private TextBox txtOldValue;
        private ColorDialog colorDialog1;
        private Label label2;
        private Label label1;
    }
}