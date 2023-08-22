using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CareerSkillPoint : MonoBehaviour
{
    Controller controller;

    public void Start()
    {
        controller = GetComponentInParent<Controller>();
        controller.SetCareerSkillPoints(GetComponent<TMP_Text>());
    }

    public void ReportButton()
    {
        controller.SetCurrentButton(GetComponent<UnityEngine.UI.Button>());
    }
}
