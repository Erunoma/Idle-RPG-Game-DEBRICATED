using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXPData : MonoBehaviour {

	public int lvl;
	public float xp;
	public float xpToLvl;
	public float xpNeededMultiplier;
	public int baseXp;
	public int money;
	public float[] xpValues;

	public int[] xpAllLevels;

	public Image xpBar;
	public Text xpTxt;

	public Text lvlTxt;

	public Text moneyTxt;


	float barStartValue;
	float endValue;

	public GameObject statAllocation;

	// Use this for initialization
	void Start () {
		baseXp = 100;
		CheckLvl();
		CheckForXP();

	}



	public void CheckForXP(){
		
		if (xp >= xpToLvl) {
			lvl++;
			statAllocation.GetComponent<StatAllocation> ().primaryStatPointsAvailable++;

			xp -= xpToLvl;
			barStartValue = 0;
			endValue = 0;
			CheckLvl ();
		}
	


		if (xp >= xpToLvl){
			CheckForXP ();
		}
	}

	public void CheckLvl(){
		if (lvl == 0) {
			lvl++;
		}
		if (lvl >= 1 && lvl <= 9) {
			xpToLvl = Mathf.RoundToInt (baseXp * xpNeededMultiplier  * 3 * lvl);
		}
		if (lvl >= 10 && lvl <= 19) {
			xpToLvl = Mathf.RoundToInt (baseXp * xpNeededMultiplier  * 6 * lvl);
		}
		if (lvl >= 20 && lvl <= 29) {
			xpToLvl = Mathf.RoundToInt (baseXp * xpNeededMultiplier  * 12 * lvl);
		}
		if (lvl >= 30 && lvl <= 39) {
			xpToLvl = Mathf.RoundToInt (baseXp * xpNeededMultiplier  * 18 * lvl);
		}
		if (lvl >= 40 && lvl <= 49) {
			xpToLvl = Mathf.RoundToInt (baseXp * xpNeededMultiplier  * 24 * lvl);
		}
		if (lvl >= 50 && lvl <= 59) {
			xpToLvl = Mathf.RoundToInt (baseXp * xpNeededMultiplier  * 30 * lvl);
		}
		if (lvl >= 60 && lvl <= 69) {
			xpToLvl = Mathf.RoundToInt (baseXp * xpNeededMultiplier  * 36 * lvl);
		}
		if (lvl >= 70 && lvl <= 79) {
			xpToLvl = Mathf.RoundToInt (baseXp * xpNeededMultiplier  * 42 * lvl);
		}
		if (lvl >= 80 && lvl <= 89) {
			xpToLvl = Mathf.RoundToInt (baseXp * xpNeededMultiplier  * 48 * lvl);
		}
		if (lvl >= 90 && lvl <= 99) {
			xpToLvl = Mathf.RoundToInt (baseXp * xpNeededMultiplier  * 54 * lvl);
		}
		if (lvl >= 100) {
			xpToLvl = Mathf.RoundToInt (baseXp * xpNeededMultiplier * 100  * lvl);
		}
	}

	void Update () {
		endValue = xp / xpToLvl;
		xpTxt.text = "XP: " + xp + " / " + xpToLvl;
		lvlTxt.text = "LVL: " + lvl.ToString ();
		moneyTxt.text = money.ToString();
		if (barStartValue < endValue) {
			barStartValue += 0.01F;
			xpBar.fillAmount = barStartValue;
		}



	}

	public void ConvertXp(){
		
	}

}
