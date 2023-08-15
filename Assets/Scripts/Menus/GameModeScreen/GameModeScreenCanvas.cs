using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeScreenCanvas : MonoBehaviour
{
   public void OnCreateCharacter()
    {
        SceneManager.LoadScene("CreateCharacterScreen");
    }
}
