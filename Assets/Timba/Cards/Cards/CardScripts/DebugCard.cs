using System;
using Timba.Cards;
using UnityEngine;

public class DebugCard : Card
{
    public DebugCard() {
        id = "-00001";
        name = "Debug Card";
        needsTarget = false;
    }

    /// <summary>
    /// Implements this card effect
    /// </summary>
    override public void Execute(object[] targets) {
        Debug.LogFormat("Executing card: {0}", name);
    }
}
