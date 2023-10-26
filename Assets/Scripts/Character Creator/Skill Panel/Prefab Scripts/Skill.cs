using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public SkillOverPanel skillOverPanel;
    public bool IsCareerSkill;
    public string Name;
    public TMP_Text SkillNameObject;
    public TMP_Text SkillPointObject;
    public GameObject MinusButton;
    public GameObject PlusButton;

    public void SetNameAndText(string name)
    {
        Name = name;
        SkillNameObject.text = name;
    }
    public void HideButtons(bool hide)  
    {
        MinusButton.SetActive(hide);
        PlusButton.SetActive(hide);
    }
    public void DetermineButtonStatus()
    {
        int skillLevel = skillOverPanel.creatorController.AccessSkillValue(Name);
        if (Name == "Pharmacology")
        {
            if(skillOverPanel.creatorController.AccessSkillValue("Chemistry")<4)
            {
                HideButtons(false);
            }
        }
        if (Name == "Chemistry"
            && skillOverPanel.pharmaSkill != null)
        {
            if(skillLevel >= 4)
            {
                skillOverPanel.PharmaAvailable(true);
            }
            else
            {
                skillOverPanel.PharmaAvailable(false);
            }
        }
        if(skillLevel == 10)
        {
            PlusButton.SetActive(false);
        }
        else if(skillLevel == 0)
        {
            MinusButton.SetActive(false);
        }
        else
        {
            MinusButton.SetActive(true);
            PlusButton.SetActive(true);
        }
    }

    public void OnPlusOrMinusButton(bool IsPlus)
    {
        if (this.GetComponentInParent<SkillPanel>().IsSpecialAbility)
        {
            if (IsCareerSkill)
            {
                int skillLevel = skillOverPanel.IncrementPickupOrCareerPoints(IsCareerSkill, IsPlus, Name);
                SkillPointObject.text = ConvertIntToTextAndDetermineZero(skillLevel);
                DetermineButtonStatus();
            }
        }
        else
        {
            int skillLevel = skillOverPanel.IncrementPickupOrCareerPoints(IsCareerSkill, IsPlus, Name);
            SkillPointObject.text = ConvertIntToTextAndDetermineZero(skillLevel);
            DetermineButtonStatus();
        }
    }
    public void SetText(string text)
    {
        SkillPointObject.text = text;
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
