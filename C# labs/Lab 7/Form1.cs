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
            int chartX = 30;  // اليسار
            int chartY = 120; // أعلى
            int chartWidth = 350;
            int chartHeight = 400;
            // قلم أسود للمحاور
            Pen axisPen = new Pen(Color.Black, 2);

            // Y-axis
            e.Graphics.DrawLine(axisPen, chartX, chartY, chartX, chartY + chartHeight);
            // X-axis
            e.Graphics.DrawLine(axisPen, chartX, chartY + chartHeight, chartX + chartWidth, chartY + chartHeight);

            int maxRevenue = revenues.Max(); // 280
            float scaleY = (float)chartHeight / maxRevenue;

            int barWidth = 20;
            int gap = 15; // المسافة بين الأعمدة

            for (int i = 0; i < years.Length; i++)
            {
                int x = chartX + gap + i * (barWidth + gap);
                int y = chartY + chartHeight - (int)(revenues[i] * scaleY); // من الأسفل للأعلى
                int height = (int)(revenues[i] * scaleY);

                // قلم فرشاة Hatch
                HatchBrush brush2 = new HatchBrush(HatchStyle.ForwardDiagonal, Color.Red, Color.White);
                e.Graphics.FillRectangle(brush2, x, y, barWidth, height);
                e.Graphics.DrawRectangle(Pens.Black, x, y, barWidth, height); // حدود العمود
            }

            Pen linePen = new Pen(Color.Blue, 2);

            for (int i = 0; i < years.Length - 1; i++)
            {
                int x1 = chartX + gap + i * (barWidth + gap) + barWidth / 2;
                int y1 = chartY + chartHeight - (int)(revenues[i] * scaleY);

                int x2 = chartX + gap + (i + 1) * (barWidth + gap) + barWidth / 2;
                int y2 = chartY + chartHeight - (int)(revenues[i + 1] * scaleY);

                e.Graphics.DrawLine(linePen, x1, y1, x2, y2);
            }

            Font font = new Font("Arial", 9);
            for (int i = 0; i < years.Length; i++)
            {
                int x = chartX + gap + i * (barWidth + gap) + barWidth / 2 - 10;
                int y = chartY + chartHeight + 5;
                e.Graphics.DrawString(years[i].ToString(), font, Brushes.Black, x, y);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
