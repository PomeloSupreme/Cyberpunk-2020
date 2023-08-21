using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupSkills : MonoBehaviour
{
    // Start is called before the first frame update
    Controller controller;

    public void Start()
    {
        controller = GetComponentInParent<Controller>();
        controller.SetPickupSkillPoints(GetComponent<TMP_Text>());
    }
}
