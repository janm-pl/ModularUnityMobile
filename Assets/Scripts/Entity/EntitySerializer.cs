using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using S = UnityEngine.SerializeField;

public class EntitySerializer : MonoBehaviour
{
    public List<Entity> SavedEntities { get; } = new List<Entity>();

    /// <summary>
    /// in full application, this should be responsible for persistent data keeping aka real serialization and deserialization.
    /// </summary>
    /// <param name="entityObject"></param>
    public void SerializeEntity(EntityObject entityObject)
    {
        var entity = Instantiate(entityObject.Prefab);
        entity.gameObject.SetActive(false);
        SavedEntities.Add(entity);
        entity.EntityObject = entityObject;
    }
}