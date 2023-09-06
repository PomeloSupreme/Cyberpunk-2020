using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelFiller : MonoBehaviour
{
    public string PanelName;
    public List<GameObject> ListGenerators= new List<GameObject>();
    Vector3 topRightOfPanel;
    float totalYMoved = 0;
    Vector3 panelPosition;
    float panelHeight;
    float timesToShiftRight = 0;
    int objectsToMoveRight;
    float listGeneratorWidth;
    float panelYPosition;

    private void Start()
    {
        panelPosition = transform.position;
        topRightOfPanel = new Vector3 (-((GetComponent<RectTransform>().rect.width)/2),(GetComponent<RectTransform>().rect.height/2), 0);
        panelYPosition = transform.position.y;
        panelHeight = this.GetComponent<RectTransform>().rect.height;
        for (int i = 0; i < ListGenerators.Count; i++)
        {
            ListGenerator currentListGenerator = ListGenerators[i].GetComponent<ListGenerator>();
            listGeneratorWidth = currentListGenerator.GetComponent<RectTransform>().rect.width;
            Vector3 rightShift = new Vector3(timesToShiftRight, 1, 1);
            //Vector3 currentVector = currentListGenerator.transform.position ;
            float distanceToMoveRight = currentListGenerator.GetComponent<RectTransform>().rect.width * timesToShiftRight;
            currentListGenerator.transform.position = topRightOfPanel + new Vector3(0, -totalYMoved, 0) + new Vector3(distanceToMoveRight, 0, 0) + new Vector3 (listGeneratorWidth/2,0,0);
            totalYMoved += ((currentListGenerator.ObjectToBeReplicated.GetComponent<RectTransform>().rect.height * currentListGenerator.SkillNames.Count) + currentListGenerator.HeightOfListGenerator()); 
            if (totalYMoved > panelHeight)
            {
                timesToShiftRight++;
                objectsToMoveRight = (int)Math.Ceiling((totalYMoved - panelHeight)/currentListGenerator.ObjectToBeReplicated.GetComponent<RectTransform>().rect.height);
                int listOfObjectSize = currentListGenerator.listOfObjects.Count;
                totalYMoved = 0;
                float parentXPosition = currentListGenerator.transform.position.x;
                distanceToMoveRight = currentListGenerator.GetComponent<RectTransform>().rect.width * timesToShiftRight;

                while (objectsToMoveRight> 0)
                {
                    currentListGenerator.listOfObjects[listOfObjectSize - objectsToMoveRight].GetComponent<RectTransform>().position =  topRightOfPanel + new Vector3(distanceToMoveRight, -totalYMoved, 0);
                    totalYMoved += currentListGenerator.ObjectToBeReplicated.GetComponent<RectTransform>().rect.height;
                    objectsToMoveRight--;
                }
            }

        }
    }   

}
