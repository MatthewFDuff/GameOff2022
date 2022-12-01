using System;
using Core.Modules.Utility.Singletons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Modules
{
    public class GameManager : PersistentSingleton<GameManager>
    {
        [SerializeField] Level[] gameLevels;
        int completedLevels = 0;
        
        public static void QuitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene("Game");
        }

        public Level GetNextLevel()
        {
            if (completedLevels >= gameLevels.Length) return null;
            return gameLevels[completedLevels];
        }
        public void CompleteLevel() => completedLevels++;
    }
}
