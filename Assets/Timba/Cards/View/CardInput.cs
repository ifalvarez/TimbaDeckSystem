using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timba.Cards {
    [RequireComponent(typeof(CardView))]
    public class CardInput : MonoBehaviour {
        public CardView cardView;
        [Range(0, 1)]
        public float dragThresholdToPlayCards;
        private Vector2 mousePivot;
        private Vector2 originalPosition;

        private LayerMask playerLayerMask;
        private LayerMask enemyLayerMask;
        private LayerMask layerMask;
        
        private void Awake() {
            //TODO: send this to a singleton or make it constant
            playerLayerMask = LayerMask.NameToLayer("player");
            enemyLayerMask = LayerMask.NameToLayer("enemy");
            layerMask = LayerMask.GetMask(new string[]{ "player", "enemy"});
            cardView = GetComponent<CardView>();
        }

        public void OnMouseDown() {
            originalPosition = transform.position;
            mousePivot = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        public void OnMouseDrag() {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(position.x + mousePivot.x, position.y + mousePivot.y);
        }

        public void OnMouseUp() {
            // Acquire targets
            object[] targets = null;
            if (cardView.Card.targetMask != TargetMask.none) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 20, Color.green, 10);
                Collider2D collider = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layerMask).collider;
                if (collider != null && (
                        ((collider.gameObject.layer == enemyLayerMask || collider.gameObject.layer == playerLayerMask) && cardView.Card.targetMask == TargetMask.all) ||
                        (collider.gameObject.layer == enemyLayerMask && cardView.Card.targetMask == TargetMask.enemy) ||
                        (collider.gameObject.layer == playerLayerMask && cardView.Card.targetMask == TargetMask.player))) {
                    targets = new object[] { collider.gameObject };
                }
            }

            // Play card 
            if (targets != null || (cardView.Card.targetMask == TargetMask.none && Camera.main.ScreenToViewportPoint(Input.mousePosition).y > dragThresholdToPlayCards)) {
                cardView.Card.Play(targets);
            } else {
                transform.position = originalPosition;
            }
        }
    }
}