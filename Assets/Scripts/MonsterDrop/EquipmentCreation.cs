using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentCreation : MonoBehaviour {

	public GameObject swordTemp;
	public GameObject createdSword;
	public GameObject floorProgress;
	public GameObject currentMonster;
	public GameObject invManager;

	public int qualityRand;
	public int qualityBonus;


	public int itemLvlRand;
	public int statAllocation;
	public int randAllocation;


	// Use this for initialization
	void Start () {
		CreateSword ();
	}
	
	// Update is called once per frame
	void Update () {
		currentMonster = GameObject.Find ("MonsterTemplate(Clone)");
	}

	public void CreateSword(){
		createdSword = Instantiate (swordTemp);
		createdSword.AddComponent<SwordProperties> ();

		Quality ();

	}

	public void Quality(){
		SwordProperties script = createdSword.GetComponent<SwordProperties> ();

		qualityRand = Random.Range (0, 1000);
		if (qualityRand <= 539) {
			script.quality = 0;
			qualityBonus = 1;
		}
		if (qualityRand <= 789 && qualityRand > 539) {
			script.quality = 1;
			qualityBonus = 3;
		}
		if (qualityRand <= 939 && qualityRand > 789) {
			script.quality = 2;
			qualityBonus = 6;
		}
		if (qualityRand <= 989 && qualityRand > 939) {
			script.quality = 3;
			qualityBonus = 10;
		}
		if (qualityRand <= 999 && qualityRand > 989) {
			script.quality = 4;
			qualityBonus = 16;
		}
		if (qualityRand <= 1000 && qualityRand > 999) {
			script.quality = 5;
			qualityBonus = 25;
		}

		ItemLvl ();
	}
	public void ItemLvl(){
		SwordProperties script = createdSword.GetComponent<SwordProperties> ();

		itemLvlRand = Random.Range (0, 15);
		script.itemLvl = floorProgress.GetComponent<FloorProgression> ().floor * 2 + itemLvlRand;
		script.lvl = 1;
		script.maxLvl = 5;
		AllocateStats ();
	}

	public void AllocateStats(){
		SwordProperties script = createdSword.GetComponent<SwordProperties> ();


		statAllocation = script.itemLvl / 2 + qualityBonus;

		randAllocation = Random.Range (0, statAllocation);
		script.str = randAllocation;
		statAllocation -= randAllocation;

		randAllocation = Random.Range (0, statAllocation);
		script.dex = randAllocation;
		statAllocation -= randAllocation;

		randAllocation = Random.Range (0, statAllocation);
		script.agi = randAllocation;
		statAllocation -= randAllocation;

		randAllocation = Random.Range (0, statAllocation);
		script.inte = randAllocation;
		statAllocation -= randAllocation;



		SetXPCurve ();
	}

	public void SetXPCurve(){
		SwordProperties script = createdSword.GetComponent<SwordProperties> ();

		script.xp = 0;
		if (script.quality == 0) {
			script.xpToLvl = 20000;
		}
		if (script.quality == 1) {
			script.xpToLvl = 30000;
		}
		if (script.quality == 2) {
			script.xpToLvl = 50000;
		}
		if (script.quality == 3) {
			script.xpToLvl = 100000;
		}
		if (script.quality == 4) {
			script.xpToLvl = 150000;
		}
		if (script.quality == 5) {
			script.xpToLvl = 200000;
		}
		SetSellValue ();
	}
	public void SetSellValue(){
		SwordProperties script = createdSword.GetComponent<SwordProperties> ();

		script.sellValue = script.itemLvl + script.str + script.dex + script.agi + script.inte * script.quality;
		PlaceIntoInventory ();
	}
	public void PlaceIntoInventory(){
		invManager.GetComponent<InventoryManager> ().AddSlot ();
	
	}


}
