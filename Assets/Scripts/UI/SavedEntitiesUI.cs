using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using S = UnityEngine.SerializeField;

public class SavedEntitiesUI : MonoBehaviour
{
    [S] EntitySerializer entitySerializer;
    [S] EntityDispenser entityDispenser;
    [S] GameModeController gameModeController;
    [S] SavedEntityButton savedEntityButtonTemplate;
    List<SavedEntityButton> entityButtons = new List<SavedEntityButton>();
    [S] GameObject uiThisStageRoot;
    [S] GameObject uiNextStageRoot;

    void OnEnable()
    {
        InitializePanel();
        gameModeController.ToggleDebugButton(entityDispenser.EntitiesPlaced.Count != 0);
    }

    void OnDisable()
    {
        gameModeController.ToggleDebugButton(false);
    }

    void InitializePanel()
    {
        var behaviourCount = entitySerializer.SavedEntities.Count;
        for (int i = 0; i < 100; i++)
        {
            if (entityButtons.Count >= behaviourCount)
                break;
            entityButtons.Add(Instantiate(savedEntityButtonTemplate, transform));
        }

        for (var i = 0; i < entityButtons.Count; i++)
        {
            var entityButton = entityButtons[i];
            entityButton.Button.onClick.RemoveAllListeners();
            var entity = entitySerializer.SavedEntities[i];
            entityButton.Button.onClick.AddListener(() => entityDispenser.CreateEntity(entity));
            entityButton.UpdateUIData(entity);
        }
    }

    public void CreateNewEntity()
    {
        uiThisStageRoot.gameObject.SetActive(false);
        uiNextStageRoot.gameObject.SetActive(true);
    }
}