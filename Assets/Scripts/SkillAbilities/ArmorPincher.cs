 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorPincher : MonoBehaviour {

	public GameObject playerData;
	public GameObject currentMonster;
	public GameObject monsterManager;

	public int spUsed;

	public float activeTimeMin;
	public float activeTimeSec;
	public float cdTime;
	public bool isActive;
	public bool isOnCD;

	public float minutes;
	public float seconds;

	public GameObject icon;
	public GameObject timerTxt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		currentMonster = monsterManager.GetComponent<MonsterGenerator> ().newObject;
		if (isActive == true) {
			timerTxt.SetActive (true);
			seconds -= Time.deltaTime;
			if (seconds <= 0) {
				minutes--;
				seconds = 59;
			}
			if (minutes < 0 ) {
				isActive = false;
				currentMonster.GetComponent<MonsterData> ().def += currentMonster.GetComponent<MonsterData> ().def * 2;
				minutes = cdTime;
				seconds = 0;
				isOnCD = true;
			}

		}	
		if (isOnCD == true) {
			seconds -= Time.deltaTime;
			if (seconds <= 0) {
				minutes--;
				seconds = 59;
			}
			if (minutes < 0 ) {
				isOnCD = false;
				icon.GetComponent<Button> ().interactable = true;
				timerTxt.SetActive (false);
			}

		}
		timerTxt.GetComponent<Text> ().text = string.Format ("{0}:{1}", minutes,Mathf.RoundToInt (seconds));

	}
	public void OnActivate(){
		if (spUsed <= playerData.GetComponent<SPData> ().spValue) {
			playerData.GetComponent<SPData> ().spValue -= spUsed;
			currentMonster.GetComponent<MonsterData> ().def -= currentMonster.GetComponent<MonsterData> ().def / 2;
			isActive = true;
			minutes = activeTimeMin;
			seconds = activeTimeSec;
			icon.GetComponent<Button> ().interactable = false;
		}
	}
}
