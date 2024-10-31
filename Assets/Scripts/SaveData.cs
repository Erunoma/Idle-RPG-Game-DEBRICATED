using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LoadGame();
		InvokeRepeating("SaveGame", 2.0f, 30.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SaveGame() {
		PlayerPrefs.SetInt ("Level", SceneManager.GetActiveScene ().buildIndex);
		PlayerPrefs.Save ();
		print ("Game saved!");
	}

	public void LoadGame() {
		SceneManager.LoadScene ( PlayerPrefs.GetInt("Level") );
		print ("Game loaded!");
	}
}
