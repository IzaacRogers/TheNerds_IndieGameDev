using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {

    int itemID;
    string itemName;
    GameObject itemObject;
    int itemValue;

    public Item(int ID, string name, int value) 
    {
        itemID = ID;
        itemName = name;
        itemObject = Resources.Load<GameObject>("Resources/Items/" + name);
        itemValue = value;
    }

    public int getItemID() {
        return itemID;
    }

}
