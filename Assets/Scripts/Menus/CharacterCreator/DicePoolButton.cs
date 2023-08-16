using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DicePoolButton : MonoBehaviour
{
    List<int> RandomDiceRolls = new List<int>();

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
    public void OnDicePoolButton()
    {
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

        for (int i = 0; i <= 9; i++)
        {
            RandomDiceRolls[i] = Random.Range(2, 10);
        }

        RollOne.text = RandomDiceRolls[0].ToString();
        RollTwo.text = RandomDiceRolls[1].ToString();
        RollThree.text = RandomDiceRolls[2].ToString();
        RollFour.text = RandomDiceRolls[3].ToString();
        RollFive.text = RandomDiceRolls[4].ToString();
        RollSix.text = RandomDiceRolls[5].ToString();
        RollSeven.text = RandomDiceRolls[6].ToString();
        RollEight.text = RandomDiceRolls[7].ToString();
        RollNine.text = RandomDiceRolls[8].ToString();

    }
}
