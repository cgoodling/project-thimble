using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

	public Transform selectedItem, selectedSlot, originalSlot;

	public GameObject slotPrefab, itemPrefab, emptyPrefab, dummySlot;
	public Vector2 inventorySize = new Vector2(4,6); 								// define the dimensions of the inventory in terms of slots
	public float slotSize;															// define the dimensions of a slot
	public Vector2 windowSize;														// define the demesions of the inventory window

	public bool canDrag = false;
	public bool mouseDown = false;

	//-------------------------------------------------------------------------------------------------------------------------------------------
	// Start()
	// Use this for initialization
	//-------------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		CreateInventory ();
	
	}// end start
	//-------------------------------------------------------------------------------------------------------------------------------------------
	// Update()
	// Update is called once per frame
	//-------------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
		GetInput ();
	}// end Update
	//-------------------------------------------------------------------------------------------------------------------------------------------
	// GetInput()
	// Handles input from the user
	//-------------------------------------------------------------------------------------------------------------------------------------------
	void GetInput(){
		//-----------------------------------------------------
		// MOUSE LEFT CLICK
		if (Input.GetMouseButtonDown (0) ){											// if mouse 1 is down...
			mouseDown = true;														// set mouseDown to true
			if (selectedItem != null){												// and if selectedItem is not null...
				canDrag = true;														// engage dragging
				originalSlot = selectedItem.parent;									// set originalSlot to the current slot
				selectedItem.GetComponent<Collider>().enabled = false;				// and disble the items collider
				selectedItem.SetParent(dummySlot.transform);						// also set the selected items parent to a dummy slot at the 
				// bottom of the hierarchy, rendering it last.
				SetItemColliders(false);											// disable all item colliders while item is beging dragged
			}
		}
		//-----------------------------------------------------
		// MOUSE LEFT CLICK DOWN
		if (Input.GetMouseButton (0) && selectedItem != null) { 					// if mouse 1 is held down...
			mouseDown = true;														// set mouseDown to true
			selectedItem.position = Input.mousePosition;							// move the item
		}
		//-----------------------------------------------------
		// MOUSE LEFT CLICK RELEASE
		else if (Input.GetMouseButtonUp (0) ) {										// if mouse 1 is released...
			mouseDown = false;														// set mouseDown to false
			if (selectedItem != null){												// and if selectedItem is not null...
				canDrag = false;													// disengage dragging
				SetItemColliders(true);												// enable all item colliders since item has been dropped
				if (selectedSlot == null){											// if selected slot is empty...
					selectedItem.SetParent(originalSlot);							// set items slot to originalSlot 
				}
				else{																// else...
					if (selectedSlot.childCount > 0){								// if the slot already has an item...

						if (selectedItem.name == selectedSlot.GetChild(0).name
							&& (selectedItem.GetComponent<Item>().type == Item.Type.consumable
							||  selectedItem.GetComponent<Item>().type == Item.Type.misc)){

							selectedItem.GetComponent<Item>().IncreseAmount(selectedSlot.GetChild(0).GetComponent<Item>().amount);
							Destroy(selectedSlot.GetChild(0).gameObject);
						}
						else {
							selectedSlot.GetChild(0).SetParent(originalSlot);		// set that items slot to the original
						}
					}
					selectedItem.SetParent(selectedSlot);							// set items slot to the current slot
				}
				if (originalSlot.childCount > 0){									// if the original slot has an item...
					originalSlot.GetChild(0).localPosition = Vector3.zero;			// switch the two items
				}
				selectedItem.localPosition = Vector3.zero;							// then set item local position to zero
				selectedItem.GetComponent<Collider>().enabled = true;				// and enable item collider
			}
		}
	}// end GetInput
	//-------------------------------------------------------------------------------------------------------------------------------------------
	// SetItemColliders()
	// enables/disables all item colliders 
	//-------------------------------------------------------------------------------------------------------------------------------------------
	void SetItemColliders(bool b){
		foreach (GameObject item in GameObject.FindGameObjectsWithTag("Item")) {
			item.GetComponent<Collider>().enabled = b;
		}
	}// end SetItemColliders
	//-------------------------------------------------------------------------------------------------------------------------------------------
	// CreateInventory()
	// Sets up the inventory
	//-------------------------------------------------------------------------------------------------------------------------------------------
	public void CreateInventory(){

		foreach (Transform t in this.transform) {
			Destroy(t.gameObject);
		}

		for (int x = 1; x <= inventorySize.x; x++) {
			for (int y = 1; y <= inventorySize.y; y++){
				GameObject slot = Instantiate(slotPrefab) as GameObject;
				slot.transform.SetParent(this.transform);
				slot.name = "slot_"+x+"_"+y;
				slot.GetComponent<RectTransform>().anchoredPosition = new Vector3(windowSize.x / (inventorySize.x+1) * x, windowSize.y / (inventorySize.y+1) * -y, 0);

				int currentslot = (x + ((y - 1) * 4 ));

				if (currentslot <= ItemDatabase.sortedItems.Count){

					GameObject item = Instantiate(itemPrefab) as GameObject;
					item.transform.SetParent(slot.transform);
					item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
					Item i = item.GetComponent<Item>();

					i.itemname 	= 	ItemDatabase.sortedItems[currentslot - 1].itemname;
					i.type 		= 	ItemDatabase.sortedItems[currentslot - 1].type;
					i.sprite 	= 	ItemDatabase.sortedItems[currentslot - 1].sprite;

					item.name = i.itemname;
					item.GetComponent<Image>().sprite = i.sprite;
				}
			}
		}
		dummySlot = Instantiate(emptyPrefab) as GameObject;				// set dummySlot as a empty prefab at the bottom of the hierarchy...
																		// children of this slot will be rendered last
		dummySlot.transform.SetParent(this.transform);
		dummySlot.name = "dummy";
	}
}// end CreateInventory
