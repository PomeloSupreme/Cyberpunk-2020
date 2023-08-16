using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsButton : MonoBehaviour
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

    public TMP_Text IntelligenceStat;
    public TMP_Text ReflexStat;
    public TMP_Text TechnicalStat;
    public TMP_Text CoolStat;
    public TMP_Text AttractivenessStat;
    public TMP_Text LuckStat;
    public TMP_Text MAStat;
    public TMP_Text BodyStat;
    public TMP_Text EmpathyStat;
    public void OnPointsButton()
    {
        DicePoolPanel.SetActive(false);
        PointsPanel.SetActive(true);
        
        IntelligenceButtonPanel.SetActive(true);
        ReflexButtonPanel.SetActive(true);
        TechnicalButtonPanel.SetActive(true);
        CoolButtonPanel.SetActive(true);
        AttractivenessButtonPanel.SetActive(true);
        LuckButtonPanel.SetActive(true);
        MAButtonPanel.SetActive(true);
        BodyButtonPanel.SetActive(true);
        EmpathyButtonPanel.SetActive(true);

        IntelligenceDropdownPanel.SetActive(false);
        ReflexDropdownPanel.SetActive(false);
        TechnicalDropdownPanel.SetActive(false);
        CoolDropdownPanel.SetActive(false);
        AttractivenessDropdownPanel.SetActive(false);
        LuckDropdownPanel.SetActive(false);
        MADropdownPanel.SetActive(false);
        BodyDropdownPanel.SetActive(false);
        EmpathyDropdownPanel.SetActive(false);

        IntelligenceStat.text = "02";
        ReflexStat.text = "02";
        TechnicalStat.text = "02";
        CoolStat.text = "02";
        AttractivenessStat.text = "02";
        LuckStat.text = "02";
        MAStat.text = "02";
        BodyStat.text = "02";
        EmpathyStat.text = "02";


    }
}
