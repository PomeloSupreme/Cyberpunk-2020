using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DicePoolDropdown : MonoBehaviour
{
    DicePoolButton dicePoolButton;
    GameObject[] dicePoolDropdowns;
    string previousSelection;
    List<string> optionDependentDiceRolls = new List<string>();
    public Label dropdownLabel;
    


    //8.18.23 The logic is kind of fucked. Need to adjust lists to subtract at index selected value, and then append the currentSelection to the front of the list. 
    public void Start()
    {
        dicePoolDropdowns = GameObject.FindGameObjectsWithTag("DicePoolDropdown");
        dicePoolButton = GameObject.FindGameObjectWithTag("DicePoolButton").GetComponent<DicePoolButton>();
        previousSelection = "--";
    }

    public void OnDropdownValueChange()
    {
        optionDependentDiceRolls = dicePoolButton.ReportOptionDependentDiceRolls();
        List<string> appendingString = dicePoolButton.ReportOptionDependentDiceRolls();
        int selectedValue = GetComponent<TMP_Dropdown>().value;
        string currentSelection = GetComponent<TMP_Dropdown>().options[selectedValue].text;

        if(currentSelection == "--")
        {
            if(previousSelection == "--")
            {
                previousSelection = currentSelection;
                foreach (GameObject dicePoolDropdown in dicePoolDropdowns)
                {
                    if (dicePoolDropdown.GetComponent<TMP_Dropdown>().options[0].text == "--")
                    {
                        dicePoolDropdown.GetComponentInChildren<TMP_Dropdown>().ClearOptions();
                        dicePoolDropdown.GetComponentInChildren<TMP_Dropdown>().AddOptions(optionDependentDiceRolls);
                    }
                }
            }
            else
            optionDependentDiceRolls.RemoveAt(selectedValue);
            optionDependentDiceRolls.Insert(1, previousSelection);
            previousSelection = currentSelection;

            foreach (GameObject dicePoolDropdown in dicePoolDropdowns)
            {
                if (dicePoolDropdown.GetComponent<TMP_Dropdown>().options[0].text == "--")
                {
                    dicePoolDropdown.GetComponentInChildren<TMP_Dropdown>().ClearOptions();
                    dicePoolDropdown.GetComponentInChildren<TMP_Dropdown>().AddOptions(optionDependentDiceRolls);
                }
            }
        }
        else if( currentSelection != previousSelection)
        {
            if (previousSelection == "--")
            {
                previousSelection = currentSelection;
                optionDependentDiceRolls.RemoveAt(selectedValue);
                foreach (GameObject dicePoolDropdown in dicePoolDropdowns)
                {
                    if (dicePoolDropdown.GetComponent<TMP_Dropdown>().options[0].text == "--")
                    {
                        dicePoolDropdown.GetComponentInChildren<TMP_Dropdown>().ClearOptions();
                        dicePoolDropdown.GetComponentInChildren<TMP_Dropdown>().AddOptions(optionDependentDiceRolls);
                    }
                }
            }
            else
            optionDependentDiceRolls.Remove(currentSelection);
            optionDependentDiceRolls.Insert(1, previousSelection);
            previousSelection = currentSelection;

            foreach (GameObject dicePoolDropdown in dicePoolDropdowns)
            {
                if(dicePoolDropdown.GetComponent<TMP_Dropdown>().options[0].text == "--")
                    {
                    dicePoolDropdown.GetComponentInChildren<TMP_Dropdown>().ClearOptions();
                    dicePoolDropdown.GetComponentInChildren<TMP_Dropdown>().AddOptions(optionDependentDiceRolls);
                }
            }
        }

        else
        {
            foreach (GameObject dicePoolDropdown in dicePoolDropdowns)
            {
                dicePoolDropdown.GetComponentInChildren<TMP_Dropdown>().ClearOptions();
                dicePoolDropdown.GetComponentInChildren<TMP_Dropdown>().AddOptions(optionDependentDiceRolls);
            }
        }
        
        appendingString.Insert(0, currentSelection);
        GetComponent<TMP_Dropdown>().ClearOptions();
        GetComponent<TMP_Dropdown>().AddOptions(appendingString);
        dicePoolButton.UpdateOptionDependentDiceRolls(optionDependentDiceRolls);        
    }
}
