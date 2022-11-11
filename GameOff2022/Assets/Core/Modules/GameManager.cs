using System;
using Core.Modules.Utility.Singletons;

namespace Core.Modules
{
    public class GameManager : PersistentSingleton<GameManager>
    {
        public static void QuitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
