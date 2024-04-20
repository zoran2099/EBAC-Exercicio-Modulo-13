using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameManger : MonoBehaviour
{
   
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1.0f;
    }
}
