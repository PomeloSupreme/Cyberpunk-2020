using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public SkillOverPanel skillOverPanel;
    public bool IsCareerSkill;
    public string Name;
    public TMP_Text SkillNameObject;
    public TMP_Text SkillPointObject;

    private void Start()
    {
        
        IsCareerSkill = false;
    }

    public void SetNameAndText(string name)
    {
        Name = name;
        SkillNameObject.text = name;
    }

    public void OnPlusOrMinusButton(bool IsPlus)
    {
        SkillPointObject.text = ConvertIntToTextAndDetermineZero(skillOverPanel.IncrementPickupOrCareerPoints(IsCareerSkill, IsPlus, Name));
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
