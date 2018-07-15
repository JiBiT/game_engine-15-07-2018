using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{

	public GameObject bulletPrefab;
	//public int bulletPrefab = 5;
	//    public Bullet whichBullet;

	private static GameObject manager;
	private PlayerManager playerManager;

	public float fireRate = 0;
	public float damage = 10;
	public LayerMask whatToHit;
	public bool hasFired = false;
	private float cannonPower = 50f;
	private float timeToFire = 3;
	Transform firePoint;
	Transform crossPos;
	public GameObject crosshair;
	public GameObject powerbar;

	Vector3 barTrans;
	Vector3 originBarTrans;



	// Use this for initialization
	void Awake ()
	{
		Debug.Log ("Es ist folgende Waffe ausgesucht: " + bulletPrefab);
		firePoint = transform.Find ("fire_position");
		crossPos = transform.Find ("crosshair");
		if (firePoint == null) {
			Debug.LogError ("No Firepoint? What?!");
		}
		if (crossPos == null) {
			Debug.LogError ("No Crosshair? What?!");
		}
		crosshair.SetActive(false);
		barTrans = powerbar.transform.localScale;
		originBarTrans = barTrans;
		barTrans.x = (originBarTrans.x * (cannonPower / 100f));
		powerbar.transform.localScale = barTrans;
	}
	
	// Update is called once per frame
	void Update ()
	{
		crosshair.SetActive(false);
		if (GetComponentInParent<PlayerMovement> ().is_movable && hasFired == false) {
			crosshair.SetActive(true);
			if (fireRate == 0) {
				if (Input.GetButtonDown ("Fire1")) {
					Shoot ();
				}
			} else {
				if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
					timeToFire = Time.time + 1 / fireRate;
					Shoot ();
				}
			}
			if (Input.GetKey (KeyCode.W)) {
				IncreasePower ();
			}
			if (Input.GetKey (KeyCode.S)) {
				DecreasePower ();
			}





		}
		if (this.hasFired) {
			
		}
		
	}

	public void IncreasePower(){
//		print ("E pressed");
		if (cannonPower < 100f) {
			cannonPower += 1f;
			barTrans.x = (originBarTrans.x * (cannonPower / 100f));
			powerbar.transform.localScale = barTrans;

		}

//		print ("actual cannonpower : " +cannonPower);
	}

	public void DecreasePower(){
//		print ("Q pressed");
		if (cannonPower > 16) {
			cannonPower -= 1f;
			barTrans.x = (originBarTrans.x * (cannonPower / 100f));
			powerbar.transform.localScale = barTrans;

		}

//		print ("actual cannonpower : " +cannonPower);
	}

	public void SelectWeapon(GameObject bullet){
		this.bulletPrefab = bullet;
		print ("Bullet wurde gewechselt zu: " + bulletPrefab);
//		Event.current.Use ();
	}


	void Shoot ()
	{
		if (EventSystem.current.IsPointerOverGameObject ()) {
			
		} else {
			//Initiate the Bullet
			Bullet bullet = new Bullet (bulletPrefab, cannonPower, firePoint, crossPos);
			//		bullet.shoot ();
			//		this.hasFired = true;
			GetComponentInParent<PlayerMovement> ().is_movable = false;
			StartCoroutine (EndRound ());
		}



		//if (hit.collider != null)
		//{
		//    Debug.DrawLine(firePointPosition, hit.point, Color.red);
		//    Debug.Log("we hit" + hit.collider.name + "and did" + damage + "Damage");
		//}
	}

	IEnumerator EndRound(){
		yield return new WaitForSeconds (3);
		manager = GameObject.FindGameObjectWithTag ("Manager");
		playerManager = manager.GetComponent<PlayerManager> ();
		playerManager.NextPlayerMove (); 

	}
}
