using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace EdlinSoftware.Cards.Tests
{
    public class EndlessCardsProviderTest
    {
        [Theory]
        [AutoData]
        public void CardsProvider_ShouldReturnEndlessStreamOfCards([Frozen(As = typeof(IDeckCreator))] FullDeckCreator deckCreator, EndlessCardsProvider cardsProvider)
        {
            for (int i = 0; i < 1000; i++)
            {
                Assert.NotNull(cardsProvider.Deal());
            }
        }
    }
}