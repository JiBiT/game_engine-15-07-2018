using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBehaviour : BulletController
{
	public int splitter_count = 4;
	public GameObject[] gos;
	public bool isCreated = false;
	GameObject clone;
    private static GameObject manager;

    // Use this for initialization
    void Start ()
	{
		if (isCreated == false) {
			StartCoroutine (EndRound ());



		}
        manager = GameObject.FindGameObjectWithTag("Manager");
        audioManager = manager.GetComponent<AudioManager>();
        audioManager.PlayTankShot();
    }


	IEnumerator EndRound(){
//		yield return new WaitForEndOfFrame ();
		float bla = 1f;
		float hop = 0f;
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2(transform.position.x, transform.position.y);
		gos = new GameObject[splitter_count];
		for (int i = 0; i < gos.Length; i++) {
			yield return new WaitForEndOfFrame ();
			bla = bla * (-1f);
			GameObject clone = (GameObject)Instantiate (gameObject, (transform.position), transform.rotation);

			clone.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition) * 100f);
			clone.GetComponent<ShotgunBehaviour> ().isCreated = true;
			hop += 0.01f;
			gos [i] = clone;
		}

	}


}
