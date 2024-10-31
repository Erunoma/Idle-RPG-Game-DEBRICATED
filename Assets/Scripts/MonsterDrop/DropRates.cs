using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRates : MonoBehaviour {

	public bool dropWeapon;
	public int randDropNumber;



	public void CheckDrop(){
		randDropNumber = Random.Range (0, 100);
		if (randDropNumber >= 95) {
			dropWeapon = true;
		}





		if (dropWeapon == true) {
			gameObject.GetComponent<EquipmentCreation> ().CreateSword ();
		}


		dropWeapon = false;
	}

}
