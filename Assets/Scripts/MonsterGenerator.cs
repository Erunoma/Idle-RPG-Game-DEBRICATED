using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterGenerator : MonoBehaviour {

	public GameObject template;
	public GameObject newObject;
	public GameObject floorProgress;

	public int randLvlNumber;


	// Use this for initialization
	void Start () {
		CreateObject ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateObject(){
		newObject = Instantiate (template);
		newObject.AddComponent<MonsterData> ();
		SetObjects ();
	}

	public void SetObjects()
	{
		MonsterData script = newObject.GetComponent<MonsterData> ();
		script.wpnLvlMan = GameObject.Find ("WeaponLVLManager");
		script.monsterManager = GameObject.Find ("MonsterManager");
		script.playerStatData = GameObject.Find ("PlayerData");
		script.healthBar = GameObject.Find ("EnemyFillBar").GetComponent<Image>();
		script.healthTxt = GameObject.Find ("EnemyHealthTxt").GetComponent<Text>();
		SetValues ();
	}

	public void SetValues() {
		MonsterData script = newObject.GetComponent<MonsterData> ();
		randLvlNumber = Random.Range (0, 3);
		script.lvl = floorProgress.GetComponent<FloorProgression> ().floor + randLvlNumber;

		if (script.lvl < 30) {
			script.hp = 23 * script.lvl * 2;
		}
		if (script.lvl < 60) {
			script.hp = 23 * script.lvl * 4;
		}
		if (script.lvl < 90) {
			script.hp = 23 * script.lvl * 6;
		}
		if (script.lvl > 100) {
			script.hp = 23 * script.lvl * 9;
		}
		script.currentHp = script.hp;
		script.def = script.lvl;
		script.money = Mathf.RoundToInt (floorProgress.GetComponent<FloorProgression> ().floor * script.hp / 1000);
		script.xpForDefeat = Mathf.RoundToInt (script.hp * script.lvl / 15);
		gameObject.GetComponent<MonsterNames> ().OutPutName ();
		script.monsterName = gameObject.GetComponent <MonsterNames> ().monsterName;
		script.monsterType = gameObject.GetComponent<MonsterNames> ().enemyType;
		gameObject.GetComponent<MonsterList> ().InsertCreatedMonster ();
	}
}
