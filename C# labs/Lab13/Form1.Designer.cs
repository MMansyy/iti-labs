using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Lab13
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
            displayBtn = new Button();
            insertBtn = new Button();
            updateBtn = new Button();
            deleteBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            nameTxt = new TextBox();
            deptTxt = new TextBox();
            label3 = new Label();
            idTxt = new TextBox();
            ConnectDB = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // displayBtn
            // 
            displayBtn.Enabled = false;
            displayBtn.Location = new Point(372, 71);
            displayBtn.Name = "displayBtn";
            displayBtn.Size = new Size(108, 29);
            displayBtn.TabIndex = 1;
            displayBtn.Text = "Display";
            displayBtn.UseVisualStyleBackColor = true;
            // 
            // insertBtn
            // 
            insertBtn.Enabled = false;
            insertBtn.Location = new Point(372, 119);
            insertBtn.Name = "insertBtn";
            insertBtn.Size = new Size(108, 29);
            insertBtn.TabIndex = 2;
            insertBtn.Text = "Insert";
            insertBtn.UseVisualStyleBackColor = true;
            // 
            // updateBtn
            // 
            updateBtn.Enabled = false;
            updateBtn.Location = new Point(372, 170);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(108, 29);
            updateBtn.TabIndex = 3;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            deleteBtn.Enabled = false;
            deleteBtn.Location = new Point(372, 221);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(108, 29);
            deleteBtn.TabIndex = 4;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 128);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 5;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 176);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 6;
            label2.Text = "Department ID";
            // 
            // nameTxt
            // 
            nameTxt.Enabled = false;
            nameTxt.Location = new Point(130, 121);
            nameTxt.Name = "nameTxt";
            nameTxt.PlaceholderText = "Enter your Name";
            nameTxt.Size = new Size(196, 27);
            nameTxt.TabIndex = 7;
            // 
            // deptTxt
            // 
            deptTxt.Enabled = false;
            deptTxt.Location = new Point(130, 169);
            deptTxt.Name = "deptTxt";
            deptTxt.PlaceholderText = "Enter Department ID";
            deptTxt.Size = new Size(196, 27);
            deptTxt.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 77);
            label3.Name = "label3";
            label3.Size = new Size(24, 20);
            label3.TabIndex = 9;
            label3.Text = "ID";
            // 
            // idTxt
            // 
            idTxt.Enabled = false;
            idTxt.Location = new Point(130, 70);
            idTxt.Name = "idTxt";
            idTxt.PlaceholderText = "use while update, delete, select";
            idTxt.Size = new Size(196, 27);
            idTxt.TabIndex = 10;
            // 
            // ConnectDB
            // 
            ConnectDB.Location = new Point(372, 266);
            ConnectDB.Name = "ConnectDB";
            ConnectDB.Size = new Size(108, 29);
            ConnectDB.TabIndex = 11;
            ConnectDB.Text = "Connect DB";
            ConnectDB.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.Font = new System.Drawing.Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.ForeColor = Color.SteelBlue;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(515, 30);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(380, 298);
            listBox1.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 358);
            Controls.Add(listBox1);
            Controls.Add(ConnectDB);
            Controls.Add(idTxt);
            Controls.Add(label3);
            Controls.Add(deptTxt);
            Controls.Add(nameTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(deleteBtn);
            Controls.Add(updateBtn);
            Controls.Add(insertBtn);
            Controls.Add(displayBtn);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button displayBtn;
        private Button insertBtn;
        private Button updateBtn;
        private Button deleteBtn;
        private Label label1;
        private Label label2;
        private TextBox nameTxt;
        private TextBox deptTxt;
        private Label label3;
        private TextBox idTxt;
        private Button ConnectDB;
        private ListBox listBox1;
    }
}
