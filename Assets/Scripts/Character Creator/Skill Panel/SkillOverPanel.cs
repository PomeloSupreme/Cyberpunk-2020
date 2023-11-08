using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

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
    public Skill pharmaSkill;
    // Start is called before the first frame update
    void Start()
    {
        careerSkillPoints = 40;
        pickupSkillPointsUsed = 0;
        currentStatPanelOpen = StatSkillPanels[1];
        PopulateSkillPanels();
        this.GetComponentInChildren<TMP_Dropdown>().value = 1;
        this.GetComponentInChildren<TMP_Dropdown>().value = 0;
        TurnStatSkillPanelsOff();
        StatSkillPanels[0].SetActive(true);
        

    }

    private void OnEnable()
    {
        TurnStatSkillPanelsOff();
        if(currentStatPanelOpen != null)
        {
            currentStatPanelOpen.SetActive(true);
        }
        if (creatorController.statValues.Count > 0)
        {
            pickupSkillPoints = UpdatePickupSkillPointsOnStatChange();
        }
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
        for (int i = 1; i < StatSkillPanels.Count; i++)
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
    private void PopulateSkillPanels()
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
                if(thisSkillPanel.SkillNames[y] == "Pharmacology")
                {
                    pharmaSkill = thisSkillPanel.SkillObjects[y].GetComponent<Skill>();
                }
                thisSkillPanel.SkillObjects[y].GetComponent<Skill>().SetNameAndText(thisSkillPanel.SkillNames[y]);
                thisSkillPanel.SkillObjects[y].GetComponent<Skill>().skillOverPanel = this.GetComponent<SkillOverPanel>();
                thisSkillPanel.SkillObjects[y].GetComponent<Skill>().DetermineButtonStatus();
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
        careerSkillListGenerator();

        foreach (GameObject gameObject in StatSkillPanels)
        {
            if (gameObject.GetComponentInChildren<SkillPanel>().IsSpecialAbility)
            {
                for (int x = 0; x < gameObject.GetComponentInChildren<SkillPanel>().SkillObjects.Count; x++)
                {
                    string gameObjectText = gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<TMP_Text>().text;
                    int pointsToMove = creatorController.AccessSkillValue(gameObjectText);
                    bool isCareerSkill = gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<Skill>().IsCareerSkill;
                    if (currentCareerSkills.Contains(gameObjectText))
                    {
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<Skill>().HideButtons(true);
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<Skill>().DetermineButtonStatus();
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<Skill>().IsCareerSkill = true;
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<TMP_Text>().color = Color.blue;
                    }
                    else
                    {
                        if (creatorController.AccessSkillValue(gameObjectText) > 0)
                        {
                            careerSkillPoints += pointsToMove;
                            updateText(false);
                            creatorController.ResetSkill(gameObjectText);
                            gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<Skill>().SetText("00");
                        }
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<Skill>().HideButtons(false);
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<Skill>().IsCareerSkill = false;
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<TMP_Text>().color = Color.white;
                    }
                }
            }
            else {
                for (int x = 0; x < gameObject.GetComponentInChildren<SkillPanel>().SkillObjects.Count; x++)
                {
                    string gameObjectText = gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<TMP_Text>().text;
                    bool isCareerSkill = gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<Skill>().IsCareerSkill;
                    if (currentCareerSkills.Contains(gameObjectText))
                    {
                        if (!isCareerSkill)
                        {
                            int pointsToMove = creatorController.AccessSkillValue(gameObjectText);
                            careerSkillPoints -= pointsToMove;
                            pickupSkillPoints += pointsToMove;
                            updateText(true);
                            updateText(false);
                        }
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<Skill>().IsCareerSkill = true;
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<TMP_Text>().color = Color.blue;
                    }
                    else
                    {
                        if (isCareerSkill)
                        {
                            int pointsToMove = creatorController.AccessSkillValue(gameObjectText);
                            careerSkillPoints += pointsToMove;
                            pickupSkillPoints -= pointsToMove;
                            updateText(true);
                            updateText(false);
                        }
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<Skill>().IsCareerSkill = false;
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<TMP_Text>().color = Color.white;
                    }
                }
               /* for (int i = 0; i < currentCareerSkills.Count; i++)
                {
                    string skillToCheck = currentCareerSkills[i];
                    
                    string currentSkill = gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<TMP_Text>().text;
                    if (skillToCheck == currentSkill)
                    {
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<Skill>().IsCareerSkill = true;
                        gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<TMP_Text>().color = Color.red;
                        skillsAlreadyChecked.Add(x);
                    }
                    else
                    {
                        if (!skillsAlreadyChecked.Contains(x))
                        {
                            gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<Skill>().IsCareerSkill = false;
                            gameObject.GetComponentInChildren<SkillPanel>().SkillObjects[x].GetComponentInChildren<TMP_Text>().color = Color.white;
                        }
                    }
                }*/
            }
        }
    }
    public void PharmaAvailable(bool ChemOverFour)
    {
        if (ChemOverFour)
        {
            pharmaSkill.HideButtons(true);
            pharmaSkill.DetermineButtonStatus();
        }
        if (!ChemOverFour)
        {
            pharmaSkill.HideButtons(false);
            if (pharmaSkill.IsCareerSkill)
            {
                careerSkillPoints += creatorController.AccessSkillValue("Pharmacology");
                updateText(false );
                creatorController.ResetSkill("Pharmacology");
                pharmaSkill.SetText("00");
            }
            else if (!pharmaSkill.IsCareerSkill)
            {
                pickupSkillPoints += creatorController.AccessSkillValue("Pharmacology");
                updateText(true);
                creatorController.ResetSkill("Pharmacology");
                pharmaSkill.SetText("00");
            }
        }
        
    }
    private void careerSkillListGenerator()
            {
    currentCareerSkills.Clear();

        switch (this.GetComponentInChildren<TMP_Dropdown>().value)
        {
            case 0:
                string[] copSkills = { "Authority", "Awareness", "Handgun", "Insight", "Athletics", "Education", "Brawling", "Melee", "Interrogation", "Streetsmarts" };
                currentCareerSkills.AddRange(copSkills);
                break;
            case 1:
                string[] corpSkills = { "Resources", "Awareness", "Insight", "Education", "Database", "Etiquette", "Persuasion", "Stock Market", "Style", "Grooming" };
                currentCareerSkills.AddRange(corpSkills);
                break;
            case 2:
                string[] fixerSkills = { "Streetdeal", "Awareness", "Forgery", "Handgun", "Insight", "Athletics", "Education", "Brawling", "Melee", "Interrogation", "Streetsmarts" };
                currentCareerSkills.AddRange(fixerSkills);
                break;
            case 3:
                string[] mediaSkills = { "Credibility", "Awareness", "Composition", "Education", "Persuasion", "Insight", "Etiquette", "Streetsmarts", "Film", "Interview" };
                currentCareerSkills.AddRange(mediaSkills);
                break;
            case 4:
                string[] medtechieSkills = { "Medical Tech", "Awareness", "Basic Tech", "Diagnose Illness", "Education", "Cryo Tech", "Database", "Pharmacology", "Zoology", "Insight" };
                currentCareerSkills.AddRange(medtechieSkills);
                break;
            case 5:
                string[] netrunnerSkills = { "Interface", "Awareness", "Basic Tech", "Education", "System Knowledge", "Cyberware Tech", "Cyberdeck Tech", "Composition", "Electronics", "Programming" };
                currentCareerSkills.AddRange(netrunnerSkills);
                break;
            case 6:
                string[] nomadSkills = { "Family", "Awareness", "Endurance", "Melee", "Rifle", "Driving", "Basic Tech", "Survival", "Brawling", "Athletics" };
                currentCareerSkills.AddRange(nomadSkills);
                break;
            case 7:
                string[] rockerSkills = { "Charisma", "Awareness", "Performance", "Style", "Composition", "Brawling", "Play Instrument", "Streetsmarts", "Persuasion", "Seduction" };
                currentCareerSkills.AddRange(rockerSkills);
                break;
            case 8:
                string[] soloSkills = { "Combat Sense", "Awareness", "Handgun", "Martial Art I", "Melee", "Weapon Tech", "Rifle", "Athletics", "Submachinegun", "Stealth" };
                currentCareerSkills.AddRange(soloSkills);
                break;
            case 9:
                string[] techieSkills = { "Jury Rig", "Awareness", "Basic Tech", "Cyber Tech", "Teaching", "Education", "Electronics" };
                currentCareerSkills.AddRange(techieSkills);
                break;
        
            }
        }
    }
