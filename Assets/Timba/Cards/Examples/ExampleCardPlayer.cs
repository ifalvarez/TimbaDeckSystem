using System.Collections.Generic;
using Timba.Players;

namespace Timba.Cards.Examples {

    /// <summary>
    /// This is an example Card Player class.
    /// The implementation of the player class is game dependant and
    /// cannot be generalized.
    /// </summary>
    public class ExampleCardPlayer : Player {
        public List<Card> hand;
        public CardStack deck;
        public CardStack discardPile;
        public CardStack destroyedPile;

        public void Draw() {
            hand.Add(deck.Draw());
        }

        public void DiscardRandom() {

        }

        public Card RandomCardFromHand() {
            return null;
        }

    }
    
}

