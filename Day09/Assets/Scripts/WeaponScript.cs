using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

	public GameObject[] weaponTypes;
	
	private int chosenWeapon = 0;

	void Start () {
		chosenWeapon = 0;
		weaponTypes[1].SetActive(false);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			chosenWeapon = 0;
			weaponTypes[1].SetActive(false);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			chosenWeapon = 1;
			weaponTypes[0].SetActive(false);
		}
		weaponTypes[chosenWeapon].SetActive(true);
	}
}
