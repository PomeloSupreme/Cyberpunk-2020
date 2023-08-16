using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomButton : MonoBehaviour
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
    public void OnRandomButton()
    {
        DicePoolPanel.SetActive(false);
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

        IntelligenceDropdownPanel.SetActive(false);
        ReflexDropdownPanel.SetActive(false);
        TechnicalDropdownPanel.SetActive(false);
        CoolDropdownPanel.SetActive(false);
        AttractivenessDropdownPanel.SetActive(false);
        LuckDropdownPanel.SetActive(false);
        MADropdownPanel.SetActive(false);
        BodyDropdownPanel.SetActive(false);
        EmpathyDropdownPanel.SetActive(false);
    }
}
