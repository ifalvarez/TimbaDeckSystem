using System;

namespace Timba.Cards {
    [Serializable]
    public class CardStack : CardZone{
        
        public Card Draw() {
            return RemoveAt(0);
        }

        public void Shuffle() {
            cards.Shuffle();
        }
    }
}
