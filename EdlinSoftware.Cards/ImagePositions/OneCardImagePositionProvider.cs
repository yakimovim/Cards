using System;

namespace EdlinSoftware.Cards.ImagePositions
{
    /// <summary>
    /// Provides position of card on image.
    /// </summary>
    public interface IOneCardImagePositionProvider
    {
        /// <summary>
        /// Returns size of card image.
        /// </summary>
        Size GetCardSize();
        /// <summary>
        /// Returns rectangle of card on the full image.
        /// </summary>
        Rect GetCardRectangle();
    }

    /// <summary>
    /// Provides position of card on image.
    /// </summary>
    public class OneCardImagePositionProvider
    {
        private readonly IOneCardImageDescription _imageDescription;

        public OneCardImagePositionProvider(IOneCardImageDescription imageDescription)
        {
            if (imageDescription == null) throw new ArgumentNullException(nameof(imageDescription));
            _imageDescription = imageDescription;
        }

        /// <summary>
        /// Returns size of card image.
        /// </summary>
        public Size GetCardSize()
        {
            return new Size(_imageDescription.CardWidth, _imageDescription.CardHeight);
        }

        /// <summary>
        /// Returns rectangle of card on the full image.
        /// </summary>
        public Rect GetCardRectangle()
        {
            return new Rect(_imageDescription.HorizontalOffset, _imageDescription.VerticalOffset, GetCardSize());
        }
    }
}