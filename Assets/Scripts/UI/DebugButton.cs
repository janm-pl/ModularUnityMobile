using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using S = UnityEngine.SerializeField;

public class DebugButton : MonoBehaviour
{
    [S] Image image;
    [S] Color colorRed;
    [S] Color colorGreen;
    public System.Action<bool> OnButtonClicked { get; set; }
    
    public void SwitchColorTheme(bool buttonEnabled)
    {
        OnButtonClicked?.Invoke(buttonEnabled);
        image.color = buttonEnabled ? colorGreen : colorRed;
    }

    public void ToggleColorTheme()
    {
        var buttonEnabled = image.color == colorRed ? true : false;
        OnButtonClicked.Invoke(buttonEnabled);
        image.color = buttonEnabled ? colorGreen : colorRed;
    }

    public void OnEnable()
    {
        SwitchColorTheme(false);
    }
}