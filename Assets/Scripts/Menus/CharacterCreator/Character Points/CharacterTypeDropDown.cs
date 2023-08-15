using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTypeDropDown : MonoBehaviour
{
    int pointValue;
    public TMP_Text points;
    public TMP_Dropdown dropdown;


    public void CharacterTypeDropdown()
    {
        switch (dropdown.value)
        {
            case 0:
                pointValue = 50;
                break;
            case 1:
                pointValue = 60;
                break;
            case 2:
                pointValue = 75;
                break;
            case 3:
                pointValue = 70;
                break;
            case 4:
                pointValue = 80;
                break;
        }
        
        points.text = (pointValue - 18).ToString();

    }
}
