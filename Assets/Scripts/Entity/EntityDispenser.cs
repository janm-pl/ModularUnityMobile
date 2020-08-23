using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using S = UnityEngine.SerializeField;

/// <summary>
/// Entity Dispenser is responsible for creating entities after deserialization. It also keeps all possible entities, and the 
/// </summary>
public class EntityDispenser : MonoBehaviour
{
    [S] EntityObject[] allObjects;

    [S] GameModeController gameModeController;

    // EntityObjectInCreation is duplicated EntityObject Scriptable Object, for purposes of creating new custom entity.
    public EntityObject EntityObjectInCreation { get; set; }
    public List<Entity> EntitiesPlaced { get; set; } = new List<Entity>();
    public EntityObject[] AllObjects => allObjects;


    /// <summary>
    /// Creates an entity duplicate and assures placement on navmesh in a random position.
    /// Use this after deserialization process, to spawn entity on screen.
    /// </summary>
    /// <param name="entity"></param>
    public void CreateEntity(Entity entity)
    {
        var entityDuplicate = Instantiate(entity);
        foreach (var module in entity.EntityObject.SelectedModules)
        {
            entityDuplicate.gameObject.CopyComponent(module);
        }

        NavMeshHit hit;
        var middlePosition = new Vector3(0, 0, -10f);
        var randomPosition = Random.insideUnitSphere * 10f;
        var finalPosition = middlePosition + randomPosition;
        if (!NavMesh.SamplePosition(finalPosition, out hit, 100f, NavMesh.AllAreas))
        {
            Destroy(entityDuplicate.gameObject);
            return;
        }

        entityDuplicate.transform.position = hit.position;
        entityDuplicate.gameObject.SetActive(true);
        gameModeController.ToggleDebugButton(true);
        EntitiesPlaced.Add(entityDuplicate);
    }
}