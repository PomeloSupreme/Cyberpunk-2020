using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DicePoolButton : MonoBehaviour
{
    GameObject[] dicePoolDropdowns;
    GameObject[] statButtons;
    GameObject[] rollTexts;
    GameObject dicePoolPanel;
    GameObject[] pointAllotments;
    GameObject pointsPanel;
    List<string> randomDiceRolls = new List<string>();
    List<string> optionDependentDiceRolls = new List<string>();

    private IEnumerator coroutine;
    private void Start()
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
        yield return new WaitForSeconds(waitTime);
        dicePoolPanel.SetActive(false);
        foreach (GameObject dicepooldropdown in dicePoolDropdowns)
        {
            dicepooldropdown.SetActive(false);
        }
    }
    public void OnDicePoolButton()
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
            else randomDiceRolls.Add(random.ToString());
        }
        optionDependentDiceRolls = randomDiceRolls;

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
       
        int rollTextIndex = 1;
        foreach (GameObject rollText in rollTexts)
        {
            rollText.GetComponent<TMP_Text>().text = randomDiceRolls[rollTextIndex];
            rollTextIndex++;
        }
    } 

        public List<string> ReportRandomDiceRolls()
    {
        return randomDiceRolls;
    }
    public List<string> ReportOptionDependentDiceRolls()
    {
        return optionDependentDiceRolls;
    }
    public void UpdateOptionDependentDiceRolls(List<string> currentOptionList)
    {
        optionDependentDiceRolls = currentOptionList;
    }
}
