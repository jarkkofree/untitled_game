using UnityEngine;

[CreateAssetMenu(fileName = "New Ware", menuName = "Ware")]
public class WareScriptableObject : ScriptableObject
{
    public string WareName;
    public StorageType StorageType;
    public int UnitVolume;
}