using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using S = UnityEngine.SerializeField;

public class ModuleToggleUI : MonoBehaviour
{
    [S] Toggle toggle;
    [S] Image image;
    [S] Text moduleDescription;
    [S] GameObject uiThisStageRoot;
    [S] GameObject uiNextStageRoot;
    public Toggle Toggle => toggle;
    
    public void InitializeToggle(AttachableModule module)
    {
        image.color = module.ColorForUI;
        moduleDescription.text = module.name;
    }
}