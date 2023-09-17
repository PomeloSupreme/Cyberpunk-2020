using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class StatTypeButton : MonoBehaviour
{
    public bool IsFastButton;
    public bool IsRandomButton;
    public bool IsPointsButton;
    CreatorController creatorController;
    public GameObject StatPointPoolText;
    public GameObject DiceRollTextParent;
    public GameObject RoleDropdown;
    public GameObject[] Stats;
    public List<TMP_Text> DiceRollTextList;

    // Start is called before the first frame update
    void Start()
    {
        creatorController= GetComponentInParent<CreatorController>();
        Stats = GameObject.FindGameObjectsWithTag("Stat");
        SetButtonName();
        GatherDiceRollTexts();
    }

    public void OnPress()
    {
        if (IsRandomButton)
        {
            SetStatButtonsOrDropdownsActive(true);
            //creatorController.RandomizeStatPoints();
            StatPointPoolText.SetActive(true);
            DiceRollTextParent.SetActive(false);
            RoleDropdown.SetActive(false);
            UpdateStatPointPoolText();

        }
        else if(IsPointsButton)
        {
            SetStatButtonsOrDropdownsActive(true);
            StatPointPoolText.SetActive(true);
            DiceRollTextParent.SetActive(false);
            RoleDropdown.SetActive(true);
            UpdateStatPointPoolText();
        }
        else if(IsFastButton)
        {
            StatPointPoolText.SetActive(false);
            DiceRollTextParent.SetActive(true);
            RoleDropdown.SetActive(false);
            creatorController.RandomizeStatValueOptions();
            for (int i = 0; i <  DiceRollTextList.Count; i++)
            {
                DiceRollTextList[i].text = ConvertIntToTextAndDetermineZero(creatorController.AccessStatValueOptionsList(i));
            }
        }
    }
    private void UpdateStatPointPoolText()
    {
        //StatPointPoolText.GetComponent<TMP_Text>().text = creatorController.AccessStatPoints().ToString() ;
    }
    private void SetStatButtonsOrDropdownsActive(bool IsButtonActive)
    {
        foreach (GameObject statName in Stats)
        {
            statName.GetComponentInChildren<Stat>().SetButtonOrDropdownActive(IsButtonActive);
        }
    }
    public void OnRoleDropdown()
    {
        int dropdownValue = GetComponent<TMP_Dropdown>().value;
        int statPointsValue;
        switch (dropdownValue)
        {
            case 0:
                statPointsValue = 50;
                break;
            case 1:
                statPointsValue = 60;
                break;
            case 2:
                statPointsValue = 75;
                break;
            case 3:
                statPointsValue = 70;
                break;
            case 4:
                statPointsValue = 80;
                break;
            default:
                statPointsValue = 0;
                Debug.Log("Error OnRoleDropdown in StatTypeButton");
                break;
        }
        //creatorController.AccessStatPoints(statPointsValue);
        UpdateStatPointPoolText();
    }
    public void SetButtonName()
    {
        if (IsFastButton)
        {
            GetComponentInChildren<TMP_Text>().text = "Dice Pool";
        }
        else if (IsRandomButton)
        {
            GetComponentInChildren<TMP_Text>().text = "Random";
        }
        else if (IsPointsButton)
        {
            GetComponentInChildren<TMP_Text>().text = "Points";
        }
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
            && value > 0)
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
}
