using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class Stat : MonoBehaviour
{
    public CreatorController creatorController;
    public StatOverPanel statOverPanel;
    public float HowMuchToFade;
    public string Name;
    public string Description;
    public TMP_Text StatValue;
    public GameObject DescriptionText;
    public GameObject buttonMinus;
    public GameObject buttonPlus;
    public GameObject dropdown;


    private void Start()
    {
        GetComponent<TMP_Text>().text= Name + ":";
        DescriptionText.GetComponentInChildren<TMP_Text>().text = Description;
        DescriptionText.SetActive(false);
    }
    public void StatPointerEnter()
    {
        Debug.Log("Mouse Entered");
        DescriptionText.SetActive(true);
        ChangeTransparencyForImage(buttonMinus, HowMuchToFade);
        ChangeTransparencyForImage(buttonPlus, HowMuchToFade);
        ChangeTransparencyForTMPText(GetComponent<TMP_Text>(), HowMuchToFade);
        ChangeTransparencyForTMPText(StatValue, HowMuchToFade);
    }

    public void StatPointerExit()
    {
        DescriptionText.SetActive(false);
        ChangeTransparencyForImage(buttonMinus, 1f);
        ChangeTransparencyForImage(buttonPlus, 1f);
        ChangeTransparencyForTMPText(this.GetComponent<TMP_Text>(), 1f);
        ChangeTransparencyForTMPText(StatValue, 1f);
    }

    public void OnMinusButton()
    {
        int currentValue = statOverPanel.OnStatButtonReturnsStatValue(Name, false);
        StatValue.GetComponent<TMP_Text>().text = ConvertIntToTextAndDetermineZero(currentValue);
        if (currentValue == 2)
        {
            buttonMinus.SetActive(false);
        }
        if (currentValue == 9)
        {
            buttonPlus.SetActive(true);
        }
        
    }

    public void OnPlusButton()
    {
        int currentValue = statOverPanel.OnStatButtonReturnsStatValue(Name, true);
        StatValue.GetComponent<TMP_Text>().text = ConvertIntToTextAndDetermineZero(currentValue);
        if (currentValue == 3)
        {
            buttonMinus.SetActive(true);
        }
        if (currentValue == 10)
        {
            buttonPlus.SetActive(false);
        }
        
    }
    public void OnDropdown()
    {
        TMP_Dropdown dropdownElement = dropdown.GetComponent<TMP_Dropdown>();
        int correctedDropdownValue = dropdownElement.value;
        if (creatorController.AccessStatValueList(Name) == 0)
        {
            correctedDropdownValue--;
        }
        else
        {
            correctedDropdownValue -= 2;
        }
        creatorController.AdjustCurrentStatValueList(correctedDropdownValue, Name);
    }
    private void ChangeTransparencyForImage(GameObject gameObject, float changeTransparency)
    {
        var color = gameObject.GetComponent<UnityEngine.UI.Image>().color;
        color.a= changeTransparency;
        gameObject.GetComponent<UnityEngine.UI.Image>().color = color;
    }
    private void ChangeTransparencyForTMPText(TMP_Text gameObject, float changeTransparency)
    {
        var color = gameObject.GetComponent<TMP_Text>().color;
        color.a= changeTransparency;
        gameObject.GetComponent<TMP_Text>().color = color;
    }
    public void SetStatTextToControllerList()
    {
        int currentValue = creatorController.ReturnStatValue(Name);
        StatValue.GetComponent<TMP_Text>().text = ConvertIntToTextAndDetermineZero(currentValue);
    }
    public string ConvertIntToTextAndDetermineZero(int value)
    {
        if( value < -9)
        {
            return value.ToString();
        }
        else if (value < 0
            && value >= -9)
        {
            return "-0" + (value * -1).ToString();
        }
        else if(value <= 9
            && value >= 0)
        {
            return "0" + value.ToString();
        }
        else  if(value > 9)
        {
            return value.ToString();
        }
        else
        {
            Debug.Log("Error in ConvertIntToText in Stat Script");
            return "ERROR";
        }
    }
    private List<string> ConvertListIntToStringIntDetermineZero(List<int> list)
    {
        List<string> result = new List<string>();
        foreach (int i in list)
        {
            result.Add(ConvertIntToTextAndDetermineZero(i));
        }
        return result;
    }
    public void SetButtonOrDropdownActive(bool ButtonIsActive)
        {
        if (ButtonIsActive)
        {
            buttonMinus.SetActive(true);
            buttonPlus.SetActive(true);
            dropdown.SetActive(false);
        }
        else
        {
            buttonMinus.SetActive(false);
            buttonPlus.SetActive(false);
            dropdown.SetActive(true);
        }
    }
    public void UpdateDropdownList(List<int> listOfInts, int currentValue)
    {
        List<string> dropdownDisplayList = new List<string>();
        dropdownDisplayList.AddRange(ConvertListIntToStringIntDetermineZero(listOfInts));
        TMP_Dropdown dropdownElement = dropdown.GetComponent<TMP_Dropdown>();
        dropdownElement.ClearOptions();
        if (currentValue == 0)
        {
            dropdownDisplayList.Insert(0, "--");
            dropdownElement.AddOptions(dropdownDisplayList);
        }
        else
        {
            
            dropdownDisplayList.Insert(0, ConvertIntToTextAndDetermineZero(currentValue));
            dropdownDisplayList.Insert(1, "--");
            dropdownElement.AddOptions(dropdownDisplayList);
        }
    }
   
}
