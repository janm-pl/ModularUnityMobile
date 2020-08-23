using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using S = UnityEngine.SerializeField;

public class SavedEntityButton : MonoBehaviour
{
    [S] Text entityName;
    [S] Text entityModules;
    [S] Button button;
    public Button Button => button;

    public void UpdateUIData(Entity entity)
    {
        entityName.text = entity.EntityObject.Prefab.name;
        string modulesText = $"";
        foreach (var module in entity.EntityObject.SelectedModules)
        {
            modulesText += $"{module.name} ";
        }

        entityModules.text = modulesText;
        
    }
}