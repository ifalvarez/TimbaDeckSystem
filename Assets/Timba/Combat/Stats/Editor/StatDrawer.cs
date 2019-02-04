using UnityEditor;
using UnityEngine;

namespace Timba.Combat {

    [CustomPropertyDrawer(typeof(Stat))]
    public class StatDrawer : PropertyDrawer {
        
        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            // Using BeginProperty / EndProperty on the parent property means that
            // prefab override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // Calculate rects
            var valueRect = new Rect(position.x, position.y, position.width, position.height);
            var isMinRect = new Rect(position.x, position.y + position.height, 30, position.height);
            var minRect = new Rect(position.x + 40, position.y + position.height, position.width - 40, position.height);
            var isMaxRect = new Rect(position.x, position.y + position.height * 2, 30, position.height);
            var maxRect = new Rect(position.x + 40, position.y + position.height * 2, position.width - 40, position.height);

            // Draw fields - passs GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("value"), GUIContent.none);
            EditorGUI.PropertyField(isMinRect, property.FindPropertyRelative("isMinConstrained"), GUIContent.none);
            EditorGUI.PropertyField(minRect, property.FindPropertyRelative("minValue"), GUIContent.none);
            EditorGUI.PropertyField(isMaxRect, property.FindPropertyRelative("isMaxConstrained"), GUIContent.none);
            EditorGUI.PropertyField(maxRect, property.FindPropertyRelative("maxValue"), GUIContent.none);

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}