using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Timba.Cards {
    /// <summary>
    /// Displays a CardZone and the cards its holding
    /// </summary>
    public class CardZoneView : MonoBehaviour {
        [SerializeField]
        private CardZone cardZone;
        public CardZone CardZone {
            get { return cardZone; }
            set {
                cardZone = value;
                Initialize();
            }
        }
        public Transform cardContainer;

        /// <summary>
        /// Instantiate the current cards in the zone and hook to the CardZone events
        /// </summary>
        void Initialize() {
            foreach(Card card in cardZone.cards) {
                CardZone_OnAdd(card);
            }
            cardZone.OnAdd += CardZone_OnAdd;
            cardZone.OnRemove += CardZone_OnRemove;
        }

        private void CardZone_OnAdd(Card card) {
            CardView cardView = Instantiate(ViewHelper.Instance.cardViewPrefab, cardContainer);
            cardView.Card = card;
        }

        private void CardZone_OnRemove(Card card) {
            Destroy(GetComponentsInChildren<CardView>().Where(x => x.Card == card).First().gameObject);
        }
        
        private void OnDisable() {
            cardZone.OnAdd -= CardZone_OnAdd;
            cardZone.OnRemove -= CardZone_OnRemove;
        }
    }
}