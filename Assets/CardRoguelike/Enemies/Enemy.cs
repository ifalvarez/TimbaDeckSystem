using System;
using System.Collections;
using Timba.Combat;
using UnityEngine;

namespace Timba.CardRoguelike {

    [Serializable]
    public class Enemy {
        public string name;
        public Combatant combatant;

        public IEnumerator TakeTurn() {
            Debug.LogFormat("Enemy {0} taking its turn", name);
            yield return null;
        }
    }
}