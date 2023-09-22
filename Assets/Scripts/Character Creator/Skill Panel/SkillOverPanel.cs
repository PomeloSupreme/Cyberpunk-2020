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
    public List<GameObject> StatSkillPanels;
    public TMP_Text PickupSkillPointsText;
    public TMP_Text CareerSkillPointsText;
    public GameObject SkillPrefab;
    // Start is called before the first frame update
    void Start()
    {
        PopulateStatPanels();
        TurnStatSkillPanelsOff();
        StatSkillPanels[0].SetActive(true);
        creatorController = GetComponentInParent<CreatorController>();
        careerSkillPoints = 40;
        pickupSkillPointsUsed = 0;
    }

    private void OnEnable()
    {
        pickupSkillPoints = UpdatePickupSkillPointsOnStatChange();
        updateText(true);
        updateText(false);
    }
    public void OnStatButtonShowSkillPanel(GameObject panel)
    {
        TurnStatSkillPanelsOff();
        panel.SetActive(true);
    }
    public void TurnStatSkillPanelsOff()
    {
        for (int i = 0; i < StatSkillPanels.Count; i++)
        {
            StatSkillPanels[i].SetActive(false);
        }
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
    private int UpdatePickupSkillPointsOnStatChange()
    {
       return (creatorController.AccessStatValueList("Reflex") + creatorController.AccessStatValueList("Intelligence") - pickupSkillPointsUsed);
    }
    private void PopulateStatPanels()
    {
        for (int i = 0; i < StatSkillPanels.Count; i++)
        {
            SkillPanel thisSkillPanel = StatSkillPanels[i].GetComponentInChildren<SkillPanel>();

            for(int y = 0; y < thisSkillPanel.SkillNames.Count; y++)
            {
                thisSkillPanel.SkillObjects.Add(Instantiate(SkillPrefab, thisSkillPanel.transform));
            }
            for (int y = 0; y < thisSkillPanel.SkillObjects.Count; y++)
            {
                thisSkillPanel.SkillObjects[y].GetComponent<Skill>().SetNameAndText(thisSkillPanel.SkillNames[y]);
            }
        }
    }
    public int IncrementPickupOrCareerPoints(bool isCareerSkill, bool isPlus, string name)
    {
        if (!isCareerSkill)
        {
            if(isPlus
                && pickupSkillPoints > 0)
            {
                pickupSkillPoints--;
                updateText(true);
                creatorController.IncrementSkill(isPlus, name);
            }
            else if(!isPlus
                && creatorController.AccessSkillValue(name) > 0)
            {
                pickupSkillPoints++;
                updateText(true);
                creatorController.IncrementSkill(isPlus, name);
            }
        }
        else
        {
            if (isPlus
                && careerSkillPoints > 0)
            {
                careerSkillPoints--;
                updateText(false);
                creatorController.IncrementSkill(isPlus, name);
            }
            else if(!isPlus
                && creatorController.AccessSkillValue(name) > 0)
            {
                careerSkillPoints++;
                updateText(false);
                creatorController.IncrementSkill(isPlus, name);
            }
        }
        return creatorController.AccessSkillValue(name);
    }
}
