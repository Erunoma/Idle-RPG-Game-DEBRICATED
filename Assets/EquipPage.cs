using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipPage : MonoBehaviour {

	public GameObject inventory;
	public bool choosingWeapon;
	public bool weaponEquipped;

	public GameObject equippedWeapon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InitWeaponEquip(){
		inventory.SetActive (true);
		choosingWeapon = true;
	}
	public void OnWeaponSelect(){
	}
}
