using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using UnityEngine;
using S = UnityEngine.SerializeField;

public class ModuleDispenser : MonoBehaviour
{
    [S] AttachableModule[] allModules;

    public AttachableModule GetAttachableModule(AttachableModuleType moduleType)
    {
        return allModules.FirstOrDefault(x => x.ModuleType == moduleType);
    }
}