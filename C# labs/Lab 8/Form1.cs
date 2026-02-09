namespace Lab_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void companyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormatDialog dlg = new FormatDialog();
            // الcurrent values
            dlg.LoadCurrentSettings(lblCompanyName.Text, lblCompanyName.Font, lblCompanyName.ForeColor);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lblCompanyName.Text = dlg.NewTextValue;
                lblCompanyName.ForeColor = dlg.SelectedColor;
                lblCompanyName.Font = new Font(dlg.SelectedFontName, dlg.SelectedFontSize);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
