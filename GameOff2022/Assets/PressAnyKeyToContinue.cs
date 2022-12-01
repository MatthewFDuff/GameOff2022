using Core.Modules;
using UnityEngine;

public class PressAnyKeyToContinue : MonoBehaviour
{
    [SerializeField] private bool overrideToMainMenu = false;
    
    // Update is called once per frame
    void Update()
    {
        if (overrideToMainMenu)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                FindObjectOfType<GameManager>()?.LoadMainMenu();
                FindObjectOfType<GameManager>().completedLevels = 0;   
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                FindObjectOfType<GameManager>()?.LoadGameScene();
            }
        }
    }
}
