using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatorController : MonoBehaviour
{
    public GameObject PanelParent;
    private List<GameObject> panels = new List<GameObject>();

    public List<int> statValues = new List<int>();
    public List<int> skillValues = new List<int>();
    List<int> statValueOptions= new List<int>();
    public List<int> currentValueOptions= new List<int>();
    
    //int statPoints;
    public GameObject[] Stats;

    private void Awake()
    {
        for (int i = 0; i < 105; i++)
        {
            skillValues.Add(0);
        }
        for(int i = 0; i < 9; i++)
        {
            statValues.Add(2);
        }
        foreach (GameObject panel in panels)
        {
            panels.Add(panel);
        }
        Stats = GameObject.FindGameObjectsWithTag("Stat");
    }
    /*private int determineSkillPositionInList(string skillName)
    {
        int skillListPosition;
        switch (skillName)
        {

        }
    }*/

    private int determineStatPositionInList (string stat)
    {
        int statListPosition;
        switch (stat)
        {
            case "Intelligence":
                statListPosition = 0;
                break;
            case "Reflex":
                statListPosition = 1;
                break;
            case "Technical":
                statListPosition = 2;
                break;
            case "Cool":
                statListPosition = 3;
                break;
            case "Attractiveness":
                statListPosition = 4;
                break;
            case "Luck":
                statListPosition = 5;
                break;
            case "Movement":
                statListPosition = 6;
                break;
            case "Body":
                statListPosition = 7;
                break;
            case "Empathy":
                statListPosition = 8;
                break;
            default:
                Debug.Log("Error In DetermineStatPositionInList Function in Creator Controller Script. String Not Found");
                statListPosition = 10;
                break;
        }
        return statListPosition;
    }
    private int determineSkillPositionsInList (string skill)
    {
        int skillListPosition;
        switch (skill)
        {
            case "Authority":
                skillListPosition = 0;
                break;
            case "Charisma":
                skillListPosition = 1;
                break;
            case "Combat Sense":
                skillListPosition = 2;
                break;
            case "Credibility":
                skillListPosition = 3;
                break;
            case "Family":
                skillListPosition = 4;
                    break;
            case "Interface":
                skillListPosition = 5;
                break;
            case "Jury Rig":
                skillListPosition = 6;
                break;
            case "Medical Tech":
                skillListPosition = 7;
                break;
            case "Resources":
                skillListPosition = 8;
                break;
            case "Streetdeal":
                skillListPosition = 9;
                break;
            case "Grooming":
                skillListPosition= 10;
                break;
            case "Style":
                skillListPosition = 11;
                break;
            case "Endurance":
                skillListPosition = 12;
                break;
            case "Strength":
                skillListPosition = 13;
                break;
            case "Swimming":
                skillListPosition = 14;
                break;
            case "Interrogation":
                skillListPosition = 15;
                break;
            case "Intimidation":
                skillListPosition = 16;
                break;
            case "Oration":
                skillListPosition = 17;
                break;
            case "Willpower":
                skillListPosition = 18;
                break;
            case "Streetsmarts":
                skillListPosition = 19;
                break;
            case "Insight":
                skillListPosition = 20;
                break;
            case "Interview":
                skillListPosition = 21;
                break;
            case "Leadership":
                skillListPosition = 22;
                break;
            case "Seduction":
                skillListPosition = 23;
                break;
            case "Etiquette":
                skillListPosition = 24;
                break;
            case "Persuasion":
                skillListPosition = 25;
                break;
            case "Performance":
                skillListPosition = 26;
                break;
            case "Accounting":
                skillListPosition = 27;
                break;
            case "Anthropology":
                skillListPosition = 28;
                break;
            case "Awareness":
                skillListPosition = 29;
                break;
            case "Biology":
                skillListPosition = 30;
                break;
            case "Chemistry":
                skillListPosition = 31;
                break;
            case "Composition":
                skillListPosition = 32;
                break;
            case "Diagnose Illness":
                skillListPosition = 33;
                break;
            case "Education":
                skillListPosition = 34;
                break;
            case "Expertise":
                skillListPosition = 35;
                break;
            case "Gambling":
                skillListPosition = 36;
                break;
            case "Geology":
                skillListPosition = 37;
                break;
            case "Subterfuge":
                skillListPosition = 38;
                break;
            case "History":
                skillListPosition = 39;
                break;
            case "Language 1":
                skillListPosition = 40;
                break;
            case "Language 2":
                skillListPosition = 41;
                break;
            case "Language 3":
                skillListPosition = 42;
                break;
            case "Database":
                skillListPosition = 43;
                break;
            case "Mathematics":
                skillListPosition = 44;
                break;
            case "Physics":
                skillListPosition = 45;
                break;
            case "Programming":
                skillListPosition = 46;
                break;
            case "Shadow":
                skillListPosition = 47;
                break;
            case "Stock Market":
                skillListPosition = 48;
                break;
            case "System Knowledge":
                skillListPosition = 49;
                break;
            case "Teaching":
                skillListPosition = 50;
                break;
            case "Survival":
                skillListPosition = 51;
                break;
            case "Zoology":
                skillListPosition = 52;
                break;
            case "Archery":
                skillListPosition = 53;
                break;
            case "Athletics":
                skillListPosition = 54;
                break;
            case "Brawling":
                skillListPosition = 55;
                break;
            case "Dance":
                skillListPosition = 56;
                break;
            case "Evasion":
                skillListPosition = 57;
                break;
            case "Driving":
                skillListPosition = 58;
                break;
            case "Sword":
                skillListPosition = 59;
                break;
            case "Handgun":
                skillListPosition = 60;
                break;
            case "Heavy Weapons":
                skillListPosition = 61;
                break;
            case "Martial Art 1":
                skillListPosition = 62;
                break;
            case "Martial Art 2":
                skillListPosition = 63;
                break;
            case "Melee":
                skillListPosition = 64;
                break;
            case "Motorcycle":
                skillListPosition = 65;
                break;
            case "Hvy. Machinery":
                skillListPosition = 66;
                break;
            case "Gyro":
                skillListPosition = 67;
                break;
            case "Airplane":
                skillListPosition = 68;
                break;
            case "Dirigible":
                skillListPosition = 69;
                break;
            case "Hovercraft":
                skillListPosition = 70;
                break;
            case "Rifle":
                skillListPosition = 71;
                break;
            case "Stealth":
                skillListPosition = 72;
                break;
            case "Submachinegun":
                skillListPosition = 73;
                break;
            case "Aero Tech":
                skillListPosition = 74;
                break;
            case "Hover Tech":
                skillListPosition = 75;
                break;
            case "Basic Tech":
                skillListPosition = 76;
                break;
            case "Cryo Tech":
                skillListPosition = 77;
                break;
            case "Cyberdeck Tech":
                skillListPosition = 78;
                break;
            case "Cyberware Tech":
                skillListPosition = 79;
                break;
            case "Demolitions":
                skillListPosition = 80;
                break;
            case "Disguise":
                skillListPosition = 81;
                break;
            case "Electronics":
                skillListPosition = 82;
                break;
            case "E-Security":
                skillListPosition = 83;
                break;
            case "First Aid":
                skillListPosition = 84;
                break;
            case "Forgery":
                skillListPosition = 85;
                break;
            case "Gyro Tech":
                skillListPosition = 86;
                break;
            case "Art":
                skillListPosition = 87;
                break;
            case "Film":
                skillListPosition = 88;
                break;
            case "Pharmacology":
                skillListPosition = 89;
                break;
            case "Pick Lock":
                skillListPosition = 90;
                break;
            case "Pick Pocket":
                skillListPosition = 91;
                break;
            case "Play Instrument":
                skillListPosition = 92;
                break;
            case "Weapon Tech":
                skillListPosition = 93;
                break;
            case "Botany":
                skillListPosition = 94;
                break;
            case "Martial Art 3":
                skillListPosition = 95;
                break;
            default:
                skillListPosition = 999;
                Debug.Log("Skill Position Entry Not Properly Spelled    " + skill);
                break;
        }
        return skillListPosition;
    }
    public int ReturnStatValue(string name)
    {
        int statPositionInList = determineStatPositionInList(name);
        return statValues[statPositionInList];
    }
    public void RandomizeStatValueOptions()
    {
        statValueOptions.Clear();
        for(int i = 0; i < 9; i++)
        {
            statValueOptions.Add(Random.Range(2, 10));
        }
        currentValueOptions.Clear();
        currentValueOptions.AddRange(statValueOptions);
    }
    /*public int AccessStatPoints()
    {
        return statPoints;
    }*/
    /*public int AccessStatPoints(int newStatPointsValue)
    {
        statPoints= newStatPointsValue;
        return statPoints;
    }*/
    public int AccessStatValueList(string name)
    {
        int index = determineStatPositionInList(name);
        return statValues[index];   
    }
    public int AccessStatValueOptionsList(int index)
    {
        return statValueOptions[index];
    }
    public List<int> AccessStatValueOptionsList()
    {
        return statValueOptions;
    }
    public void AdjustCurrentStatValueList(int dropdownValue, string name)
    {
        if (dropdownValue == -1)
        {
            currentValueOptions.Add(statValues[determineStatPositionInList(name)]);
            statValues[determineStatPositionInList(name)] = 0;
        }
        else if (statValues[determineStatPositionInList(name)] != 0)
        {
            currentValueOptions.Add(statValues[determineStatPositionInList(name)]);
            statValues[determineStatPositionInList(name)] = currentValueOptions[dropdownValue];
            currentValueOptions.RemoveAt(dropdownValue);
        }
        else
        {
            statValues[determineStatPositionInList(name)] = currentValueOptions[dropdownValue];
            currentValueOptions.RemoveAt(dropdownValue);
        }
        
        foreach(GameObject stat in Stats)
        {
            Stat statElement = stat.GetComponent<Stat>();
            statElement.UpdateDropdownList(currentValueOptions, statValues[determineStatPositionInList(statElement.Name)]);
        }
    }
    public void ResetStatValues(int resetValue)
    {
        statValues.Clear();
        for (int i = 0; i < 9; i++)
        {
            statValues.Add(resetValue);
        }
    }
    public void ResetSkill(string skillName)
    {
        skillValues[determineSkillPositionsInList(skillName)] = 0;
    }
    public void IncrementStat(bool isPlus, string name)
    {
        if (isPlus)
        {
            statValues[determineStatPositionInList(name)]++;
        }
        if (!isPlus)
        {
            statValues[determineStatPositionInList(name)]--;
        }
    }
    public int IncrementSkill(bool isPlus, string name)
    {
        if (isPlus)
        {
            skillValues[determineSkillPositionsInList(name)]++;
        }
        else if(!isPlus
            && skillValues[determineSkillPositionsInList(name)] > 0)
        {
            skillValues[determineSkillPositionsInList(name)]--;
        }
        return skillValues[determineSkillPositionsInList(name)];
    }
    public int AccessSkillValue(string name)
    {
        int skillValue = determineSkillPositionsInList(name);
        if (skillValue == 999)
        {
            return 0;
            Debug.Log("Error: AccessSkillValue Returned 999: Skill Position Entry Not Properly Spelled");
        }
        else
        {
            return skillValues[determineSkillPositionsInList(name)];
        }
    }
    public int TotalStatValue()
    {
        int totalStatValue = 0;
        foreach (int stat in statValues)
        {
            totalStatValue += stat;
        }
        return totalStatValue;

    }
}
