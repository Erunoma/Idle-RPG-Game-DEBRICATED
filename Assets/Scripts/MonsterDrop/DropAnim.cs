using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropAnim : MonoBehaviour {


	public GameObject xpDropTemp;
	public GameObject xpDrop;
	public GameObject moneyDropTemp;
	public GameObject moneyDrop;
	public List<GameObject> equipmentDrop;


	public Vector2 spawnPoint;

	public GameObject monsterData;
	public GameObject monsterList;
	public float force;

	public GameObject parentCanvas;

	public float dropDelay;
	public float deleteDelay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		monsterData = GameObject.Find ("MonsterTemplate(Clone)");
	}

	public void OnMonsterKilled(){
		StartCoroutine (XPDrops ());
	}

	IEnumerator XPDrops(){
		yield return new WaitForSeconds (dropDelay);
		xpDrop = Instantiate (xpDropTemp, spawnPoint, Quaternion.identity);
		xpDrop.transform.SetParent (parentCanvas.transform, false);

		if (monsterList.GetComponent<MonsterList> ().bossActive == false) {
			xpDrop.GetComponent<Text> ().text = "XP: " + monsterData.GetComponent<MonsterData> ().xpForDefeat;
			xpDrop.GetComponent<Animator> ().SetBool ("IsActive", true);
			StartCoroutine (MoneyDrops ());
		}
		if (monsterList.GetComponent<MonsterList> ().bossActive == true) {
			xpDrop.GetComponent<Text> ().text = "XP: " + monsterData.GetComponent<BossData> ().xpForDefeat;
			xpDrop.GetComponent<Animator> ().SetBool ("IsActive", true);
			StartCoroutine (MoneyDrops ());
		}
	}

	IEnumerator MoneyDrops(){
		yield return new WaitForSeconds (dropDelay);
		moneyDrop = Instantiate (moneyDropTemp, spawnPoint, Quaternion.identity);
		moneyDrop.transform.SetParent (parentCanvas.transform, false);


		if (monsterList.GetComponent<MonsterList> ().bossActive == false) {
			moneyDrop.GetComponent<Text> ().text = "         " + monsterData.GetComponent<MonsterData> ().money.ToString ();
			moneyDrop.GetComponent<Animator> ().SetBool ("IsActive", true);
		}
		if (monsterList.GetComponent<MonsterList> ().bossActive == true) {
			moneyDrop.GetComponent<Text> ().text = "         " + monsterData.GetComponent<BossData> ().money.ToString ();
			moneyDrop.GetComponent<Animator> ().SetBool ("IsActive", true);
		}

		StartCoroutine (GearDrops ());
	}

	IEnumerator GearDrops(){
		yield return new WaitForSeconds (dropDelay);

		StartCoroutine(DeleteDrops ());

	}

	IEnumerator DeleteDrops(){
		yield return new WaitForSeconds (deleteDelay);
		Destroy (moneyDrop);
		Destroy (xpDrop);
	}
}
