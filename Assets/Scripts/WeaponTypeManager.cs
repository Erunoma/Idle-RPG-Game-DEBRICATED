using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponTypeManager : MonoBehaviour {

	public int baseWeaponXP;
	public float xpNeededMultiplier;
	public float xpGainedMultiplier;

	public GameObject equipPage;

	public float oneHandLvl;
	public float oneHandXp;
	public float oneHandXpReq;
	public float oneHandDamageMultiplier;
	public Image oneHandBar;
	public Text oneHandTxt;

	public float weaponDamageMultiplier;
	public float weaponDps;

	public float dpsFromEquippedWeapon;

	public int playerWeaponType;
	public GameObject playerData;

	public GameObject currentWeapon;
	

	// Use this for initialization
	void Start () {
		oneHandXpReq = Mathf.RoundToInt (baseWeaponXP * xpNeededMultiplier  * 2 * oneHandLvl);
	}
	
	// Update is called once per frame
	void Update () {
		currentWeapon = equipPage.GetComponent<EquipPage> ().equippedWeapon;
		oneHandBar.fillAmount = oneHandLvl / 1000;
		oneHandTxt.text = "LVL: " + oneHandLvl + " / 1000";
		if (oneHandXp >= oneHandXpReq) {
			oneHandLvl++;
			oneHandXp -= oneHandXpReq;
			oneHandXpReq = Mathf.RoundToInt (baseWeaponXP * xpNeededMultiplier  * 2 * oneHandLvl);
		}
		if (equipPage.GetComponent<EquipPage> ().weaponEquipped == true) {
			dpsFromEquippedWeapon = equipPage.GetComponent<EquipPage> ().equippedWeapon.GetComponent<SwordProperties> ().dps;
		}
		weaponDps = oneHandLvl * (weaponDamageMultiplier + oneHandDamageMultiplier);
	}

	public void CalculateXP(){
		if (playerWeaponType == 0) {
			oneHandXp += playerData.GetComponent<PlayerStatData> ().dps * xpGainedMultiplier;
		currentWeapon.GetComponent<SwordProperties>().xp += playerData.GetComponent<PlayerStatData> ().dps * xpGainedMultiplier;

		}
	}
}
