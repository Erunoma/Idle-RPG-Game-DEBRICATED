using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDPS : MonoBehaviour {

	public Text dpsTxt;
	public GameObject weapon;

	// Use this for initialization
	void Start () {
		weapon = this.gameObject.transform.GetChild (2).gameObject;

	}
	
	// Update is called once per frame
	void Update () {
		dpsTxt.text = "DPS: " + weapon.GetComponent<SwordProperties> ().dps.ToString ();
	}
}
