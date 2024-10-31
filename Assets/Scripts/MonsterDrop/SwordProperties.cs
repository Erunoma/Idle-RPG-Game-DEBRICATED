using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordProperties : MonoBehaviour {

	public int quality; //0 = common, 1 = uncommon, 2 = rare, 3 = epic, 4 = legendary, 5 = godly;
	public int str;
	public int dex;
	public int agi;
	public int inte;
	public int dps;
	public int sellValue;
	public int itemLvl;
	public int lvl;
	public int maxLvl;
	public float xp;
	public float xpToLvl;
	public string name;

	int dpsFromStr;
	int dpsFromDex;
	int dpsFromAgi;
	int dpsFromInt;

	public int itemId;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		dpsFromStr = str * 5;
		dpsFromDex = dex * 2;
		dpsFromAgi = agi * 2;
		dpsFromInt = inte;
		dps = dpsFromStr + dpsFromDex + dpsFromAgi + dpsFromInt;
		if (xp >= xpToLvl && lvl < maxLvl) {
			lvl++;
			xpToLvl = xpToLvl * 1.5F;
			xp = 0;
			OnLvlUp();
		}
	}

	public void CheckXP (){

	}

	public void OnLvlUp(){
		str += 2;
		agi += 2;
		dex += 2;
		inte += 2;
		itemLvl += 5;
		sellValue = itemLvl * str * agi * dex * inte;
	}
}
