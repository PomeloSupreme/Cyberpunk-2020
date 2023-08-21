using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPointsButtons : MonoBehaviour
{
    public GameObject pointsPanel;
    public GameObject buttonsPanel;

    public void Update()
    {
        if(pointsPanel.activeInHierarchy == false)
        {
            buttonsPanel.SetActive(false);
        }
        else buttonsPanel.SetActive(true);
    }
}
