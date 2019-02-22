using System.Collections;
using System.Collections.Generic;
using Timba.Cards;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    private CardOwner cardOwner;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
        cardOwner = GetComponent<CardOwner>();
        Card.OnCardPlayed += Card_OnCardPlayed;
    }

    private void Card_OnCardPlayed(Card card) {
        if(card.owner == cardOwner) {
            animator.SetTrigger("attack");
        }
    }
}
