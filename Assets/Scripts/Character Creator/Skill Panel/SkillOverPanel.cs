using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SkillOverPanel : MonoBehaviour
{
    public CreatorController creatorController;
    int pickupSkillPoints;
    int pickupSkillPointsUsed;
    int careerSkillPoints;
    public List<GameObject> StatSkillPanels;
    public TMP_Text PickupSkillPointsText;
    public TMP_Text CareerSkillPointsText;
    public GameObject SkillPrefab;
    private GameObject currentStatPanelOpen;
    private TMP_Text previousTextButton;
    List<string> currentCareerSkills = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        careerSkillPoints = 40;
        pickupSkillPointsUsed = 0;
        currentStatPanelOpen = StatSkillPanels[0];
        PopulateStatPanels();
        TurnStatSkillPanelsOff();
        StatSkillPanels[0].SetActive(true);
       
    }

    private void OnEnable()
    {
        TurnStatSkillPanelsOff();
        currentStatPanelOpen.SetActive(true);
        pickupSkillPoints = UpdatePickupSkillPointsOnStatChange();
        updateText(true);
        updateText(false);
    }
    public void OnStatButtonShowSkillPanel(GameObject panel)
    {
        
        TurnStatSkillPanelsOff();
        panel.SetActive(true);
        currentStatPanelOpen = panel;
        //text.color= Color.blue;
       //text.fontSize = 50;
        if (previousTextButton != null)
        {
            previousTextButton.fontSize = 36;
            previousTextButton.color = Color.white;
            //previousTextButton = text;
        }
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
        else if (!isPickupSkills)
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
                thisSkillPanel.SkillObjects[y].GetComponent<Skill>().skillOverPanel = this.GetComponent<SkillOverPanel>();
            }
        }
    }
    public int IncrementPickupOrCareerPoints(bool isCareerSkill, bool isPlus, string name)
    {
        if (!isCareerSkill)
        {
            if(isPlus
                && pickupSkillPoints > 0
                && creatorController.AccessSkillValue(name) < 10)
            {
                pickupSkillPointsUsed++;
                pickupSkillPoints--;
                updateText(true);
                creatorController.IncrementSkill(isPlus, name);
            }
            else if(!isPlus
                && creatorController.AccessSkillValue(name) > 0)
            {
                pickupSkillPointsUsed--;
                pickupSkillPoints++;
                updateText(true);
                creatorController.IncrementSkill(isPlus, name);
            }
        }
        else
        {
            if (isPlus
                && careerSkillPoints > 0
                && creatorController.AccessSkillValue(name) < 10)
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
    public void OnRoleChange()
    {
        currentCareerSkills.Clear();
        switch (this.GetComponentInChildren<TMP_Dropdown>().value)
        {
            case 0:
                string[] copSkills = { "Awareness", "Handgun","Human Perception","Athletics","Education","Brawling","Melee","Interrogation","Streetwise"}; 
                currentCareerSkills.AddRange(copSkills);
                break;
            case 1:
                string[] corpSkills = { "Awareness", "Human Perception", "Education", "Library Search", "Social", "Persuasion", "Stock Market", "Wardrobe & Style", "Personal Grooming" };
                currentCareerSkills.AddRange(corpSkills);
                break;

        }
        foreach (GameObject gameObject in StatSkillPanels)
        {
            for (int i = 0; i < currentCareerSkills.Count; i++) 
            {
                string skillToCheck = currentCareerSkills[i];
                for (int x = 0; x < gameObject.GetComponent<SkillPanel>().SkillObjects.Count; x++)
                {
                    string currentSkill = gameObject.GetComponent<SkillPanel>().SkillObjects[x].GetComponent<TMP_Text>().text;
                    if (skillToCheck == currentSkill)
                    {
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponent<TMP_Text>().color = Color.red;
                    }
                    else
                    {
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponent<TMP_Text>().color = Color.white;
                    }
            }
            }
        }

    }
}
