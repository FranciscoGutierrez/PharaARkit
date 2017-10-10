using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AirTap : MonoBehaviour, IInputClickHandler, IFocusable
{
    public void OnFocusEnter()
    {
        Debug.Log("Fousing!");
        throw new NotImplementedException();
    }

    public void OnFocusExit()
    {
        throw new NotImplementedException();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("clicked god daamit");
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.JoystickButton0) == true) Debug.Log("A Button Pressed");
        if (Input.GetKey(KeyCode.JoystickButton3) == true) Debug.Log("Y Button Pressed");
    }
}
