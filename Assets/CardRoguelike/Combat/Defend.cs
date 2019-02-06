using Timba.Combat;
using UnityEngine;

public class Defend : StatChanger {
    int armor;

    public Defend(Combatant source, Combatant target, int armor) : base(source, target) {
        this.armor = armor;
    }

    public override void CalculateStatChanges() {
        if(armor < 0) {
            Debug.LogError("Armor gain cant be negative");
        }
        deltaStats.armor += Mathf.Max(0, armor + source.stats.dex);
    }
}