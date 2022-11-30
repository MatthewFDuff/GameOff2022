using System.Collections;
using System.Collections.Generic;
using Core.Modules;
using UnityEngine;

public class PressAnyKeyToContinue : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            FindObjectOfType<GameManager>()?.LoadGameScene();
        }
    }
}
