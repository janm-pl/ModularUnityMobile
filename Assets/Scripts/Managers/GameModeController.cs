using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using S = UnityEngine.SerializeField;

public class GameModeController : MonoBehaviour
{
    [S] DebugButton debugButton;
    public GameMode CurrentGameMode { get; set; } = GameMode.Setup;

    void Start()
    {
        debugButton.OnButtonClicked += SwitchGameMode;
    }

    void SwitchGameMode(bool debugMode)
    {
        CurrentGameMode = debugMode ? GameMode.Debug : GameMode.Setup;
    }

    public void ToggleDebugButton(bool enable)
    {
        debugButton.gameObject.SetActive(enable);
        if (!enable)
            SwitchGameMode(false);
    }

    public enum GameMode
    {
        Setup,
        Debug
    }
}