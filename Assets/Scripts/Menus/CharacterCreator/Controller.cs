using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Controller : MonoBehaviour
{
    //Statistic & Skill variables

    int intelligence;
    int relfex;
    int technicalAbility;
    int cool;
    int attractiveness;
    int luck;
    int movementAllowance;
    int bodyType;
    int empathy; 



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
    

    // Start is called before the first frame update
    void Start()
    {
        DicePoolIntialization();
    }

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

        currentDicePoolDropdown.ChangePreviousValue(currentDropdown.value + chosenDropdownValues.Count - 1);
        optionDependentDiceRolls.AddRange(randomDiceRolls);

        optionDependentDiceRolls = RemoveSelectedDropdownOptions(optionDependentDiceRolls, chosenDropdownValues);

        PopulateDropdownOptions(dicePoolDropdowns, optionDependentDiceRolls);

        CorrectSelfDropdownOptions(currentDropdown, currentDicePoolDropdown, textOfCurrentValue, optionDependentDiceRolls);
    }
        public void DropdownChoice(TMP_Dropdown dropdown, List<int> chosenValues, int previousValue)
    {
        if (dropdown.options[dropdown.value].text == "--")
        {
            chosenValues.Remove(previousValue);
            Debug.Log("Chose Empty");
        }
        else if (chosenValues.Contains(dropdown.value + chosenValues.Count()))
        {
            Debug.Log("Number Already Chosen");
        }
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


    public void OnDicePoolButton()
    {
        randomDiceRolls = DicePoolRandomizer(randomDiceRolls);
        DicePoolActivator(pointAllotments, dicePoolDropdowns, statButtons, randomDiceRolls);
        RollTextFiller(rollTexts);
    }
        public List<string> DicePoolRandomizer(List<string> randomDiceRolls)
        {
            randomDiceRolls.Clear();
            randomDiceRolls.Add("--");

            for (int i = 0; i <= 8; i++)
            {
                int random = Random.Range(3, 11);
                if (random < 10)
                {
                    randomDiceRolls.Add("0" + random.ToString());
                }
                else
                    randomDiceRolls.Add(random.ToString());
            }
            return randomDiceRolls;
        }
        public void DicePoolActivator(GameObject[] pointAllotments, GameObject[] dicePoolDropdowns, GameObject[] statButtons, List<string> randomDiceRolls)
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
        public void RollTextFiller(GameObject[] rollTexts)
        {
            Debug.Log(rollTexts.Length);
            for (int i = 0; i < rollTexts.Length; i++)
            {
                rollTexts[i].GetComponent<TMP_Text>().text = randomDiceRolls[i + 1];
            }

        }
    public void DicePoolIntialization()
    {
        dicePoolDropdowns = GameObject.FindGameObjectsWithTag("DicePoolDropdown");
        statButtons = GameObject.FindGameObjectsWithTag("StatButton");
        rollTexts = GameObject.FindGameObjectsWithTag("RollText");
        dicePoolPanel = GameObject.FindGameObjectWithTag("DicePoolPanel");
        pointAllotments = GameObject.FindGameObjectsWithTag("PointAllotment");
        pointsPanel = GameObject.FindGameObjectWithTag("PointPanel");
        coroutine = LateStart(0.1f);
        StartCoroutine(coroutine);
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
    public TMP_Dropdown GetDropdownFromPanel(GameObject panel)
    {
        return panel.GetComponentInChildren<TMP_Dropdown>();
    }

    public List<string> RemoveSelectedDropdownOptions(List<string> optionList, List<int> chosenList)
    {
        for (int i = 0; i < chosenDropdownValues.Count; i++)
        {
            optionList.RemoveAt((chosenList[i]) - i);
        }
        return optionList;
    }
    public void PopulateDropdownOptions(GameObject[] dicePoolDropdowns, List<string> optionList)
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
    public void CorrectSelfDropdownOptions(TMP_Dropdown currentDropdown, DicePoolDropdown currentDicePoolDropdown, string textOfCurrentValue, List<string> optionDependentDiceRolls)
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
}

    


