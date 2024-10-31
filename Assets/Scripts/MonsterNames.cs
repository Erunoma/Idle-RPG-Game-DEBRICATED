using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterNames : MonoBehaviour {

	public int enemyType;
	public int nameChosen;
	public string monsterName;
	public string[] soft;
	public string[] hard;
	public string[] skinny;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OutPutName(){
		enemyType = Random.Range (0, 2);
		if (enemyType == 0) {
			monsterName = soft [Random.Range (0, soft.Length)];
		}
		if (enemyType == 1) {
			monsterName = hard [Random.Range (0, hard.Length)];
		}
		if (enemyType == 2) {
			monsterName = skinny [Random.Range (0, skinny.Length)];
		}
	}


}
