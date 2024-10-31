using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour {

	public GameObject charPage;
	public GameObject charScroll;

	public GameObject weaponTypePage;
	public GameObject wpnTypeScroll;

	public GameObject skillsPage;
	public GameObject skillsScroll;

	public GameObject inventoryPage;
	public GameObject inventoryScroll;


	public void OpenCharPage(){
		charPage.SetActive (true);
		charPage.GetComponent<Animator> ().SetBool ("Close", false);
		charPage.GetComponent<Animator> ().SetBool ("Open",true);
		StartCoroutine (CharContentActive ());
	}
	public void CloseCharPage(){
		charPage.GetComponent<Animator> ().SetBool ("Open",false);
		charPage.GetComponent<Animator> ().SetBool ("Close", true);
		StartCoroutine (DisableCharObject ());
	}

	IEnumerator CharContentActive(){
		yield return new WaitForSeconds (0.50F);
		charScroll.SetActive (true);
	}
	IEnumerator DisableCharObject(){
		yield return new WaitForSeconds (0.30F);
		charPage.SetActive (false);
		charScroll.SetActive (false);
	}



	public void OpenWpnPage(){
		weaponTypePage.SetActive (true);
		weaponTypePage.GetComponent<Animator> ().SetBool ("Close", false);
		weaponTypePage.GetComponent<Animator> ().SetBool ("Open",true);
		StartCoroutine (WpnTypeContentActive ());
	}
	public void CloseWpnPage(){
		weaponTypePage.GetComponent<Animator> ().SetBool ("Open",false);
		weaponTypePage.GetComponent<Animator> ().SetBool ("Close", true);
		StartCoroutine (DisableWpnTypeObject ());
	}

	IEnumerator WpnTypeContentActive(){
		yield return new WaitForSeconds (0.50F);
		wpnTypeScroll.SetActive (true);
	}
	IEnumerator DisableWpnTypeObject(){
		yield return new WaitForSeconds (0.30F);
		weaponTypePage.SetActive (false);
		wpnTypeScroll.SetActive (false);
	}



	public void OpenSkillsPage(){
		skillsPage.SetActive (true);
		skillsPage.GetComponent<Animator> ().SetBool ("Close", false);
		skillsPage.GetComponent<Animator> ().SetBool ("Open",true);
		StartCoroutine (SkillsContentActive ());
	}
	public void CloseSkillsPage(){
		skillsPage.GetComponent<Animator> ().SetBool ("Open",false);
		skillsPage.GetComponent<Animator> ().SetBool ("Close", true);

		StartCoroutine (DisableSkillsObject ());
	}

	public void OpenInventoryPage(){
		inventoryPage.SetActive (true);
		inventoryPage.GetComponent<Animator> ().SetBool ("Close", false);
		inventoryPage.GetComponent<Animator> ().SetBool ("Open",true);
		StartCoroutine (InventoryActive ());
	}
	public void CloseInventoryPage(){
		inventoryPage.GetComponent<Animator> ().SetBool ("Open",false);
		inventoryPage.GetComponent<Animator> ().SetBool ("Close", true);

		StartCoroutine (DisableInventoryObject ());
	}

	IEnumerator SkillsContentActive(){
		yield return new WaitForSeconds (0.50F);
		skillsScroll.SetActive (true);
	}
	IEnumerator DisableSkillsObject(){
		yield return new WaitForSeconds (0.30F);
		GameObject[] sceneWheels = GameObject.FindGameObjectsWithTag ("LoadingWheel");
		foreach (GameObject wheels in sceneWheels) {
			wheels.SetActive (false);
		}
		skillsPage.SetActive (false);
		skillsScroll.SetActive (false);

	}

	IEnumerator InventoryActive(){
		yield return new WaitForSeconds (0.50F);
		inventoryScroll.SetActive (true);
	}
	IEnumerator DisableInventoryObject(){
		yield return new WaitForSeconds (0.30F);
		inventoryPage.SetActive (false);
		inventoryScroll.SetActive (false);

	}
		
}
