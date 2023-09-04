using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ListGenerator : MonoBehaviour
{
    public string ParentName;
    public GameObject ObjectToBeReplicated;
    public List<GameObject> listOfObjects;
    public int NumberOfObjectsToMake;
    public List<string> SkillNames;
    public bool AreTheseSpecialAbilities;
    float yValueOfObject;
    float xValueOfObject;
    float positionFromListHead = 0;
    Vector3 parentPosition;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = ParentName;
        parentPosition = transform.position;
        yValueOfObject = ObjectToBeReplicated.GetComponent<RectTransform>().rect.height;
        //positionChange = new Vector3(0, yValueOfObject, 0);

        for (int i = 0; i< SkillNames.Count; i++)
        {
            parentPosition -= new Vector3(0, yValueOfObject);
            listOfObjects.Add(Instantiate(ObjectToBeReplicated, parentPosition , Quaternion.identity, this.transform));
            
            
        }
        for (int i = 0; i< listOfObjects.Count; i++)
        {
            Skill currentSkill = listOfObjects[i].GetComponent<Skill>();
            currentSkill.SkillName = SkillNames[i];
            if (AreTheseSpecialAbilities)
            {
                currentSkill.IsSpecialAbility= true;
            }
        }
    }

    public float HeightOfListGenerator()
    {
        return this.GetComponent<RectTransform>().rect.height;
    }

}
