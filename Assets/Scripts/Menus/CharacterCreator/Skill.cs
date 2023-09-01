using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public string SkillName;
    public bool IsSpecialAbility = false;
    int skillLevel;

    private void Start()
    {
        this.GetComponentInChildren<Text>().text = SkillName;
    }

    public void SetSkillLevel(int currentSkillLevel)
    {
        skillLevel = currentSkillLevel;
    }
    public int GetSkillLevel()
    {
        return skillLevel;
    }
}


