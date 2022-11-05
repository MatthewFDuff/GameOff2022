using UnityEngine;

namespace Core.Modules.Utility.Singletons
{
    /// <summary>
    /// Singleton pattern.
    /// </summary>
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        /// <summary>
        /// Singleton design pattern
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                _instance = FindObjectOfType<T> ();
                
                if (_instance != null) return _instance;
                
                var obj = new GameObject ();
                _instance = obj.AddComponent<T> ();
                return _instance;
            }
        }

        /// <summary>
        /// On awake, we initialize our instance. Make sure to call base.Awake() in override if you need awake.
        /// </summary>
        protected virtual void Awake ()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            _instance = this as T;			
        }
    }
}