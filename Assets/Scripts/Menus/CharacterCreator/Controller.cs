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

    int intelligence = 2;
    int reflex = 2;
    int technicalAbility = 2;
    int cool = 2;
    int attractiveness = 2;
    int luck = 2;
    int movementAllowance = 2;
    int bodyType = 2;
    int empathy = 2;

    /*public int careerSkillPointsCount;
    public int pickupSkillPointsCount;*/

    //OnDicePoolButton() Variables

    GameObject[] dicePoolDropdowns;
    GameObject[] statButtons;
    GameObject[] rollTexts;
    GameObject dicePoolPanel;
    GameObject[] pointAllotments;
    GameObject pointsPanel;
    List<Tuple<int, string>> randomDiceRolls = new List<Tuple<int, string>>();

    private IEnumerator coroutine;

    //OnDicePoolDropDown() Variables

    //List<Tuple<int, string>> chosenDropdownValues = new List<Tuple<int, string>>();
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
        currentDicePoolDropdown = currentDropdown.GetComponent<DicePoolDropdown>();
        List<Tuple<int, string>> availableOptionsList = new List<Tuple<int, string>>();
        Tuple <int, string> currentTuple = currentDicePoolDropdown.ConvertOptionValueToTuple(currentDropdown.value);
        currentDicePoolDropdown = currentDropdown.GetComponentInParent<DicePoolDropdown>();

        /*Debug.Log("Previous Value is " + previousValue);
        Debug.Log("Dropdown Value is " + currentDropdown.value);
        Debug.Log("Dropdown Value + Count is " + currentDropdown.value + " " + chosenDropdownValues.Count());
        Debug.Log("Dropdown Chosen List Count is " + chosenDropdownValues.Count);*/
        //--Takes the value from the selected dropdown option and correspsonds it to the currentList
        //--Checks whether the option was empty or for a new value and sets that value to the currentSelectedTuple
        //--and the previous currentSellectedTuple to the previousSelectedTuple

        DropdownChoice(currentDicePoolDropdown, currentDropdown);

        //--Generates a list of tuples that are currently available after a new value has been selected

        availableOptionsList.AddRange(GenerateAvailableOptionsList(randomDiceRolls));

        //--Generates a list of strings that is going to be fed into the optionData of the TMP_Dropdown

        List<string> availableOptionsListStrings = new List<string>();
        availableOptionsListStrings.AddRange(GenerateOptionListFromRandomDiceRolls(availableOptionsList));

        PopulateDropdownOptions(dicePoolDropdowns, availableOptionsListStrings, availableOptionsList);

        //--CorrectSelfDropdownOptions(currentDropdown, currentDicePoolDropdown, availableOptionsListStrings);

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
        private void DropdownChoice(DicePoolDropdown currentDicePoolDropdown, TMP_Dropdown dropdown)
    {
        /*The Problem is in this code. If you pull from the top of the dropdown list there isnt an issue
         * because we shift the values on the objectList +1 to account for everything sliding up, 
         * but in the event you pull from the bottom of the dropdown list, the +1 shift still occurs even though
         * no such shift as occurred*/
        bool dropdownHasNotChanged = false;
        Tuple<int, string> previousSelectedTuple = currentDicePoolDropdown.AccessCurrentTuple();
        Tuple<int, string> currentSelectedTuple = null;
        Debug.Log("Current dropdown value " + dropdown.value);

        if (currentDicePoolDropdown.AccessCurrentList().Count() == 1)
        {
            if (dropdown.value == 0)
            {
                Debug.Log("No Change Has Been Made");
            }
            else if (dropdown.value == 1)
            {
                currentSelectedTuple = new Tuple<int, string>(0, "--");
            }
            else
            {
                Debug.Log("Error at If 115");
            }
        }
        else
        {
            currentSelectedTuple = currentDicePoolDropdown.AccessCurrentList()[dropdown.value];
        }

        //Debug.Log("Current Selected Tuple = " + currentSelectedTuple);
        Debug.Log("List Count " + currentDicePoolDropdown.AccessCurrentList().Count);
        Tuple<int, string> choseEmptyTuple = new Tuple<int, string>(0, "--");

        if (dropdown.options[dropdown.value].text == "--")
        {
            currentDicePoolDropdown.ChangePreviousSelectedTupleToCurrent();
            currentDicePoolDropdown.ChangeCurrentSelectedTuple(choseEmptyTuple);
            Debug.Log("Chose Empty");
        }
        else
        {
           /* for (int i = 0; i < chosenValues.Count(); i++)
            {
                if (chosenValues[i] == previousSelectedTuple)
                {
                    dropdownHasNotChanged = true;
                    Debug.Log("DropDown Hasnt Changed");
                }
                else if (chosenValues[i] == currentSelectedTuple
                    && currentSelectedTuple.Item2 != "--")
                {
                    Debug.Log("ERROR: Selected Tuple Has Already Been Selected And Should Not Appear | ChosenValue[i] = " + chosenValues[i] + " | currentTuple = " + currentSelectedTuple);
                }
            }
            if (!dropdownHasNotChanged)
            {

            }*/

            currentDicePoolDropdown.ChangePreviousSelectedTupleToCurrent();
            currentDicePoolDropdown.ChangeCurrentSelectedTuple(currentSelectedTuple);
        }
    }
        public List<Tuple<int,string>> GenerateAvailableOptionsList(List<Tuple<int, string>> randomDiceRolls)
    { 
        List<Tuple<int, string>> availableOptionsList = new List<Tuple<int, string>>();
        availableOptionsList.AddRange(randomDiceRolls);
        foreach(GameObject dicePoolDropdown in dicePoolDropdowns)
        {
            for(int i = 1; i < availableOptionsList.Count(); i++)
            {
                if (availableOptionsList[i] == GetDropdownFromPanel(dicePoolDropdown).GetComponentInParent<DicePoolDropdown>().AccessCurrentTuple())
                {
                    availableOptionsList.RemoveAt(i);
                    i--;
                }
            }
        }
        return availableOptionsList;
    }
        //--I suspect the last of the issue lies in this else if
        /*else if (chosenValues.Contains(dropdown.value))
        {
            Debug.Log("Number Already Chosen");
        }
        //This might also be wrong below
        else if (previousValue == 0)
        {
            /*int trueValue = dropdown.value;
            for(int i = 0; i < chosenValues.Count(); i++)
            {
                if (trueValue == chosenValues[i])
                {
                    trueValue++;
                }
            }
            chosenValues.Add(trueValue);
            //chosenValues.Add(dropdown.value + chosenValues.Count());
        }
        else
        {
            /*int trueValue = dropdown.value;
            for (int i = 0; i < chosenValues.Count(); i++)
            {
                if (trueValue == chosenValues[i])
                {
                    trueValue++;
                }
            }
            chosenValues.Add(trueValue);
            //chosenValues.Add(dropdown.value + chosenValues.Count());
            chosenValues.Remove(previousValue);
        }
        Debug.Log(trueValue);
    }*/
    /*private void CorrectSelfDropdownOptions(TMP_Dropdown currentDropdown, DicePoolDropdown currentDicePoolDropdown, List<string> optionDependentDiceRolls)
    {
        if (currentTuple.Item1 == 0)
        {
            currentDropdown.ClearOptions();
            currentDropdown.AddOptions(optionDependentDiceRolls);
            currentDicePoolDropdown.ChangeCurrentSelectedTuple(currentTuple);
        }
        else
        {
            optionDependentDiceRolls.Insert(0, currentTuple.Item2);
            currentDropdown.ClearOptions();
            currentDropdown.AddOptions(optionDependentDiceRolls);
            currentDicePoolDropdown.ChangeCurrentSelectedTuple(currentTuple);
        }
    }*/
        private void PopulateDropdownOptions(GameObject[] dicePoolDropdowns, List<string> optionList, List<Tuple<int, string>> currentList)
    {
        foreach (GameObject dicePoolDropdown in dicePoolDropdowns)
        {
            GetDropdownFromPanel(dicePoolDropdown).GetComponentInParent<DicePoolDropdown>().ChangeCurrentListToNewList(currentList);
            List<string> specificOptionDependentDiceRolls = new List<string>();
            if (GetDropdownFromPanel(dicePoolDropdown).GetComponentInParent<DicePoolDropdown>().AccessCurrentTuple().Item1 == 0)
            {
                GetDropdownFromPanel(dicePoolDropdown).ClearOptions();
                GetDropdownFromPanel(dicePoolDropdown).AddOptions(optionList);
            }
            else if (GetDropdownFromPanel(dicePoolDropdown).GetComponentInParent<DicePoolDropdown>().AccessCurrentTuple().Item1 != 0)
            {
                specificOptionDependentDiceRolls.AddRange(optionList);
                specificOptionDependentDiceRolls.Insert(0, GetDropdownFromPanel(dicePoolDropdown).GetComponentInParent<DicePoolDropdown>().AccessCurrentTuple().Item2);
                GetDropdownFromPanel(dicePoolDropdown).ClearOptions();
                GetDropdownFromPanel(dicePoolDropdown).AddOptions(specificOptionDependentDiceRolls);
            }
        }
    }
       /* private List<string> RemoveSelectedDropdownOptions(List<string> optionList, List<int> chosenList)
    {//Double Checked, Should Be Good
        for (int i = 0; i < chosenDropdownValues.Count; i++)
        {
            optionList.RemoveAt(chosenList[i]);
        }
        return optionList;
    }*/
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
            if (currentDicePoolDropdown.AccessCurrentTuple().Item1 == 0)
            {
                intelligence = currentStatValue;
                statAlloter.AddReflexOrIntToPointPool(reflex, intelligence);
            }
            else
            {
                //pickupSkillPointsCount -= intelligence;
                intelligence = currentStatValue;
                statAlloter.AddReflexOrIntToPointPool(reflex, intelligence);
            }

        }
        else if (currentText == "Reflex:")
        {
            if (currentDicePoolDropdown.AccessCurrentTuple().Item1 == 0)
            {
                reflex = currentStatValue;
                statAlloter.AddReflexOrIntToPointPool(reflex, intelligence);
            }
            else
            {
                //pickupSkillPointsCount -= reflex;
                reflex = currentStatValue;
                statAlloter.AddReflexOrIntToPointPool(reflex, intelligence);
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
        Debug.Log(intelligence);
    }

    public void OnDicePoolButton()
    {
        randomDiceRolls = DicePoolRandomizer(randomDiceRolls);
        DicePoolActivator(pointAllotments, dicePoolDropdowns, statButtons, randomDiceRolls);
        SetInitialCurrentList(randomDiceRolls);
        RollTextFiller(rollTexts);
        statAlloter.AddReflexOrIntToPointPool(0, 0, 0);
        intelligence = 0;
        reflex = 0;
    }
        private List<Tuple<int, string>> DicePoolRandomizer(List<Tuple<int, string>> randomDiceRolls)
    {
        Tuple<int, string> startTuple = new Tuple<int, string>(0, "--");
        randomDiceRolls.Clear();
        randomDiceRolls.Add(startTuple);

        for (int i = 0; i <= 8; i++)
        {
            string stringForTuple;
            int random = UnityEngine.Random.Range(3, 11);
            if (random < 10)
            {
                stringForTuple = "0" + random.ToString();
            }
            else
            {
                stringForTuple = random.ToString();
            }
            Tuple<int, string> tupleToAddToList = new Tuple<int, string>(i + 1, stringForTuple);
            randomDiceRolls.Add(tupleToAddToList);
        }
        return randomDiceRolls;
    }
        private void DicePoolActivator(GameObject[] pointAllotments, GameObject[] dicePoolDropdowns, GameObject[] statButtons, List<Tuple<int, string>> randomDiceRolls)
        {
            dicePoolPanel.SetActive(true);
            pointsPanel.SetActive(false);
            List<string> optionList = GenerateOptionListFromRandomDiceRolls(randomDiceRolls);
            foreach (GameObject pointAllotment in pointAllotments)
            {
                pointAllotment.SetActive(false);
            }
            foreach (GameObject dicepooldropdown in dicePoolDropdowns)
            {
                dicepooldropdown.SetActive(true);
                dicepooldropdown.GetComponentInChildren<TMP_Dropdown>().ClearOptions();
               
                dicepooldropdown.GetComponentInChildren<TMP_Dropdown>().AddOptions(optionList);
            }
            foreach (GameObject statButton in statButtons)
            {
                statButton.SetActive(false);
            }
        }
        private void RollTextFiller(GameObject[] rollTexts)
        {
        List<string> optionList = GenerateOptionListFromRandomDiceRolls(randomDiceRolls);
            Debug.Log(rollTexts.Length);
            for (int i = 0; i < rollTexts.Length; i++)
            {
                rollTexts[i].GetComponent<TMP_Text>().text = optionList[i + 1];
            }

        }
        private List<string> GenerateOptionListFromRandomDiceRolls(List<Tuple<int, string>> randomDiceRolls)
    {
        List<string> optionList = new List<string>();
        for (int i = 0; i < randomDiceRolls.Count; i++)
        {
            optionList.Add(randomDiceRolls[i].Item2);
        }
        return optionList;
    }
        private void SetInitialCurrentList(List<Tuple<int, string>> randomDiceRolls)
    {
        Tuple<int, string> intialCurrentTuple = new Tuple<int, string>(0, "--");
        foreach (GameObject dicePoolDropdown in dicePoolDropdowns)
        {
            GetDropdownFromPanel(dicePoolDropdown).GetComponentInParent<DicePoolDropdown>().ChangeCurrentListToNewList(randomDiceRolls);
            GetDropdownFromPanel(dicePoolDropdown).GetComponentInParent<DicePoolDropdown>().ChangeCurrentSelectedTuple(intialCurrentTuple);
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
        statAlloter = GetComponent<StatAlotter>();
        statAlloter.AddReflexOrIntToPointPool(2, 2);
        /*intelligence = 2;
        reflex = 2;*/
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
            statAlloter.AddReflexOrIntToPointPool(2, 2, 0);
            statAlloter.AddReflexOrIntToPointPool(2, 2);
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
            intelligence = currentStatValue;
            statAlloter.AddReflexOrIntToPointPool(reflex, intelligence);
        }
        else if (currentText == "Reflex:")
        {
            reflex = currentStatValue;
            statAlloter.AddReflexOrIntToPointPool(reflex, intelligence);
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
    
}

    

    
    
    


    


