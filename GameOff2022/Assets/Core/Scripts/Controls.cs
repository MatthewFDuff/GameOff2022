using UnityEngine;

namespace Core.Scripts
{
    [CreateAssetMenu(fileName = "Controls", menuName = "Scriptables/Controls", order = 0)]
    public class Controls : ScriptableObject
    {
        // As we create controls, assign them here with a default.
        public KeyCode attack;
        public KeyCode jump = KeyCode.Space;

        public void Save()
        {
            PlayerPrefs.GetInt("attack", (int) attack);
            PlayerPrefs.GetInt("jump", (int) jump);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            attack = (KeyCode) PlayerPrefs.GetInt("attack", (int) attack);
            jump = (KeyCode) PlayerPrefs.GetInt("jump", (int) jump);
        }
    }
}