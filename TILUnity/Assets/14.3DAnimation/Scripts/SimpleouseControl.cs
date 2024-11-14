using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleouseControl : MonoBehaviour
{
    private void Start()
    {
        OnApplicationFocus(true);
    }

    private bool isFocusing = true;

    private void OnApplicationFocus(bool hasFocus)
    {
        isFocusing = hasFocus;

        if (isFocusing)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isFocusing = false;
        }
    }
    
}
