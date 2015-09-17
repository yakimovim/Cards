using EdlinSoftware.Cards.ImagePositions;
using Ploeh.AutoFixture;
using Xunit;
using static EdlinSoftware.Cards.Ranks;
using static EdlinSoftware.Cards.Suits;

namespace EdlinSoftware.Cards.Tests.ImagePositions
{
    public class RectangularCardImagePositionProviderTest
    {
        private readonly RectangularDeckImageDescription _description;
        private readonly Fixture _fixture;
        private readonly Size _cardSize;

        public RectangularCardImagePositionProviderTest()
        {
            _fixture = new Fixture();

            _cardSize = _fixture.Create<Size>();

            _description = new RectangularDeckImageDescription
            {
                CardWidth = _cardSize.Width,
                CardHeight = _cardSize.Height,
                Ranks = new[]
                {
                    Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
                },
                Suits = new[] { Clubs, Diamonds, Hearts, Spades }
            };

            _fixture.Inject<IRectangularDeckImageDescription>(_description);
        }

        [Fact]
        public void GetCardSize_ReturnsCorrectSize()
        {
            var provider = _fixture.Create<RectangularCardImagePositionProvider>();

            Assert.Equal(_cardSize, provider.GetCardSize());
        }

        [Theory]
        [InlineData(10.0, 5.0, 20.0, 15.0)]
        [InlineData(0.0, 0.0, 20.0, 15.0)]
        [InlineData(10.0, 5.0, 0.0, 0.0)]
        [InlineData(0.0, 0.0, 0.0, 0.0)]
        public void GetCardRectangle_ReturnsCorrectRect_Offset_Spacing(
            double hOffset,
            double vOffset,
            double hSpace,
            double vSpace)
        {
            _description.HorizontalOffsetOfFirstCard = hOffset;
            _description.VerticalOffsetOfFirstCard = vOffset;

            _description.HorizontalSpacingBetweenCards = hSpace;
            _description.VerticalSpacingBetweenCards = vSpace;

            var provider = _fixture.Create<RectangularCardImagePositionProvider>();

            var size = provider.GetCardSize();

            Assert.Equal(new Rect(hOffset + 0 * size.Width, vOffset + 0 * size.Height, size), provider.GetCardRectangle(Ace.Of(Clubs)));
            Assert.Equal(new Rect(hOffset + 12 * size.Width + 11 * hSpace, vOffset + 0 * size.Height, size), provider.GetCardRectangle(King.Of(Clubs)));
            Assert.Equal(new Rect(hOffset + 12 * size.Width + 11 * hSpace, vOffset + 3 * size.Height + 2 * vSpace, size), provider.GetCardRectangle(King.Of(Spades)));
            Assert.Equal(new Rect(hOffset + 0 * size.Width, vOffset + 3 * size.Height + 2 * vSpace, size), provider.GetCardRectangle(Ace.Of(Spades)));
        }
    }
}