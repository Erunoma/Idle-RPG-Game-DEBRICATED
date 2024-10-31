using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWpnProp : MonoBehaviour {

	public GameObject weaponInfo;
	public GameObject equipPage;
	public GameObject equipConfirm;
	public bool isWeapon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnPressed(){
		if (equipPage.GetComponent<EquipPage> ().choosingWeapon == true) {
			equipConfirm.SetActive (true);
			equipConfirm.GetComponent<EquipConfirm> ().selectedWeapon = gameObject;
			return;
		}
		if (equipPage.GetComponent<EquipPage> ().choosingWeapon == false) {
			weaponInfo.SetActive (true);
			weaponInfo.GetComponent<WeaponInfo> ().selectedWeapon = gameObject;
			return;
		}
	}
}
