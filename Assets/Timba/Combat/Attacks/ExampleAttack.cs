namespace Timba.Combat {
    public class ExampleAttack : Attack {
        public ExampleAttack(Combatant source, Combatant target) : base(source, target) { }

        public override void CalculateStatChanges() {
            // Implement your attack here. The following is an example using the stats attack and armor
            // deltaStats.hp.Value -= DamageFormulas.Physical(source.stats.attack, target.stats.armor);
        }

    }
}