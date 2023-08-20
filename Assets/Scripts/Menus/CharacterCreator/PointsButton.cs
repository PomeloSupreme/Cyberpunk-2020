using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsButton : MonoBehaviour
{
    /*GameObject[] dicePoolDropdowns;
    GameObject[] statButtons;
    GameObject[] rollTexts;
    GameObject dicePoolPanel;
    GameObject[] pointAllotments;
    GameObject pointsPanel;
    GameObject secondaryPointsPanel;
    int pointValue;*/
    Controller controller;

    private void Start()
    {
        controller = GetComponentInParent<Controller>();
        /*dicePoolDropdowns = GameObject.FindGameObjectsWithTag("DicePoolDropdown");
        statButtons = GameObject.FindGameObjectsWithTag("StatButton");
        rollTexts = GameObject.FindGameObjectsWithTag("RollText");
        dicePoolPanel = GameObject.FindGameObjectWithTag("DicePoolPanel");
        pointAllotments = GameObject.FindGameObjectsWithTag("PointAllotment");
        pointsPanel = GameObject.FindGameObjectWithTag("PointPanel");
        secondaryPointsPanel = GameObject.FindGameObjectWithTag("SecondaryPointsPool");*/
    }
    public void ReportDropdownToController()
    {
        controller.SetCurrentDropdown(GetComponent<TMP_Dropdown>());
    }
    /*public void OnPointsButton()
    {
        

        secondaryPointsPanel.SetActive(true);
        dicePoolPanel.SetActive(false);
        pointsPanel.SetActive(true);

        switch (pointsPanel.GetComponentInChildren<TMP_Dropdown>().value)
        {
            case 0:
                pointValue = 50;
                break;
            case 1:
                pointValue = 60;
                break;
            case 2:
                pointValue = 75;
                break;
            case 3:
                pointValue = 70;
                break;
            case 4:
                pointValue = 80;
                break;
        }

        pointsPanel.GetComponentInChildren<TMP_Text>().text = (pointValue - 18).ToString();

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
    }*/
    
}
