using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Timba
{
    [Serializable]
    public class StatsManagerWindow : EditorWindow, IHasCustomMenu
    {
        #region GUI Contents
        private readonly GUIContent updateStatsClassContent = new GUIContent("Update", "Updates the stats class with the listed stat names");
        private readonly GUIContent addStatContent = new GUIContent("New stat", "Adds a new stat to the list");
        #endregion

        #region runner steerign vars
        private static StatsManagerWindow Instance;
        private bool m_IsBuilding;
        public static bool selectedInHierarchy;
        private Vector2 m_TestListScroll;
        #endregion

        private GameObject m_SelectedLine;

        public List<string> stats;

        static StatsManagerWindow()
        {
            //InitBackgroundRunners();
        }

        /*
        private static void InitBackgroundRunners()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= OnHierarchyWindowItemDraw;
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemDraw;
            EditorApplication.hierarchyWindowChanged -= OnHierarchyChangeUpdate;
            EditorApplication.hierarchyWindowChanged += OnHierarchyChangeUpdate;
            EditorApplication.playmodeStateChanged -= OnPlaymodeStateChanged;
            EditorApplication.playmodeStateChanged += OnPlaymodeStateChanged;
        }
        
        private static void OnPlaymodeStateChanged()
        {
            if (s_Instance && EditorApplication.isPlaying  == EditorApplication.isPlayingOrWillChangePlaymode)
                s_Instance.RebuildTestList();
        }
        
            public static void OnHierarchyChangeUpdate()
        {
            
            if (!s_Instance || s_Instance.m_TestLines == null || EditorApplication.isPlayingOrWillChangePlaymode) return;

            // create a test runner if it doesn't exist
            TestRunner.GetTestRunner();

            // make tests are not places under a go that is not a test itself
            foreach (var test in TestComponent.FindAllTestsOnScene())
            {
                if (test.gameObject.transform.parent != null && test.gameObject.transform.parent.gameObject.GetComponent<TestComponent>() == null)
                {
                    test.gameObject.transform.parent = null;
                    Debug.LogWarning("Tests need to be on top of the hierarchy or directly under another test.");
                }
            }
            if (selectedInHierarchy) selectedInHierarchy = false;
            else s_Instance.RebuildTestList();
            
        }

        public static void OnHierarchyWindowItemDraw(int id, Rect rect)
        {
            var o = EditorUtility.InstanceIDToObject(id);
            if (o is GameObject)
            {
                var go = o as GameObject;

                if (Event.current.type == EventType.MouseDown
                    && Event.current.button == 0
                    && rect.Contains(Event.current.mousePosition))
                {
                    var temp = go.transform;
                    while (temp != null)
                    {
                        var c = temp.GetComponent<TestComponent>();
                        if (c != null) break;
                        temp = temp.parent;
                    }
                    if (temp != null) SelectInHierarchy(temp.gameObject);
                }
            }
        }
        */


        public void OnDestroy()
        {
            //EditorApplication.hierarchyWindowItemOnGUI -= OnHierarchyWindowItemDraw;
            //EditorApplication.hierarchyWindowChanged -= OnHierarchyChangeUpdate;
        }

        public void OnEnable()
        {
            titleContent = new GUIContent("Stats Manager");
            Instance = this;
            Instance.stats = new List<string>();
            //m_Settings = ProjectSettingsBase.Load<IntegrationTestsRunnerSettings>();
            //InitBackgroundRunners();
        }

        public void OnSelectionChange()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode
                || Selection.objects == null
                || Selection.objects.Length == 0) return;
            /*
            if (Selection.gameObjects.Length == 1)
            {
                var go = Selection.gameObjects.Single();
                var temp = go.transform;
                while (temp != null)
                {
                    var tc = temp.GetComponent<TestComponent>();
                    if (tc != null) break;
                    temp = temp.parent;
                }

                if (temp != null)
                {
                    SelectInHierarchy(temp.gameObject);
                    Selection.activeGameObject = temp.gameObject;
                    m_SelectedLine = temp.gameObject;
                }
            }*/
        }
        
        private static void SelectInHierarchy(GameObject gameObject)
        {
            /*
            if (!Instance) return;
            if (gameObject == Instance.m_SelectedLine && gameObject.activeInHierarchy) return;
            if (EditorApplication.isPlayingOrWillChangePlaymode) return;
            if (!gameObject.activeSelf)
            {
                selectedInHierarchy = true;
                gameObject.SetActive(true);
            }

            var tests = TestComponent.FindAllTestsOnScene();
            var skipList = gameObject.GetComponentsInChildren(typeof(TestComponent), true).ToList();
            tests.RemoveAll(skipList.Contains);
            foreach (var test in tests)
            {
                var enable = test.GetComponentsInChildren(typeof(TestComponent), true).Any(c => c.gameObject == gameObject);
                if (test.gameObject.activeSelf != enable) test.gameObject.SetActive(enable);
            }*/
        }


        public void Update()
        {
            /*
            if (m_ReadyToRun && EditorApplication.isPlaying)
            {
                m_ReadyToRun = false;
                var testRunner = TestRunner.GetTestRunner();
                testRunner.TestRunnerCallback.Add(new RunnerCallback(this));
                var testComponents = m_TestsToRun.Select(go => go.GetComponent<TestComponent>()).ToList();
                testRunner.InitRunner(testComponents, m_DynamicTestsToRun);
            }*/
        }
        
        private void RebuildTestList()
        {
            /*
            m_TestLines = null;
            if (!TestComponent.AnyTestsOnScene() 
                && !TestComponent.AnyDynamicTestForCurrentScene()) return;

            if (!EditorApplication.isPlayingOrWillChangePlaymode)
            {
                var dynamicTestsOnScene = TestComponent.FindAllDynamicTestsOnScene();
                var dynamicTestTypes = TestComponent.GetTypesWithHelpAttribute(SceneManager.GetActiveScene().path);

                foreach (var dynamicTestType in dynamicTestTypes)
                {
                    var existingTests = dynamicTestsOnScene.Where(component => component.dynamicTypeName == dynamicTestType.AssemblyQualifiedName);
                    if (existingTests.Any())
                    {
                        var testComponent = existingTests.Single();
                        foreach (var c in testComponent.gameObject.GetComponents<Component>())
                        {
                            var type = Type.GetType(testComponent.dynamicTypeName);
                            if (c is TestComponent || c is Transform || type.IsInstanceOfType(c)) continue;
                            DestroyImmediate(c);
                        }
                        dynamicTestsOnScene.Remove(existingTests.Single());
                        continue;
                    }
                    TestComponent.CreateDynamicTest(dynamicTestType);
                }

                foreach (var testComponent in dynamicTestsOnScene)
                    DestroyImmediate(testComponent.gameObject);
            }

            var topTestList = TestComponent.FindAllTopTestsOnScene();

            var newResultList = new List<TestResult>();
            m_TestLines = ParseTestList(topTestList, newResultList);

            var oldDynamicResults = m_ResultList.Where(result => result.dynamicTest);
            foreach (var oldResult in m_ResultList)
            {
                var result = newResultList.Find(r => r.Id == oldResult.Id);
                if (result == null) continue;
                result.Update(oldResult);
            }
            newResultList.AddRange(oldDynamicResults.Where(r => !newResultList.Contains(r)));
            m_ResultList = newResultList;

            IntegrationTestRendererBase.RunTest = RunTests;
            IntegrationTestGroupLine.FoldMarkers = m_FoldMarkers;
            IntegrationTestLine.Results = m_ResultList;
            
            m_FilterSettings.UpdateCounters(m_ResultList.Cast<ITestResult>());

            m_FoldMarkers.RemoveAll(o => o == null);

            selectedInHierarchy = true;
            Repaint();
            */
        }

