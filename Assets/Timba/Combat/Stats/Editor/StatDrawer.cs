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
            float third = (position.width - 120) / 3;
            var valueRect = new Rect(position.x, position.y, third, position.height);
            var isMinPrefixRect = new Rect(position.x + third + 10, position.y, 30, position.height);
            var isMinRect = new Rect(position.x + third + 40, position.y, 20, position.height);
            var minRect = new Rect(position.x + third + 60, position.y, third, position.height);
            var isMaxPrefixRect = new Rect(position.x + third * 2 + 70, position.y, 30, position.height);
            var isMaxRect = new Rect(position.x + third * 2 + 100, position.y, 20, position.height);
            var maxRect = new Rect(position.x + third * 2 + 120, position.y, third, position.height);

            // Draw fields - passs GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("value"), GUIContent.none);
            EditorGUI.PrefixLabel(isMinPrefixRect, new GUIContent("Min:"));
            EditorGUI.PropertyField(isMinRect, property.FindPropertyRelative("isMinConstrained"), GUIContent.none);
            GUI.enabled = property.FindPropertyRelative("isMinConstrained").boolValue; 
            EditorGUI.PropertyField(minRect, property.FindPropertyRelative("minValue"), GUIContent.none);
            GUI.enabled = true;
            EditorGUI.PrefixLabel(isMaxPrefixRect, new GUIContent("Max:"));
            EditorGUI.PropertyField(isMaxRect, property.FindPropertyRelative("isMaxConstrained"), GUIContent.none);
            GUI.enabled = property.FindPropertyRelative("isMaxConstrained").boolValue; 
            EditorGUI.PropertyField(maxRect, property.FindPropertyRelative("maxValue"), GUIContent.none);
            GUI.enabled = true;

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }

}