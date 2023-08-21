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
    string previousText;
    string currentText;
    Controller controller;


    



    public void Start()
    {
        controller = GetComponentInParent<Controller>();
        previousValue = 0;
        currentText = "--";
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

    public void ChangeCurrentText(string text)
    {
        currentText = text;
    }

    public string AccessCurrentText()
    {
        return currentText;
    }
    public string AccessPreviousText()
    {
        return previousText;
    }
    public void ChangePreviousText(string text)
    {
        previousText = text;
    }

    
}
