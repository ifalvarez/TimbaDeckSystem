using System.Collections;
using System.Collections.Generic;
using Timba.Cards;
using UnityEngine;

namespace Timba.CardRoguelike {
    public class ViewController : MonoBehaviour {
        public CardZoneView hand;
        public CardZoneView drawPile;
        public CardZoneView discardPile;
        public CardZoneView destroyedPile;

        private void Start() {
            hand.CardZone = Board.Instance.player.hand;
            drawPile.CardZone = Board.Instance.player.drawPile;
            discardPile.CardZone = Board.Instance.player.discardPile;
            destroyedPile.CardZone = Board.Instance.player.destroyedPile;
        }
    }
}