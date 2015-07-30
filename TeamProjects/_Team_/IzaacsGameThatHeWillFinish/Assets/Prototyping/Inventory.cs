using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory {

    public List<Items> items;

	// Use this for initialization
	void Awake () {
        items = new List<Items>();
        //Currencies
        items.Add(new Items(0, "Credits", 1,       Items.ItemTypes.Currencies));
        items.Add(new Items(1, "Points",  1000,    Items.ItemTypes.Currencies));
        items.Add(new Items(2, "Quark",   1000000, Items.ItemTypes.Currencies));

        //Goods 3-100
        items.Add(new Items(3, "Tylium",     5,   Items.ItemTypes.Goods));
        items.Add(new Items(4, "Isogen",     10,  Items.ItemTypes.Goods));
        items.Add(new Items(5, "Pyre",       50,  Items.ItemTypes.Goods));
        items.Add(new Items(6, "Collapsium", 70,  Items.ItemTypes.Goods));
        items.Add(new Items(7, "Lux",        150, Items.ItemTypes.Goods));

        //Ships 101-200


        //Weapons 201-300
        items.Add(new Items(201, "RifleAmmo",      10, Items.ItemTypes.Weapons));
        items.Add(new Items(202, "PulseRifleAmmo", 25, Items.ItemTypes.Weapons));
        items.Add(new Items(203, "PulseGrenade",   50, Items.ItemTypes.Weapons));

        //Trading 301-400


	}
}
