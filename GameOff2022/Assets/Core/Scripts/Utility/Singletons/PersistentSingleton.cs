using UnityEngine;

namespace Core.Scripts.Utility.Singletons
{
    /// <summary>
    /// A singleton that does not get destroyed when the scene changes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PersistentSingleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;

                _instance = FindObjectOfType<T>();

                if (_instance != null) return _instance;
                
                var newInstance = new GameObject();
                _instance = newInstance.AddComponent<T>();

                return _instance;
            }
        }

        /// <summary>
        /// When a new instance is created we check if there's already an instance of the object. If there is one, we destroy the new one.
        /// </summary>
        protected virtual void Awake()
        {
            if (!Application.isPlaying) return;

            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(transform.gameObject);
            }
            else
            {
                if(this != _instance) Destroy(gameObject);
            }
        }
    }
}