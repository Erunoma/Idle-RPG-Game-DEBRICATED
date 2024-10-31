using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossData : MonoBehaviour {


	public int lvl;
	public float hp;
	public int def;
	public int monsterType;
	public string monsterName;
	public float currentHp;
	public int xpForDefeat;
	public int money;


	public Image healthBar;
	public Text healthTxt;

	public float barStartValue;
	public float endValue;


	public bool isActive;

	public GameObject wpnLvlMan;


	public GameObject playerStatData;
	public GameObject monsterManager;

	void Start(){
		InvokeRepeating("Damage", 1.0f, 1.0f);
	}

	void Update(){
	//	healthBar.fillAmount = currentHp / hp;
		endValue = currentHp / hp;
		healthTxt.text = currentHp + " / " + hp.ToString();

		if (barStartValue > endValue) {
			barStartValue -= 0.02F;
			healthBar.fillAmount = barStartValue;
		}

		if (currentHp <= 0) {
			monsterManager.GetComponent<MonsterList> ().OnBossDefeated ();
			barStartValue = 1F;
			healthBar.fillAmount = barStartValue;
			Debug.Log("Boss is defeated!");

		}
		if (currentHp > hp) {
			currentHp = hp;
		}
	}

	public void Damage(){
		if (isActive == true) {
			currentHp -= Mathf.RoundToInt(playerStatData.GetComponent<PlayerStatData> ().dps - def);
			wpnLvlMan.GetComponent<WeaponTypeManager> ().CalculateXP ();
		}
	}



}
