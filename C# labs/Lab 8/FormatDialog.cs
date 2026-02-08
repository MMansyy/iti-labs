using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab_8
{
    public partial class FormatDialog : Form
    {


        public string SelectedFontName { get; set; }


        public float SelectedFontSize { get; set; }

        public Color SelectedColor { get; set; }


        public string NewTextValue { get; set; }

        public FormatDialog()
        {
            InitializeComponent();
        }

        private void FormatDialog_Load(object sender, EventArgs e)
        {

        }

        public void LoadCurrentSettings(string name, Font currentFont, Color currentColor)
        {
            txtOldValue.Text = name;
            txtNewValue.Text = name; 

            if (currentFont.Name == "Times New Roman") rbTimes.Checked = true;
            else if (currentFont.Name == "Arial") rbArial.Checked = true;
            else if (currentFont.Name == "Courier") rbCourier.Checked = true;

            if (currentFont.Size == 16) rbSize16.Checked = true;
            else if (currentFont.Size == 20) rbSize20.Checked = true;
            else if (currentFont.Size == 24) rbSize24.Checked = true;

            this.SelectedColor = currentColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbTimes.Checked) SelectedFontName = "Times New Roman";
            else if (rbArial.Checked) SelectedFontName = "Arial";
            else SelectedFontName = "Courier"; 

            if (rbSize16.Checked) SelectedFontSize = 16;
            else if (rbSize20.Checked) SelectedFontSize = 20;
            else if (rbSize24.Checked) SelectedFontSize = 24;

            if (txtNewValue.Text == "")
            {
                NewTextValue = txtOldValue.Text;
            }
            else
            {
                NewTextValue = txtNewValue.Text;
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtNewValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.SelectedColor = colorDialog1.Color;
            }
        }
    }
}
