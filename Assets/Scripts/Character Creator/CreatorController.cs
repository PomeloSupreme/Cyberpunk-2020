using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatorController : MonoBehaviour
{
    public GameObject PanelParent;
    private List<GameObject> panels = new List<GameObject>();

    List<int> statValues = new List<int>();

    enum Stat
    {
        Intelligence,
        Reflex,
        Technical,
        Cool,
        Attractiveness,
        Luck,
        Movement,
        Body,
        Empathy,
    }



    private void Start()
    {
        for(int i = 0; i < statValues.Count; i++)
        {
            statValues[i] = 2;
        }
        foreach (GameObject panel in panels)
        {
            panels.Add(panel);
        }

        Debug.Log((int)Stat.Intelligence);
    }

    private int determineStatPositionInList (string stat)
    {
        int statListPosition;
        switch (name)
        {
            case "Intelligence":
                statListPosition = 0;
                break;
            case "Reflex":
                statListPosition = 1;
                break;
            case "Technical":
                statListPosition = 2;
                break;
            case "Cool":
                statListPosition = 3;
                break;
            case "Attractiveness":
                statListPosition = 4;
                break;
            case "Luck":
                statListPosition = 5;
                break;
            case "Movement":
                statListPosition = 6;
                break;
            case "Body":
                statListPosition = 7;
                break;
            case "Empathy":
                statListPosition = 8;
                break;
            default:
                Debug.Log("Error In DetermineStatPositionInList Function in Creator Controller Script. String Not Found");
                statListPosition = 10;
                break;
        }
        return statListPosition;
    }
    public int ReturnStatValue(string name)
    {
        int statPositionInList = determineStatPositionInList(name);
        return statValues[statPositionInList];
    }
    public int OnStatButtonReturnsStatValue(string name, bool isPLus)
    {
        int statPositionInList = determineStatPositionInList(name);
        int currentStatValue = statValues[statPositionInList];
        if (isPLus)
        {
            if (currentStatValue >= 0
                && currentStatValue < 10)
            {
                statValues[statPositionInList]++;
            }
        }
        else if (!isPLus)
        {
            if (currentStatValue <= 10
                && currentStatValue > 0)
            {
                statValues[statPositionInList]--;
            }
        }
        else
        {
            Debug.Log("Error in OnStatButton, isPlus was not read properly");
        }
        return statValues[statPositionInList];
    }
     
}
