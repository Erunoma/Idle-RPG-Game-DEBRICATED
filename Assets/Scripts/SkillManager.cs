using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

	public int[] skillActive;
	public bool[] skillActivated;
	public GameObject playerData;
	public GameObject weaponTypeManager;

	public GameObject[] abilities;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (skillActive [0] == 1 && skillActivated[0] == false) {
			weaponTypeManager.GetComponent<WeaponTypeManager> ().oneHandDamageMultiplier += 0.1F;
			skillActivated [0] = true;
		}
		if (skillActive [1] == 1 && skillActivated[1] == false) {
			weaponTypeManager.GetComponent<WeaponTypeManager> ().xpGainedMultiplier += 0.2F;
			skillActivated [1] = true;
		}
		if (skillActive [2] == 1 && skillActivated[2] == false) {
			abilities [1].SetActive (true);
			skillActivated [2] = true;
		}
		if (skillActive [3] == 1 && skillActivated[3] == false) {
			weaponTypeManager.GetComponent<WeaponTypeManager> ().weaponDamageMultiplier += 0.05F;
			skillActivated [3] = true;
		}
		if (skillActive [4] == 1 && skillActivated[4] == false) {
			abilities [0].SetActive (true);
			skillActivated [4] = true;
		}
		if (skillActive [5] == 1 && skillActivated[5] == false) {
			playerData.GetComponent<PlayerStatData> ().dpsFromBoss += Mathf.RoundToInt( 
				playerData.GetComponent<PlayerStatData> ().dpsFromStats +
			weaponTypeManager.GetComponent<WeaponTypeManager> ().weaponDps
				* 1.1F / 10);
			skillActivated [5] = true;
		}
		
	}


}
