using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTimer : MonoBehaviour {

	public Text timerTxt;
	public float timeLeft;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<MonsterList> ().bossActive == true) {
			timeLeft -= Time.deltaTime;
			timerTxt.text = Mathf.RoundToInt (timeLeft).ToString();
			if (timeLeft < 0) {
				timeLeft = 60;
				gameObject.GetComponent<MonsterList> ().OnBossFailed ();

			}
		}
	}
}
