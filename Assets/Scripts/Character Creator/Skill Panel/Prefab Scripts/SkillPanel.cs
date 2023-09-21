using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanel : MonoBehaviour
{
    public GameObject SkillPrefab;
    List<string> SkillNames = new List<string>();
    SkillOverPanel skillOverPanel;

    private void Start()
    {
        skillOverPanel = GetComponentInParent<SkillOverPanel>();

    }
}
