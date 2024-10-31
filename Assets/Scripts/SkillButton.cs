using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {

	public GameObject loadingWheel;
	public GameObject loader;
	public GameObject foreGround;
	public GameObject[] skillLines;
	public GameObject[] nextSkills;
	public GameObject playerData;
	public GameObject wpnData;



	public bool skillsReached;
	public bool statsReached;
	public int strReq;
	public int dexReq;
	public int agiReq;
	public int intReq;
	public int skillLvlReq;

	public bool isConfirming;
	public bool isConfirmed;
	public GameObject skillManager;
	public int skillID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerData.GetComponent<PlayerStatData> ().str >= strReq &&
		    playerData.GetComponent<PlayerStatData> ().dex >= dexReq &&
		    playerData.GetComponent<PlayerStatData> ().agi >= agiReq &&
		    playerData.GetComponent<PlayerStatData> ().inte >= intReq &&
		    wpnData.GetComponent<WeaponTypeManager> ().oneHandLvl >= skillLvlReq) {
			statsReached = true; 
		}



		if (isConfirming == true && isConfirmed == false) {
			loader.GetComponent<Image> ().fillAmount += 0.01F;
		}
		if (isConfirming == false && isConfirmed == false) {
			loader.GetComponent<Image> ().fillAmount -= 0.01F;
		}
		if (isConfirming == true && loader.GetComponent<Image> ().fillAmount >= 1 && skillsReached == true) {
			isConfirmed = true;
			isConfirming = false;
			foreach (GameObject lines in skillLines) {
				lines.GetComponent<Animator> ().SetBool ("IsActive", true);
			}
			foreach (GameObject skills in nextSkills) {
				skills.GetComponent<SkillButton> ().skillsReached = true;
				OnConfirmed ();
			}
		}
		if (skillManager.GetComponent<SkillManager> ().skillActive [skillID] == 1) {
			isConfirmed = true;
			loader.GetComponent<Image> ().fillAmount = 1;
		}

	}

	public void Confirming(){
		if (statsReached == true)
		isConfirming = true;
		
	}
	public void denyConfirming(){
		isConfirming = false;
	}

	public void OnConfirmed(){
		skillManager.GetComponent<SkillManager> ().skillActive [skillID] = 1;
	}

	public void OnTap(){
		GameObject[] sceneWheels = GameObject.FindGameObjectsWithTag ("LoadingWheel");
		foreach (GameObject wheels in sceneWheels) {
			wheels.SetActive (false);
		}
		loadingWheel.SetActive (true);
		loadingWheel.GetComponent<Animator>().SetBool("IsRotating",true);
		skillManager.GetComponent<SkillTexts> ().oneHandTxt.text = skillManager.GetComponent<SkillTexts> ().oneHandTxts [skillID].ToString();
		skillManager.GetComponent<SkillTexts> ().oneHandReq.text = skillManager.GetComponent<SkillTexts> ().oneHandReqs [skillID].ToString();
	}
}
