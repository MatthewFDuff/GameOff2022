using UnityEngine;

namespace Core.Modules.Controls
{
    [CreateAssetMenu(fileName = "Controls", menuName = "Scriptables/Controls", order = 0)]
    public class Controls : ScriptableObject
    {
        // As we create controls, assign them here with a default.
        public KeyCode attack;

        public void Save()
        {
            PlayerPrefs.GetInt("attack", (int) attack);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            attack = (KeyCode) PlayerPrefs.GetInt("attack", (int) attack);
        }
    }
}