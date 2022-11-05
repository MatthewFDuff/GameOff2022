using System.Collections.Generic;
using Core.Modules.Utility.Singletons;
using UnityEngine;

namespace Core.Modules.UI
{
    /// <summary>
    /// The UIManager is used to control which views/UI are visible and makes it easy to switch between views while editing.
    /// </summary>
    [ExecuteInEditMode]
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private List<UIView> views;
        [SerializeField] private List<Camera> cameras;

        [SerializeField] private Transform viewContainer;
        [SerializeField] private Transform cameraContainer;

        #region Lifecycle Methods
        
        protected override void Awake()
        {
            base.Awake();

            GetCameras();
            GetViews();

            InitializeViews();
        }

        private void Update()
        {
            #if UNITY_EDITOR
            GetCameras();
            GetViews();
            #endif
        }
        
        #endregion

        #region Instance Management

        /// <summary>
        /// Update the list of cameras.
        /// </summary>
        private void GetCameras()
        {
            cameras.Clear();

            var camerasObject = cameraContainer ? cameraContainer : transform.Find("Cameras");
            
            if (camerasObject == null) return;

            foreach (var cameraObject in camerasObject.GetComponentsInChildren<Transform>(true))
            {
                if (cameraObject.TryGetComponent<Camera>(out var cam))
                {
                    cameras.Add(cam);
                }
            }
        }
        
        /// <summary>
        /// Update the list of views.
        /// </summary>
        private void GetViews()
        {
            views.Clear();
            
            var viewsObject = viewContainer ? viewContainer : transform.Find("Views");

            if (viewsObject == null) return;
                
            foreach (var viewObject in viewsObject.GetComponentsInChildren<Transform>(true))
            {
                if (viewObject.TryGetComponent<UIView>(out var view))
                {
                    views.Add(view);
                }
            }
        }

        #endregion

        #region View Management

        private void InitializeViews()
        {
            foreach (var view in views)
            {
                view.Initialize();
            }
        }
        
        /// <summary>
        /// Shows the view of type T and hides all non-persistent views. Used to switch between UI Views.
        ///
        /// Usage: UIManager.Instance.ShowOnly<SettingsView>();
        /// </summary>
        /// <typeparam name="T">The type of the UIView to be made visible.</typeparam>
        public void ShowOnly<T>()
        {
            foreach (var view in views)
            {
                if (view is T)
                {
                    view.Show();
                }
                else
                {
                    if (view.isPersistent) continue;

                    view.Hide();
                }
            }
        }

        #endregion

        
    }
}