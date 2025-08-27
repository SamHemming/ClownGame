using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    static public bool isInputEnabled = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            LeftClick();
    }

    void LeftClick()
    {
        //Was ui element clicked?


        //Raycast to find point in ground
    }
}
