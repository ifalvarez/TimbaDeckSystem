using System;
using System.Linq;

namespace Timba.Cards {
    public class AvailableCardBehaviours {
        private static Type[] availableTypes;
        public static Type[] AvailableTypes {
            get {
                if (availableTypes == null) {
                    OnScriptsReloaded();
                }
                return availableTypes;
            }
        }
        public static string[] availableTypeNames;

        static AvailableCardBehaviours() {
            OnScriptsReloaded();
        }

        [UnityEditor.Callbacks.DidReloadScripts]
        private static void OnScriptsReloaded() {
            // Search all the classes that implement the CardBehaviour interface to create a dropdown in the inspector
            AvailableCardBehaviours.availableTypes = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(
                t => t.IsClass &&
                typeof(CardBehaviour).IsAssignableFrom(t)
            ).ToArray();
            availableTypeNames = AvailableCardBehaviours.availableTypes.Select(x => x.Name).ToArray();
        }
    }
}