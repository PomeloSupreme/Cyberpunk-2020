using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    StatAlotter statAlotter;
    public string SkillName;
    int skillLevel;
    public bool IsSpecialAbility = false;
    public GameObject PlusButton;
    public GameObject MinusButton;
    TMP_Text skillLevelText; 

    private void Start()
    {
        statAlotter= GetComponentInParent<StatAlotter>();
        this.GetComponentInChildren<Text>().text = SkillName;
        MinusButton.SetActive(false);
        skillLevelText = GetComponentInChildren<TMP_Text>();
    }

    public void SetSkillLevel(int currentSkillLevel)
    {
        skillLevel = currentSkillLevel;
    }
    public int GetSkillLevel()
    {
        return skillLevel;
    }
     public void OnSkillPlusButton()
    {
        if (IsSpecialAbility
            && this.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == false)
        {
            Debug.Log("Special Ability Is Not Available For This Role");
        }
        else if (this.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == false)
        {
            if (statAlotter.ReportPickUpSkills() == 0)
            {
                Debug.Log("pickup skills at zero");
            }
            else if (this.GetComponentInParent<Skill>().GetSkillLevel() >= 10)
            {
                Debug.Log("Skill cannot be greater than 10");
            }
            else
            {
                statAlotter.IncrementPickUpSkills(-1);
                skillLevel++;
                SetSkillLevelText();
            }
        }
        else if (this.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == true)
        {
            if (statAlotter.ReportCareerSkills() == 0)
            {
                Debug.Log("career skills at zero");
            }
            else if(skillLevel >= 10)
            {
                Debug.Log("Error: Skill cannot be greater than 10");
            }
            else
            {
                statAlotter.IncrementCareerSkills(-1);
                skillLevel++;
                SetSkillLevelText();
            }
        }
        if(skillLevel == 10)
        {
            PlusButton.SetActive(false);
        }
        if(skillLevel == 1)
        {
            MinusButton.SetActive(true);
        }
        
    }
    public void OnSkillMinusButton()
    {
       
        if (IsSpecialAbility
            && this.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == false)
        {
            Debug.Log("Special Ability Is Not Available For This Role");
        }
        else if (this.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == false)
        {
            if (skillLevel == 0)
            {
                Debug.Log("Skill Points Empty");
            }
            else
            {
                statAlotter.IncrementPickUpSkills(1);
                skillLevel--;
                SetSkillLevelText();
            }
        }
        else if (this.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == true)
        {

            if (skillLevel == 0)
            {
                Debug.Log("Skill Points Empty");
            }
            else
            {
                statAlotter.IncrementCareerSkills(1);
                skillLevel--;
                SetSkillLevelText();
            }

        }
        if (skillLevel == 0)
        {
            MinusButton.SetActive(false);
        }
        if (skillLevel == 9)
        {
            PlusButton.SetActive(true);
        }
    }
    public void SetSkillLevelText()
    {
        if (skillLevel <= 9)
        {
            skillLevelText.text = "0" + skillLevel.ToString();
        }
        else
        {
            skillLevelText.text = skillLevel.ToString();
        }
    }
}


