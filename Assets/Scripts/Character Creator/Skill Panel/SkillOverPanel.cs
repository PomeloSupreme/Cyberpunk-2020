using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SkillOverPanel : MonoBehaviour
{
    CreatorController creatorController;
    int pickupSkillPoints;
    int pickupSkillPointsUsed;
    int careerSkillPoints;
    public TMP_Text PickupSkillPointsText;
    public TMP_Text CareerSkillPointsText;
    // Start is called before the first frame update
    void Start()
    {
        creatorController = GetComponentInParent<CreatorController>();
        careerSkillPoints = 40;

    }

    private void OnEnable()
    {
        UpdatePickupSkillPointsOnStatChange();
        updateText(true);
        updateText(false);
    }

    private void updateText(bool isPickupSkills)
    {
        if (isPickupSkills)
        {
            PickupSkillPointsText.text = ConvertIntToTextAndDetermineZero(pickupSkillPoints);
        }
        else
        {
            CareerSkillPointsText.text = ConvertIntToTextAndDetermineZero(careerSkillPoints);
        }
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
    private void UpdatePickupSkillPointsOnStatChange()
    {
        int totalPickupSkillPoints = creatorController.AccessStatValueList("Reflex") + creatorController.AccessStatValueList("Intelligence") - pickupSkillPointsUsed;
    }
}
