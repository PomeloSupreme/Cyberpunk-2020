using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    GameObject[] dicePoolDropdowns;
    GameObject[] statButtons;
    GameObject[] rollTexts;
    GameObject dicePoolPanel;
    GameObject[] pointAllotments;
    GameObject pointsPanel;
    GameObject secondaryPointsPanel;
    

    private void Start()
    {
        dicePoolDropdowns = GameObject.FindGameObjectsWithTag("DicePoolDropdown");
        statButtons = GameObject.FindGameObjectsWithTag("StatButton");
        rollTexts = GameObject.FindGameObjectsWithTag("RollText");
        dicePoolPanel = GameObject.FindGameObjectWithTag("DicePoolPanel");
        pointAllotments = GameObject.FindGameObjectsWithTag("PointAllotment");
        pointsPanel = GameObject.FindGameObjectWithTag("PointPanel");
        secondaryPointsPanel = GameObject.FindGameObjectWithTag("SecondaryPointsPool");
    }

    public void OnRandomButton()
    {
        pointsPanel.SetActive(true);
        secondaryPointsPanel.SetActive(false);
        dicePoolPanel.SetActive(false);
        //  pointsPanel.
        foreach (GameObject pointAllotment in pointAllotments)
        {
            pointAllotment.SetActive(true);
        }
        foreach (GameObject dicepooldropdown in dicePoolDropdowns)
        {
            dicepooldropdown.SetActive(false);
        }
        foreach (GameObject statButton in statButtons)
        {
            statButton.SetActive(true);
        }

        int pointValue = 0;

        for (int i = 0; i <= 8; i++)
        {
            pointValue += Random.Range(1, 10);
        }

        pointsPanel.GetComponentInChildren<TMP_Text>().text = (pointValue - 18).ToString();

        foreach (GameObject pointAllotment in pointAllotments)
        {
            pointAllotment.SetActive(true);
            pointAllotment.GetComponent<TMP_Text>().text = "02";
        }
    }
    
    /*public void OnRandomButton()
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
    }*/
}
