using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemTypes {
    public List<Item> items = new List<Item>();

    public ItemTypes() {
        //0-2 currency
        items.Add(new Item(0, "Credits", 1));
        items.Add(new Item(1, "Points", 1000));
        items.Add(new Item(2, "Quarks", 1000000));

        //3-100 tradables
        items.Add(new Item(3, "Tylium", 10));
        items.Add(new Item(4, "Isogen", 20));
        items.Add(new Item(5, "Pyre", 50));
        items.Add(new Item(6, "Collapsium", 100));
        items.Add(new Item(7, "Lux", 5000));

        //101-200 contraband
        items.Add(new Item(101, "RifleAmmo", 25));
        items.Add(new Item(102, "PulsRifleAmmo", 50));
        items.Add(new Item(103, "PulseGrenade", 150));

    }

    public int getItem(int ID) {
        int output = -1;
        for (int i = 0; i < items.Count; i++) {
            if (items.ToArray()[i].getItemID() == ID)
                output = items.ToArray()[i].getItemID();
        }
        return output;
    }

}
