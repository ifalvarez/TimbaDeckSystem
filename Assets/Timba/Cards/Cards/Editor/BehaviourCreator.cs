using DotLiquid;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BehaviourCreator {
    public static string classTemplate = "Assets/Timba/Cards/Cards/Editor/CardBehaviourTemplate.cs.template";

    [MenuItem("Assets/Create/Timba/Cards/CardBehaviour Script")]
    public static void SelectFileName() {
        BehaviourCreatorPopupWindow window = ScriptableObject.CreateInstance<BehaviourCreatorPopupWindow>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        window.ShowPopup();
    }

    public static void CreateScript(string name) {
        string classPath = string.Format("{0}/{1}.cs", AssetDatabase.GetAssetPath(Selection.activeObject), name);
        Debug.LogFormat("Creating Script in: {0}", classPath);
        
        // Read template
        string templateText = null;
        using (StreamReader sr = new StreamReader(classTemplate)) {
            templateText = sr.ReadToEnd();
        }

        // Write file
        using (StreamWriter outfile = new StreamWriter(classPath)) {
            Template template = Template.Parse(templateText);  // Parses and compiles the template
            string fileContent = template.Render(Hash.FromAnonymousObject(new { className = name })); 
            outfile.Write(fileContent);
        }
        AssetDatabase.Refresh();
        Debug.Log("Script created at: " + classPath);
    }

}

public class BehaviourCreatorPopupWindow : EditorWindow {
    public string editorWindowText = "Choose a class name: ";
    string className = "NewBehaviour";
    
    void OnGUI() {
        className = EditorGUILayout.TextField(editorWindowText, className);

        if (GUILayout.Button("Create class")) {
            BehaviourCreator.CreateScript(className);
            Close();
        }
    }
}
