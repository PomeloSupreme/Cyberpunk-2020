using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DicePoolButton : MonoBehaviour
{
    public GameObject DicePoolPanel = new GameObject();
    public GameObject PointsPanel = new GameObject();
    public void OnDicePoolButton()
    {
        DicePoolPanel.SetActive(true);
        PointsPanel.SetActive(false);
    }
}
