using UnityEngine;

namespace Core.Modules.Controls
{
    [CreateAssetMenu(fileName = "Controls", menuName = "Scriptables/Controls", order = 0)]
    public class Controls : ScriptableObject
    {
        // As we create controls, assign them here with a default.
        public KeyCode lightAttack;
        public KeyCode heavyAttack;

        public void Save()
        {
            PlayerPrefs.GetInt("lightAttack", (int) lightAttack);
            PlayerPrefs.GetInt("heavyAttack", (int) heavyAttack);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            lightAttack = (KeyCode) PlayerPrefs.GetInt("lightAttack", (int) lightAttack);
            heavyAttack = (KeyCode) PlayerPrefs.GetInt("heavyAttack", (int) heavyAttack);
        }
    }
}