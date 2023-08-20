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
    int previousValue;
    Controller controller;


    


    //8.18.23 The logic is kind of fucked. Need to adjust lists to subtract at index selected value, and then append the currentSelection to the front of the list. 
    public void Start()
    {
        controller = GetComponentInParent<Controller>();
        previousValue = 0;
    }

    public void ReportDropdownToController()
    {
        controller.SetCurrentDropdown(GetComponent<TMP_Dropdown>());
    }

    public void ChangePreviousValue(int currentValue)
    {
        previousValue = currentValue;
    }

    public int AccessPreviousValue()
    {
        return previousValue;
    }
    /*public void OnDropdownValueChange()
    {
        int selectedValue = GetComponentInChildren<TMP_Dropdown>().value;

        if(selectedValue == 0)
        {
            Debug.Log("Chose Empty");
        }
        else if (DicePoolDropdown.chosenDropdownValues.Contains(selectedValue))
        {
            Debug.Log("Number Already Chosen BOOOOO");
        }
        else DicePoolDropdown.chosenDropdownValues.Add(selectedValue);

    }


    public void BADOnDropdownValueChange()
    {
        optionDependentDiceRolls = dicePoolButton.ReportOptionDependentDiceRolls();
        List<string> appendingString = dicePoolButton.ReportOptionDependentDiceRolls();
        //Dropdown value assigned to text player has selected
        int selectedValue = GetComponent<TMP_Dropdown>().value;
        //Text Player Has Selected
        string currentSelection = GetComponent<TMP_Dropdown>().options[selectedValue].text;

        if (currentSelection == "--")
        {
            if (previousSelection == "--")
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
            //optionDependentDiceRolls.RemoveAt(selectedValue);
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
        else if (currentSelection != previousSelection)
        {
            if (previousSelection == "--")
            {
                previousSelection = currentSelection;
                optionDependentDiceRolls.RemoveAt(selectedValue);
                foreach (GameObject dicePoolDropdown in dicePoolDropdowns)
                {
                    if (dicePoolDropdown.GetComponentInChildren<TMP_Dropdown>().options[0].text == "--")
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
                DropdownOptionsListUpdaterForEmpty(dicePoolDropdown);
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

    public TMP_Dropdown GetDropdownComponent(GameObject panel)
    {
        return panel.GetComponentInChildren<TMP_Dropdown>();
    }

    public void DropdownOptionsListUpdaterForEmpty(GameObject panel)
    {
        TMP_Dropdown dropdown = GetDropdownComponent(panel);
        if (dropdown.options[0].text == "--")
        {
            dropdown.ClearOptions();
            dropdown.AddOptions(optionDependentDiceRolls);
        }
    }*/
}
