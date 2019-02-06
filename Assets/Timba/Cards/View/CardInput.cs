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
        public LayerMask layerMask;

        private void Awake() {
            cardView = GetComponent<CardView>();
            //layerMask = LayerMask.NameToLayer("player") & LayerMask.NameToLayer("enemy");
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
            if (cardView.Card.needsTarget) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 20, Color.green, 10);
                RaycastHit2D raycastHit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layerMask);
                EnemyView enemy = raycastHit.collider.GetComponent<EnemyView>();
                if (enemy != null) {
                    cardView.Card.Play(enemy);
                } else {
                    transform.position = originalPosition;
                }
            } else {
                if (Camera.main.ScreenToViewportPoint(Input.mousePosition).y > dragThresholdToPlayCards) {
                    cardView.Card.Play(null);
                } else {
                    transform.position = originalPosition;
                }
            }

        }
    }
}