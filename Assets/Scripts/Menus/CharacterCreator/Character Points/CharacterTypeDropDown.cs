using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTypeDropDown : MonoBehaviour
{
    int pointValue;

    GameObject pointsPanel;
    GameObject[] pointAllotments;

    public void Start()
    {
        pointAllotments = GameObject.FindGameObjectsWithTag("PointAllotment");
        pointsPanel = GameObject.FindGameObjectWithTag("PointPanel");
    }

    public void CharacterTypeDropdown()
    {
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
    }
}
