using System.Drawing.Drawing2D;

namespace Lab_7
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
             g = e.Graphics;
            // العناوين
            Font companyFont = new Font("Arial", 20, FontStyle.Bold);
            Font titleFont = new Font("Arial", 14, FontStyle.Regular);
            Brush brush1 = Brushes.Black;
            g.DrawString("ABC Company", companyFont, brush1, new PointF(250, 30));
            g.DrawString("Annual Revenue", titleFont, brush1, new PointF(270, 70));

            // الجدول
            int tableX = 400;
            int tableY = 120;
            int tableWidth = 350;
            int tableHeight = 400;

            Pen pen = new Pen(Color.Black, 2);
            g.DrawRectangle(pen, tableX, tableY, tableWidth, tableHeight);

            // تقسيم الجدول من النص
            int columnX = tableX + (tableWidth / 2);

            g.DrawLine(
                pen,
                columnX,
                tableY,
                columnX,
                tableY + tableHeight
            );

            // تقسيم الجدول بالعرض
            int rowCount = 11;
            int rowHeight = tableHeight / rowCount;

            for (int i = 1; i < rowCount; i++)
            {
                int y = tableY + i * rowHeight;
                g.DrawLine(pen, tableX, y, tableX + tableWidth, y);
            }

            //الداتا بتاعت الجدول
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font dataFont = new Font("Arial", 12, FontStyle.Regular);
            Brush brush = Brushes.Black;

            g.DrawString("Year", headerFont, brush, new PointF(tableX + 10, tableY + 10));
            g.DrawString("Revenue", headerFont, brush, new PointF(columnX + 10, tableY + 10));

            int[] years = { 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997 };
            int[] revenues = { 150, 170, 180, 175, 200, 250, 210, 240, 280, 140 };

            for (int i = 0; i < years.Length; i++)
            {
                int yPosition = tableY + (i + 1) * rowHeight + 10; 
                g.DrawString(years[i].ToString(), dataFont, brush, new PointF(tableX + 10, yPosition));
                g.DrawString(revenues[i].ToString(), dataFont, brush, new PointF(columnX + 10, yPosition));
            }
            // تشارت
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
