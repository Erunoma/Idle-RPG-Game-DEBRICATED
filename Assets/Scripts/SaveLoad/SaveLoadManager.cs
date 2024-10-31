using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public static class SaveLoadManager {

	public static void SavePlayer(PlayerStatData playerData, PlayerXPData playerXP, FloorProgression floorProgress,
		SkillManager skills, WeaponTypeManager wpnManager, StatAllocation statAllocation, SPData spData){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/player.sav", FileMode.Create);

		PlayerData data = new PlayerData (playerData, playerXP, floorProgress, skills, wpnManager, statAllocation, spData);

		bf.Serialize (stream, data);
		stream.Close();
	}


	public static int[] LoadPlayer(){
		if (File.Exists (Application.persistentDataPath + "/player.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/player.sav", FileMode.Open);

			PlayerData data = bf.Deserialize (stream) as PlayerData;

			stream.Close ();
			return  data.saveInts;
		} else {
			Debug.Log ("File Does Not Exist.");
			return new int[25];

		}


	}
		
}

[Serializable]
public class PlayerData{

	public int[] saveInts;
	public float[] saveFloats;


	public PlayerData(PlayerStatData playerData, PlayerXPData playerXP, FloorProgression floorProgress, 
		SkillManager skills, WeaponTypeManager wpnManager, StatAllocation statAllocation,
		SPData spData){
		saveInts = new int[24];
		saveFloats = new float[1];
		saveInts[0] = playerData.str;
		saveInts[1] = playerData.dex;
		saveInts[2] = playerData.agi;
		saveInts[3] = playerData.inte;
		saveInts[4] = playerXP.lvl;
		saveInts[5] = Mathf.RoundToInt (playerXP.xpToLvl);
		saveInts[6] = floorProgress.floor;
		saveInts[7] = floorProgress.monstersOnFloor;
		saveInts[8] = floorProgress.monstersSlain;
		saveInts[9] = skills.skillActive[0];
		saveInts[10] = skills.skillActive[1];
		saveInts[11] = skills.skillActive[2];
		saveInts[12] = skills.skillActive[3];
		saveInts[13] = skills.skillActive[4];
		saveInts[14] = skills.skillActive[5];
		saveInts[15] = skills.skillActive[6];
		saveInts[16] = skills.skillActive[7];
		saveInts [17] = Mathf.RoundToInt (wpnManager.oneHandLvl);
		saveInts [18] = Mathf.RoundToInt (wpnManager.oneHandXpReq);
		saveInts [19] = Mathf.RoundToInt (wpnManager.oneHandXp);
		saveInts [20] = Mathf.RoundToInt(playerXP.xp);
		saveInts [21] = statAllocation.primaryStatPointsAvailable;
		saveInts [22] = Mathf.RoundToInt(spData.spValue);
		saveInts [23] = Mathf.RoundToInt(spData.spMax);
		saveInts [24] = playerXP.money;




	}
}