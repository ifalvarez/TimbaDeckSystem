using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timba.Cards {
    public class ViewController : MonoBehaviour {
        public Board board;
        public CardView cardViewPrefab;

        public Transform handTransform;

        /// <summary>
        /// Takes the game state and reflects it on the view
        /// </summary>
        public void InitializeView() {
            // Show enemies

            // Show player

            // Show hand
            foreach (Card card in board.player.hand.cards) {
                CardView cardView = Instantiate(cardViewPrefab, handTransform);
                cardView.Card = card;
            }

            // Show relics
        }
    }
}