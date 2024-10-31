using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MonsterList : MonoBehaviour {

	public GameObject[] monsters;	
	public GameObject[] bosses;
	public GameObject currentMonster;
	public int monstersCreated;
	public int random;
	public Text lvlTxt;
	public Text monsterName;

	public bool bossActive;
	public bool isFarming;

	public GameObject playerData;
	public GameObject floorProgress;

	public GameObject enterBossButton;
	public GameObject bossTimer;

	public GameObject dropManager;



	void Start(){
		
	}


	void Update(){
		if (bossActive == true) {
			bossTimer.SetActive (true);
		}
		if (bossActive == false) {
			bossTimer.SetActive (false);
		}
		if (isFarming == true) {
			enterBossButton.SetActive (true);
		}
		if (isFarming == false) {
			enterBossButton.SetActive (false);
		}
	}

	public void InsertMonster(){
		if (floorProgress.GetComponent<FloorProgression> ().monstersSlain >= floorProgress.GetComponent<FloorProgression> ().monstersOnFloor) {
			InsertCreatedBoss ();
			return;
		}
		random = Random.Range (0, monsters.Length);
		currentMonster = monsters[random];
		currentMonster.SetActive (true);
		currentMonster.GetComponent<MonsterData> ().isActive = true;
		currentMonster.GetComponent<MonsterData> ().barStartValue = 1;
		lvlTxt.text = "LVL: "+ currentMonster.GetComponent<MonsterData> ().lvl.ToString ();
		monsterName.text = currentMonster.GetComponent<MonsterData> ().monsterName.ToString ();

	}

	public void StartMonsterCreation(){
		gameObject.GetComponent<MonsterGenerator> ().CreateObject ();
	}
	public void InsertCreatedMonster(){
		currentMonster = gameObject.GetComponent<MonsterGenerator> ().newObject;
		currentMonster.SetActive (true);
		currentMonster.GetComponent<MonsterData> ().isActive = true;
		currentMonster.GetComponent<MonsterData> ().barStartValue = 1;
		lvlTxt.text = "LVL: "+ currentMonster.GetComponent<MonsterData> ().lvl.ToString ();
		monsterName.text = currentMonster.GetComponent<MonsterData> ().monsterName.ToString ();
	}

	public void StartBossCreation(){
		gameObject.GetComponent<BossGenerator> ().CreateObject ();
	}
	public void InsertCreatedBoss(){
		currentMonster = gameObject.GetComponent<BossGenerator> ().newObject;
		currentMonster.SetActive (true);
		currentMonster.GetComponent<BossData> ().isActive = true;
		currentMonster.GetComponent<BossData> ().barStartValue = 1;
		lvlTxt.text = "LVL: "+ currentMonster.GetComponent<BossData> ().lvl.ToString ();
		monsterName.text = "Mighty " + currentMonster.GetComponent<BossData> ().monsterName.ToString ();
		bossActive = true;
	}

	public void InsertBoss(){
		currentMonster = bosses [floorProgress.GetComponent<FloorProgression> ().floor - 1];
		currentMonster.SetActive (true);
		currentMonster.GetComponent<BossData> ().isActive = true;
		currentMonster.GetComponent<BossData> ().barStartValue = 1;
		lvlTxt.text = "LVL: "+ currentMonster.GetComponent<BossData> ().lvl.ToString ();
		monsterName.text = currentMonster.GetComponent<BossData> ().monsterName.ToString ();
		bossActive = true;
	}

	public void OnMonsterDefeated(){
		CalcXP ();

		if (isFarming == true) {
			playerData.GetComponent<PlayerXPData>().money += currentMonster.GetComponent<MonsterData> ().money;
			dropManager.GetComponent<DropRates> ().CheckDrop ();
			currentMonster.GetComponent<MonsterData> ().isActive = false;
			currentMonster.GetComponent<MonsterData> ().currentHp = currentMonster.GetComponent<MonsterData> ().hp;
			currentMonster.SetActive (false);
			Destroy(currentMonster);
			playerData.GetComponent<PlayerXPData> ().CheckForXP ();

			//InsertMonster ();
			StartMonsterCreation();
			return;
		}
		if (isFarming == false) {
			playerData.GetComponent<PlayerXPData>().money += currentMonster.GetComponent<MonsterData> ().money;
			dropManager.GetComponent<DropRates> ().CheckDrop ();
			dropManager.GetComponent<DropAnim> ().OnMonsterKilled ();
			floorProgress.GetComponent<FloorProgression> ().monstersSlain+=1;
			currentMonster.GetComponent<MonsterData> ().isActive = false;
			currentMonster.GetComponent<MonsterData> ().currentHp = currentMonster.GetComponent<MonsterData> ().hp;
			currentMonster.SetActive (false);
			Destroy(currentMonster);
			playerData.GetComponent<PlayerXPData> ().CheckForXP ();

			if (floorProgress.GetComponent<FloorProgression> ().monstersSlain >= floorProgress.GetComponent<FloorProgression> ().monstersOnFloor) {
				StartBossCreation ();
				return;

			}
			//InsertMonster ();
			StartMonsterCreation();
		}

	}

	public void OnBossDefeated(){
		CalcXP ();
		playerData.GetComponent<PlayerXPData>().money += currentMonster.GetComponent<BossData> ().money;
		bossActive = false;
		floorProgress.GetComponent<FloorProgression> ().monstersSlain = 0;
		floorProgress.GetComponent<FloorProgression> ().floor++;
		//floorProgress.GetComponent<FloorProgression> ().monstersOnFloor++;
		currentMonster.GetComponent<BossData> ().isActive = false;
		currentMonster.GetComponent<BossData> ().currentHp = currentMonster.GetComponent<BossData> ().hp;
		currentMonster.SetActive (false);
		playerData.GetComponent<PlayerXPData> ().CheckForXP ();
		StartMonsterCreation ();
	}
	public void OnBossFailed(){
		bossActive = false;
		currentMonster.GetComponent<BossData> ().isActive = false;
		currentMonster.GetComponent<BossData> ().currentHp = currentMonster.GetComponent<BossData> ().hp;
		currentMonster.SetActive (false);
		isFarming = true;
		StartMonsterCreation ();
	}

	public void OnReEnterBoss(){
		Destroy(currentMonster);
		isFarming = false;
		StartBossCreation ();
	}

	public void OnLeaveBoss(){
		Destroy(currentMonster);
		isFarming = true;
		StartMonsterCreation ();
	}

	public void CalcXP()
	{
		if (bossActive == false) {
			if (playerData.GetComponent<PlayerXPData> ().lvl > currentMonster.GetComponent<MonsterData> ().lvl) {
				if (playerData.GetComponent<PlayerXPData> ().lvl > currentMonster.GetComponent<MonsterData> ().lvl + 6) {
					playerData.GetComponent<PlayerXPData> ().xp += currentMonster.GetComponent<MonsterData> ().xpForDefeat / 2;
					return;
				}
				playerData.GetComponent<PlayerXPData> ().xp += currentMonster.GetComponent<MonsterData> ().xpForDefeat;
			}

			if (playerData.GetComponent<PlayerXPData> ().lvl <= currentMonster.GetComponent<MonsterData> ().lvl) {
				playerData.GetComponent<PlayerXPData> ().xp += currentMonster.GetComponent<MonsterData> ().xpForDefeat; 
			}
		}


		if (bossActive == true) {
			if (playerData.GetComponent<PlayerXPData> ().lvl > currentMonster.GetComponent<BossData> ().lvl) {
				if (playerData.GetComponent<PlayerXPData> ().lvl > currentMonster.GetComponent<BossData> ().lvl + 3) {
					playerData.GetComponent<PlayerXPData> ().xp += currentMonster.GetComponent<BossData> ().xpForDefeat / 4;
					return;
				}
				playerData.GetComponent<PlayerXPData> ().xp += currentMonster.GetComponent<BossData> ().xpForDefeat / 2;
			}

			if (playerData.GetComponent<PlayerXPData> ().lvl <= currentMonster.GetComponent<BossData> ().lvl) {
				playerData.GetComponent<PlayerXPData> ().xp += currentMonster.GetComponent<BossData> ().xpForDefeat; 
			}
		}
	}


}
