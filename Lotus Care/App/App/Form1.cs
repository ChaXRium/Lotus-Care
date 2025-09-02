using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Enable DPI scaling for this form
            this.AutoScaleMode = AutoScaleMode.Dpi;

            // Connect Paint event
            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int radius = 30; // corner radius
            Rectangle rect = panel1.ClientRectangle;

            using (GraphicsPath path = new GraphicsPath())
            {
                // Rounded rectangle corners
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);  // Top-left
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Top-right
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Bottom-right
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Bottom-left

                path.CloseFigure();

                // Apply rounded region
                panel1.Region = new Region(path);

                // Enable high-quality rendering
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Optional: draw border
                using (Pen pen = new Pen(Color.DarkGray, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            this.Hide();
            registerForm.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
