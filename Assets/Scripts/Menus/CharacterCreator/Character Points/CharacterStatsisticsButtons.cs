using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsisticsButtons : MonoBehaviour
{
    public TMP_Text pointPool;
    public TMP_Text statValue;
    Controller controller;

    public void Start()
    {
        controller = GetComponentInParent<Controller>();
    }

    
    public void plusButton()
    {
        if (int.Parse(pointPool.text.TrimEnd('\r', '\n')) > 0)
        {
            if (int.Parse(statValue.text.TrimEnd('\r', '\n')) < 9)
            {
                statValue.text = "0" + (int.Parse(statValue.text.TrimEnd('\r', '\n')) + 1).ToString();
                
                if(int.Parse(pointPool.text.TrimEnd('\r', '\n')) <= 10)
                {
                    pointPool.text = "0" + (int.Parse(pointPool.text.TrimEnd('\r', '\n')) - 1).ToString();
                }
                else pointPool.text = (int.Parse(pointPool.text.TrimEnd('\r', '\n')) - 1).ToString();
            }
            else if (int.Parse(statValue.text.TrimEnd('\r', '\n')) == 9)
            {
                statValue.text = (int.Parse(statValue.text.TrimEnd('\r', '\n')) + 1).ToString();

                if (int.Parse(pointPool.text.TrimEnd('\r', '\n')) <= 10)
                {
                    pointPool.text = "0" + (int.Parse(pointPool.text.TrimEnd('\r', '\n')) - 1).ToString();
                }
                else pointPool.text = (int.Parse(pointPool.text.TrimEnd('\r', '\n')) - 1).ToString();
            }
            else Debug.Log("No Points Left");
        }
    }

    public void minusButton()
    {
        if (int.Parse(statValue.text.TrimEnd('\r', '\n')) > 2)
        {
            if (int.Parse(pointPool.text.TrimEnd('\r', '\n')) <= 9)
            {
                statValue.text = "0" + (int.Parse(statValue.text.TrimEnd('\r', '\n')) - 1).ToString();
                pointPool.text = "0" + (int.Parse(pointPool.text.TrimEnd('\r', '\n')) + 1).ToString();
            }
            else if (int.Parse(pointPool.text.TrimEnd('\r', '\n')) > 9)
            {
                statValue.text = "0" + (int.Parse(statValue.text.TrimEnd('\r', '\n')) - 1).ToString();
                pointPool.text = (int.Parse(pointPool.text.TrimEnd('\r', '\n')) + 1).ToString();

            }
            else Debug.Log("Stat Cant Go Lower");
        }
    }
    public void ReportButton()
    {
        controller.SetCurrentButton(GetComponent<UnityEngine.UI.Button>());
    }

}
