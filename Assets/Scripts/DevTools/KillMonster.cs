using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMonster : MonoBehaviour {

	public GameObject monsterList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void KillCurrentMonster(){
		if (monsterList.GetComponent<MonsterList> ().bossActive == false) {
			
			monsterList.GetComponent<MonsterList> ().currentMonster.GetComponent<MonsterData> ().currentHp = 0;
			return;
		}
		if (monsterList.GetComponent<MonsterList> ().bossActive == true) {
			monsterList.GetComponent<MonsterList> ().currentMonster.GetComponent<BossData> ().currentHp = 0;
			return;
		}
	}
}
