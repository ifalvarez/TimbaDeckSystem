using UnityEngine;


/// <summary>
/// A singleton class for MonoBehaviour.
/// </summary>
/// <typeparam name="T">The type of the singleton. If the type is "FooBar", this value should be "FooBar".</typeparam>
public abstract class PocoSingleton<T> where T : PocoSingleton<T> {
    static T instance;
    public static T Instance {
        get {
            if (instance == null)
                Debug.LogError(string.Format("Trying to access the Instance of {0} but it is null.\n is the script that creates the instance already loaded?", typeof(T).Name));
            return instance;
        }
        set {
            instance = value;
        }
    }

    public PocoSingleton() {
        if (typeof(T) != this.GetType() && !typeof(T).IsAssignableFrom(this.GetType())) throw new System.InvalidOperationException("Type argument does not match singleton type!");

        if (instance == null) {
            Instance = (T)this;
        } else {
            Debug.LogError("Only one instance of " + this.GetType() + " is allowed!");
        }
    }

    static public bool IsLoaded() {
        return instance != null;
    }
}