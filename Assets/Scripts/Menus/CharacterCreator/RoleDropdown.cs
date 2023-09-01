using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoleDropdown : MonoBehaviour
{
    StatAlotter statAlotter;
    // Start is called before the first frame update
    void Start()
    {
        statAlotter = GetComponentInParent<StatAlotter>();
        statAlotter.roleDropdown = GetComponentInChildren<TMP_Dropdown>();
        Debug.Log("roleDropdown set");
    }

}
