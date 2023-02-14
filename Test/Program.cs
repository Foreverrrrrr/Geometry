using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Geometry.Geometry;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Point2D p0 = new Geometry.Geometry.Point2D(0, 0);
            Point2D p1 = new Geometry.Geometry.Point2D(0, -10);
            Point2D p2 = new Geometry.Geometry.Point2D(10, 0);
            Point2D p3 = new Geometry.Geometry.Point2D(10, -10);
            Matrix matrix = DefiniteProportionSetPoint(p0, p1, p2, p3, 5, 3);
            var a = MatrixLoadMaterial(matrix, Load.Snake, 5, 0);
            //MatrixLoadMaterial(matrix, Load.Snake, 10, 2);
        }
    }
}
