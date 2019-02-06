using System;
using Timba.Cards;

public class DefendCardBehaviour : CardBehaviour
{
    public int[] Parameters { get; set; }

    /// <summary>
    /// Implements this effect behaviour
    /// </summary>
    public void Execute(Card card, object[] targets) {
        new Defend(CombatHelper.Instance.playerCombatant, CombatHelper.Instance.playerCombatant, Parameters[0]).Execute();
    }

	public string Description {
        get {
            // Implement the description of this behaviour here
			return string.Format("Gain {0} armor", Parameters[0]);
        }
    }
}
