﻿using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Timba.Cards {

    [CustomPropertyDrawer(typeof(SerializableCardBehaviour))]
    public class SerializableCardBehaviourDrawer : PropertyDrawer {
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            // Draw dropdown and assign the selected option value
            //Debug.Log(property.FindPropertyRelative("type").stringValue);
            int index = Mathf.Max(0, Array.IndexOf(AvailableCardBehaviours.availableTypeNames, property.FindPropertyRelative("type").stringValue));
            //Debug.Log(index);
            index = EditorGUI.Popup(
                new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight),
                "Type", index, AvailableCardBehaviours.availableTypeNames);
            //Debug.LogFormat("selected {0}", index);
            property.FindPropertyRelative("type").stringValue = AvailableCardBehaviours.availableTypeNames[index];

            // Draw the parameters property
            EditorGUI.indentLevel += 1;
            EditorGUI.PropertyField(
                new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight), 
                property.FindPropertyRelative("parameters"), 
                true);
            EditorGUI.indentLevel -= 1;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            SerializedProperty parameters = property.FindPropertyRelative("parameters");
            int extraLines = 1;
            if (parameters.isExpanded) {
                extraLines += parameters.arraySize + 1;
            }
            return base.GetPropertyHeight(property, label) + EditorGUIUtility.singleLineHeight * extraLines + EditorGUIUtility.standardVerticalSpacing * extraLines;
        }
    }
}