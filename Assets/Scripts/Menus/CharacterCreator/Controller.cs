using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Controller : MonoBehaviour
{
    //Statistic & Skill variables

    int intelligence;
    int reflex;
    int technicalAbility;
    int cool;
    int attractiveness;
    int luck;
    int movementAllowance;
    int bodyType;
    int empathy;

    public int careerSkillPointsCount;
    public int pickupSkillPointsCount;

    public TMP_Text careerSkillPoints;
    public TMP_Text pickupSkillPoints;
        
    //OnDicePoolButton() Variables
    
    GameObject[] dicePoolDropdowns;
    GameObject[] statButtons;
    GameObject[] rollTexts;
    GameObject dicePoolPanel;
    GameObject[] pointAllotments;
    GameObject pointsPanel;
    List<string> randomDiceRolls = new List<string>();

    private IEnumerator coroutine;

    //OnDicePoolDropDown() Variables

    List<int> chosenDropdownValues = new List<int>();
    TMP_Dropdown currentDropdown;
    DicePoolDropdown currentDicePoolDropdown;

    GameObject secondaryPointsPanel;
    int pointValue;
    UnityEngine.UI.Button currentButton;

    //Information To Update StatAlotter
    StatAlotter statAlloter;

    void Start()
    {
        Intialization();
    }

    //Dice Pool Dropdown Stuff Below

    public void OnDicePoolDropdown()
    {
        List<string> optionDependentDiceRolls = new List<string>();
        string textOfCurrentValue = currentDropdown.options[currentDropdown.value].text;
        currentDicePoolDropdown = currentDropdown.GetComponentInParent<DicePoolDropdown>();
        int previousValue = currentDicePoolDropdown.AccessPreviousValue();
        

        /*Debug.Log("Previous Value is " + previousValue);
        Debug.Log("Dropdown Value is " + currentDropdown.value);
        Debug.Log("Dropdown Value + Count is " + currentDropdown.value + " " + chosenDropdownValues.Count());
        Debug.Log("Dropdown Chosen List Count is " + chosenDropdownValues.Count);*/

        DropdownChoice(currentDropdown, chosenDropdownValues, previousValue);

        currentDicePoolDropdown.ChangePreviousValue(currentDropdown.value + chosenDropdownValues.Count);
        optionDependentDiceRolls.AddRange(randomDiceRolls);

        optionDependentDiceRolls = RemoveSelectedDropdownOptions(optionDependentDiceRolls, chosenDropdownValues);

        PopulateDropdownOptions(dicePoolDropdowns, optionDependentDiceRolls);

        CorrectSelfDropdownOptions(currentDropdown, currentDicePoolDropdown, textOfCurrentValue, optionDependentDiceRolls);

        SetStatForDropdown(currentDicePoolDropdown, currentDropdown);

        /*Debug.Log("int" + intelligence);
        Debug.Log("ref" + reflex);
        Debug.Log("TA" + technicalAbility);
        Debug.Log("Cool" + cool);
        Debug.Log("ATT" + attractiveness);
        Debug.Log("luck" + luck);
        Debug.Log("MA" + movementAllowance);
        Debug.Log("BT" + bodyType);
        Debug.Log("Emp" + empathy);*/
    }
        private void DropdownChoice(TMP_Dropdown dropdown, List<int> chosenValues, int previousValue)
    {
        /*The Problem is in this code. If you pull from the top of the dropdown list there isnt an issue
         * because we shift the values on the objectList +1 to account for everything sliding up, 
         * but in the event you pull from the bottom of the dropdown list, the +1 shift still occurs even though
         * no such shift as occurred*/
      
        if (dropdown.options[dropdown.value].text == "--")
        {
            chosenValues.Remove(previousValue);
            Debug.Log("Chose Empty");
        }
        else if (chosenValues.Contains(dropdown.value + chosenValues.Count()))
        {
            Debug.Log("Number Already Chosen");
        }
        //This might also be wrong below
        else if (previousValue == 0)
        {
            chosenValues.Add(dropdown.value + chosenValues.Count());
        }
        else
        {
            chosenValues.Add(dropdown.value + chosenValues.Count());
            chosenValues.Remove(previousValue);
        }
    }
        private void CorrectSelfDropdownOptions(TMP_Dropdown currentDropdown, DicePoolDropdown currentDicePoolDropdown, string textOfCurrentValue, List<string> optionDependentDiceRolls)
    {
        if (textOfCurrentValue == "--")
        {
            currentDropdown.ClearOptions();
            currentDropdown.AddOptions(optionDependentDiceRolls);
            currentDicePoolDropdown.ChangeCurrentText(textOfCurrentValue);
        }
        else
        {
            optionDependentDiceRolls.Insert(0, textOfCurrentValue);
            currentDropdown.ClearOptions();
            currentDropdown.AddOptions(optionDependentDiceRolls);
            currentDicePoolDropdown.ChangeCurrentText(textOfCurrentValue);
        }
    }
        private void PopulateDropdownOptions(GameObject[] dicePoolDropdowns, List<string> optionList)
    {
        foreach (GameObject dicePoolDropdown in dicePoolDropdowns)
        {
            List<string> specificOptionDependentDiceRolls = new List<string>();
            if (GetDropdownFromPanel(dicePoolDropdown).GetComponentInParent<DicePoolDropdown>().AccessCurrentText() == "--")
            {
                GetDropdownFromPanel(dicePoolDropdown).ClearOptions();
                GetDropdownFromPanel(dicePoolDropdown).AddOptions(optionList);
            }
            else if (GetDropdownFromPanel(dicePoolDropdown).GetComponentInParent<DicePoolDropdown>().AccessCurrentText() != "--")
            {
                specificOptionDependentDiceRolls.AddRange(optionList);
                specificOptionDependentDiceRolls.Insert(0, GetDropdownFromPanel(dicePoolDropdown).GetComponentInParent<DicePoolDropdown>().AccessCurrentText());
                GetDropdownFromPanel(dicePoolDropdown).ClearOptions();
                GetDropdownFromPanel(dicePoolDropdown).AddOptions(specificOptionDependentDiceRolls);
            }
        }
    }
        private List<string> RemoveSelectedDropdownOptions(List<string> optionList, List<int> chosenList)
    {//Double Checked, Should Be Good
        for (int i = 0; i < chosenDropdownValues.Count; i++)
        {
            optionList.RemoveAt((chosenList[i]) - i);
        }
        return optionList;
    }
        private TMP_Dropdown GetDropdownFromPanel(GameObject panel)
    {
        return panel.GetComponentInChildren<TMP_Dropdown>();
    }
        private void SetStatForDropdown(DicePoolDropdown dicePoolDropdown, TMP_Dropdown dropdown)
    {
        int currentStatValue;
        string currentText;
        if (dropdown.options[dropdown.value].text == "--")
        {
            currentStatValue = 0;
            currentText = dicePoolDropdown.GetComponentInParent<TMP_Text>().text;
        }
        else
        {
            currentStatValue = int.Parse(dropdown.options[dropdown.value].text);
            currentText = dicePoolDropdown.GetComponentInParent<TMP_Text>().text;
        }
        
        if (currentText == "Intelligence:")
        {
            if (currentDicePoolDropdown.AccessPreviousText() == "--")
            {
                pickupSkillPointsCount -= intelligence;
                intelligence = currentStatValue;
                pickupSkillPointsCount += intelligence;
                pickupSkillPoints.text = pickupSkillPointsCount.ToString();
                statAlloter.SkillPointsMatchController = false;
            }
            else
            {
                pickupSkillPointsCount -= intelligence;
                intelligence = currentStatValue;
                pickupSkillPointsCount += intelligence;
                pickupSkillPoints.text = pickupSkillPointsCount.ToString();
                statAlloter.SkillPointsMatchController = false;
            }

        }
        else if (currentText == "Reflex:")
        {
            if (currentDicePoolDropdown.AccessPreviousText() == "--")
            {
                reflex = currentStatValue;
                pickupSkillPointsCount += reflex;
                pickupSkillPoints.text = pickupSkillPointsCount.ToString();
            }
            else
            {
                pickupSkillPointsCount -= reflex;
                reflex = currentStatValue;
                pickupSkillPointsCount += reflex;
                pickupSkillPoints.text = pickupSkillPointsCount.ToString();
            }
        }
        else if (currentText == "Technical Ability:")
        {
            technicalAbility = currentStatValue;
        }
        else if (currentText == "Cool:")
        {
            cool = currentStatValue;
        }
        else if (currentText == "Attractiveness:")
        {
            attractiveness = currentStatValue;
        }
        else if (currentText == "Luck:")
        {
            luck = currentStatValue;
        }
        else if (currentText == "Movement Allowance:")
        {
            movementAllowance = currentStatValue;
        }
        else if (currentText == "Body Type:")
        {
            bodyType = currentStatValue;
        }
        else if (currentText == "Empathy:")
        {
            empathy = currentStatValue;
        }

    }

    public void OnDicePoolButton()  
    {
        randomDiceRolls = DicePoolRandomizer(randomDiceRolls);
        DicePoolActivator(pointAllotments, dicePoolDropdowns, statButtons, randomDiceRolls);
        RollTextFiller(rollTexts);
        pickupSkillPoints.text = "00";
        pickupSkillPointsCount = 0;
        intelligence = 0;
        reflex = 0;
    }
        private List<string> DicePoolRandomizer(List<string> randomDiceRolls)
        {
            randomDiceRolls.Clear();
            randomDiceRolls.Add("--");

            for (int i = 0; i <= 8; i++)
            {
                int random = UnityEngine.Random.Range(3, 11);
                if (random < 10)
                {
                    randomDiceRolls.Add("0" + random.ToString());
                }
                else
                    randomDiceRolls.Add(random.ToString());
            }
            return randomDiceRolls;
        }
        private void DicePoolActivator(GameObject[] pointAllotments, GameObject[] dicePoolDropdowns, GameObject[] statButtons, List<string> randomDiceRolls)
        {
            dicePoolPanel.SetActive(true);
            pointsPanel.SetActive(false);
            foreach (GameObject pointAllotment in pointAllotments)
            {
                pointAllotment.SetActive(false);
            }
            foreach (GameObject dicepooldropdown in dicePoolDropdowns)
            {
                dicepooldropdown.SetActive(true);
                dicepooldropdown.GetComponentInChildren<TMP_Dropdown>().ClearOptions();
                dicepooldropdown.GetComponentInChildren<TMP_Dropdown>().AddOptions(randomDiceRolls);
            }
            foreach (GameObject statButton in statButtons)
            {
                statButton.SetActive(false);
            }
        }
        private void RollTextFiller(GameObject[] rollTexts)
        {
            Debug.Log(rollTexts.Length);
            for (int i = 0; i < rollTexts.Length; i++)
            {
                rollTexts[i].GetComponent<TMP_Text>().text = randomDiceRolls[i + 1];
            }

        }
    private void Intialization()
    {
        dicePoolDropdowns = GameObject.FindGameObjectsWithTag("DicePoolDropdown");
        statButtons = GameObject.FindGameObjectsWithTag("StatButton");
        rollTexts = GameObject.FindGameObjectsWithTag("RollText");
        dicePoolPanel = GameObject.FindGameObjectWithTag("DicePoolPanel");
        pointAllotments = GameObject.FindGameObjectsWithTag("PointAllotment");
        pointsPanel = GameObject.FindGameObjectWithTag("PointPanel");
        coroutine = LateStart(0.001f);
        StartCoroutine(coroutine);
        secondaryPointsPanel = GameObject.FindGameObjectWithTag("SecondaryPointsPool");
        careerSkillPointsCount = 40;
        pickupSkillPointsCount = 4;
        intelligence = 2;
        reflex = 2;
        statAlloter = GetComponent<StatAlotter>();
    }
    IEnumerator LateStart(float waitTime)
    {
        //Hides Dice Pool Panel near start but allows tags to be added to lists before being hidden
        yield return new WaitForSeconds(waitTime);
        dicePoolPanel.SetActive(false);
        foreach (GameObject dicepooldropdown in dicePoolDropdowns)
        {
            dicepooldropdown.SetActive(false);
        }
        careerSkillPoints.text = ("40");
        pickupSkillPoints.text = ("04");    
    }
    public void SetCurrentDropdown (TMP_Dropdown referencedDropdown)
    {
        currentDropdown = referencedDropdown;
    }
    public void SetCurrentButton (UnityEngine.UI.Button referencedButton)
    {
        currentButton = referencedButton;
    }

    //Points Button Stuff Below

    public void OnPointsButton()
    {
        PointsPanelActivator();

        pointValue = PointValueSetter(currentDropdown);

        pointsPanel.GetComponentInChildren<TMP_Text>().text = (pointValue - 18).ToString();

        ResetPointButtonLayout();
        
    }
        private void PointsPanelActivator()
        {
            secondaryPointsPanel.SetActive(true);
            dicePoolPanel.SetActive(false);
            pointsPanel.SetActive(true);
            pickupSkillPoints.text = "04";
            pickupSkillPointsCount = 4;
            intelligence = 2;
            reflex = 2;
    }
        private int PointValueSetter(TMP_Dropdown dropdown)
    {
        switch (pointsPanel.GetComponentInChildren<TMP_Dropdown>().value)
        {
            case 0:
                return 50;
            case 1:
                return 60;
            case 2:
                return 75;
            case 3:
                return 70;
            case 4:
                return 80;
        }
        Debug.Log("Error In PointValueSetter");
        return 0;
    }
        private void ResetPointButtonLayout()
    {
        foreach (GameObject pointAllotment in pointAllotments)
        {
            pointAllotment.SetActive(true);
            pointAllotment.GetComponent<TMP_Text>().text = "02";
        }
        foreach (GameObject dicepooldropdown in dicePoolDropdowns)
        {
            dicepooldropdown.SetActive(false);
        }
        foreach (GameObject statButton in statButtons)
        {
            statButton.SetActive(true);
        }
    }
    
    public void OnPlusStatButton()
    {
        TMP_Text pointPool = pointsPanel.GetComponentInChildren<TMP_Text>();
        TMP_Text statValue = currentButton.GetComponentInParent<TMP_Text>(); 
        if (int.Parse(pointPool.text.TrimEnd('\r', '\n')) > 0)
        {
            if (int.Parse(statValue.text.TrimEnd('\r', '\n')) < 9)
            {
                statValue.text = "0" + (int.Parse(statValue.text.TrimEnd('\r', '\n')) + 1).ToString();

                if (int.Parse(pointPool.text.TrimEnd('\r', '\n')) <= 10)
                {
                    pointPool.text = "0" + (int.Parse(pointPool.text.TrimEnd('\r', '\n')) - 1).ToString();
                }
                else pointPool.text = (int.Parse(pointPool.text.TrimEnd('\r', '\n')) - 1).ToString();
            }
            else if (int.Parse(statValue.text.TrimEnd('\r', '\n')) == 9)
            {
                statValue.text = (int.Parse(statValue.text.TrimEnd('\r', '\n')) + 1).ToString();

                if (int.Parse(pointPool.text.TrimEnd('\r', '\n')) <= 10)
                {
                    pointPool.text = "0" + (int.Parse(pointPool.text.TrimEnd('\r', '\n')) - 1).ToString();
                }
                else pointPool.text = (int.Parse(pointPool.text.TrimEnd('\r', '\n')) - 1).ToString();
            }
            else Debug.Log("No Points Left");
        }
        SetStatForButton(statValue);
    }
    public void OnMinusStatButton()
    {
        TMP_Text pointPool = pointsPanel.GetComponentInChildren<TMP_Text>();
        TMP_Text statValue = currentButton.GetComponentInParent<TMP_Text>();
        if (int.Parse(statValue.text.TrimEnd('\r', '\n')) > 2)
        {
            if (int.Parse(pointPool.text.TrimEnd('\r', '\n')) <= 9)
            {
                statValue.text = "0" + (int.Parse(statValue.text.TrimEnd('\r', '\n')) - 1).ToString();
                pointPool.text = "0" + (int.Parse(pointPool.text.TrimEnd('\r', '\n')) + 1).ToString();
            }
            else if (int.Parse(pointPool.text.TrimEnd('\r', '\n')) > 9)
            {
                statValue.text = "0" + (int.Parse(statValue.text.TrimEnd('\r', '\n')) - 1).ToString();
                pointPool.text = (int.Parse(pointPool.text.TrimEnd('\r', '\n')) + 1).ToString();

            }
            else Debug.Log("Stat Cant Go Lower");
        }
        SetStatForButton(statValue);
    }
    private void SetStatForButton(TMP_Text statValue)
    {
        int currentStatValue = int.Parse(statValue.text.TrimEnd('\r', '\n'));
        string currentText = currentButton.transform.parent.parent.parent.GetComponent<TMP_Text>().text;
        if (currentText == "Intelligence:")
        {
            pickupSkillPointsCount -= intelligence;
            intelligence = currentStatValue;
            pickupSkillPointsCount += intelligence;
            pickupSkillPoints.text = pickupSkillPointsCount.ToString();
        }
        else if (currentText == "Reflex:")
        {
            pickupSkillPointsCount -= reflex;
            reflex = currentStatValue;
            pickupSkillPointsCount += reflex;
            pickupSkillPoints.text = pickupSkillPointsCount.ToString();
        }
        else if (currentText == "Technical Ability:")
        {
            technicalAbility = currentStatValue;
        }
        else if (currentText == "Cool:")
        {
            cool = currentStatValue;
        }
        else if (currentText == "Attractiveness:")
        {
            attractiveness = currentStatValue;
        }
        else if (currentText == "Luck:")
        {
            luck = currentStatValue;
        }
        else if (currentText == "Movement Allowance:")
        {
            movementAllowance = currentStatValue;
        }
        else if (currentText == "Body Type:")
        {
            bodyType = currentStatValue;
        }
        else if (currentText == "Empathy:")
        {
            empathy = currentStatValue;
        }

    }
    public void OnRandomeButton()
    {
        pointsPanel.SetActive(true);
        secondaryPointsPanel.SetActive(false);
        dicePoolPanel.SetActive(false);
        intelligence = 2;
        reflex = 2;
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
            pointValue += UnityEngine.Random.Range(1, 11);
        }

        pointsPanel.GetComponentInChildren<TMP_Text>().text = (pointValue - 18).ToString();

        foreach (GameObject pointAllotment in pointAllotments)
        {
            pointAllotment.SetActive(true);
            pointAllotment.GetComponent<TMP_Text>().text = "02";
        }
    }
    public void SetCareerSkillPoints(TMP_Text tMP_Text)
    {
        careerSkillPoints = tMP_Text;
    }
    public void SetPickupSkillPoints(TMP_Text tMP_Text)
    {
        pickupSkillPoints = tMP_Text;
    }
    
}

    

    
    
    


    


