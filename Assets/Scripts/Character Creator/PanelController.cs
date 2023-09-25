using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Panels = new List<GameObject>();
    public GameObject LeftButton;
    public GameObject RightButton;
    public List<GameObject> MiddleButtons = new List<GameObject>();
    public List<string> MiddleButtonNames;
    private int currentPanel;

    public void Start()
    {
        Panels[0].SetActive(true);
        
        for(int i = 0; i < MiddleButtons.Count; i++)
        {
            MiddleButtons[i].GetComponentInChildren<TMP_Text>().text = MiddleButtonNames[i];
        }
        StartCoroutine(DelayedStart());
    }
    private IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(0.001f);
        for (int i = 1; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
        }

    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            OnLeftButton();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            OnRightButton();
        }
    }
    public void OnLeftButton()
    {
        if(currentPanel == 0)
        {
            Panels[currentPanel].SetActive(false);
            currentPanel = Panels.Count - 1;
            Panels[currentPanel].SetActive(true);
        }
        else
        {
            Panels[currentPanel].SetActive(false);
            currentPanel--;
            Panels[currentPanel].SetActive(true);
        }
    }
    public void OnRightButton()
    {
        if(currentPanel == Panels.Count - 1)
        {
            Panels[currentPanel].SetActive(false);
            currentPanel = 0;
            Panels[currentPanel].SetActive(true);
        }
        else
        {
            Panels[currentPanel].SetActive(false);
            currentPanel++;
            Panels[currentPanel].SetActive(true);
        }
    }
    public void OnMiddleButton(GameObject thisButton)
    {
        for (int i = 0; i < MiddleButtons.Count; i++)
        {
            if (thisButton == MiddleButtons[i])
            {
                Panels[currentPanel].SetActive(false);
                currentPanel = i;
                Panels[currentPanel].SetActive(true);
            }
        }
    }

    
}
