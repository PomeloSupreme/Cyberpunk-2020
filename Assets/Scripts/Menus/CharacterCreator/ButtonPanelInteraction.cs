using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanelInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject childPanel;
    public GameObject[] otherPanels;
    
    public void MakePanelActive()
    {
        childPanel.SetActive(true);
        for(int i = 0; i < otherPanels.Length; i++)
        {
            otherPanels[i].SetActive(false);
        }
    }
    public void MakePanelInactive()
    {
        childPanel.SetActive(false);
    }
}
