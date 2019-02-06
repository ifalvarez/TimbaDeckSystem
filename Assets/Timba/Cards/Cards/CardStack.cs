using System;

namespace Timba.Cards {
    [Serializable]
    public class CardStack : CardZone{
        public CardZone resuplyFrom;

        public Card Draw() {
            if(cards.Count == 0 && resuplyFrom != null && resuplyFrom.cards.Count != 0) {
                resuplyFrom.MoveAll(this);
            }
            if(cards.Count != 0) {
                return RemoveAt(0);
            } else {
                return null;
            }
        }

        public void Shuffle() {
            cards.Shuffle();
        }
    }
}
