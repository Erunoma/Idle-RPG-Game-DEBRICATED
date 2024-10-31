using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevToolsScript : MonoBehaviour {

	public bool isEnabled;
	public GameObject devTool;

	// Use this for initialization
	void Start () {
		devTool.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void DevToolPanel(){
		
		if (isEnabled == true) {
			devTool.SetActive (false);
			isEnabled = false;
			return;
		}
		if (isEnabled == false) {
			devTool.SetActive (true);
			isEnabled = true;
			return;
		}
	}
}
