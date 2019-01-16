using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HorizontalCurvedLayout : MonoBehaviour
{
    public AnimationCurve curve;
    public float cellWidth = 2;
    public float height;
    public float maxRotation;

    void Update() {
        float xPosition = transform.childCount - transform.childCount % 2;
        xPosition = xPosition * cellWidth / -2;
        for (int i = 0; i < transform.childCount; i++) {
            float percentage = (float)i / (float)(transform.childCount - 1);
            float y = curve.Evaluate(percentage) * height;
            transform.GetChild(i).position = Vector2.MoveTowards(
                transform.GetChild(i).position,
                new Vector2(transform.position.x + xPosition, transform.position.y + y),
                0.1f);
            float angle = Mathf.Lerp(-maxRotation, maxRotation, percentage);
            transform.GetChild(i).eulerAngles = new Vector3(0, 0, -angle);
            xPosition += cellWidth;
        }
    }
}
