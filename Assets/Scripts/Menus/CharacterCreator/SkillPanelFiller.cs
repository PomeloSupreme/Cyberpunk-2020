using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelFiller : MonoBehaviour
{
    public string PanelName;
    public List<GameObject> ListGenerators= new List<GameObject>();
    Vector3 panelPosition;
    float totalYMoved = 0;
    float panelHeight;
    float timesToShiftRight = 0;
    int objectsToMoveRight;
    float listGeneratorWidth;
    public float xAdjuster;
    public float segmentGap;
    public float columnGap;
    public float rightShift;

    private void Start()
    {
        panelPosition = transform.position - new Vector3 (rightShift, 0, 0) ;
        //panelPosition = panelPosition + new Vector3(-GetComponent<RectTransform>().rect.width / 2, (GetComponent<RectTransform>().rect.height / 2) -15, 0);
        //panelPosition = new Vector3(0, 0);
        panelHeight = this.GetComponent<RectTransform>().rect.height;
        for (int i = 0; i < ListGenerators.Count; i++)
        {
            
            ListGenerator currentListGenerator = ListGenerators[i].GetComponent<ListGenerator>();
            listGeneratorWidth = currentListGenerator.GetComponent<RectTransform>().rect.width;
            if (panelHeight - totalYMoved < 2 * currentListGenerator.GetComponent<RectTransform>().rect.height)
            {
                timesToShiftRight++;
                float distanceToMoveRight = ((currentListGenerator.GetComponent<RectTransform>().rect.width - xAdjuster) * timesToShiftRight);
                totalYMoved = 0;
                currentListGenerator.transform.position = panelPosition + new Vector3(distanceToMoveRight, -totalYMoved, 0) + new Vector3(listGeneratorWidth / 2, 0, 0) + new Vector3 (0, segmentGap, 0);
                totalYMoved += ((currentListGenerator.ObjectToBeReplicated.GetComponent<RectTransform>().rect.height * currentListGenerator.SkillNames.Count) + currentListGenerator.HeightOfListGenerator());
                if (totalYMoved > panelHeight)
                {
                    timesToShiftRight++;
                    objectsToMoveRight = (int)Math.Ceiling((totalYMoved - panelHeight) / currentListGenerator.ObjectToBeReplicated.GetComponent<RectTransform>().rect.height);
                    int listOfObjectSize = currentListGenerator.listOfObjects.Count;
                    totalYMoved = 0;
                    distanceToMoveRight = ((currentListGenerator.GetComponent<RectTransform>().rect.width) * timesToShiftRight);

                    while (objectsToMoveRight > 0)
                    {
                        currentListGenerator.listOfObjects[listOfObjectSize - objectsToMoveRight].GetComponent<RectTransform>().position = panelPosition + new Vector3(distanceToMoveRight, -totalYMoved, 0) + new Vector3(listGeneratorWidth / 2, 0, 0) + new Vector3(xAdjuster, 0, 0);
                        totalYMoved += currentListGenerator.ObjectToBeReplicated.GetComponent<RectTransform>().rect.height;
                        objectsToMoveRight--;
                    }
                }
            }
            else
            {
                //Vector3 currentVector = currentListGenerator.transform.position ;
                float distanceToMoveRight = ((currentListGenerator.GetComponent<RectTransform>().rect.width - xAdjuster) * timesToShiftRight);
                currentListGenerator.transform.position = panelPosition + new Vector3(distanceToMoveRight, -totalYMoved, 0) + new Vector3(listGeneratorWidth / 2, 0, 0) + new Vector3(0, segmentGap, 0);
                totalYMoved += ((currentListGenerator.ObjectToBeReplicated.GetComponent<RectTransform>().rect.height * currentListGenerator.SkillNames.Count) + currentListGenerator.HeightOfListGenerator());
                if (totalYMoved > panelHeight)
                {
                    timesToShiftRight++;
                    objectsToMoveRight = (int)Math.Ceiling((totalYMoved - panelHeight) / currentListGenerator.ObjectToBeReplicated.GetComponent<RectTransform>().rect.height);
                    int listOfObjectSize = currentListGenerator.listOfObjects.Count;
                    totalYMoved = 0;
                    distanceToMoveRight = ((currentListGenerator.GetComponent<RectTransform>().rect.width - xAdjuster) * timesToShiftRight);

                    while (objectsToMoveRight > 0)
                    {
                        currentListGenerator.listOfObjects[listOfObjectSize - objectsToMoveRight].GetComponent<RectTransform>().position = panelPosition + new Vector3(distanceToMoveRight, -totalYMoved, 0) + new Vector3(listGeneratorWidth / 2, 0, 0);
                        totalYMoved += currentListGenerator.ObjectToBeReplicated.GetComponent<RectTransform>().rect.height;
                        objectsToMoveRight--;
                    }
                }
            }
        }
        //supposed to scale the skills whenever they go past the screen. 
        /*float scale = 1;
        listGeneratorWidth = 600;
        //float listGeneratorWidth = this.GetComponent<RectTransform>().rect.width;
        //if (timesToShiftRight * listGeneratorWidth > this.GetComponent<RectTransform>().rect.width)
        if (timesToShiftRight * listGeneratorWidth > listGeneratorWidth)
        {
            //while (timesToShiftRight * listGeneratorWidth > this.GetComponent<RectTransform>().rect.width)
            while (timesToShiftRight * listGeneratorWidth > listGeneratorWidth)
            {
                foreach (Transform transform in transform)
                {
                    transform.localScale = (new Vector3(scale, scale, scale));
                    listGeneratorWidth *= scale;
                    scale -= 0.1f;
                }
            }
        }*/
    }

}
