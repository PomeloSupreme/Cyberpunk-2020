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
     List<string> RandomDiceRolls = new List<string>();

    private void Start()
    {
        dicePoolDropdowns = GameObject.FindGameObjectsWithTag("DicePoolDropdown");
        statButtons = GameObject.FindGameObjectsWithTag("StatButton");
        rollTexts = GameObject.FindGameObjectsWithTag("RollText");
        dicePoolPanel = GameObject.FindGameObjectWithTag("DicePoolPanel");
        pointAllotments = GameObject.FindGameObjectsWithTag("PointAllotment");
        pointsPanel = GameObject.FindGameObjectWithTag("PointPanel");
    }

    public void OnDicePoolButton()
    {
        RandomDiceRolls.Clear();
        RandomDiceRolls.Add("--");

        for (int i = 0; i <= 8; i++)
        {
            int random = Random.Range(3, 11);
            if (random < 10)
            {
                RandomDiceRolls.Add("0" + random.ToString());
            }
            else RandomDiceRolls.Add(random.ToString());
        }

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
            dicepooldropdown.GetComponentInChildren<TMP_Dropdown>().AddOptions(RandomDiceRolls);
        }
        foreach (GameObject statButton in statButtons)
        {
            statButton.SetActive(false);
        }
       
        int rollTextIndex = 1;
        foreach (GameObject rollText in rollTexts)
        {
            rollText.GetComponent<TMP_Text>().text = RandomDiceRolls[rollTextIndex];
            rollTextIndex++;
        }
    } 

        public List<string> ReportString()
    {
        return RandomDiceRolls;
    }
}
