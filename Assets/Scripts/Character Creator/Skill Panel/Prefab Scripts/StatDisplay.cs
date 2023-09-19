using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    CreatorController creatorController;
    public string Name;
    public TMP_Text StatValueDisplay;
    
    void Start()
    {
        creatorController = GetComponentInParent<CreatorController>();
        GetComponent<TMP_Text>().text = Name;
    }

    public void UpdateStatValueDisplay()
    {
        StatValueDisplay.text = ConvertIntToTextAndDetermineZero(creatorController.AccessStatValueList(Name));
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
