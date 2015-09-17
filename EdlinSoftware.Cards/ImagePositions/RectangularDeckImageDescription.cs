namespace EdlinSoftware.Cards.ImagePositions
{
    /// <summary>
    /// Represents description of image with full deck.
    /// All values are in pixels. The image should contain
    /// images of all cards in the full deck. Images of separate
    /// cards should be placed horizontally by ranks and
    /// vertically by suites.
    /// </summary>
    public interface IRectangularDeckImageDescription
    {
        /// <summary>
        /// Horizontal offset of first card from top-left corner of the image in pixels.
        /// </summary>
        double HorizontalOffsetOfFirstCard { get; }
        /// <summary>
        /// Vertical offset of first card from top-left corner of the image in pixels.
        /// </summary>
        double VerticalOffsetOfFirstCard { get; }

        /// <summary>
        /// Width of single card in pixels.
        /// </summary>
        double CardWidth { get; }
        /// <summary>
        /// Height of single card in pixels.
        /// </summary>
        double CardHeight { get; }

        /// <summary>
        /// Horizontal distance between two adjacent cards on the image in pixels.
        /// </summary>
        double HorizontalSpacingBetweenCards { get; }
        /// <summary>
        /// Vertical distance between two adjacent cards on the image in pixels.
        /// </summary>
        double VerticalSpacingBetweenCards { get; }

        /// <summary>
        /// Horizontal order of card ranks on the image.
        /// </summary>
        Ranks[] Ranks { get; }
        /// <summary>
        /// Vertical order of card suits on the image.
        /// </summary>
        Suits[] Suits { get; }
    }

    /// <summary>
    /// Represents description of image with full deck.
    /// All values are in pixels. The image should contain
    /// images of all cards in the full deck. Images of separate
    /// cards should be placed horizontally by ranks and
    /// vertically by suites.
    /// </summary>
    public class RectangularDeckImageDescription : IRectangularDeckImageDescription
    {
        /// <summary>
        /// Horizontal offset of first card from top-left corner of the image in pixels.
        /// </summary>
        public double HorizontalOffsetOfFirstCard { get; set; }
        /// <summary>
        /// Vertical offset of first card from top-left corner of the image in pixels.
        /// </summary>
        public double VerticalOffsetOfFirstCard { get; set; }

        /// <summary>
        /// Width of single card in pixels.
        /// </summary>
        public double CardWidth { get; set; }
        /// <summary>
        /// Height of single card in pixels.
        /// </summary>
        public double CardHeight { get; set; }

        /// <summary>
        /// Horizontal distance between two adjacent cards on the image in pixels.
        /// </summary>
        public double HorizontalSpacingBetweenCards { get; set; }
        /// <summary>
        /// Vertical distance between two adjacent cards on the image in pixels.
        /// </summary>
        public double VerticalSpacingBetweenCards { get; set; }

        /// <summary>
        /// Horizontal order of card ranks on the image.
        /// </summary>
        public Ranks[] Ranks { get; set; }
        /// <summary>
        /// Vertical order of card suits on the image.
        /// </summary>
        public Suits[] Suits { get; set; }
    }
}