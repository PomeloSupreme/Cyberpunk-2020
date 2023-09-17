using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class StatOverPanel : MonoBehaviour
{
    public GameObject RandomButton;
    public GameObject PointsButton;
    public GameObject DiceRollButton;
    CreatorController creatorController;
    public GameObject StatPointPoolText;
    public GameObject DiceRollTextParent;
    public GameObject RoleDropdown;
    public GameObject[] Stats;
    public List<TMP_Text> DiceRollTextList;
    int statPoints;

    // Start is called before the first frame update
    void Start()
    {
        creatorController = GetComponentInParent<CreatorController>();
        Stats = GameObject.FindGameObjectsWithTag("Stat");
        SetButtonName();
        GatherDiceRollTexts();
        PopulateRoleDropdown();
        OnPointsButton();
    }

    public void OnRandomButton()
    {
        SetStatButtonsOrDropdownsActive(true);
        ResetStats(2);
        RandomizeStatPoints();
        StatPointPoolText.SetActive(true);
        DiceRollTextParent.SetActive(false);
        RoleDropdown.SetActive(false);
        UpdateStatPointPoolText();
    }
    public void OnPointsButton()
    {
        SetStatButtonsOrDropdownsActive(true);
        ResetStats(2);
        StatPointPoolText.SetActive(true);
        DiceRollTextParent.SetActive(false);
        RoleDropdown.SetActive(true);
        OnRoleDropdown();
        UpdateStatPointPoolText();
    }
    public void OnDiceRollButton()
    {
        SetStatButtonsOrDropdownsActive(false);
        creatorController.ResetStatValues(0);
        StatPointPoolText.SetActive(false);
        DiceRollTextParent.SetActive(true);
        RoleDropdown.SetActive(false);
        creatorController.RandomizeStatValueOptions();
        for (int i = 0; i < DiceRollTextList.Count; i++)
        {
            DiceRollTextList[i].text = ConvertIntToTextAndDetermineZero(creatorController.AccessStatValueOptionsList(i));
        }
        foreach(GameObject stat in Stats)
        {
            TMP_Dropdown dropdown = stat.transform.parent.GetComponentInChildren<TMP_Dropdown>();
            dropdown.ClearOptions();
            List<int> list = creatorController.AccessStatValueOptionsList();
            List<string> listToString = new List<string>();
            foreach (int i in list)
            {
                listToString.Add(ConvertIntToTextAndDetermineZero(i));
            }
            listToString.Insert(0, "--");
            dropdown.AddOptions(listToString);
        }
    }
    private void UpdateStatPointPoolText()
    {
        StatPointPoolText.GetComponent<TMP_Text>().text = statPoints.ToString();
    }
    private void SetStatButtonsOrDropdownsActive(bool IsButtonActive)
    {
        foreach (GameObject statName in Stats)
        {
            statName.GetComponentInChildren<Stat>().SetButtonOrDropdownActive(IsButtonActive);
        }
    }
    private void PopulateRoleDropdown()
    {
        TMP_Dropdown roleDropdown = RoleDropdown.GetComponent<TMP_Dropdown>();
        roleDropdown.ClearOptions();
        List<string> roles = new List<string> { "Average", "Minor Supporting Character", "Minor Hero", "Major Supporting Character", "Major Hero" };
        roleDropdown.AddOptions(roles);
    }
    public void OnRoleDropdown()
    {
        int dropdownValue = RoleDropdown.GetComponent<TMP_Dropdown>().value;
        switch (dropdownValue)
        {
            case 0:
                statPoints = 50;
                break;
            case 1:
                statPoints = 60;
                break;
            case 2:
                statPoints = 75;
                break;
            case 3:
                statPoints = 70;
                break;
            case 4:
                statPoints = 80;
                break;
            default:
                statPoints = 0;
                Debug.Log("Error OnRoleDropdown in StatTypeButton");
                break;
        }
        statPoints -= 18;
        UpdateStatPointPoolText();
    }
    public void SetButtonName()
    {
            DiceRollButton.GetComponentInChildren<TMP_Text>().text = "Dice Pool";
            RandomButton.GetComponentInChildren<TMP_Text>().text = "Random";
            PointsButton.GetComponentInChildren<TMP_Text>().text = "Points";
    }
    private void GatherDiceRollTexts()
    {
        foreach (Transform diceRolls in DiceRollTextParent.GetComponent<Transform>())
        {
            diceRolls.GetComponent<TMP_Text>().text = "00";
            DiceRollTextList.Add(diceRolls.GetComponent<TMP_Text>());
        }
    }
    private string ConvertIntToTextAndDetermineZero(int value)
    {
        if (value < -9)
        {
            return value.ToString();
        }
        else if (value < 0
            && value >= -9)
        {
            return "-0" + (value * -1).ToString();
        }
        else if (value <= 9
            && value >= 0)
        {
            return "0" + value.ToString();
        }
        else if (value > 9)
        {
            return value.ToString();
        }
        else
        {
            Debug.Log("Error in ConvertIntToText in Stat Script");
            return "ERROR";
        }
    }
    private void ResetStats(int resetValue)
    {
        creatorController.ResetStatValues(resetValue);
        foreach (GameObject stat in Stats)
        {
            stat.GetComponent<Stat>().SetStatTextToControllerList();
        }
    }
    public int OnStatButtonReturnsStatValue(string name, bool isPlus)
    {
        int currentStatValue = creatorController.ReturnStatValue(name);
        if (isPlus)
        {
            if (statPoints > 0
                && currentStatValue < 10)
            {
                creatorController.IncrementStat(isPlus, name) ;
                statPoints--;
            }
        }
        else if (!isPlus)
        {
            if (currentStatValue > 2)
            {
                creatorController.IncrementStat(isPlus, name);
                statPoints++;
            }
        }
        else
        {
            Debug.Log("Error in OnStatButton, isPlus was not read properly");
        }
        StatPointPoolText.GetComponent<TMP_Text>().text = ConvertIntToTextAndDetermineZero(statPoints);
        return creatorController.AccessStatValueList(name);
    }
    public void RandomizeStatPoints()
    {
        statPoints = 0;
        for (int i = 0; i < 9; i++)
        {
            statPoints += Random.Range(1, 10);
        }
    }

}
