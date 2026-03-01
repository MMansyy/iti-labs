namespace Lab11
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
            dataView = new DataGridView();
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
            updateDbBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataView).BeginInit();
            SuspendLayout();
            // 
            // dataView
            // 
            dataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView.Location = new Point(520, 24);
            dataView.Name = "dataView";
            dataView.RowHeadersWidth = 51;
            dataView.Size = new Size(380, 305);
            dataView.TabIndex = 0;
            // 
            // displayBtn
            // 
            displayBtn.Location = new Point(383, 91);
            displayBtn.Name = "displayBtn";
            displayBtn.Size = new Size(94, 29);
            displayBtn.TabIndex = 1;
            displayBtn.Text = "Display";
            displayBtn.UseVisualStyleBackColor = true;
            displayBtn.Click += displayBtn_Click;
            // 
            // insertBtn
            // 
            insertBtn.Location = new Point(383, 139);
            insertBtn.Name = "insertBtn";
            insertBtn.Size = new Size(94, 29);
            insertBtn.TabIndex = 2;
            insertBtn.Text = "Insert";
            insertBtn.UseVisualStyleBackColor = true;
            insertBtn.Click += insertBtn_Click;
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(383, 190);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(94, 29);
            updateBtn.TabIndex = 3;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(383, 241);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(94, 29);
            deleteBtn.TabIndex = 4;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 151);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 5;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 199);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 6;
            label2.Text = "Department ID";
            // 
            // nameTxt
            // 
            nameTxt.Location = new Point(135, 144);
            nameTxt.Name = "nameTxt";
            nameTxt.Size = new Size(196, 27);
            nameTxt.TabIndex = 7;
            // 
            // deptTxt
            // 
            deptTxt.Location = new Point(135, 192);
            deptTxt.Name = "deptTxt";
            deptTxt.Size = new Size(196, 27);
            deptTxt.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 100);
            label3.Name = "label3";
            label3.Size = new Size(24, 20);
            label3.TabIndex = 9;
            label3.Text = "ID";
            // 
            // idTxt
            // 
            idTxt.Location = new Point(135, 93);
            idTxt.Name = "idTxt";
            idTxt.PlaceholderText = "use while update, delete, select";
            idTxt.Size = new Size(196, 27);
            idTxt.TabIndex = 10;
            // 
            // updateDbBtn
            // 
            updateDbBtn.Location = new Point(383, 286);
            updateDbBtn.Name = "updateDbBtn";
            updateDbBtn.Size = new Size(94, 29);
            updateDbBtn.TabIndex = 11;
            updateDbBtn.Text = "UpdateDB";
            updateDbBtn.UseVisualStyleBackColor = true;
            updateDbBtn.Click += updateDbBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 346);
            Controls.Add(updateDbBtn);
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
            Controls.Add(dataView);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataView;
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
        private Button updateDbBtn;
    }
}
