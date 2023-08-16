using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DicePoolButton : MonoBehaviour
{
    

    public GameObject DicePoolPanel = new GameObject();
    public GameObject PointsPanel = new GameObject();

    public GameObject IntelligenceButtonPanel;
    public GameObject ReflexButtonPanel;
    public GameObject TechnicalButtonPanel;
    public GameObject CoolButtonPanel;
    public GameObject AttractivenessButtonPanel;
    public GameObject LuckButtonPanel;
    public GameObject MAButtonPanel;
    public GameObject BodyButtonPanel;
    public GameObject EmpathyButtonPanel;

    public GameObject IntelligenceDropdownPanel;
    public GameObject ReflexDropdownPanel;
    public GameObject TechnicalDropdownPanel;
    public GameObject CoolDropdownPanel;
    public GameObject AttractivenessDropdownPanel;
    public GameObject LuckDropdownPanel;
    public GameObject MADropdownPanel;
    public GameObject BodyDropdownPanel;
    public GameObject EmpathyDropdownPanel;

    public TMP_Text RollOne;
    public TMP_Text RollTwo;
    public TMP_Text RollThree;
    public TMP_Text RollFour;
    public TMP_Text RollFive;
    public TMP_Text RollSix;
    public TMP_Text RollSeven;
    public TMP_Text RollEight;
    public TMP_Text RollNine;

    public TMP_Dropdown IntelligenceDropdown;
    public TMP_Dropdown ReflexDropdown;
    public TMP_Dropdown TechnicalDropdown;
    public TMP_Dropdown CoolDropdown;
    public TMP_Dropdown AttractivenessDropdown;
    public TMP_Dropdown LuckDropdown;
    public TMP_Dropdown MADropdown;
    public TMP_Dropdown BodyDropdown;
    public TMP_Dropdown EmpathyDropdown;
    public void OnDicePoolButton()
    {
        IntelligenceDropdown.ClearOptions();
        ReflexDropdown.ClearOptions();
        TechnicalDropdown.ClearOptions();
        CoolDropdown.ClearOptions();
        AttractivenessDropdown.ClearOptions();
        LuckDropdown.ClearOptions();
        MADropdown.ClearOptions();
        BodyDropdown.ClearOptions();
        EmpathyDropdown.ClearOptions();

        DicePoolPanel.SetActive(true);
        PointsPanel.SetActive(false);

        IntelligenceButtonPanel.SetActive(false);
        ReflexButtonPanel.SetActive(false);
        TechnicalButtonPanel.SetActive(false);
        CoolButtonPanel.SetActive(false);
        AttractivenessButtonPanel.SetActive(false);
        LuckButtonPanel.SetActive(false);
        MAButtonPanel.SetActive(false);
        BodyButtonPanel.SetActive(false);
        EmpathyButtonPanel.SetActive(false);

        IntelligenceDropdownPanel.SetActive(true);
        ReflexDropdownPanel.SetActive(true);
        TechnicalDropdownPanel.SetActive(true);
        CoolDropdownPanel.SetActive(true);
        AttractivenessDropdownPanel.SetActive(true);
        LuckDropdownPanel.SetActive(true);
        MADropdownPanel.SetActive(true);
        BodyDropdownPanel.SetActive(true);
        EmpathyDropdownPanel.SetActive(true);

        List<string> RandomDiceRolls = new List<string>();
        RandomDiceRolls.Add("00");

        for (int i = 0; i <= 8; i++)
        {
            int random = Random.Range(3, 11);
            if (random < 10)
            {
                RandomDiceRolls.Add("0" + random.ToString());
            }
            else RandomDiceRolls.Add(random.ToString());
        }

        RollOne.text = RandomDiceRolls[1];
        RollTwo.text = RandomDiceRolls[2];
        RollThree.text = RandomDiceRolls[3];
        RollFour.text = RandomDiceRolls[4];
        RollFive.text = RandomDiceRolls[5];
        RollSix.text = RandomDiceRolls[6];
        RollSeven.text = RandomDiceRolls[7];
        RollEight.text = RandomDiceRolls[8];
        RollNine.text = RandomDiceRolls[9];


        IntelligenceDropdown.AddOptions(RandomDiceRolls);
        ReflexDropdown.AddOptions(RandomDiceRolls);
        TechnicalDropdown.AddOptions(RandomDiceRolls);
        CoolDropdown.AddOptions(RandomDiceRolls);
        AttractivenessDropdown.AddOptions(RandomDiceRolls);
        LuckDropdown.AddOptions(RandomDiceRolls);
        MADropdown.AddOptions(RandomDiceRolls);
        BodyDropdown.AddOptions(RandomDiceRolls);
        EmpathyDropdown.AddOptions(RandomDiceRolls);

        

    }
}
