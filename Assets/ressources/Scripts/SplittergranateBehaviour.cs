using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplittergranateBehaviour : BulletController
{
	public int splitter_count = 10;
	GameObject[] gos;
	bool isCreated = false;


	// Use this for initialization


	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire2")) {
			fire ();
		}

	}

	void fire ()
	{
		//Clone of the bullet
		if (!isCreated) {
			float bla = 1f;
			float hop = 0f;
			//GameObject Clone;
			//Clone = (Instantiate(gameObject, transform.position, transform.rotation)) as GameObject;
			gos = new GameObject[splitter_count];
			for (int i = 0; i < gos.Length; i++) {
				bla = bla * (-1f);
				GameObject clone = (GameObject)Instantiate (gameObject, (transform.position + new Vector3((hop*bla),0f,0f)), transform.rotation);
				clone.GetComponent<Rigidbody2D> ().AddForce (new Vector2 ((10 * (bla*-1)), 0) * 150f);
				hop += 0.01f;
				gos [i] = clone;
			}


			//Instantiate(gameObject, transform.position, transform.rotation);
			//Instantiate(gameObject, transform.position, transform.rotation);
			//Instantiate(gameObject, transform.position, transform.rotation);


			GameObject.Destroy (gameObject);
			isCreated = true;



		}

	}








}
