using Core.Modules.Utility.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.Modules.UI.Views
{
    public class MainView : UIView
    {
        [Header("UI Components")]
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button quitButton;

        public override void Initialize()
        {
            base.Initialize();
            
            playButton.AddOnClickListener(Play);
            // settingsButton.AddOnClickListener(Settings);
            quitButton.AddOnClickListener(Quit);
        }

        private static void Play()
        {
            SceneManager.LoadSceneAsync("Game");
        }

        private static void Settings()
        {
            UIManager.Instance.ShowOnly<SettingsView>();
        }

        private static void Quit()
        {
            GameManager.QuitGame();
        }
    }
}