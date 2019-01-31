﻿using System.Collections;
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
            set {
                card = value;
                nameText.text = card.name;
            }
        }
    }
}