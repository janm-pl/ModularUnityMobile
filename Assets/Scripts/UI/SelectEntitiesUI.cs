using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using S = UnityEngine.SerializeField;

public class SelectEntitiesUI : MonoBehaviour
{
    [S] EntityDispenser entityDispenser;
    [S] EntityButtonUI entityButtonPrefab;
    [S] GameObject uiThisStageRoot;
    [S] GameObject uiNextStageRoot;
    
    public List<EntityButtonUI> instancedEntityButtons;

    void OnEnable()
    {
        InitializePanel();
    }

    void InitializePanel()
    {
        var entitiesCount = entityDispenser.AllObjects.Length;
        for (int i = 0; i < 100; i++)
        {
            if (instancedEntityButtons.Count >= entitiesCount)
                break;
            instancedEntityButtons.Add(Instantiate(entityButtonPrefab, transform));
        }

        for (var i = 0; i < instancedEntityButtons.Count; i++)
        {
            var entity = entityDispenser.AllObjects[i];
            var entityButton = instancedEntityButtons[i];
            entityButton.Image.sprite = entity.EntityButtonImage;
            entityButton.Button.onClick.AddListener(() => NextUIStage(entity));
        }
    }


    void NextUIStage(EntityObject obj)
    {
        entityDispenser.EntityObjectInCreation = Instantiate(obj);
        uiThisStageRoot.gameObject.SetActive(false);
        uiNextStageRoot.gameObject.SetActive(true);
    }
}