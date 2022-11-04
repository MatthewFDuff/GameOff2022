#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    public class SceneTool : EditorWindow
    {
        private const string RootDirectory = "Assets";

        private int _selectedSceneFolder = 0;

        private Dictionary<string, string> _sceneFolders;

        [MenuItem("Window/SceneTool")]
        public static void ShowWindow()
        {
            GetWindow(typeof(SceneTool), false, "Scene Tool");
        }

        private void InitializeSceneFolder()
        {
            _sceneFolders?.Clear();
            _sceneFolders = new Dictionary<string, string>();

            var subfolders = AssetDatabase.GetSubFolders(RootDirectory);
            foreach (var subfolderPath in subfolders)
            {
                FindScenesFolders(subfolderPath);
            }
        }

        private void FindScenesFolders(string subfolderPath)
        {
            var folderName = subfolderPath.Split('/').Last();
            if (folderName.ToLower().Equals("scenes"))
            {
                _sceneFolders.Add(subfolderPath.Remove(subfolderPath.Length - "/Scenes".Length).Split('/').Last(),
                    subfolderPath);
            }

            var subfolders = AssetDatabase.GetSubFolders(subfolderPath);
            foreach (var folder in subfolders)
            {
                FindScenesFolders(folder);
            }
        }

        private void OnGUI()
        {
            InitializeSceneFolder();

            if (_sceneFolders == null || _sceneFolders.Count == 0) return;

            _selectedSceneFolder =
                EditorGUILayout.Popup("Prefab Folder", _selectedSceneFolder, _sceneFolders.Keys.ToArray());

            var sceneFolderPath = _sceneFolders[_sceneFolders.Keys.ToArray()[_selectedSceneFolder]];

            if (sceneFolderPath == null) return;

            var sceneGuids = AssetDatabase.FindAssets("t:scene", new[] {sceneFolderPath});
            foreach (var sceneGuid in sceneGuids)
            {
                var scenePath = AssetDatabase.GUIDToAssetPath(sceneGuid);
                var sceneName = scenePath.Split('/').Last();

                if (GUILayout.Button(sceneName.Replace(".unity", "")))
                {
                    if (SceneManager.GetActiveScene().isDirty)
                        EditorSceneManager.SaveScene(SceneManager.GetActiveScene());

                    EditorSceneManager.OpenScene(scenePath);
                }
            }
        }
    }
}
#endif