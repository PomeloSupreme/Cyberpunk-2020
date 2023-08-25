using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
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

    int authority;
    int charismaticLeadership;
    int combatSense;
    int credibility;
    int family;
    int interfaceSkill;
    int juryRig;
    int medicalTech;
    int resources;
    int streetdeal;

    


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
        if (currentButton.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == false)
        {
            if (pickupSkillsCount == 0)
            {
                Debug.Log("pickup skills at zero");
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
        if (currentButton.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == false)
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
        if (ToggleText == "Authority")
        {
            authority += changeValue;
            button.GetComponentInParent<TMP_Text>().text = IfAddZeroToFront(authority);
            /*if (authority < 9)
            {
                button.GetComponentInParent<TMP_Text>().text = "0" + authority.ToString();
            }
            else
            {
                button.GetComponentInParent<TMP_Text>().text = authority.ToString();
            }*/
        }
        if (ToggleText == "Charisma")
        {
            charismaticLeadership += changeValue;
            button.GetComponentInParent<TMP_Text>().text = IfAddZeroToFront(charismaticLeadership);
        }
        if (ToggleText == "Combat Sense")
        {
            combatSense += changeValue;
            button.GetComponentInParent<TMP_Text>().text = IfAddZeroToFront(combatSense);
        }
        if (ToggleText == "Credibility")
        {
            credibility += changeValue;
            TMPTextTextFromButton(button).text = IfAddZeroToFront(credibility);
        }
        if (ToggleText == "Family")
        {
            family += changeValue;
            TMPTextTextFromButton(button).text = IfAddZeroToFront(family);
        }
        if (ToggleText == "Interface")
        {
            interfaceSkill += changeValue;
            TMPTextTextFromButton(button).text = IfAddZeroToFront(interfaceSkill); 
        }
        if (ToggleText == "Jury Rig")
        {
            juryRig += changeValue;
            TMPTextTextFromButton(button).text = IfAddZeroToFront(juryRig);
        }
        if (ToggleText == "Medical Tech")
        {
            medicalTech += changeValue;
            TMPTextTextFromButton(button).text = IfAddZeroToFront(medicalTech);
        }
        if (ToggleText == "Resources")
        {
            resources += changeValue;
            TMPTextTextFromButton(button).text = IfAddZeroToFront(resources);
        }
        if (ToggleText == "Streetdeal")
        {
            streetdeal += changeValue;
            TMPTextTextFromButton(button).text = IfAddZeroToFront(streetdeal);
        }

    }
    private string IfAddZeroToFront(int numberInQuestion)
    {
        if (numberInQuestion <9)
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
}
