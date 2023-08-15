using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsButton : MonoBehaviour
{
    
    public GameObject DicePoolPanel = new GameObject();
    public GameObject PointsPanel = new GameObject();
    public void OnPointsButton()
    {
        DicePoolPanel.SetActive(false);
        PointsPanel.SetActive(true);
    }
}
