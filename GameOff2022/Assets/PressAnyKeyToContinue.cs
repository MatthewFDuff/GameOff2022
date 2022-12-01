using Core.Modules;
using UnityEngine;

public class PressAnyKeyToContinue : MonoBehaviour
{
    [SerializeField] private bool overrideToMainMenu = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (overrideToMainMenu)
            {
                FindObjectOfType<GameManager>()?.LoadMainMenu();
            }
            else
            {
                FindObjectOfType<GameManager>()?.LoadGameScene();
            }
        }
    }
}
