using System.Diagnostics;

namespace EdlinSoftware.Cards.ImagePositions
{
    public struct Rect
    {
        [DebuggerStepThrough]
        public Rect(double left, double top, double width, double height) : this()
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        [DebuggerStepThrough]
        public Rect(double left, double top, Size size) : this()
        {
            Left = left;
            Top = top;
            Width = size.Width;
            Height = size.Height;
        }

        public double Left { get; }
        public double Top { get; }
        public double Width { get; }
        public double Height { get; }

        public Size Size => new Size(Width, Height);

        public bool Equals(Rect other)
        {
            return Left.Equals(other.Left) && Top.Equals(other.Top) && Width.Equals(other.Width) && Height.Equals(other.Height);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Rect && Equals((Rect) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Left.GetHashCode();
                hashCode = (hashCode*397) ^ Top.GetHashCode();
                hashCode = (hashCode*397) ^ Width.GetHashCode();
                hashCode = (hashCode*397) ^ Height.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"Rect: at ({Left}, {Top}) with size {Width} x {Height}";
        }
    }
}