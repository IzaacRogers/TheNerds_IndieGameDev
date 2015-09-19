using UnityEngine;
using System.Collections;

public class PlayerInventory {

    static ItemTypes itemTypes = new ItemTypes();
    int[] itemAmount = new int[itemTypes.items.Count];

    int maxInventorySize;
    int currentStorage;

    public PlayerInventory(int InventroySize) {
        this.maxInventorySize = InventroySize;
    }

    public void addAmount(int ID, int amount) {
        for (int i = 0; i < itemAmount.Length; i++) {
            currentStorage += itemAmount[i];
        }

        if(currentStorage+amount<=maxInventorySize)
            itemAmount[itemTypes.getItem(ID)] += amount;
    }

    public void removeAmount(int ID, int amount) {
        if (itemAmount[itemTypes.getItem(ID)] >= amount)
            itemAmount[itemTypes.getItem(ID)] -= amount;
    }
    
}
