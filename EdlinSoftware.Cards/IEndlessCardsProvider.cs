using System;
using System.Diagnostics;

namespace EdlinSoftware.Cards
{
    /// <summary>
    /// Provider of endless stream of shuffled cards.
    /// </summary>
    public interface IEndlessCardsProvider
    {
        /// <summary>
        /// Returns one card.
        /// </summary>
        Card Deal();
    }

    public class EndlessCardsProvider : IEndlessCardsProvider
    {
        private readonly IDeckCreator _deckCreator;

        private Deck _deck;

        [DebuggerStepThrough]
        public EndlessCardsProvider(IDeckCreator deckCreator)
        {
            if (deckCreator == null) throw new ArgumentNullException(nameof(deckCreator));
            _deckCreator = deckCreator;
        }

        public Card Deal()
        {
            while (_deck == null || _deck.IsEmpty)
            {
                _deck = _deckCreator.CreateDeck();
                _deck.Shuffle();
            }

            return _deck.Deal();
        }
    }

}