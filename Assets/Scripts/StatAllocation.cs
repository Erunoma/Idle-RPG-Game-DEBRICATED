using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatAllocation : MonoBehaviour {

	public int primaryStatPointsAvailable;
	public int primaryStatPointsUsed;

	public int increaseStr;
	public int increaseDex;
	public int increaseAgi;
	public int increaseInt;


	public Text allocationText;
	public Text strAllocation;
	public Text dexAllocation;
	public Text agiAllocation;
	public Text intAllocation;

	public GameObject playerStats;

	public Text strTxt;
	public Text dexTxt;
	public Text agiTxt;
	public Text intTxt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		allocationText.text = "Allocation Points:   " + primaryStatPointsAvailable.ToString ();
		strTxt.text = playerStats.GetComponent<PlayerStatData> ().str.ToString();
		dexTxt.text = playerStats.GetComponent<PlayerStatData> ().dex.ToString();
		agiTxt.text = playerStats.GetComponent<PlayerStatData> ().agi.ToString();
		intTxt.text = playerStats.GetComponent<PlayerStatData> ().inte.ToString();
	}

	public void OnStrIncrease(){
		if (primaryStatPointsAvailable > 0) {
			primaryStatPointsAvailable--;
			primaryStatPointsUsed++;
			increaseStr++;
			strAllocation.text =  increaseStr.ToString ();
		}
	}
	public void OnDexIncrease(){
		if (primaryStatPointsAvailable > 0) {
			primaryStatPointsAvailable--;
			primaryStatPointsUsed++;
			increaseDex++;
			dexAllocation.text =  increaseDex.ToString ();
		}
	}
	public void OnAgiIncrease(){
		if (primaryStatPointsAvailable > 0) {
			primaryStatPointsAvailable--;
			primaryStatPointsUsed++;
			increaseAgi++;
			agiAllocation.text =  increaseAgi.ToString ();
		}
	}
	public void OnIntIncrease(){
		if (primaryStatPointsAvailable > 0) {
			primaryStatPointsAvailable--;
			primaryStatPointsUsed++;
			increaseInt++;
			intAllocation.text =  increaseInt.ToString ();
		}
	}


	public void OnStrDecrease(){
		if (primaryStatPointsUsed > 0) {
			primaryStatPointsUsed--;
			primaryStatPointsAvailable++;
			increaseStr--;
			strAllocation.text = increaseStr.ToString ();
		}
	}
	public void OnDexDecrease(){
		if (primaryStatPointsUsed > 0) {
			primaryStatPointsUsed--;
			primaryStatPointsAvailable++;
			increaseDex--;
			dexAllocation.text = increaseDex.ToString ();
		}
	}
	public void OnAgiDecrease(){
		if (primaryStatPointsUsed > 0) {
			primaryStatPointsUsed--;
			primaryStatPointsAvailable++;
			increaseAgi--;
			agiAllocation.text = increaseAgi.ToString ();
		}
	}
	public void OnIntDecrease(){
		if (primaryStatPointsUsed > 0) {
			primaryStatPointsUsed--;
			primaryStatPointsAvailable++;
			increaseInt--;
			intAllocation.text = increaseInt.ToString ();
		}
	}

	public void OnSave(){
		playerStats.GetComponent<PlayerStatData> ().str += increaseStr;
		playerStats.GetComponent<PlayerStatData> ().dex += increaseDex;
		playerStats.GetComponent<PlayerStatData> ().agi += increaseAgi;
		playerStats.GetComponent<PlayerStatData> ().inte += increaseInt;
		increaseStr = 0;
		increaseDex = 0;
		increaseAgi = 0;
		increaseInt = 0;
		strAllocation.text = increaseStr.ToString ();
		dexAllocation.text = increaseDex.ToString ();
		agiAllocation.text = increaseAgi.ToString ();
		intAllocation.text = increaseInt.ToString ();
		primaryStatPointsUsed = 0;
	}
}
