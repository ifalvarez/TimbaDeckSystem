using System;
using UnityEngine;

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
                Debug.LogWarningFormat("No cards to draw in CardStack {0}", this);
                return null;
            }
        }

        public void Shuffle() {
            cards.Shuffle();
        }
    }
}
