using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPhysical : Attack {
    public Stat stats;

    public override void CalculateStatChanges() {
        deltaStats.hp.Value -= DamageFormulas.Physical(source.stats.attack, target.stats.armor);
    }

}
