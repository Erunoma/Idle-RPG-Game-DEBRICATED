using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipConfirm : MonoBehaviour {

	public GameObject selectedWeapon;
	public Image weaponIcon;
	public Text dpsIncrease;
	public Text newDps;
	public GameObject playerManager;
	public GameObject equipPage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		weaponIcon.sprite = selectedWeapon.GetComponent<Image> ().sprite;
		dpsIncrease.text = selectedWeapon.GetComponent<SwordProperties> ().dps.ToString();
		newDps.text = playerManager.GetComponent<PlayerStatData> ().dps + selectedWeapon.GetComponent<SwordProperties> ().dps.ToString ();
	}

	public void OnConfirm(){
		equipPage.GetComponent<EquipPage> ().equippedWeapon = selectedWeapon;
		equipPage.GetComponent<EquipPage> ().choosingWeapon = false;
		equipPage.GetComponent<EquipPage> ().weaponEquipped = true;

	}
}
