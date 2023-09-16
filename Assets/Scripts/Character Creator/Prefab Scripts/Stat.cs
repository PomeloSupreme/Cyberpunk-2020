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
    public float HowMuchToFade;
    public string Name;
    public string Description;
    public TMP_Text StatValue;
    public GameObject DescriptionText;
    public GameObject buttonMinus;
    public GameObject buttonPlus;


    private void Start()
    {
        creatorController = GetComponentInParent<CreatorController>();
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
        int currentValue = creatorController.OnStatButtonReturnsStatValue(Name, false);
        
        if (currentValue == 2)
        {
            buttonMinus.GetComponent<GameObject>().SetActive(false);
        }
        if (currentValue == 9)
        {
            buttonPlus.GetComponent<GameObject>().SetActive(true);
        }
        SetStatTextToControllerList();
    }

    public void OnPlusButton()
    {
        int currentValue = creatorController.OnStatButtonReturnsStatValue(name, true);

        if (currentValue == 3)
        {
            buttonMinus.GetComponent<GameObject>().SetActive(true);
        }
        if (currentValue == 10)
        {
            buttonPlus.GetComponent<GameObject>().SetActive(false);
        }
        SetStatTextToControllerList();
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
    private void SetStatTextToControllerList()
    {
        int currentValue = creatorController.ReturnStatValue(Name);
        StatValue.GetComponent<TMP_Text>().text = ConvertIntToTextAndDetermineZero(currentValue);
    }
    private string ConvertIntToTextAndDetermineZero(int value)
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
            && value > 0)
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

}
