using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Items{

    public int itemID;
    public string itemName;
    public GUITexture icon;
    public int value;
    public ItemTypes itemTypes;

    public Items(int ID, string name, int value, ItemTypes type) {
        itemID = ID;
        itemName = name;
        this.value = value;
        itemTypes = type;

        icon = Resources.Load<GUITexture>("Resources/ItemIcons/" + itemName);
    }

    public enum ItemTypes 
    {
        Currencies,
        Goods,
        Ships,
        Weapons,
        Trading
    }
}