using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using S = UnityEngine.SerializeField;

public class AttachableModule : MonoBehaviour
{
    public AttachableModuleType ModuleType;
    public Color ColorForUI;
    
    public void RemoveBehaviour()
    {
        Destroy(this);
    }

    public virtual void InvokeAction()
    {
        Debug.Log("Invoking behaviour", this);
    }
}