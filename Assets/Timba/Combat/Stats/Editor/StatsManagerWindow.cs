using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Timba.Combat {
    [Serializable]
    public class StatsManagerWindow : EditorWindow, IHasCustomMenu {
        #region GUI Contents
        private readonly GUIContent updateStatsClassContent = new GUIContent("Save", "Updates the stats class with the listed stat names");
        private readonly GUIContent addStatContent = new GUIContent("New stat", "Adds a new stat to the list");
        private readonly GUIContent deleteStatContent = new GUIContent("X", "Remove this stat from the list");
        #endregion

        #region runner steerign vars
        private static StatsManagerWindow Instance;
        private bool m_IsBuilding;
        private Vector2 m_StatListScroll;
        #endregion

        private GameObject m_SelectedLine;

        public List<string> stats;

        static StatsManagerWindow() {
        }

        public void OnEnable() {
            titleContent = new GUIContent("Stats Manager");
            Instance = this;
            Instance.stats = typeof(Stats).GetFields().Where(x => !x.IsStatic).Select(x => x.Name).ToList();
        }

        #region draw window
        public void OnGUI() {
            if (BuildPipeline.isBuildingPlayer) {
                m_IsBuilding = true;
            } else if (m_IsBuilding) {
                m_IsBuilding = false;
                Repaint();
            }

            PrintHeadPanel();

            EditorGUILayout.BeginVertical(GUIStyles.testList);
            m_StatListScroll = EditorGUILayout.BeginScrollView(m_StatListScroll);
            bool repaint = PrintStatList();
            if (GUILayout.Button(addStatContent, EditorStyles.miniButtonMid)) {
                NewStat();
            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();

            if (repaint) Repaint();
        }

        public void PrintHeadPanel() {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            using (new EditorGUI.DisabledScope(!stats.Any() || EditorApplication.isCompiling || EditorApplication.isPlayingOrWillChangePlaymode)) {
                if (GUILayout.Button(updateStatsClassContent, EditorStyles.toolbarButton)) {
                    UpdateStatsClass();
                }
            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }

        private bool PrintStatList() {
            for (int i = 0; i < stats.Count; i++) {
                EditorGUILayout.BeginHorizontal();
                string s = stats.ElementAt(i);
                stats.RemoveAt(i);
                stats.Insert(i, EditorGUILayout.TextField(s));
                if(GUILayout.Button(deleteStatContent, EditorStyles.miniButtonRight)) {
                    stats.RemoveAt(i);
                }
                EditorGUILayout.EndHorizontal();
            }
            return true;
        }
        #endregion

        /// <summary>
        /// Create the Stats class using the stats currently listed on the window
        /// </summary>
        private void UpdateStatsClass() {
            StatClassCreator.statNames = stats.ToArray();
            StatClassCreator.Create();
        }

        private void NewStat() {
            stats.Add("<new stat>");
        }

        // Implements IHasCustomMenu
        public void AddItemsToMenu(GenericMenu menu) {
            /*
            menu.AddItem(m_GUIBlockUI, m_Settings.blockUIWhenRunning, m_Settings.ToggleBlockUIWhenRunning);
            menu.AddItem(m_GUIPauseOnFailure, m_Settings.pauseOnTestFailure, m_Settings.TogglePauseOnTestFailure);
            */
        }

        public void OnInspectorUpdate() {
            if (focusedWindow != this) Repaint();
        }

        [MenuItem("Timba/Combat/Stats Manager")]
        public static StatsManagerWindow ShowWindow() {
            var w = GetWindow(typeof(StatsManagerWindow));
            w.Show();
            return w as StatsManagerWindow;
        }
    }
}
