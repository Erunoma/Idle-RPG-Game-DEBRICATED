using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponInfo : MonoBehaviour {

	public GameObject selectedWeapon;
	public Image weaponIcon;
	public Image xpBar;

	public Text wpnStr;
	public Text wpnDex;
	public Text wpnAgi;
	public Text wpnInte;

	public Text sellPrice;
	public Text dpsIncrease;

	public Text quality;
	public Text itemLvl;

	public float endValue;
	public Text lvl;
	public Text xpText;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		weaponIcon.sprite = selectedWeapon.GetComponent<Image> ().sprite;

		endValue = selectedWeapon.GetComponent<SwordProperties> ().xp / selectedWeapon.GetComponent<SwordProperties> ().xpToLvl;
		xpBar.fillAmount = endValue;
		xpText.text = selectedWeapon.GetComponent<SwordProperties> ().xp + " / " + selectedWeapon.GetComponent<SwordProperties> ().xpToLvl.ToString ();
		lvl.text = "LVL: " + selectedWeapon.GetComponent<SwordProperties> ().lvl.ToString ();

		wpnStr.text = selectedWeapon.GetComponent<SwordProperties> ().str.ToString ();
		wpnDex.text = selectedWeapon.GetComponent<SwordProperties> ().dex.ToString ();
		wpnAgi.text = selectedWeapon.GetComponent<SwordProperties> ().agi.ToString ();
		wpnInte.text = selectedWeapon.GetComponent<SwordProperties> ().inte.ToString ();

		itemLvl.text = selectedWeapon.GetComponent<SwordProperties> ().itemLvl.ToString();

		sellPrice.text = selectedWeapon.GetComponent<SwordProperties> ().sellValue.ToString ();

		dpsIncrease.text = selectedWeapon.GetComponent<SwordProperties> ().dps.ToString();

		if (selectedWeapon.GetComponent<SwordProperties> ().quality == 0) {
			quality.text = "Common";
			quality.color = new Color (188F, 189F, 192F);
		}
		if (selectedWeapon.GetComponent<SwordProperties> ().quality == 1) {
			quality.text = "Uncommon";
			quality.color = new Color (49F, 182F, 0F);
		}
		if (selectedWeapon.GetComponent<SwordProperties> ().quality == 2) {
			quality.text = "Rare";
			quality.color = new Color (2F, 57F, 208F);
		}
		if (selectedWeapon.GetComponent<SwordProperties> ().quality == 3) {
			quality.text = "Epic";
			quality.color = new Color (132F, 2F, 208F);
		}
		if (selectedWeapon.GetComponent<SwordProperties> ().quality == 4) {
			quality.text = "Legendary";
			quality.color = new Color (219F, 138F, 16F);
		}
		if (selectedWeapon.GetComponent<SwordProperties> ().quality == 5) {
			quality.text = "Godly";
			quality.color = new Color (222F, 11F, 166F);
		}

	}
}
