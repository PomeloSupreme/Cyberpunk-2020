using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupSkills : MonoBehaviour
{
    // Start is called before the first frame update
    StatAlotter statAlotter;

    public void Start()
    {
        statAlotter = GetComponentInParent<StatAlotter>();
        statAlotter.SetPickupSkillPoints(GetComponent<TMP_Text>());
    }
}
