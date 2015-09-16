using EdlinSoftware.Cards.ImagePositions;
using Xunit;
using static EdlinSoftware.Cards.Ranks;
using static EdlinSoftware.Cards.Suits;

namespace EdlinSoftware.Cards.Tests.ImagePositions
{
    public class RectangularCardImagePositionProviderTest
    {
        private readonly RectangularDeckImageDescription _description;

        public RectangularCardImagePositionProviderTest()
        {
            _description = new RectangularDeckImageDescription
            {
                ImageWidth = 2179,
                ImageHeight = 1216,
                HorizontalOffsetOfFirstCard = 0.0,
                VerticalOffsetOfFirstCard = 0.0,
                CardWidth = 167.6,
                CardHeight = 243.2,
                HorizontalSpacingBetweenCards = 0.0,
                VerticalSpacingBetweenCards = 0.0,
                Ranks = new[]
                {
                    Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
                },
                Suits = new[] { Clubs, Diamonds, Hearts, Spades }
            };
        }

        [Fact]
        public void GetCardSize_ReturnsCorrectSize()
        {
            var provider = new RectangularCardImagePositionProvider(_description);

            Assert.Equal(new Size(167.6, 243.2), provider.GetCardSize());
        }

        [Fact]
        public void GetCardRectangle_ReturnsCorrectRect_NoOffset_NoSpacing()
        {
            var provider = new RectangularCardImagePositionProvider(_description);

            var size = provider.GetCardSize();

            Assert.Equal(new Rect(0 * size.Width, 0 * size.Height, size), provider.GetCardRectangle(Ace.Of(Clubs)));
            Assert.Equal(new Rect(12 * size.Width, 0 * size.Height, size), provider.GetCardRectangle(King.Of(Clubs)));
            Assert.Equal(new Rect(12 * size.Width, 3 * size.Height, size), provider.GetCardRectangle(King.Of(Spades)));
            Assert.Equal(new Rect(0 * size.Width, 3 * size.Height, size), provider.GetCardRectangle(Ace.Of(Spades)));
        }

        [Fact]
        public void GetCardRectangle_ReturnsCorrectRect_Offset_NoSpacing()
        {
            var hOffset = _description.HorizontalOffsetOfFirstCard = 20.0;
            var vOffset = _description.VerticalOffsetOfFirstCard = 15.0;

            var provider = new RectangularCardImagePositionProvider(_description);

            var size = provider.GetCardSize();

            Assert.Equal(new Rect(hOffset + 0 * size.Width, vOffset + 0 * size.Height, size), provider.GetCardRectangle(Ace.Of(Clubs)));
            Assert.Equal(new Rect(hOffset + 12 * size.Width, vOffset + 0 * size.Height, size), provider.GetCardRectangle(King.Of(Clubs)));
            Assert.Equal(new Rect(hOffset + 12 * size.Width, vOffset + 3 * size.Height, size), provider.GetCardRectangle(King.Of(Spades)));
            Assert.Equal(new Rect(hOffset + 0 * size.Width, vOffset + 3 * size.Height, size), provider.GetCardRectangle(Ace.Of(Spades)));
        }

        [Fact]
        public void GetCardRectangle_ReturnsCorrectRect_NoOffset_Spacing()
        {
            var hSpace = _description.HorizontalSpacingBetweenCards = 20.0;
            var vSpace = _description.VerticalSpacingBetweenCards = 15.0;

            var provider = new RectangularCardImagePositionProvider(_description);

            var size = provider.GetCardSize();

            Assert.Equal(new Rect(0 * size.Width, 0 * size.Height, size), provider.GetCardRectangle(Ace.Of(Clubs)));
            Assert.Equal(new Rect(12 * size.Width + 11 * hSpace, 0 * size.Height, size), provider.GetCardRectangle(King.Of(Clubs)));
            Assert.Equal(new Rect(12 * size.Width + 11 * hSpace, 3 * size.Height + 2 * vSpace, size), provider.GetCardRectangle(King.Of(Spades)));
            Assert.Equal(new Rect(0 * size.Width, 3 * size.Height + 2 * vSpace, size), provider.GetCardRectangle(Ace.Of(Spades)));
        }

        [Fact]
        public void GetCardRectangle_ReturnsCorrectRect_Offset_Spacing()
        {
            var hOffset = _description.HorizontalOffsetOfFirstCard = 10.0;
            var vOffset = _description.VerticalOffsetOfFirstCard = 5.0;

            var hSpace = _description.HorizontalSpacingBetweenCards = 20.0;
            var vSpace = _description.VerticalSpacingBetweenCards = 15.0;

            var provider = new RectangularCardImagePositionProvider(_description);

            var size = provider.GetCardSize();

            Assert.Equal(new Rect(hOffset + 0 * size.Width, vOffset + 0 * size.Height, size), provider.GetCardRectangle(Ace.Of(Clubs)));
            Assert.Equal(new Rect(hOffset + 12 * size.Width + 11 * hSpace, vOffset + 0 * size.Height, size), provider.GetCardRectangle(King.Of(Clubs)));
            Assert.Equal(new Rect(hOffset + 12 * size.Width + 11 * hSpace, vOffset + 3 * size.Height + 2 * vSpace, size), provider.GetCardRectangle(King.Of(Spades)));
            Assert.Equal(new Rect(hOffset + 0 * size.Width, vOffset + 3 * size.Height + 2 * vSpace, size), provider.GetCardRectangle(Ace.Of(Spades)));
        }
    }
}