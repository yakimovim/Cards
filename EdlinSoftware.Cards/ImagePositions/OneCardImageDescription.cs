namespace EdlinSoftware.Cards.ImagePositions
{
    /// <summary>
    /// Represents description of one card.
    /// All values are in pixels.
    /// </summary>
    public interface IOneCardImageDescription
    {
        /// <summary>
        /// Horizontal offset of card from top-left corner of the image in pixels.
        /// </summary>
        double HorizontalOffset { get; }
        /// <summary>
        /// Vertical offset of card from top-left corner of the image in pixels.
        /// </summary>
        double VerticalOffset { get; }

        /// <summary>
        /// Width of card in pixels.
        /// </summary>
        double CardWidth { get; }
        /// <summary>
        /// Height of card in pixels.
        /// </summary>
        double CardHeight { get; }
    }

    /// <summary>
    /// Represents description of one card.
    /// All values are in pixels.
    /// </summary>
    public class OneCardImageDescription : IOneCardImageDescription
    {
        /// <summary>
        /// Horizontal offset of card from top-left corner of the image in pixels.
        /// </summary>
        public double HorizontalOffset { get; set; }
        /// <summary>
        /// Vertical offset of card from top-left corner of the image in pixels.
        /// </summary>
        public double VerticalOffset { get; set; }

        /// <summary>
        /// Width of card in pixels.
        /// </summary>
        public double CardWidth { get; set; }
        /// <summary>
        /// Height of card in pixels.
        /// </summary>
        public double CardHeight { get; set; }
    }
}