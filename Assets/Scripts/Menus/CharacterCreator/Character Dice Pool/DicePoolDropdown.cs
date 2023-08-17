using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DicePoolDropdown : MonoBehaviour
{
    DicePoolButton dicePoolButton;

    public void Start()
    {
        dicePoolButton = GameObject.FindGameObjectWithTag("DicePoolButton").GetComponent<DicePoolButton>();
    }
    public void OnDropdownValueChange()
    {
        List<string> originalList = dicePoolButton.ReportString();


        
    }
}
