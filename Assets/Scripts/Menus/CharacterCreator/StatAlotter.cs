using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatAlotter : MonoBehaviour
{
    Controller controller;
    
    int pickupSkillsCount;
    int careerSkillsCount;

    TMP_Text careerSkills;
    TMP_Text pickupSkills;

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
        
    }

    private void DoSkillPointsMatch(bool skillPointsMatch)
    {
        if (skillPointsMatch == false)
        {
            pickupSkillsCount = controller.pickupSkillPointsCount;
            careerSkillsCount = controller.careerSkillPointsCount;
        }
    }
}
