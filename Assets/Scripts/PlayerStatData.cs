using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatData : MonoBehaviour {


	public float dps;
	public Text dpsTxt;
	public int str;
	public int dex;
	public int agi;
	public int inte;
	public GameObject wpnTypeMan;

	int dpsFromStr;
	int dpsFromDex;
	int dpsFromAgi;
	int dpsFromInt;
	public int dpsFromStats;

	public GameObject monsterList;
	public int dpsFromBoss;

	void Start (){
		
	}
	void Update(){
		dpsTxt.text = "DPS: " + dps.ToString();
		dpsFromStr = str * 5;
		dpsFromDex = dex * 2;
		dpsFromAgi = agi * 2;
		dpsFromInt = inte;
		dpsFromStats = dpsFromStr + dpsFromDex + dpsFromAgi + dpsFromInt;
		dps = Mathf.RoundToInt (wpnTypeMan.GetComponent<WeaponTypeManager>().weaponDps + 
			dpsFromStats + wpnTypeMan.GetComponent<WeaponTypeManager>().dpsFromEquippedWeapon);
		if (monsterList.GetComponent<MonsterList> ().bossActive == true) {
			dps = Mathf.RoundToInt (wpnTypeMan.GetComponent<WeaponTypeManager>().weaponDps + dpsFromStats + 
				dpsFromBoss + wpnTypeMan.GetComponent<WeaponTypeManager>().dpsFromEquippedWeapon);
		}
	}
}
