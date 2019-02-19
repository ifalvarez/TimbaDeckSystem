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
        public GameObject cardsPanel;
        private CardView cardPrefab;

        /// <summary>
        /// Instantiate the current cards in the zone and hook to the CardZone events
        /// </summary>
        void Initialize() {
            bool isParentRectTransform = transform.GetType() == typeof(RectTransform);
            cardPrefab = isParentRectTransform ? ViewHelper.Instance.cardViewUiPrefab : ViewHelper.Instance.cardViewSpritePrefab;
            foreach (Card card in cardZone.cards) {
                CardZone_OnAdd(card);
            }
            cardZone.OnAdd += CardZone_OnAdd;
            cardZone.OnRemove += CardZone_OnRemove;
        }

        private void CardZone_OnAdd(Card card) {
            CardView cardView = Instantiate(cardPrefab, cardContainer);
            cardView.Card = card;
        }

        private void CardZone_OnRemove(Card card) {
            CardView cardView = cardContainer.GetComponentsInChildren<CardView>().Where(x => x.Card == card).FirstOrDefault();
            if(cardView != null) {
                Destroy(cardView.gameObject);
            } else {
                Debug.LogError("Trying to destroy a cardView but its not found");
            }
        }

        private void OnDestroy() {
            cardZone.OnAdd -= CardZone_OnAdd;
            cardZone.OnRemove -= CardZone_OnRemove;
        }

        public void ToggleCardsPanel() {
            cardsPanel.SetActive(!cardsPanel.activeSelf);
        }
    }
}