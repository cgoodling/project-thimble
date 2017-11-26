using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public Sprite[] sprites;

	public static List<Item> allItems = new List<Item>();
	public static List<Item> sortedItems = new List<Item>();

	// Use this for initialization
	void Awake () {
	
		// NEW ITEM
		Item i0 = gameObject.AddComponent<Item>();
		i0.itemname = "blue";
		i0.type = Item.Type.equip;
		i0.sprite = sprites [0];
		allItems.Add (i0);

		// NEW ITEM
		Item i1 = gameObject.AddComponent<Item>();
		i1.itemname = "red";
		i1.type = Item.Type.consumable;
		i1.sprite = sprites [1];
		allItems.Add (i1);

		// NEW ITEM
		Item i2 = gameObject.AddComponent<Item>();
		i2.itemname = "red";
		i2.type = Item.Type.consumable;
		i2.sprite = sprites [1];
		allItems.Add (i2);

		Item i3 = gameObject.AddComponent<Item>();
		i3.itemname = "red";
		i3.type = Item.Type.consumable;
		i3.sprite = sprites [1];
		allItems.Add (i3);

		Item i4 = gameObject.AddComponent<Item>();
		i4.itemname = "red";
		i4.type = Item.Type.consumable;
		i4.sprite = sprites [1];
		allItems.Add (i4);

		Item i5 = gameObject.AddComponent<Item>();
		i5.itemname = "red";
		i5.type = Item.Type.consumable;
		i5.sprite = sprites [1];
		allItems.Add (i5);

		Item i6 = gameObject.AddComponent<Item>();
		i6.itemname = "red";
		i6.type = Item.Type.consumable;
		i6.sprite = sprites [1];
		allItems.Add (i6);


		SortAllItems ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SortAllItems(){
		sortedItems.Clear ();
		foreach (Item i in allItems) {
				sortedItems.Add(i);
		}
	}

	public void SortItemsByType(string type){
		sortedItems.Clear ();
		foreach (Item i in allItems) {
			if(i.type.ToString() == type){
				sortedItems.Add(i);
			}
		}
	}
}
