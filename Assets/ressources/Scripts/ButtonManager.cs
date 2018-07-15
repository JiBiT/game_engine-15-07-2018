using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

	public GameObject[] tanks;

	public Button granate;
	public Button splittergranate;
	public Button shotgun;
	public Button bouncegranate;
	public Button healthbar;

	public GameObject granatePrefab;
	public GameObject splittergranatePrefab;
	public GameObject shotgunPrefab;
	public GameObject bouncegranatePrefab;
	// Use this for initialization
	void Start ()
	{
		granate = granate.GetComponent<Button> ();
		splittergranate = splittergranate.GetComponent<Button> ();
		shotgun = shotgun.GetComponent<Button> ();
		bouncegranate = bouncegranate.GetComponent<Button> ();

		granate.onClick.AddListener (delegate {
			TaskOnWeaponBtn (granatePrefab);
		});
		splittergranate.onClick.AddListener (delegate {
			TaskOnWeaponBtn (splittergranatePrefab);
		});
		shotgun.onClick.AddListener (delegate {
			TaskOnWeaponBtn (shotgunPrefab);
		});
		bouncegranate.onClick.AddListener (delegate {
			TaskOnWeaponBtn (bouncegranatePrefab);
		});
	}

	void TaskOnWeaponBtn (GameObject check)
	{
		tanks = GameObject.FindGameObjectsWithTag ("Tank");
		foreach (GameObject tank in tanks) {
			PlayerMovement playerScript = tank.GetComponent<PlayerMovement> ();
			if (playerScript.is_movable == true) {
				Weapon weaponScript = tank.GetComponentInChildren<Weapon> ();
				weaponScript.SelectWeapon (check);
				SetActiveButton (check);
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (granatePrefab && !splittergranatePrefab && !shotgunPrefab)
//        {
//            granate.GetComponent<Image>().color = Color.red;
//            splittergranate.GetComponent<Image>().color = Color.white;
//            shotgun.GetComponent<Image>().color = Color.white;
//        }
//        if (!granatePrefab && splittergranatePrefab && !shotgunPrefab)
//        {
//            granate.GetComponent<Image>().color = Color.white;
//            splittergranate.GetComponent<Image>().color = Color.red;
//            shotgun.GetComponent<Image>().color = Color.white;
//        }
//        if (!granatePrefab && !splittergranatePrefab && shotgunPrefab)
//        {
//            granate.GetComponent<Image>().color = Color.white;
//            splittergranate.GetComponent<Image>().color = Color.white;
//            shotgun.GetComponent<Image>().color = Color.red;
//        }
	}

	public void SetActiveButton (GameObject prefab)
	{
		
		if (prefab == granatePrefab) {
			granate.GetComponent<Image> ().color = Color.red;
			splittergranate.GetComponent<Image> ().color = Color.white;
			shotgun.GetComponent<Image> ().color = Color.white;
			bouncegranate.GetComponent<Image> ().color = Color.white;
		} else if (prefab == splittergranatePrefab) {
			granate.GetComponent<Image> ().color = Color.white;
			splittergranate.GetComponent<Image> ().color = Color.red;
			shotgun.GetComponent<Image> ().color = Color.white;
			bouncegranate.GetComponent<Image> ().color = Color.white;
		} else if (prefab == shotgunPrefab) {
			granate.GetComponent<Image> ().color = Color.white;
			splittergranate.GetComponent<Image> ().color = Color.white;
			shotgun.GetComponent<Image> ().color = Color.red;
			bouncegranate.GetComponent<Image> ().color = Color.white;
		} else if (prefab == bouncegranatePrefab) {
			granate.GetComponent<Image> ().color = Color.white;
			splittergranate.GetComponent<Image> ().color = Color.white;
			shotgun.GetComponent<Image> ().color = Color.white;
			bouncegranate.GetComponent<Image> ().color = Color.red;
		}




	}
}
