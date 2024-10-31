using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossGenerator : MonoBehaviour {

	public GameObject template;
	public GameObject newObject;
	public GameObject floorProgress;
	public GameObject wpnManager;

	public int randLvlNumber;
	public int randHealthNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateObject(){
		newObject = Instantiate (template);
		newObject.AddComponent<BossData> ();
		SetObjects ();
	}

	public void SetObjects()
	{
		BossData script = newObject.GetComponent<BossData> ();
		script.wpnLvlMan = GameObject.Find ("WeaponLVLManager");
		script.monsterManager = GameObject.Find ("MonsterManager");
		script.playerStatData = GameObject.Find ("PlayerData");
		script.healthBar = GameObject.Find ("EnemyFillBar").GetComponent<Image>();
		script.healthTxt = GameObject.Find ("EnemyHealthTxt").GetComponent<Text>();
		SetValues ();
	}

	public void SetValues() {
		BossData script = newObject.GetComponent<BossData> ();
	
		script.lvl = floorProgress.GetComponent<FloorProgression> ().floor + 10;
	
		if (script.lvl < 30 && script.lvl > 0) {
			script.hp = 30 * script.lvl * 8;
		}
		if (script.lvl < 60 && script.lvl > 30) {
			script.hp = 30 * script.lvl *  16;
		}
		if (script.lvl < 90 && script.lvl > 60) {
			script.hp = 30 * script.lvl * 28;
		}
		if (script.lvl > 100 && script.lvl > 90) {
			script.hp = 30 * script.lvl * 40;
		}
		script.currentHp = script.hp;
		script.def = script.lvl;
		script.money = Mathf.RoundToInt (floorProgress.GetComponent<FloorProgression> ().floor * script.hp / 1000);
		script.xpForDefeat = Mathf.RoundToInt (script.hp * script.lvl / 15);
		gameObject.GetComponent<MonsterNames> ().OutPutName ();
		script.monsterName = gameObject.GetComponent <MonsterNames> ().monsterName;
		script.monsterType = gameObject.GetComponent<MonsterNames> ().enemyType;
		gameObject.GetComponent<MonsterList> ().InsertCreatedBoss ();
	}
}
