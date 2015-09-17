using EdlinSoftware.Cards.ImagePositions;
using Ploeh.AutoFixture;
using Xunit;

namespace EdlinSoftware.Cards.Tests.ImagePositions
{
    public class OneCardImagePositionProviderTest
    {
        private readonly OneCardImageDescription _description;
        private readonly Fixture _fixture;
        private readonly Size _cardSize;

        public OneCardImagePositionProviderTest()
        {
            _fixture = new Fixture();

            _cardSize = _fixture.Create<Size>();

            _description = new OneCardImageDescription
            {
                CardWidth = _cardSize.Width,
                CardHeight = _cardSize.Height
            };

            _fixture.Inject<IOneCardImageDescription>(_description);
        }

        [Fact]
        public void GetCardSize_ReturnsCorrectSize()
        {
            var provider = _fixture.Create<OneCardImagePositionProvider>();

            Assert.Equal(_cardSize, provider.GetCardSize());
        }

        [Theory]
        [InlineData(10.0, 5.0)]
        [InlineData(0.0, 0.0)]
        public void GetCardRectangle_ReturnsCorrectRect_Offset_Spacing(
            double hOffset,
            double vOffset)
        {
            _description.HorizontalOffset = hOffset;
            _description.VerticalOffset = vOffset;

            var provider = _fixture.Create<OneCardImagePositionProvider>();

            var size = provider.GetCardSize();

            Assert.Equal(new Rect(hOffset, vOffset, size), provider.GetCardRectangle());
        }
    }
}