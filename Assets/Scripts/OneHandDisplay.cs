using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneHandDisplay : MonoBehaviour {

	public GameObject fillBar;
	public GameObject txt;
	public GameObject wpnManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		fillBar.GetComponent<Image> ().fillAmount = wpnManager.GetComponent<WeaponTypeManager> ().
			oneHandLvl / 1000;
		txt.GetComponent<Text>().text = "LVL: " + wpnManager.GetComponent<WeaponTypeManager>().
			oneHandLvl + " / 1000";
	}
}
