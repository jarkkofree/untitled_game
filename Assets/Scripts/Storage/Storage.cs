using UnityEngine;

public class Storage
{
    public bool Give(WareScriptableObject ware, int quantity) {
        
        // do we have enough ware.StorageType space free
        if(ware.UnitVolume * quantity > GetFreeSpace(ware.StorageType))
            return false;
        
        // do the transfer
        transfer(ware, quantity);
        return true;

    }
    public bool Take(WareScriptableObject ware, int quantity) {
        
        // do we have enough quantity of ware
        if (Count(ware) < quantity)
            return false;

        transfer(ware, -quantity);
        return true;
    }
    public int Count(WareScriptableObject ware) { return 0; }
    public int GetCapacity(StorageType type) { return 0; }
    public int GetFreeSpace(StorageType type) { return 0; }
    public bool AddModule(StorageModuleScriptableObject module, Storage buildStorage) {  return true; }

    private void transfer(WareScriptableObject ware, int quantity)
    {

    }
}
