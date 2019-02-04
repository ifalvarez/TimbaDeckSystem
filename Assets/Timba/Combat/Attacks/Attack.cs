namespace Timba.Combat {
    public abstract class Attack {

        public Combatant source;
        public Combatant target;
        public Stats sourceStats;
        public Stats targetStats;

        /// <summary>
        /// Stats that will change due to this attack.
        /// Should be populated by the CalculateStatChanges method
        /// </summary>
        public Stats deltaStats;

        public delegate void AttackAction();
        public event AttackAction OnCopyStats;
        public event AttackAction OnCalculateStatChanges;
        public event AttackAction OnApplyStatChanges;


        public Attack(Combatant source, Combatant target) {
            this.source = source;
            this.target = target;
            CopyStats();
            CalculateStatChanges();
            if (OnCalculateStatChanges != null) {
                OnCalculateStatChanges();
            }
            ApplyStatChanges();
        }

        /// <summary>
        /// Makes a copy of the stats of the source and targets.
        /// This allows the attack or any of its modifiers to make changes to the stats without affecting the originals
        /// </summary>
        void CopyStats() {
            sourceStats = source.stats;
            targetStats = target.stats;
            if (OnCopyStats != null) {
                OnCopyStats();
            }
        }

        /// <summary>
        /// Calculates how each stat will change due to the effect of this attack.
        /// This is the main logic of the attack
        /// </summary>
        abstract public void CalculateStatChanges();

        /// <summary>
        /// Applies the changes to the stats
        /// </summary>
        public void ApplyStatChanges() {
            target.stats += deltaStats;
            if (OnApplyStatChanges != null) {
                OnApplyStatChanges();
            }
        }

    }
}