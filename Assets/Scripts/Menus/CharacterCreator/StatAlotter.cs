using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StatAlotter : MonoBehaviour
{
    Controller controller;
    
    int pickupSkillsCount;
    int careerSkillsCount;
    int pickupSkillsChangeCounter;

    TMP_Text careerSkills;
    TMP_Text pickupSkills;

    GameObject[] skillPointToggles;

    public TMP_Dropdown roleDropdown;
    
    
    


    UnityEngine.UI.Button currentButton;

    public bool SkillPointsMatchController;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Controller>();
        pickupSkillsChangeCounter = 0;
        pickupSkillsCount = 4;
        pickupSkills.text = "04";
        careerSkillsCount = 40;
        skillPointToggles = GameObject.FindGameObjectsWithTag("SkillPointToggle");
    }
   /* private void DoSkillPointsMatch(bool skillPointsMatch)
    {
        if (skillPointsMatch == false)
        {
            pickupSkillsCount = (controller.pickupSkillPointsCount + pickupSkillsChangeCounter);
            pickupSkills.text = IfAddZeroToFront(pickupSkillsCount);
            skillPointsMatch = true;
            Debug.Log("Points Match Check| controller pickupCount" + controller.pickupSkillPointsCount + " | change counter " + pickupSkillsChangeCounter);
        }
    }*/
    public void AddReflexOrIntToPointPool(int reflexStat, int intelligenceStat)
    {
        pickupSkillsCount = (reflexStat + intelligenceStat + pickupSkillsChangeCounter);
        pickupSkills.text = IfAddZeroToFront(pickupSkillsCount);
    }
    public void AddReflexOrIntToPointPool(int reflexStat, int intelligenceStat, int pointCounter)
    {
        pickupSkillsChangeCounter = 0;
        pickupSkillsCount = (reflexStat + intelligenceStat + pickupSkillsChangeCounter);
        pickupSkills.text = IfAddZeroToFront(pickupSkillsCount);
    }
    public void SetCurrentButton(UnityEngine.UI.Button button)
    {
        currentButton = button;
    }
    public void OnSkillPlusButton()
    {
        bool isPlus = true;
        if (currentButton.GetComponentInParent<Skill>().IsSpecialAbility
            && currentButton.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == false)
        {
            Debug.Log("Special Ability Is Not Available For This Role");
        }
        else if (currentButton.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == false)
        {
            if (pickupSkillsCount == 0)
            {
                Debug.Log("pickup skills at zero");
            }
            else if (currentButton.GetComponentInParent<Skill>().GetSkillLevel() >= 10)
            {
                Debug.Log("Skill cannot be greater than 10");
            }
            else
            {
                pickupSkillsCount--;
                if (pickupSkillsCount < 9)
                {
                    pickupSkills.text = "0" + pickupSkillsCount.ToString();
                    SetSkill(currentButton, isPlus);
                }
                else
                {
                    pickupSkills.text = pickupSkillsCount.ToString();
                    SetSkill(currentButton, isPlus);
                }
            }
        }
        else if (currentButton.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == true)
        {
            if (careerSkillsCount == 0)
            {
                Debug.Log("career skills at zero");
            }
            else if(currentButton.GetComponentInParent<Skill>().GetSkillLevel() >= 10)
            {
                Debug.Log("Skill cannot be greater than 10");
            }
            else
            {
                careerSkillsCount--;
                if (careerSkillsCount < 9)
                {
                    careerSkills.text = "0" + careerSkillsCount.ToString();
                    SetSkill(currentButton, isPlus);
                }
                else
                {
                    careerSkills.text = careerSkillsCount.ToString();
                    SetSkill(currentButton, isPlus);
                }
            }
        }
        
    }
    public void OnSkillMinusButton()
    {
        bool isPlus = false;
        if (currentButton.GetComponentInParent<Skill>().IsSpecialAbility
            && currentButton.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == false)
        {
            Debug.Log("Special Ability Is Not Available For This Role");
        }
        else if (currentButton.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == false)
        {
            TMP_Text pointPool = currentButton.GetComponentInParent<TMP_Text>();
                if (pointPool.text == "00")
                {
                    Debug.Log("Skill Points Empty");
                }
            else if (pickupSkillsCount < 9)
                {
                pickupSkillsCount++;
                pickupSkills.text = "0" + pickupSkillsCount.ToString();
                SetSkill(currentButton, isPlus);
                
            }
                else
                {
                pickupSkillsCount++;
                pickupSkills.text = pickupSkillsCount.ToString();
                SetSkill(currentButton, isPlus);
            }
        }
        else if (currentButton.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == true)
        {
                
                if (currentButton.GetComponentInParent<TMP_Text>().text == "00")
                {
                    Debug.Log("Skill Points Empty");
                }
            else if (careerSkillsCount < 9)
                {
                careerSkillsCount++;
                careerSkills.text = "0" + careerSkillsCount.ToString();
                SetSkill(currentButton, isPlus);
            }
                else
                {
                careerSkillsCount++;
                careerSkills.text = careerSkillsCount.ToString();
                SetSkill(currentButton, isPlus);
            }
            
        }
        
    }
    public void SetSkill(UnityEngine.UI.Button button, bool isPlus)
    {
        TMP_Text SkillPointValue = button.GetComponentInParent<TMP_Text>();
        int changeValue;
        string ToggleText = button.transform.parent.parent.GetComponentInChildren<Text>().text;
        if (isPlus == true)
        {
            changeValue = 1;
            pickupSkillsChangeCounter--;
        }
        else
        {
            changeValue = (-1);
            pickupSkillsChangeCounter++;
        }
        Debug.Log("pickupSkillsChangeCounter = " + pickupSkillsChangeCounter);

        button.GetComponentInParent<Skill>().SetSkillLevel((button.GetComponentInParent<Skill>().GetSkillLevel()) + changeValue);
        button.GetComponentInParent<TMP_Text>().text = IfAddZeroToFront(button.GetComponentInParent<Skill>().GetSkillLevel());
            /*if (authority < 9)
            {
                button.GetComponentInParent<TMP_Text>().text = "0" + authority.ToString();
            }
            else
            {
                button.GetComponentInParent<TMP_Text>().text = authority.ToString();
            }*/
        
    }
    private string IfAddZeroToFront(int numberInQuestion)
    {
        if (numberInQuestion > (-10)
            && numberInQuestion < 0)
        {
            return "-0" + (numberInQuestion * (-1)).ToString();
        }
        else if (numberInQuestion <=9)
        {
            return "0" + numberInQuestion.ToString();
        }
        
        else
        {
            return numberInQuestion.ToString();
        }
    }
    private TMP_Text TMPTextTextFromButton(UnityEngine.UI.Button button)
    {
        return button.GetComponentInParent<TMP_Text>();
    }
    public void SetPickupSkillPoints (TMP_Text tmpText)
    {
        pickupSkills = tmpText;
    }
    public void SetCareerSkillPoints(TMP_Text tmpText)
    {
        careerSkills = tmpText;
    }
    public void OnRoleDropdown()
    {
        foreach (GameObject skillPointToggle in skillPointToggles)
        {
            skillPointToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
        }
        int selectedRole = roleDropdown.value;
        List<string> careerSkills = new List<string>();

        switch(selectedRole)
        {
            case 0:
                string[] copSkills = { "Authority", "Awareness", "Handgun", "Insight", "Athletics", "Education", "Brawling", "Melee", "Interrogation", "Streetwise" };
                careerSkills.AddRange(copSkills); 
                break;
            case 1:
                string[] corpSkills = { "Resources", "Awareness", "Insight", "Education", "Library Search", "Social", "Persuasion", "Stock Market", "Style", "Grooming" };
                careerSkills.AddRange(corpSkills);
                break;
            case 2:
                string[] fixerSkills = { "Streetdeal", "Awareness", "Forgery", "Handgun", "Brawling", "Melee", "Pick Lock", "Pick Pocket", "Intimidate", "Persuasion" };
                careerSkills.AddRange(fixerSkills);
                break;
            case 3:
                string[] mediaSkills = { "Credibility", "Awareness", "Insight", "Education", "Library Search", "Social", "Persuasion", "Stock Market", "Style", "Grooming" };
                careerSkills.AddRange(mediaSkills);
                break;
            case 4:
                string[] medTechSkills = { "Medical Tech", "Awareness", "Basic Tech", "Diagnose", "Education", "Cryotank Op", "Library Search", "Medicine", "Zoology", "Insight" };
                careerSkills.AddRange(medTechSkills);
                break;
            case 5:
                string[] netrunnerSkills = { "Interface", "Awareness", "Basic Tech", "Education", "System Know.", "CyberTech", "C-Deck Design", "Composition", "Electronics", "Programming" };
                careerSkills.AddRange(netrunnerSkills);
                break;
            case 6:
                string[] nomadSkills = { "Family", "Awareness", "Endurance", "Melee", "Rifle", "Drive", "Basic Tech", "Survival", "Brawling", "Athletics" };
                careerSkills.AddRange(nomadSkills);
                break;
            case 7:
                string[] rockerSkills = { "Charisma", "Awareness", "Perform", "Style", "Composition", "Brawling", "Play Instrument", "Streetwise", "Persuasion", "Seduction" };
                careerSkills.AddRange(rockerSkills);
                break;
            case 8:
                string[] soloSkills = { "Combat Sense", "Awareness", "Handgun", "Martial Art", "Melee", "Weapons Tech", "Rifle", "Athletics", "SMG", "Stealth" };
                careerSkills.AddRange(soloSkills);
                break;
            case 9:
                string[] techieSkills = { "Jury Rig", "Awareness", "Basic Tech", "CyberTech", "Teaching", "Education", "Electronics", "Tech Skill", "Tech Skill", "Tech Skill" };
                careerSkills.AddRange(techieSkills);
                break;
        }

        foreach (GameObject skillPointToggle in skillPointToggles)
        {
            string skillName = skillPointToggle.GetComponent<Skill>().SkillName;
            for (int i = 0; i < careerSkills.Count; i++)
            {
                if (careerSkills[i] == skillName)
                {
                    skillPointToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = true;
                }
            }
        }
    }
    

}


