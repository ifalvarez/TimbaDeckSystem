using System;
using Timba.Cards;
using UnityEngine;

public class DebugCardBehaviour : CardBehaviour
{
    public int[] Parameters { get; set; }

    /// <summary>
    /// Implements this effect behaviour
    /// </summary>
    public void Execute(Card card, object[] targets) {
        Debug.LogFormat("Executing card: {0}", card.name);
    }
}
