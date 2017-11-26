using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

	public GameObject inventoryScreen;
	public GameObject btn_all;
	public GameObject btn_equip;
	public GameObject btn_consumables;

	public KeyCode inventory;
	

	//-------------------------------------------------------------------------------------------------------------------------------------------
	// Start()
	// discription: Use this for initialization
	//-------------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
	
		ToggleInventoryWindow (); // toggle inventory screen off

	}// end Start
	
	//-------------------------------------------------------------------------------------------------------------------------------------------
	// Update()
	// discription: Update is called once per frame
	//-------------------------------------------------------------------------------------------------------------------------------------------
	void Update () {

		if (Input.GetKeyDown (inventory)) {

			ToggleInventoryWindow(); // toggle inventory screen on/off
		}


	}// end Update

	//-------------------------------------------------------------------------------------------------------------------------------------------
	// ToggleInventoryWindow()
	// discription: sets inventory screen and buttons to active/inactive
	// notes: some frame drop when inventory is opened or closed
	//-------------------------------------------------------------------------------------------------------------------------------------------
	void ToggleInventoryWindow(){

		inventoryScreen.SetActive (!inventoryScreen.activeInHierarchy);
		btn_all.SetActive (inventoryScreen.activeInHierarchy);
		btn_equip.SetActive (inventoryScreen.activeInHierarchy);
		btn_consumables.SetActive (inventoryScreen.activeInHierarchy);
		Cursor.visible = inventoryScreen.activeInHierarchy;
	}// end ToggleInventoryWindow

	//-------------------------------------------------------------------------------------------------------------------------------------------
	// OldToggleInventoryWindow()
	// requires:
	//			public Canvas canvasPrefab;
	//			public Image  backgroundPrefab;
	//			public Camera cameraPrefab;
	//			public Button btn_allPrefab;
	//			public Button btn_equipPrefab;
	//			public Button btn_consumablePrefab;
	//			public bool inventoryOpen = false;
	// discription: creates or destroys the inventory, based on prefab instantiation
	//
	// notes: no frame drop when the window is opened or closed
	//-------------------------------------------------------------------------------------------------------------------------------------------
	void OldToggleInventoryWindow(){

		/* OFF
		if (Input.GetKeyDown (inventory)) {

			// inventory is not open
			if (inventoryOpen == false){
				inventoryOpen = true;

				Canvas test_canvas         = Instantiate(canvasPrefab);
				test_canvas.transform.SetParent(this.transform);
				Transform test = test_canvas.transform;
				Image  test_background     = Instantiate(backgroundPrefab);
				Button test_btn_all        = Instantiate(btn_allPrefab);
				Button test_btn_equip      = Instantiate(btn_equipPrefab);
				Button test_btn_consumable = Instantiate(btn_consumablePrefab);

				test_background.transform.SetParent(test);
				test_background.transform.localPosition = Vector3.zero;
				test_btn_all.transform.SetParent(test);
				test_btn_all.transform.localPosition = Vector3.zero;
				test_btn_equip.transform.SetParent(test);
				test_btn_equip.transform.localPosition = Vector3.zero;
				test_btn_consumable.transform.SetParent(test);
				test_btn_consumable.transform.localPosition = Vector3.zero;

				GameObject cam = GameObject.Find("MainCamera");
				cam.transform.SetParent(test);
				cam.transform.localPosition = Vector3.zero;
			}

			// inventory is open
			else if (inventoryOpen == true){
				inventoryOpen = false;

				GameObject cam = GameObject.Find ("MainCamera");
				cam.transform.SetParent(null);
				cam.transform.localPosition = Vector3.zero;

				foreach (Transform child in this.transform){
					Destroy(child.gameObject);
				}
			}
		}*/

	}// end OldToggleInventoryScreen
}
