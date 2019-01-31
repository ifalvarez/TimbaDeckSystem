using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Timba.Cards {

    [CustomPropertyDrawer(typeof(SerializableCardBehaviour))]
    public class SerializableCardBehaviourDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            // Search all the classes that implement the CardBehaviour interface to create a dropdown in the inspector
            Type[] types = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where (
                t => t.IsClass &&
                typeof(CardBehaviour).IsAssignableFrom(t)
            ).ToArray();
            string[] availableTypes = types.Select(x => x.Name).ToArray();

            // Draw dropdown and assign the selected option value
            property.FindPropertyRelative("type").stringValue = availableTypes[EditorGUI.Popup(position, "Type", 0, availableTypes)];

            // Draw the parameters property
            EditorGUI.PropertyField(
                new Rect(position.x, position.y + position.height, position.width, position.height), 
                property.FindPropertyRelative("parameters"), 
                true);
        }
    }
}