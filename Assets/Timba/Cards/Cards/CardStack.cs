using System.Collections.Generic;
using UnityEngine;

namespace Timba.Cards {

    public class CardStack : CardZone{
        
        public Card Draw() {
            return RemoveAt(0);
        }

        public void Shuffle() {
            cards.Shuffle();
        }
    }
}
