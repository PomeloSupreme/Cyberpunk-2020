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
    public float HowMuchToFade;
    public string Name;
    public string Description;
    public TMP_Text StatValue;
    public GameObject DescriptionText;
    public GameObject buttonMinus;
    public GameObject buttonPlus;


    private void Start()
    {
        GetComponent<TMP_Text>().text= Name;
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
       
    }

    public void OnPlusButton()
    {

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

}
