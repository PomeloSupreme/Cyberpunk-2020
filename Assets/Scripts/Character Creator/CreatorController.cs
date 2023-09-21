using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatorController : MonoBehaviour
{
    public GameObject PanelParent;
    private List<GameObject> panels = new List<GameObject>();

    public List<int> statValues = new List<int>();
    public List<int> skillValues = new List<int>();
    List<int> statValueOptions= new List<int>();
    public List<int> currentValueOptions= new List<int>();
    
    //int statPoints;
    public GameObject[] Stats;

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
        Stats = GameObject.FindGameObjectsWithTag("Stat");
    }
    /*private int determineSkillPositionInList(string skillName)
    {
        int skillListPosition;
        switch (skillName)
        {

        }
    }*/

    private int determineStatPositionInList (string stat)
    {
        int statListPosition;
        switch (stat)
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
    public void RandomizeStatValueOptions()
    {
        statValueOptions.Clear();
        for(int i = 0; i < 9; i++)
        {
            statValueOptions.Add(Random.Range(2, 10));
        }
        currentValueOptions.Clear();
        currentValueOptions.AddRange(statValueOptions);
    }
    
    /*public int AccessStatPoints()
    {
        return statPoints;
    }*/
    /*public int AccessStatPoints(int newStatPointsValue)
    {
        statPoints= newStatPointsValue;
        return statPoints;
    }*/
    public int AccessStatValueList(string name)
    {
        int index = determineStatPositionInList(name);
        return statValues[index];
    }
    public int AccessStatValueOptionsList(int index)
    {
        return statValueOptions[index];
    }
    public List<int> AccessStatValueOptionsList()
    {
        return statValueOptions;
    }
    public void AdjustCurrentStatValueList(int dropdownValue, string name)
    {
        if (dropdownValue == -1)
        {
            currentValueOptions.Add(statValues[determineStatPositionInList(name)]);
            statValues[determineStatPositionInList(name)] = 0;
        }
        else if (statValues[determineStatPositionInList(name)] != 0)
        {
            currentValueOptions.Add(statValues[determineStatPositionInList(name)]);
            statValues[determineStatPositionInList(name)] = currentValueOptions[dropdownValue];
            currentValueOptions.RemoveAt(dropdownValue);
        }
        else
        {
            statValues[determineStatPositionInList(name)] = currentValueOptions[dropdownValue];
            currentValueOptions.RemoveAt(dropdownValue);
        }
        
        foreach(GameObject stat in Stats)
        {
            Stat statElement = stat.GetComponent<Stat>();
            statElement.UpdateDropdownList(currentValueOptions, statValues[determineStatPositionInList(statElement.Name)]);
        }
    }
    public void ResetStatValues(int resetValue)
    {
        statValues.Clear();
        for (int i = 0; i < 9; i++)
        {
            statValues.Add(resetValue);
        }
    }
    public void IncrementStat(bool isPlus, string name)
    {
        if (isPlus)
        {
            statValues[determineStatPositionInList(name)]++;
        }
        if (!isPlus)
        {
            statValues[determineStatPositionInList(name)]--;
        }
    }
    public int TotalStatValue()
    {
        int totalStatValue = 0;
        foreach (int stat in statValues)
        {
            totalStatValue += stat;
        }
        return totalStatValue;

    }
}
