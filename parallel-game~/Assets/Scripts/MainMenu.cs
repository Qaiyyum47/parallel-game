using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
   {
    SceneManager.LoadSceneAsync(1);
        Debug.Log("Player has respawned!");
    }
   
   public void ExitGame()
        { 
    Application.Quit();
}

public void MidgameQuit()
{
    SceneManager.LoadSceneAsync(0);
        Debug.Log("Player hasout!");
    }
}

  