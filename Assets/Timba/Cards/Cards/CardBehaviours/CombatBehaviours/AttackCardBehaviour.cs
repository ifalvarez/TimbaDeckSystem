using System.Linq;
using Timba.Combat;
using UnityEngine;

namespace Timba.Cards {

    public class AttackCardBehaviour : CardBehaviour {
        public int[] Parameters { get; set; }

        public void Execute(Card card, object[] targets) {
            Combatant[] combatants = targets.Select(x => ((MonoBehaviour)x).GetComponent<Combatant>()).ToArray();
            foreach (Combatant combatant in combatants) {
                AttackPhysical attack = new AttackPhysical(combatant, combatant);
            }
        }
    }
}