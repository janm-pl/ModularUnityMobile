using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using S = UnityEngine.SerializeField;

public class ModulesPanelUI : MonoBehaviour
{
    [S] EntityDispenser entityDispenser;
    [S] EntitySerializer entitySerializer;
    [S] ModuleDispenser moduleDispenser;
    [S] ModuleToggleUI moduleToggleUiTemplate;
    [S] GameObject nextStageButton;
    [S] GameObject uiThisStageRoot;
    [S] GameObject uiNextStageRoot;

    List<ModuleToggleUI> instancedToggles = new List<ModuleToggleUI>();

    void OnEnable()
    {
        InitializePanel();
    }

    void InitializePanel()
    {
        var behaviourCount = entityDispenser.EntityObjectInCreation.AttachableModules.Length;
        for (int i = 0; i < 100; i++)
        {
            if (instancedToggles.Count >= behaviourCount)
                break;
            instancedToggles.Add(Instantiate(moduleToggleUiTemplate, transform));
        }

        for (var i = 0; i < instancedToggles.Count; i++)
        {
            var toggleBehaviour = instancedToggles[i];
            if (i < behaviourCount)
            {
                toggleBehaviour.gameObject.SetActive(true);   
                toggleBehaviour.Toggle.isOn = false;
                var module = moduleDispenser.GetAttachableModule(entityDispenser.EntityObjectInCreation.AttachableModules[i]);
                toggleBehaviour.Toggle.onValueChanged.RemoveAllListeners();
                toggleBehaviour.Toggle.onValueChanged.AddListener((bool value) => AddOrRemoveModule(value, module));
                instancedToggles[i].InitializeToggle(module);
            }
            // deactivate extra unused toggles
            else
            {
                  toggleBehaviour.gameObject.SetActive(false);     
            }
        }
    }


    public void NextUIStage()
    {
        entitySerializer.SerializeEntity(entityDispenser.EntityObjectInCreation);
        uiThisStageRoot.gameObject.SetActive(false);
        uiNextStageRoot.gameObject.SetActive(true);
    }

    void AddOrRemoveModule(bool add, AttachableModule module)
    {
        if (add)
        {
            entityDispenser.EntityObjectInCreation
                .SelectedModules.Add(module);
        }
        else
        {
            entityDispenser.EntityObjectInCreation
                .SelectedModules.Remove(module);
        }
    }
}