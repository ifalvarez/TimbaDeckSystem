using Timba.Combat;
using UnityEngine;

namespace Timba.CardRoguelike {
    /// <summary>
    /// Adds the attack damage and the source strength.
    /// Substrats the total from the armor of the target first, then from his hp
    /// </summary>
    public class Attack : StatChanger {
        public int damage;

        public Attack(Combatant source, Combatant target, int damage) : base(source, target) {
            this.damage = damage;
            if(damage < 0) {
                Debug.LogErrorFormat("Damage cant be negative, current: {0}", damage);
            }
        }

        public override void CalculateStatChanges() {
            damage += source.stats.str;
            int armorDamage = Mathf.Min((int)target.stats.armor, damage);
            deltaStats.armor -= armorDamage;
            deltaStats.hp -= Mathf.Max(0, damage - armorDamage);
        }

    }
}
