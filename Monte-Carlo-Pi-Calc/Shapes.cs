using System;

namespace Shapes {
    public class Circle {

        public int Radius { get; private set; }
        public Circle(int Radius) =>
            this.Radius = Radius;

        public bool IsPointInCircle(Point point) =>
            Radius > Math.Sqrt(point.X * point.X + point.Y * point.Y);

    }
    public class Point {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point(int X, int Y) {
            this.X = X;
            this.Y = Y;
        }
        public override string ToString() => X + "_" + Y;
    }
}
