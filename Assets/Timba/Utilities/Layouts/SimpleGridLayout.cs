using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timba.Util {
    [ExecuteInEditMode]
    public class SimpleGridLayout : MonoBehaviour {
        // Bounds
        private Bounds bounds;
        private Vector3 size;

        // Padding
        //public int paddingLeft;
        //public int paddingRight;
        //public int paddingTop;
        //public int paddingDown;
        
        // Cells
        public Vector2 cellSize;
        public Vector2 spacing;
        [Min(1)]
        public int columns;

        // Curvature
        //public AnimationCurve curve;
        //public float maxRotation;

        void Update() {
            //Vector2 paddedSize = new Vector2(size.x - paddingLeft - paddingRight, size.y - paddingTop - paddingDown);
            int rows = transform.childCount / columns + (transform.childCount % columns > 0 ? 1 : 0);
            size = new Vector2(cellSize.x * columns + spacing.x * (columns - 1), cellSize.y * rows + spacing.x * (rows - 1)); 
            bounds = new Bounds(transform.position, size);
            
            Vector2 currentPosition = new Vector3(bounds.min.x + cellSize.x / 2, bounds.max.y - cellSize.y / 2);
            for (int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).position = currentPosition;
                currentPosition.x += cellSize.x + spacing.x;
                if (!bounds.Contains(currentPosition)) {
                    currentPosition.x -= (cellSize.x + spacing.x) * columns;
                    currentPosition.y -= cellSize.y + spacing.y;
                }
            }
        }

        void OnDrawGizmosSelected() {
            // Draw a semitransparent blue cube at the transforms position
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, size);
        }
    }
}