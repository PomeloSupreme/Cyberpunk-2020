using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelSelectionButton : MonoBehaviour
{
    // Start is called before the first frame update
    public string name;
    public GameObject[] PanelsToReveal;
    public GameObject[] PanelsToHide;


    private void Start()
    {
        this.GetComponentInChildren<TMP_Text>().text = name;
    }
    public void RevealAndHide()
    {
        foreach (GameObject panel in PanelsToReveal)
        {
            panel.SetActive(true);
        }
        foreach (GameObject panel in PanelsToHide)
        {
            panel.SetActive(false);
        }
    }
}
