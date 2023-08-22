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
        pickupSkillsCount = controller.pickupSkillPointsCount;
        careerSkillsCount = controller.careerSkillPointsCount;
        careerSkills = controller.careerSkillPoints;
        pickupSkills = controller.pickupSkillPoints;
        SkillPointsMatchController= true;
    }

    private void Update()
    {
        DoSkillPointsMatch(SkillPointsMatchController);
    }

    private void DoSkillPointsMatch(bool skillPointsMatch)
    {
        if (skillPointsMatch == false)
        {
            pickupSkillsCount = controller.pickupSkillPointsCount;
            careerSkillsCount = controller.careerSkillPointsCount;
            skillPointsMatch = true;
        }
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
                }
                else
                {
                    pickupSkills.text = pickupSkillsCount.ToString();
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
                }
                else
                {
                    careerSkills.text = careerSkillsCount.ToString();
                }
            }
        }
        SetSkill(currentButton, isPlus);
    }
    public void OnSkillMinusButton()
    {
        bool isPlus = false;
        if (currentButton.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == false)
        {
            TMP_Text pointPool = currentButton.GetComponentInParent<TMP_Text>();
                pickupSkillsCount++;
                if (pointPool.text == "00")
                {
                    Debug.Log("Skill Points Empty");
                }
            else if (pickupSkillsCount < 9)
                {
                    pickupSkills.text = "0" + pickupSkillsCount.ToString();
                }
                else
                {
                    pickupSkills.text = pickupSkillsCount.ToString();
                }
        }
        else if (currentButton.GetComponentInParent<UnityEngine.UI.Toggle>().isOn == true)
        {
                careerSkillsCount++;
                if (currentButton.GetComponentInParent<TMP_Text>().text == "00")
                {
                    Debug.Log("Skill Points Empty");
                }
            else if (careerSkillsCount < 9)
                {
                    careerSkills.text = "0" + careerSkillsCount.ToString();
                }
                else
                {
                    careerSkills.text = careerSkillsCount.ToString();
                }
        }
        SetSkill(currentButton, isPlus);
    }
    public void SetSkill(UnityEngine.UI.Button button, bool isPlus)
    {
        TMP_Text SkillPointValue = button.GetComponentInParent<TMP_Text>();
        int changeValue;
        string ToggleText = button.GetComponentInParent<UnityEngine.UIElements.TextElement>().text;
        if (isPlus == true)
        {
            changeValue = 1;
        }
        else
        {
            changeValue = (-1);
        }
        if (ToggleText == "Authority")
        {
            authority += changeValue;
            if (authority < 9)
            {
                button.GetComponentInParent<TMP_Text>().text = "0" + authority.ToString();
            }
            else
            {
                button.GetComponentInParent<TMP_Text>().text = authority.ToString();
            }

        }

    }
}
