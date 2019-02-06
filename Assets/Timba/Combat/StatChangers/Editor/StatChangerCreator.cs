using DotLiquid;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AttackCreator {
    public static string statsClassTemplate = "Assets/Timba/Combat/Attacks/Editor/AttackTemplate.cs.template";

    [MenuItem("Assets/Create/Timba/Combat/Attack Script")]
    public static void SelectFileName() {
        AttackEditorPopupWindow window = ScriptableObject.CreateInstance<AttackEditorPopupWindow>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        window.ShowPopup();
    }

    public static void CreateAttackScript(string name) {
        string attackClassPath = string.Format("{0}/{1}.cs", AssetDatabase.GetAssetPath(Selection.activeObject), name);
        Debug.LogFormat("Creating Attack Script in: {0}", attackClassPath);
        
        // Read template
        string templateText = null;
        using (StreamReader sr = new StreamReader(statsClassTemplate)) {
            templateText = sr.ReadToEnd();
        }

        // Write file
        using (StreamWriter outfile = new StreamWriter(attackClassPath)) {
            Template template = Template.Parse(templateText);  // Parses and compiles the template
            string fileContent = template.Render(Hash.FromAnonymousObject(new { className = name })); 
            outfile.Write(fileContent);
        }
        AssetDatabase.Refresh();
        Debug.Log("Attack script created at: " + attackClassPath);
    }

}

public class AttackEditorPopupWindow : EditorWindow {
    public string editorWindowText = "Choose a class name: ";
    string className = "NewAttack";
    
    void OnGUI() {
        className = EditorGUILayout.TextField(editorWindowText, className);

        if (GUILayout.Button("Create class")) {
            AttackCreator.CreateAttackScript(className);
            Close();
        }
    }
}
