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

    private void Start()
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
            case "Charismatic Leadership":
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
            case "Personal Grooming":
                skillListPosition= 10;
                break;
            case "Wardrobe & Style":
                skillListPosition = 11;
                break;
            case "Endurance":
                skillListPosition = 12;
                break;
            case "Strength Feat":
                skillListPosition = 13;
                break;
            case "Swimming":
                skillListPosition = 14;
                break;
            case "Interrogation":
                skillListPosition = 15;
                break;
            case "Intimidate":
                skillListPosition = 16;
                break;
            case "Oratory":
                skillListPosition = 17;
                break;
            case "Resist Torture/Drugs":
                skillListPosition = 18;
                break;
            case "Streetwise":
                skillListPosition = 19;
                break;
            case "Human Perception":
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
            case "Social":
                skillListPosition = 24;
                break;
            case "Persuasion & Fast Talk":
                skillListPosition = 25;
                break;
            case "Perform":
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
            case "Education & Gen.Know":
                skillListPosition = 34;
                break;
            case "Expert":
                skillListPosition = 35;
                break;
            case "Gamble":
                skillListPosition = 36;
                break;
            case "Geology":
                skillListPosition = 37;
                break;
            case "Hide/Evade":
                skillListPosition = 38;
                break;
            case "History":
                skillListPosition = 39;
                break;
            case "Language 1":
                skillListPosition = 40;
                break;
            case "Langauge 2":
                skillListPosition = 41;
                break;
            case "Langauge 3":
                skillListPosition = 42;
                break;
            case "Library Search":
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
            case "Shadow/Track":
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
            case "Wilderness Survival":
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
            case "Dodge & Escape":
                skillListPosition = 57;
                break;
            case "Driving":
                skillListPosition = 58;
                break;
            case "Fencing":
                skillListPosition = 59;
                break;
            case "Handgun":
                skillListPosition= 60;
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
            case "Operate Hvy. Machinery":
                skillListPosition = 66;
                break;
            case "Pilot(Gyro)":
                skillListPosition = 67;
                break;
            case "Pilot(Fixed Wing)":
                skillListPosition = 68;
                break;
            case "Pilot(Dirigible)":
                skillListPosition = 69;
                break;
            case "Pilot(Vect. Thrust Vehicle)":
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
            case "AV Tech":
                skillListPosition = 75;
                break;
            case "Basic Tech":
                skillListPosition = 76;
                break;
            case "Cryotank Operation":
                skillListPosition = 77;
                break;
            case "Cyberdeck Design":
                skillListPosition = 78;
                break;
            case "CyberTech":
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
            case "Elect. Security":
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
            case "Paint or Draw":
                skillListPosition = 87;
                break;
            case "Photo & Film":
                skillListPosition = 88;
                break;
            case "Pharmaceuticals":
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
            case "Weaponsmith":
                skillListPosition = 93;
                break;
            case "Botany":
                skillListPosition = 94;
                break;
            default:
                skillListPosition = 110;
                Debug.Log("Skill Position Entry Not Properly Spelled");
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
        return skillValues[determineSkillPositionsInList(name)];
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
