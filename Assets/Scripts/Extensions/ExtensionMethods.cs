using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class ExtensionMethods
{
    public static Component CopyComponent(this GameObject destination, Component original)
    {
        Type type = original.GetType();
        Component copiedComponent = destination.AddComponent(type);
        FieldInfo[] fields = type.GetFields(); 
        foreach (FieldInfo field in fields)
        {
            field.SetValue(copiedComponent, field.GetValue(original));
        }
        return copiedComponent;
    }
}