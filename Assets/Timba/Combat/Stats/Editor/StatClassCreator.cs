using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using DotLiquid;

namespace Timba {

    public class StatClassCreator
    {
        public static string statsClassPath = "Assets/Timba/Combat/Scripts/Stats.cs";
        public static string statsClassTemplate = "Assets/Timba/Combat/Templates/Stats.cs.template";
        public static string[] statNames = { "hp", "mp", "attack", "armor", "magic", "resistance", "critChance", "critDamage" };

        public static void Create()
        {
            Debug.Log("Creating Stats script: " + statsClassPath);
            //if (File.Exists(statsClassPath) == false) { // do not overwrite

            // Read template
            string templateText = null;
            using (StreamReader sr = new StreamReader(statsClassTemplate))
            {
                templateText = sr.ReadToEnd();
            }

            // Write file
            using (StreamWriter outfile = new StreamWriter(statsClassPath))
            {
                Template template = Template.Parse(templateText);  // Parses and compiles the template
                string fileContent = template.Render(Hash.FromAnonymousObject(new { statNames = statNames })); // Renders the output => "hi tobi"
                outfile.Write(fileContent);
            }
            AssetDatabase.Refresh();
        }
    }

}