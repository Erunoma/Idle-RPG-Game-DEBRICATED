using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpDev : MonoBehaviour {

	public GameObject playerData;
	public GameObject statAllo;


	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LvlUp1(){
		playerData.GetComponent<PlayerXPData> ().lvl += 1;
		statAllo.GetComponent<StatAllocation> ().primaryStatPointsAvailable += 1;
	}
	public void LvlUp10(){
		playerData.GetComponent<PlayerXPData> ().lvl += 10;
		statAllo.GetComponent<StatAllocation> ().primaryStatPointsAvailable += 10;
	}
	public void LvlUp100(){
		playerData.GetComponent<PlayerXPData> ().lvl += 100;
		statAllo.GetComponent<StatAllocation> ().primaryStatPointsAvailable += 100;
	}
	public void LvlUp1000(){
		playerData.GetComponent<PlayerXPData> ().lvl += 1000;
		statAllo.GetComponent<StatAllocation> ().primaryStatPointsAvailable += 1000;
	}
}
