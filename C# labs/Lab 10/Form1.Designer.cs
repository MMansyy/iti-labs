namespace Lab_10
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
            leftList = new ListBox();
            rigthList = new ListBox();
            leftTxt = new TextBox();
            rightTxt = new TextBox();
            btnMoveRight = new Button();
            btnMoveLeft = new Button();
            btnCopy = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // leftList
            // 
            leftList.FormattingEnabled = true;
            leftList.Location = new Point(42, 121);
            leftList.Name = "leftList";
            leftList.Size = new Size(341, 344);
            leftList.TabIndex = 0;
            // 
            // rigthList
            // 
            rigthList.FormattingEnabled = true;
            rigthList.Location = new Point(538, 121);
            rigthList.Name = "rigthList";
            rigthList.Size = new Size(341, 344);
            rigthList.TabIndex = 1;
            // 
            // leftTxt
            // 
            leftTxt.Location = new Point(42, 68);
            leftTxt.Name = "leftTxt";
            leftTxt.ReadOnly = true;
            leftTxt.Size = new Size(341, 27);
            leftTxt.TabIndex = 2;
            // 
            // rightTxt
            // 
            rightTxt.Location = new Point(538, 68);
            rightTxt.Name = "rightTxt";
            rightTxt.ReadOnly = true;
            rightTxt.Size = new Size(341, 27);
            rightTxt.TabIndex = 3;
            // 
            // btnMoveRight
            // 
            btnMoveRight.Location = new Point(399, 148);
            btnMoveRight.Name = "btnMoveRight";
            btnMoveRight.Size = new Size(124, 41);
            btnMoveRight.TabIndex = 4;
            btnMoveRight.Text = ">";
            btnMoveRight.UseVisualStyleBackColor = true;
            // 
            // btnMoveLeft
            // 
            btnMoveLeft.Location = new Point(399, 215);
            btnMoveLeft.Name = "btnMoveLeft";
            btnMoveLeft.Size = new Size(124, 41);
            btnMoveLeft.TabIndex = 5;
            btnMoveLeft.Text = "<";
            btnMoveLeft.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(399, 282);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(124, 41);
            btnCopy.TabIndex = 6;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(399, 351);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(124, 41);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(399, 424);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(124, 41);
            btnBack.TabIndex = 8;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 537);
            Controls.Add(btnBack);
            Controls.Add(btnDelete);
            Controls.Add(btnCopy);
            Controls.Add(btnMoveLeft);
            Controls.Add(btnMoveRight);
            Controls.Add(rightTxt);
            Controls.Add(leftTxt);
            Controls.Add(rigthList);
            Controls.Add(leftList);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox leftList;
        private ListBox rigthList;
        private TextBox leftTxt;
        private TextBox rightTxt;
        private Button btnMoveRight;
        private Button btnMoveLeft;
        private Button btnCopy;
        private Button btnDelete;
        private Button btnBack;
    }
}
