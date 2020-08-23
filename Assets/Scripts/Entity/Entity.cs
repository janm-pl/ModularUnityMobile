using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using S = UnityEngine.SerializeField;

public class Entity : MonoBehaviour
{
    public EntityObject EntityObject { get; set; }
    AttachableModule[] attachableModules;

    void Start()
    {
        attachableModules = GetComponentsInChildren<AttachableModule>();
    }

    public void TriggerAllModules()
    {
        if (GameManager.Instance.GameModeController.CurrentGameMode != GameModeController.GameMode.Debug)
            return;
        
        foreach (var attachableModule in attachableModules)
        {
            attachableModule.InvokeAction();
        }
    }
}