using System.Diagnostics;

namespace EdlinSoftware.Cards.ImagePositions
{
    [DebuggerDisplay("Size: {Width} x {Height}")]
    public struct Size
    {
        [DebuggerStepThrough]
        public Size(double width, double height) : this()
        {
            Width = width;
            Height = height;
        }

        public double Width { get; }
        public double Height { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Size && Equals((Size)obj);
        }

        public bool Equals(Size other)
        {
            return Width.Equals(other.Width) && Height.Equals(other.Height);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Width.GetHashCode()*397) ^ Height.GetHashCode();
            }
        }
    }
}