using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timba.Cards {
    [CreateAssetMenu(fileName = "CardDatabase", menuName = "Timba/Cards/Card Database")]
    public class CardDatabase : ScriptableObject {
        public Card[] cards;
    }
}