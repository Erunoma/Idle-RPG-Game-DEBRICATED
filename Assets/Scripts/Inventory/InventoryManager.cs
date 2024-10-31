using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public GameObject boxPrefab;
	public GameObject inventoryContent;
	public GameObject selectedSlotForItem;
	public GameObject dropManager;

	public List<GameObject> inventorySlots;



	public void AddSlot(){
		selectedSlotForItem = Instantiate (boxPrefab);
		dropManager.GetComponent<EquipmentCreation> ().createdSword.transform.SetParent (selectedSlotForItem.transform);
		dropManager.GetComponent<EquipmentCreation> ().createdSword.transform.position = selectedSlotForItem.transform.position;
//
		dropManager.GetComponent<EquipmentCreation> ().createdSword.transform.localScale = new Vector2 (2.33F, 0.94F);
		selectedSlotForItem.transform.SetParent (inventoryContent.transform,false);
		inventorySlots.Add (selectedSlotForItem);
		}

	public void OnSortByDPS(){
		
	}
	
}

