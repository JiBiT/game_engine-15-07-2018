using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncegranateBehaviour : BulletController
{
	private float bounce_counter = 0;


    // Use this for initialization


    private static GameObject manager;


    public override void OnCollisionEnter2D (Collision2D coll)
	{
//		base.OnCollisionEnter2D (coll);
//		if (overriden) {
		Debug.Log ("override enter collision");
		//		
		if (coll.collider.tag == "Ground") {


			bounce_counter += 1;

			if (bounce_counter >= 3) {
				groundController.DestroyGround (destructionCircle);
				Explode();
                manager = GameObject.FindGameObjectWithTag("Manager");
                audioManager = manager.GetComponent<AudioManager>();
                audioManager.PlayTankShot();
            }


		} else if (coll.collider.tag == "Tank" || coll.collider.tag == "Hitable") {
			groundController.DestroyGround (destructionCircle);
			Explode ();
		}
//		}

//		else if (coll.collider.tag == "Tank" || coll.collider.tag == "Hitable")
//		{
//			Destroy(gameObject);
//			print("hit Tank");
//			lifepoints -= 20;
//			fillAmount -= 20/100;
//			gotHit = true;
//		}
	}










}
