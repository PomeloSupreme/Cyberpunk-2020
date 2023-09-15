using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorController : MonoBehaviour
{
    public GameObject PanelParent;
    private List<GameObject> panels = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject panel in panels)
        {
            panels.Add(panel);
        }
    }


}