#region draw window
        public void OnGUI()
        {
            if (BuildPipeline.isBuildingPlayer)
            {
                m_IsBuilding = true;
            }
            else if (m_IsBuilding)
            {
                m_IsBuilding = false;
                Repaint();
            }

            PrintHeadPanel();

            EditorGUILayout.BeginVertical(GUIStyles.testList);
            m_TestListScroll = EditorGUILayout.BeginScrollView(m_TestListScroll);
            bool repaint = PrintTestList();
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();

            if (repaint) Repaint();
        }

        public void PrintHeadPanel()
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            using (new EditorGUI.DisabledScope(!stats.Any() || EditorApplication.isCompiling || EditorApplication.isPlayingOrWillChangePlaymode)) {
                if (GUILayout.Button(updateStatsClassContent, EditorStyles.toolbarButton))
                {
                    UpdateStatsClass();
                }
            }
            if (GUILayout.Button(addStatContent, EditorStyles.toolbarButton)) {
                NewStat();
            }
            GUILayout.FlexibleSpace ();
            EditorGUILayout.EndHorizontal ();
        }
                
        private bool PrintTestList()
        {
            for(int i = 0; i < stats.Count; i++) {
                EditorGUILayout.BeginHorizontal();
                string s = stats.ElementAt(i);
                stats.RemoveAt(i);
                stats.Insert(i, EditorGUILayout.TextField(s));
                EditorGUILayout.EndHorizontal();
            }
            return true;
        }
#endregion

        /// <summary>
        /// Create the Stats class using the stats currently listed on the window
        /// </summary>
        private void UpdateStatsClass()
        {
            StatClassCreator.statNames = stats.ToArray();
            StatClassCreator.Create();
        }

        private void NewStat() {
            stats.Add("<new stat>");
        }

        // Implements IHasCustomMenu
        public void AddItemsToMenu(GenericMenu menu)
        {
            /*
            menu.AddItem(m_GUIBlockUI, m_Settings.blockUIWhenRunning, m_Settings.ToggleBlockUIWhenRunning);
            menu.AddItem(m_GUIPauseOnFailure, m_Settings.pauseOnTestFailure, m_Settings.TogglePauseOnTestFailure);
            */
        }

        public void OnInspectorUpdate()
        {
            if (focusedWindow != this) Repaint();
        }

        [MenuItem("Window/Timba Combat System/Stats Manager")]
        public static StatsManagerWindow ShowWindow()
        {
            var w = GetWindow(typeof(StatsManagerWindow));
            w.Show();
            return w as StatsManagerWindow;
        }
    }
}
