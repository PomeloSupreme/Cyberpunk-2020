using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RandomButton : MonoBehaviour
{
    GameObject[] dicePoolDropdowns;
    GameObject[] statButtons;
    GameObject[] rollTexts;
    GameObject dicePoolPanel;
    GameObject[] pointAllotments;
    GameObject pointsPanel;
    GameObject secondaryPointsPanel;
    

    private void Start()
    {
        dicePoolDropdowns = GameObject.FindGameObjectsWithTag("DicePoolDropdown");
        statButtons = GameObject.FindGameObjectsWithTag("StatButton");
        rollTexts = GameObject.FindGameObjectsWithTag("RollText");
        dicePoolPanel = GameObject.FindGameObjectWithTag("DicePoolPanel");
        pointAllotments = GameObject.FindGameObjectsWithTag("PointAllotment");
        pointsPanel = GameObject.FindGameObjectWithTag("PointPanel");
        secondaryPointsPanel = GameObject.FindGameObjectWithTag("SecondaryPointsPool");
    }

    public void OnRandomButton()
    {
        pointsPanel.SetActive(true);
        secondaryPointsPanel.SetActive(false);
        dicePoolPanel.SetActive(false);
        //  pointsPanel.
        foreach (GameObject pointAllotment in pointAllotments)
        {
            pointAllotment.SetActive(true);
        }
        foreach (GameObject dicepooldropdown in dicePoolDropdowns)
        {
            dicepooldropdown.SetActive(false);
        }
        foreach (GameObject statButton in statButtons)
        {
            statButton.SetActive(true);
        }

        int pointValue = 0;

        for (int i = 0; i <= 8; i++)
        {
            pointValue += Random.Range(1, 10);
        }

        pointsPanel.GetComponentInChildren<TMP_Text>().text = (pointValue - 18).ToString();

        foreach (GameObject pointAllotment in pointAllotments)
        {
            pointAllotment.SetActive(true);
            pointAllotment.GetComponent<TMP_Text>().text = "02";
        }
    }
    
    
}
