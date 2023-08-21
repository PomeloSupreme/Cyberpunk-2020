using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsisticsButtons : MonoBehaviour
{
   
    Controller controller;

    public void Start()
    {
        controller = GetComponentInParent<Controller>();
    }

    public void ReportButton()
    {
        controller.SetCurrentButton(GetComponent<UnityEngine.UI.Button>());
    }

}
