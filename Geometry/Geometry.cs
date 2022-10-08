using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    /// <summary>
    /// 几何算法
    /// </summary>
    public static class Geometry
    {
        /// <summary>
        /// 倾斜角基准
        /// </summary>
        public enum AngleCriterion
        {
            /// <summary>
            /// 水平基准
            /// </summary>
            HorizontalLine,
            /// <summary>
            /// 垂直基准
            /// </summary>
            PerpendiCularLine
        }

        /// <summary>
        /// 平面直线坐标
        /// </summary>
        public struct Line2D
        {
            /// <summary>
            /// 平面直线坐标
            /// </summary>
            /// <param name="x1">线段起始X坐标</param>
            /// <param name="y1">线段起始Y坐标</param>
            /// <param name="x2">线段结束X坐标</param>
            /// <param name="y2">线段结束Y坐标</param>
            public Line2D(double x1, double y1, double x2, double y2)
            {
                _startx = 0;
                _starty = 0;
                _endx = 0;
                _endy = 0;
                StartX = x1;
                StartY = y1;
                EndX = x2;
                EndY = y2;
            }

            private double _startx;
            /// <summary>
            /// 直线起始X坐标
            /// </summary>
            public double StartX
            {
                get { return _startx; }
                set { _startx = value; }
            }

            private double _starty;
            /// <summary>
            /// 直线起始Y坐标
            /// </summary>
            public double StartY
            {
                get { return _starty; }
                set { _starty = value; }
            }

            private double _endx;
            /// <summary>
            /// 直线结束X坐标
            /// </summary>
            public double EndX
            {
                get { return _endx; }
                set { _endx = value; }
            }

            private double _endy;
            /// <summary>
            /// 直线结束Y坐标
            /// </summary>
            public double EndY
            {
                get { return _endy; }
                set { _endy = value; }
            }
        }

        /// <summary>
        /// 平面坐标
        /// </summary>
        public struct Point2D
        {
            /// <summary>
            /// 平面点位坐标
            /// </summary>
            /// <param name="x">X坐标值</param>
            /// <param name="y">Y坐标值</param>
            public Point2D(double x, double y)
            {
                _x = 0;
                _y = 0;
                this.X = x;
                this.Y = y;
            }

            private double _x;
            /// <summary>
            /// X坐标
            /// </summary>
            public double X
            {
                get { return _x; }
                set { _x = value; }
            }

            private double _y;
            /// <summary>
            /// Y坐标
            /// </summary>
            public double Y
            {
                get { return _y; }
                set { _y = value; }
            }
        }

        /// <summary>
        /// 空间坐标
        /// </summary>
        public struct Point3D
        {
            /// <summary>
            /// 空间坐标
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="z"></param>
            public Point3D(double x, double y, double z)
            {
                _x = 0;
                _y = 0;
                _z = 0;
                this.X = x;
                this.Y = y;
                this.Z = z;
            }

            private double _x;
            /// <summary>
            /// 空间X坐标
            /// </summary>
            public double X
            {
                get { return _x; }
                set { _x = value; }
            }

            private double _y;
            /// <summary>
            /// 空间Y坐标
            /// </summary>
            public double Y
            {
                get { return _y; }
                set { _y = value; }
            }

            private double _z;
            /// <summary>
            /// 空间Z坐标
            /// </summary>
            public double Z
            {
                get { return _z; }
                set { _z = value; }
            }
        }

        /// <summary>
        /// PID参数结构体
        /// </summary>
        public struct PIDHelper
        {
            /// <summary>
            /// PID参数初始化
            /// </summary>
            /// <param name="Kp">P比例值</param>
            /// <param name="Ki">I积分值</param>
            /// <param name="Kd">D微分值</param>
            /// <param name="DeadBand">死区宽度</param>
            /// <param name="MaxLimit">最大值限制</param>
            /// <param name="MinLimit">最小值限制</param>
            /// <param name="setvalue">目标值</param>
            public PIDHelper(double Kp, double Ki, double Kd, double DeadBand, double MaxLimit, double MinLimit,double setvalue)
            {
                prakp = Kp;
                praki = Ki;
                prakd = Kd;
                deadband = DeadBand;
                MAXLIM = MaxLimit;
                MINLIM = MinLimit;
                setValue = setvalue;
                err = 0;
                err_last=0;
                err_next = 0;

            }

            private double prakp;
            /// <summary>
            /// -rando
            /// 比例的参数信息
            /// </summary>
            public double Kp
            {
                set => this.prakp = value;
                get => this.prakp;
            }

            private double praki;
            /// <summary>积分的参数信息</summary>
            public double Ki
            {
                set => this.praki = value;
                get => this.praki;
            }

            private double prakd;
            /// <summary>微分的参数信息</summary>
            public double Kd
            {
                set => this.prakd = value;
                get => this.prakd;
            }

            private double deadband;
            /// <summary>获取或设置死区的值</summary>
            public double DeadBand
            {
                set => this.deadband = value;
                get => this.deadband;
            }

            private double MAXLIM;
            /// <summary>获取或设置输出的上限，默认为没有设置</summary>
            public double MaxLimit
            {
                set => this.MAXLIM = value;
                get => this.MAXLIM;
            }

            private double MINLIM;
            /// <summary>获取或设置输出的下限，默认为没有设置</summary>
            public double MinLimit
            {
                set => this.MINLIM = value;
                get => this.MINLIM;
            }

            private double setValue;
            /// <summary>获取或设置目标值</summary>
            public double SetValue
            {
                set => this.setValue = value;
                get => this.setValue;
            }

            private double err;
            /// <summary>偏差值</summary>
            public double Err
            {
                get => this.Err;
                set=> this.Err = value;
            }

            private double err_last;
            /// <summary>上一个偏差值</summary>
            public double Err_Last
            {
                get => this.Err_Last;
                set => this.Err_Last = value;
            }

            private double err_next;
            /// <summary>下一个偏差</summary>
            public double Err_Next
            {
                get { return err_next; }
                set { err_next = value; }
            }

        }


        /// <summary>
        /// 点线测量
        /// </summary>
        /// <param name="linex1">线起始X</param>
        /// <param name="liney1">线起始Y</param>
        /// <param name="linex2">线终点X</param>
        /// <param name="liney2">线终点Y</param>
        /// <param name="ptx">点X</param>
        /// <param name="pty">点Y</param>
        ///  <param name="conversion">像素单位</param>
        /// <returns>[0]距离 [1]垂足点X [2]垂直点Y</returns>
        public static double[] PointgoLine(double linex1, double liney1, double linex2, double liney2, double ptx, double pty, double conversion = 1)
        {
            double A = liney2 - liney1;
            double B = linex1 - linex2;
            double C = (linex2 * liney1) - (linex1 * liney2);
            double outpta = Math.Abs((A * ptx) + (B * pty) + C) / Math.Sqrt((Math.Pow(A, 2.0) + Math.Pow(B, 2.0)));
            double distance = outpta * conversion;
            double Ptlinex = ((B * B * ptx) - (A * B * pty) - (A * C)) / ((A * A) + (B * B));
            double Ptliney = (((A * -1) * B * ptx) + (A * A * pty) - (B * C)) / ((A * A) + (B * B));
            return new double[] { distance, Ptlinex, Ptliney };
        }

        /// <summary>
        /// 点线测量
        /// </summary>
        /// <param name="line">直线结构</param>
        /// <param name="point1">点结构</param>
        /// <param name="conversion">像素单位</param>
        /// <returns>[0]距离 [1]垂足点X [2]垂直点Y</returns>
        public static double[] PointgoLine(Line2D line, Point2D point1, double conversion = 1)
        {
            double A = line.EndY - line.StartY;
            double B = line.StartX - line.EndX;
            double C = (line.EndX * line.StartY) - (line.StartX * line.EndY);
            double outpta = Math.Abs((A * point1.X) + (B * point1.Y) + C) / Math.Sqrt((Math.Pow(A, 2.0) + Math.Pow(B, 2.0)));
            double distance = outpta * conversion;
            double Ptlinex = ((B * B * point1.X) - (A * B * point1.Y) - (A * C)) / ((A * A) + (B * B));
            double Ptliney = (((A * -1) * B * point1.X) + (A * A * point1.Y) - (B * C)) / ((A * A) + (B * B));
            return new double[] { distance, Ptlinex, Ptliney };
        }

        /// <summary>
        /// 点点测量
        /// </summary>
        /// <param name="pointx1">起始点X</param>
        /// <param name="pointy1">起始点Y</param>
        /// <param name="pointx2">结束点X</param>
        /// <param name="pointy2">结束点Y</param>
        /// <param name="conversion">像素单位</param>
        /// <returns>距离</returns>
        public static double PointMeasure(double pointx1, double pointy1, double pointx2, double pointy2, double conversion = 1)
        {
            return Math.Sqrt(Math.Pow((Math.Abs(pointx1 - pointx2)), 2.0) + Math.Pow(Math.Abs((pointy1 - pointy2)), 2.0)) * conversion;
        }

        /// <summary>
        /// 倾斜角计算
        /// </summary>
        /// <param name="line">线段结构体</param>
        /// <param name="criterion">倾斜基准</param>
        /// <returns>角度</returns>
        public static double Angle(Line2D line, AngleCriterion criterion)
        {
            double k = 0;
            if (criterion == AngleCriterion.PerpendiCularLine)
            {
                k = ((line.StartX - line.EndX) / (line.StartY - line.EndY));
            }
            else
            {
                k = ((line.StartY - line.EndY) / (line.StartX - line.EndX));
            }
            return Math.Atan(k) * 180 / Math.PI;
        }

        /// <summary>
        /// 几何平面一般式
        /// </summary>
        /// <param name="p1">基准3D点1</param>
        /// <param name="p2">基准3D点2</param>
        /// <param name="p3">基准3D点3</param>
        /// <returns>几何平面一般方程式Ax +By +Cz + D = 0，[0]A,[1]B,[2]C,[3]D</returns>
        public static double[] PlanarGeneralForm(Point3D p1, Point3D p2, Point3D p3)
        {
            double a1 = (p2.Y - p1.Y) * (p3.Z - p1.Z);
            double a2 = (p2.Z - p1.Z) * (p3.Y - p1.Y);
            double a = a1 - a2;
            double b1 = (p2.Z - p1.Z) * (p3.X - p1.X);
            double b2 = (p2.X - p1.X) * (p3.Z - p1.Z);
            double b = b1 - b2;
            double c1 = (p2.X - p1.X) * (p3.Y - p1.Y);
            double c2 = (p2.Y - p1.Y) * (p3.X - p1.X);
            double c = c1 - c2;
            double d1 = (a * p1.X) + (b * p1.Y) + (c * p1.Z);
            double d = 0 - d1;
            return new double[] { a, b, c, d };
        }

        /// <summary>
        /// 空间点到几何平面的距离
        /// </summary>
        /// <param name="p">3D坐标</param>
        /// <param name="a">平面一般式A变量</param>
        /// <param name="b">平面一般式B变量</param>
        /// <param name="c">平面一般式C变量</param>
        /// <param name="d">平面一般式D变量</param>
        /// <returns>垂直距离</returns>
        public static double DistanceFromPointPlane(Point3D p, double a, double b, double c, double d)
        {
            double a1 = Math.Abs((a * p.X) + (b * p.Y) + (c * p.Z) + d);
            double b1 = Math.Sqrt((a * a) + (b * b) + (c * c));
            return a1 / b1;
        }

       /// <summary>
       /// 增量式PID算法
       /// </summary>
       /// <param name="helper">PID参数结构</param>
       /// <param name="prvalue">实际值</param>
       /// <returns></returns>
        public static double PIDCalculate(PIDHelper helper,double prvalue)
        {
            double value = prvalue;
            helper.Err_Next = helper.Err_Last;
            helper.Err_Last = helper.Err;
            helper.Err = helper.SetValue - value;
            value += helper.Kp * (helper.Err - helper.Err_Last + helper.Ki * helper.Err + helper.Kd * (helper.Err - 2.0 * helper.Err_Last + helper.Err_Next));
            if (value > helper.MaxLimit)
                value = helper.MaxLimit;
            if (value <  helper.MinLimit)
                value = helper.MinLimit;
            return value;
        }
    }
}
