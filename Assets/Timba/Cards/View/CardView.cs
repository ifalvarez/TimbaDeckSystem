using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Timba.Cards {
    public class CardView : MonoBehaviour {
        public TextMeshPro nameText;
        public TextMeshPro descriptionText;
        public TextMeshPro flavorText;
        public Sprite image;
        public Sprite rarity;
        public Sprite decoration;

        private Card card;
        public Card Card {
            get {
                return card;
            }
            set {
                card = value;
                nameText.text = card.name;
                descriptionText.text = card.Description;
                card.OnPlay += Card_OnPlay;
            }
        }
                
        private void Card_OnPlay(Card card) {
            Destroy(gameObject);
        }
    }
}