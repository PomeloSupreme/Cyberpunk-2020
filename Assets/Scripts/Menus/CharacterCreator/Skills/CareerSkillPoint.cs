using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CareerSkillPoint : MonoBehaviour
{
    StatAlotter statAlotter;

    public void Start()
    {
        statAlotter = GetComponentInParent<StatAlotter>();
        statAlotter.SetCareerSkillPoints(GetComponent<TMP_Text>());
        GetComponent<TMP_Text>().text = "40";
    }
}
