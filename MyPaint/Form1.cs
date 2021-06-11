using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        private Color drawingColor = Color.Black;
        private decimal fontSize = 5;
        int x ;
        int y ;
        List<Graphics> graphics = new List<Graphics>();

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (e.Button == MouseButtons.Left)
            {
 
                Graphics gr = panel1.CreateGraphics();
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                Pen pen = new Pen(drawingColor, (float)fontSize);

                gr.DrawLine(pen, x, y, e.X, e.Y);

                graphics.Add(gr);
               
            }
                x = e.X;
                y = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                drawingColor = colorDialog.Color;
                if (drawingColor != Color.Black)
                    { button1.BackColor = drawingColor; }
                
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            fontSize = numericUpDown1.Value;
        }

        
        
    }
}
