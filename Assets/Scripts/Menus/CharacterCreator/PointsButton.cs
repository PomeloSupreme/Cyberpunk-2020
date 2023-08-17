using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsButton : MonoBehaviour
{
    GameObject[] dicePoolDropdowns;
    GameObject[] statButtons;
    GameObject[] rollTexts;
    GameObject dicePoolPanel;
    GameObject[] pointAllotments;
    GameObject pointsPanel;

    private void Start()
    {
        dicePoolDropdowns = GameObject.FindGameObjectsWithTag("DicePoolDropdown");
        statButtons = GameObject.FindGameObjectsWithTag("StatButton");
        rollTexts = GameObject.FindGameObjectsWithTag("RollText");
        dicePoolPanel = GameObject.FindGameObjectWithTag("DicePoolPanel");
        pointAllotments = GameObject.FindGameObjectsWithTag("PointAllotment");
        pointsPanel = GameObject.FindGameObjectWithTag("PointPanel");
    }
    public void OnPointsButton()
    {

        dicePoolPanel.SetActive(false);
        pointsPanel.SetActive(true);
        foreach (GameObject pointAllotment in pointAllotments)
        {
            pointAllotment.SetActive(true);
            pointAllotment.GetComponent<TMP_Text>().text = "02";
        }
        foreach (GameObject dicepooldropdown in dicePoolDropdowns)
        {
            dicepooldropdown.SetActive(false);
        }
        foreach (GameObject statButton in statButtons)
        {
            statButton.SetActive(true);
        }
    }
    
}
