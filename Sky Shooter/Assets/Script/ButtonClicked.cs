using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonClicked : MonoBehaviour
{
    public delegate void MultiDelegate();
    MultiDelegate myMultiDelegate;

    Button button;
    void Start()
    {
        button.GetComponent<Button>();

        button.onClick.AddListener(() => {
            myMultiDelegate?.Invoke();
        });
        
    }
}
