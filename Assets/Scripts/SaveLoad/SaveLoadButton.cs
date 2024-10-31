using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadButton : MonoBehaviour {

	public GameObject floorProgression;
	public GameObject playerData;
	public GameObject wpnLvlManager;
	public GameObject statAllocation;
	public GameObject skillManager;
	public GameObject playerXPManager;
	public GameObject monsterList;


	public void Save(){
		SaveLoadManager.SavePlayer (playerData.GetComponent<PlayerStatData>(), playerXPManager.GetComponent<PlayerXPData>(), 
			floorProgression.GetComponent<FloorProgression>(), 
			skillManager.GetComponent<SkillManager>(),
			wpnLvlManager.GetComponent<WeaponTypeManager>(),
			statAllocation.GetComponent<StatAllocation>(),
			playerData.GetComponent<SPData>());
	}

	public void Load(){
		int[] loadedInts = SaveLoadManager.LoadPlayer ();
		FloorProgression flpr = floorProgression.GetComponent<FloorProgression> ();
		PlayerStatData pldata = playerData.GetComponent<PlayerStatData> ();
		WeaponTypeManager wpnMan = wpnLvlManager.GetComponent<WeaponTypeManager> ();
		StatAllocation stal = statAllocation.GetComponent<StatAllocation> ();
		SkillManager skMan = skillManager.GetComponent<SkillManager> ();
		PlayerXPData xpData = playerXPManager.GetComponent<PlayerXPData> ();

		pldata.str = loadedInts [0];
		pldata.dex = loadedInts [1];
		pldata.agi = loadedInts [2];
		pldata.inte = loadedInts [3];
		xpData.lvl = loadedInts [4];
		xpData.xpToLvl = loadedInts [5];
		flpr.floor = loadedInts [6];
		flpr.monstersOnFloor = loadedInts [7];
		flpr.monstersSlain = loadedInts [8];
		skMan.skillActive [0] = loadedInts [9];
		skMan.skillActive [1] = loadedInts [10];
		skMan.skillActive [2] = loadedInts [11];
		skMan.skillActive [3] = loadedInts [12];
		skMan.skillActive [4] = loadedInts [13];
		skMan.skillActive [5] = loadedInts [14];
		skMan.skillActive [6] = loadedInts [15];
		skMan.skillActive [7] = loadedInts [16];
		wpnMan.oneHandLvl = loadedInts [17];
		wpnMan.oneHandXpReq = loadedInts [18];
		wpnMan.oneHandXp = loadedInts [19];
		xpData.xp = loadedInts [20];
		stal.primaryStatPointsAvailable = loadedInts [21];

		Destroy (monsterList.GetComponent<MonsterList> ().currentMonster);
		monsterList.GetComponent<MonsterList> ().StartMonsterCreation ();
	}
}
