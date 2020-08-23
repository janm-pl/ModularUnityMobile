using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using S = UnityEngine.SerializeField;

[CreateAssetMenu]
public class EntityObject : ScriptableObject
{
   [S] Entity prefab;
   [S] AttachableModuleType[] attachableModules;
   [S] Sprite entityButtonImage;

   public Sprite EntityButtonImage => entityButtonImage;
   public Entity Prefab => prefab;
   public AttachableModuleType[] AttachableModules => attachableModules;
   public List<AttachableModule> SelectedModules { get; set; } = new List<AttachableModule>();
}
