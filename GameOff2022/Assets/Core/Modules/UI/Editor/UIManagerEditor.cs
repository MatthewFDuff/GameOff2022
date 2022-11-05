using UnityEditor;
using UnityEngine;

namespace Core.Modules.UI.Editor
{
    [CustomEditor(typeof(UIManager))]
    public class UIManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var targetManager = (UIManager) target;
            var viewContainer = targetManager.transform.Find("Views");
            
            if (viewContainer == null) return;

            var views = viewContainer.GetComponentsInChildren<Transform>(true);
            if (views.Length <= 0) return;
            
            GUILayout.Label("Set Active View");
            foreach (var viewObject in views)
            {
                if (!viewObject.TryGetComponent<UIView>(out var view)) continue;

                if (GUILayout.Button(view.name))
                {
                    foreach (var viewObj in viewContainer.GetComponentsInChildren<Transform>(true))
                    {
                        if (!viewObj.TryGetComponent<UIView>(out var v)) continue;
                        
                        v.DisplayCanvas(v.transform.name.Equals(view.name));
                        
                        if(v.transform.name.Equals(view.name)) EditorGUIUtility.PingObject(v.gameObject);
                    }
                }
            }
            
        }
    }
}