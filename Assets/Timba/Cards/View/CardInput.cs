using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timba.Cards {

    public class CardInput : MonoBehaviour {
        public Card card;
        [Range(0, 1)]
        public float dragThresholdToPlayCards;
        private Vector2 mousePivot;
        private Vector2 originalPosition;

        private void Start() {
            card = new DebugCard();
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
            if (card.needsTarget) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                EnemyView enemy = Physics2D.Raycast(ray.origin, ray.direction).collider.GetComponent<EnemyView>();
                if (enemy != null) {
                    card.Play(enemy);
                } else {
                    transform.position = originalPosition;
                }
            } else {
                if (Camera.main.ScreenToViewportPoint(Input.mousePosition).y > dragThresholdToPlayCards) {
                    card.Play(null);
                } else {
                    transform.position = originalPosition;
                }
            }

        }
    }
}