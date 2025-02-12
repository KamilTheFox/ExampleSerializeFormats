using Point = PointLib.Point;

namespace ProjectSerialization
{
    [Serializable]
    internal class Point3D : Point
    {
        public int Z { get; set; }

        public Point3D() : base() { Z = rnd.Next(100); }

        public override double Metric()
        {
            return Math.Sqrt(X*X+Y*Y+Z*Z);
        }
        public override string ToString()
        {
            return $"({X} {Y} {Z})";
        }
    }
}
