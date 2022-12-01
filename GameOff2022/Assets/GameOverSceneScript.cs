using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayAgainButtonPressed(string sceneName)
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitButtonPressed(string sceneName)
    {
        SceneManager.LoadScene("Menu");
    }
}
