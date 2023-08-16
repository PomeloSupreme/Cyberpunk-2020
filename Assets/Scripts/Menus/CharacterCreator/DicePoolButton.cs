using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DicePoolButton : MonoBehaviour
{
    Stack<int> RandomDiceRolls = new Stack<int>();

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
            RandomDiceRolls.Push(Random.Range(3, 10));
        }

        RollOne.text = RandomDiceRolls.Pop().ToString();
        RollTwo.text = RandomDiceRolls.Pop().ToString();
        RollThree.text = RandomDiceRolls.Pop().ToString();
        RollFour.text = RandomDiceRolls.Pop().ToString();
        RollFive.text = RandomDiceRolls.Pop().ToString();
        RollSix.text = RandomDiceRolls.Pop().ToString();
        RollSeven.text = RandomDiceRolls.Pop().ToString();
        RollEight.text = RandomDiceRolls.Pop().ToString();
        RollNine.text = RandomDiceRolls.Pop().ToString();

    }
}
