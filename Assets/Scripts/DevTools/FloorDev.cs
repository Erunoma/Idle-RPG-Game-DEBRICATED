using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDev : MonoBehaviour {

	public GameObject floorMan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FloorUp1(){
		floorMan.GetComponent<FloorProgression> ().floor += 1;
	}
	public void FloorUp10(){
		floorMan.GetComponent<FloorProgression> ().floor += 10;
	}
	public void FloorUp100(){
		floorMan.GetComponent<FloorProgression> ().floor += 100;
	}
	public void FloorUp1000(){
		floorMan.GetComponent<FloorProgression> ().floor += 1000;
	}
}
