using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    



    public void Start()
    {
        dicePoolDropdowns = GameObject.FindGameObjectsWithTag("DicePoolDropdown");
        dicePoolButton = GameObject.FindGameObjectWithTag("DicePoolButton").GetComponent<DicePoolButton>();
        previousSelection = "--";
    }
    public void OnDropdownValueChange()
    {
        optionDependentDiceRolls = dicePoolButton.ReportOptionDependentDiceRolls();

        string currentSelection = dropdownLabel.text;
        if(currentSelection == "--")
        {
            optionDependentDiceRolls.Add(previousSelection);
            foreach(GameObject dicePoolDropdown in dicePoolDropdowns)
            {
                dicePoolDropdown.GetComponent<TMP_Dropdown>().ClearOptions();
                dicePoolDropdown.GetComponent<TMP_Dropdown>().AddOptions(optionDependentDiceRolls);
            }
        }
        else
        {
            optionDependentDiceRolls.Remove(currentSelection);
            optionDependentDiceRolls.Add(previousSelection);
            previousSelection= currentSelection;

            foreach(GameObject dicePoolDropdown in dicePoolDropdowns)
            {
                dicePoolDropdown.GetComponent<TMP_Dropdown>().ClearOptions();
                dicePoolDropdown.GetComponent<TMP_Dropdown>().AddOptions(optionDependentDiceRolls);
            }
        }
        dicePoolButton.UpdateOptionDependentDiceRolls(optionDependentDiceRolls);
        
        


        
    }
}
