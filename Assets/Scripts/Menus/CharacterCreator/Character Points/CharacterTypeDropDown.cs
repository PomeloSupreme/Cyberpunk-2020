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

    public TMP_Text IntelligenceStat;
    public TMP_Text ReflexStat;
    public TMP_Text TechnicalStat;
    public TMP_Text CoolStat;
    public TMP_Text AttractivenessStat;
    public TMP_Text LuckStat;
    public TMP_Text MAStat;
    public TMP_Text BodyStat;
    public TMP_Text EmpathyStat;


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

        IntelligenceStat.text = "02";
        ReflexStat.text = "02";
        TechnicalStat.text = "02";
        CoolStat.text = "02";
        AttractivenessStat.text = "02";
        LuckStat.text = "02";
        MAStat.text = "02";
        BodyStat.text = "02";
        EmpathyStat.text = "02";

    }
}
