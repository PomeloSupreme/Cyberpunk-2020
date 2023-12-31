using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DicePoolDropdown : MonoBehaviour
{
    Tuple<int, string> previousSelectedTuple;
    Tuple<int, string> currentSelectedTuple = new Tuple <int, string>(0, "--");
    Controller controller;
    List<Tuple<int, string>> currentList = new List<Tuple<int, string>>();
    Tuple<int, string> choseEmptyTuple = new Tuple<int, string>(0, "--");

    public void Start()
    {
        controller = GetComponentInParent<Controller>();
    }
    //Problem lies Here
    public Tuple<int, string> ConvertOptionValueToTuple(int optionValue)
    {
        if (currentList.Count <= 2
            && optionValue == 1)
        {
            return choseEmptyTuple;
        }
        else
        {
            Tuple<int, string> dropdownSelectedTuple = currentList[optionValue];
            return dropdownSelectedTuple;
        }
    }
    public void ReportDropdownToController()
    {
        controller.SetCurrentDropdown(GetComponent<TMP_Dropdown>());
    }

    public void ChangePreviousSelectedTupleToCurrent()
    {
        previousSelectedTuple = currentSelectedTuple;
    }

    public Tuple<int, string> AccessPreviousTuple()
    {
        return previousSelectedTuple;
    }

    public void ChangeCurrentSelectedTuple(Tuple<int, string> currentTuple)
    {
        currentSelectedTuple = currentTuple;
    }
    public Tuple<int, string> AccessCurrentTuple()
    {
        return currentSelectedTuple;
    }
    public List<Tuple<int, string>> AccessCurrentList()
    {

        return currentList;
    }
    public void ChangeCurrentListToNewList(List<Tuple<int, string>> tupleList)
    {
        currentList.Clear();
        currentList.AddRange(tupleList);
    }    
    public void InsertCurrentTupleToFrontOfCurrentList(Tuple<int, string> currentTuple)
    {
        currentList.Insert(0, currentTuple);
    }
}
