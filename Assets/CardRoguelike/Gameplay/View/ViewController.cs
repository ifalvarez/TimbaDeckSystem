using System.Collections;
using System.Collections.Generic;
using Timba.Cards;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public CardZoneView hand;

    private void Start() {
        hand.CardZone = Board.Instance.player.hand;
    }
}
