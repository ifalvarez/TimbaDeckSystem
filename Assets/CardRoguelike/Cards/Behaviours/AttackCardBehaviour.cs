using System.Linq;
using Timba.Cards;
using Timba.Combat;
using UnityEngine;

namespace Timba.CardRoguelike {

    public class AttackCardBehaviour : CardBehaviour {
        public int[] Parameters { get; set; }

        public void Execute(Card card, object[] targets) {
            Combatant[] enemyCombatants = targets.Select(x => ((MonoBehaviour)x).GetComponent<Combatant>()).ToArray();
            foreach (Combatant enemyCombatant in enemyCombatants) {
                PhysicalAttack attack = new PhysicalAttack(Parameters[0], CombatHelper.Instance.playerCombatant, enemyCombatant);
                attack.Execute();
            }
        }
    }
}