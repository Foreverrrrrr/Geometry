
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Geometry.Geometry;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point2D p0;
        Point2D p1;
        Point2D p2;
        Point2D p3;
        public Form1()
        {
            InitializeComponent();
            p0 = new Point2D(0, 0);
            p1 = new Point2D(0, 100);
            p2 = new Point2D(100, 0);
            p3 = new Point2D(100, 100);
            double[] doubles = new double[1000];
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                doubles[i] = random.NextDouble() * random.Next(15, 1000);

            }
            var t = SampleMode(doubles);
            //p0 = new Point2D(16.8484, 6.9094);
            //p1 = new Point2D(16.8484, 14.0852);
            //p2 = new Point2D(10.2812, 6.9094);
            //p3 = new Point2D(10.2812, 14.0198);
            Matrix matrix = DefiniteProportionSetPoint(p0, p1, p2, p3, 4, 5);
            pt = MatrixLoadMaterial(matrix, Geometry.Geometry.Load.Snake, 20, 0);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Point2D p0 = new Geometry.Geometry.Point2D(0, 0);
            //Point2D p1 = new Geometry.Geometry.Point2D(0, -10);
            //Point2D p2 = new Geometry.Geometry.Point2D(10, 0);
            //Point2D p3 = new Geometry.Geometry.Point2D(10, -10);
            //Matrix matrix = DefiniteProportionSetPoint(p0, p1, p2, p3, 5, 3);
            //var a = MatrixLoadMaterial(matrix, Load.Snake, 5, 0);
            g = e.Graphics;
            int a = 100;
            SolidBrush b1 = new SolidBrush(Color.Blue);//定义单色画刷 
            Pen t = new Pen(Color.Red, 2);
            Pen p = new Pen(Color.Blue, 2);
            g.TranslateTransform(-300, -300);
            g.DrawLine(t, (float)p0.X * a, (float)p0.Y * a, (float)p1.X * a, (float)p1.Y * a);
            g.DrawLine(t, (float)p2.X * a, (float)p2.Y * a, (float)p3.X * a, (float)p3.Y * a);
            if (pt?.Length > 0)
            {
                for (int i = 0; i < pt.Length; i++)
                {
                    if (i == pt.Length - 1)
                    {
                        g.DrawString(pt[i].X * a + "-" + pt[i].Y * a + "-" + i, new Font("宋体", 10), b1, Convert.ToSingle(pt[i].X) * a, Convert.ToSingle(pt[i].Y) * a);

                        return;
                    }


                    g.DrawLine(p, Convert.ToSingle(pt[i].X) * a, Convert.ToSingle(pt[i].Y) * a, Convert.ToSingle(pt[i + 1].X) * a, Convert.ToSingle(pt[i + 1].Y) * a);
                    g.DrawString(pt[i].X * a + "-" + pt[i].Y * a + "-" + i, new Font("宋体", 10), b1, Convert.ToSingle(pt[i].X) * a, Convert.ToSingle(pt[i].Y) * a);
                }
            }

        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {

        }

        static Point2D[] pt;
        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
