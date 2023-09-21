using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseOverRevealsText : MonoBehaviour
{
    public string TextToDisplay;
    public GameObject
    public void StatPointerEnter()
    {
        
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
}
