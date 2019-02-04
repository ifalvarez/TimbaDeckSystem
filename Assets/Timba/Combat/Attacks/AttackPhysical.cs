using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timba.Combat {
    public class AttackPhysical : Attack {
        public Stat stats;

        public AttackPhysical(Combatant source, Combatant target) : base(source, target) { }

        public override void CalculateStatChanges() {
            deltaStats.hp.Value -= DamageFormulas.Physical(source.stats.attack, target.stats.armor);
        }

    }
}