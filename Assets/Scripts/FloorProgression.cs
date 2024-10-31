using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorProgression : MonoBehaviour {

	public int monstersOnFloor;
	public int monstersSlain;
	public int floor;
	public int floorsUnlocked;
	public Text floorText;
	public Text monsterTxt;

	public GameObject monsterList;

	// Use this for initialization
	void Start () {
		CheckFloor ();
	}
	
	// Update is called once per frame
	void Update () {
		monsterTxt.text = monstersSlain + " / " + monstersOnFloor.ToString (); 
		floorText.text = "Floor " + floor.ToString ();
	}

	public void CheckFloor(){
		monstersSlain = 0;
		//monsterList.GetComponent<MonsterList>().InsertMonster();

	}



}
