using System;
using System.Diagnostics;
using static System.Math;

namespace EdlinSoftware.Cards.ImagePositions
{
    /// <summary>
    /// Provides position of given card on image.
    /// </summary>
    public interface ICardImagePositionProvider
    {
        /// <summary>
        /// Returns size of card image.
        /// </summary>
        Size GetCardSize();
        /// <summary>
        /// Returns rectangle of given card on the full image.
        /// </summary>
        /// <param name="card">Card to get rectangle for.</param>
        Rect GetCardRectangle(Card card);
    }

    public class RectangularCardImagePositionProvider : ICardImagePositionProvider
    {
        private readonly IRectangularDeckImageDescription _imageDescription;

        [DebuggerStepThrough]
        public RectangularCardImagePositionProvider(IRectangularDeckImageDescription imageDescription)
        {
            if (imageDescription == null) throw new ArgumentNullException(nameof(imageDescription));
            _imageDescription = imageDescription;
        }

        public Size GetCardSize()
        {
            return new Size(_imageDescription.CardWidth, _imageDescription.CardHeight);
        }

        public Rect GetCardRectangle(Card card)
        {
            var hIndex = Array.IndexOf(_imageDescription.Ranks, card.Rank);
            var vIndex = Array.IndexOf(_imageDescription.Suits, card.Suit);

            var left = _imageDescription.HorizontalOffsetOfFirstCard + 
                hIndex * _imageDescription.CardWidth + 
                Max(0, hIndex - 1) * _imageDescription.HorizontalSpacingBetweenCards;
            var top = _imageDescription.VerticalOffsetOfFirstCard + 
                vIndex * _imageDescription.CardHeight + 
                Max(0, vIndex - 1) * _imageDescription.VerticalSpacingBetweenCards;

            return new Rect(left, top, GetCardSize());
        }
    }
}