using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timba.Cards {
    public class ViewController : MonoBehaviour {
        public CardView cardViewPrefab;

        public Transform handTransform;

        private void Start() {
            InitializeView();
        }

        /// <summary>
        /// Takes the game state and reflects it on the view
        /// </summary>
        public void InitializeView() {
            // Show enemies

            // Show player

            // Show hand
            foreach (Card card in Board.Instance.player.hand.cards) {
                CardView cardView = Instantiate(cardViewPrefab, handTransform);
                cardView.Card = card;
            }

            // Show relics
        }
    }
}