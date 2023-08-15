using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
   public void OnStartSimulation()
    {
        SceneManager.LoadScene("GameModeScreen");
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
