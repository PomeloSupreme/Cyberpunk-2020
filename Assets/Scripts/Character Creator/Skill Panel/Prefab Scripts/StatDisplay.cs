using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    public CreatorController creatorController;
    public string Name;
    public TMP_Text StatValueDisplay;

    private void Awake()
    {
        creatorController = GetComponentInParent<CreatorController>();
    }
    void Start()
    {
        GetComponent<TMP_Text>().text = Name +": ";
        //UpdateStatValueDisplay();
    }
    private void OnEnable()
    {
        if (creatorController.statValues.Count > 0)
        {
            UpdateStatValueDisplay();
        }
    }

    public void UpdateStatValueDisplay()
    {
        if(StatValueDisplay != null)
        {
            StatValueDisplay.text = ConvertIntToTextAndDetermineZero(creatorController.AccessStatValueList(Name));
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
}
