using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Storage Module", menuName = "StorageModule")]
public class StorageModuleScriptableObject : ScriptableObject
{
    public string ModuleName;
    public StorageType Type;
    public int Capacity;
    public List<WareSet> Requirements;
}
