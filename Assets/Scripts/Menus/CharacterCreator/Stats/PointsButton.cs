using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsButton : MonoBehaviour
{
    
    Controller controller;

    private void Start()
    {
        controller = GetComponentInParent<Controller>();
   
    }
    public void ReportDropdownToController()
    {
        controller.SetCurrentDropdown(GetComponent<TMP_Dropdown>());
    }
    
}
