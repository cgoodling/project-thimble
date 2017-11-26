using UnityEngine;
using System.Collections;
using UnityEngine.UI;
	
public class Item : MonoBehaviour {
	
	public string itemname;
	public enum Type {equip, consumable, misc}
	public Type type;
	public Sprite sprite;
	public int amount = 1;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseEnter(){
			if (transform.parent.parent.GetComponent<InventoryController> ().mouseDown == false) {
			transform.parent.parent.GetComponent<InventoryController> ().selectedItem = this.transform;		// set selectedItem to the current item
		}
	}

	void OnMouseOver(){
		if (transform.parent.parent.GetComponent<InventoryController> ().mouseDown == false) {
			transform.parent.parent.GetComponent<InventoryController> ().selectedItem = this.transform;
		}
	}

	void OnMouseExit(){
		if (!transform.parent.parent.GetComponent<InventoryController> ().canDrag) {
			transform.parent.parent.GetComponent<InventoryController> ().selectedItem = null;
		}
	}

	public void IncreseAmount(int qty){
		amount += qty;
		transform.Find ("amount_text").GetComponent<Text> ().text = amount.ToString ();
	}
}