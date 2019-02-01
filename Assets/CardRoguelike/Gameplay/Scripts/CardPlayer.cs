using System;
using System.Collections.Generic;
using Timba.Cards;
using Timba.Players;

/// <summary>
/// Card player implementation for CardRoguelike.
/// This class has:
/// - All the zones the player owns
/// - Common operations the player can perform
/// </summary>
[Serializable]
public class CardPlayer : Player {
    public CardZone hand;
    public CardStack drawPile;
    public CardStack discardPile;
    public CardStack destroyedPile;

    public CardPlayer() {
        hand = new CardZone();
        drawPile = new CardStack();
        discardPile = new CardStack();
        destroyedPile = new CardStack();
    }

    public void Draw(int amount = 1) {
        for (int i = 0; i < amount; i++) {
            hand.Add(drawPile.Draw());
        }
    }
    
    public void DiscardRandom() {
        hand.MoveRandom(discardPile);
    }

    public Card RandomCardFromHand() {
        return hand.cards.RandomItem();
    }

    public void ShuffleDiscardInDraw() {
        List<Card> cards = discardPile.RemoveAll();
        drawPile.AddRange(cards);
    }


}
    


