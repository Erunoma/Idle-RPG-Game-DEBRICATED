using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPData : MonoBehaviour {

	public float spValue;
	public float spMax;

	public Image spBar;
	public Text spTxt;

	public float barStartValue;
	public float endValue;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("IncreaseSP", 1.0F, 5.0F);

	}
	
	// Update is called once per frame
	void Update () {
		spTxt.text = spValue + " / " + spMax;
		endValue = spValue / spMax;
		if (barStartValue < endValue) {
			barStartValue += 0.01F;
			spBar.fillAmount = barStartValue;
		}
		if (barStartValue > endValue) {
			barStartValue -= 0.01F;
			spBar.fillAmount = barStartValue;
		}
		if (spValue > spMax) {
			spValue = spMax;
		}
	}

	public void IncreaseSP(){
		if (spValue <= spMax) {
			spValue += 5;
		}
	}
}
