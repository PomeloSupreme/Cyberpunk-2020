using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour
    {
   
    StatAlotter statAlotter;

    public void Start()
    {
        statAlotter = GetComponentInParent<StatAlotter>();
    }

    public void ReportButton()
    {
        statAlotter.SetCurrentButton(GetComponent<UnityEngine.UI.Button>());
    }

}

