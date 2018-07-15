using Assets.ressources.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class BulletController : MonoBehaviour
{

	public CircleCollider2D destructionCircle;
	public Vector2 mousePosition;
	public Vector2 firePointPosition;
	public static GroundController groundController;

	//	public ParticleSystem boom;
	//	public GameObject explosion;
	private static GameObject manager;
	public AudioManager audioManager;
 
	public ParticleSystem smoke;
	public ParticleSystem explode;

	private Player_Health p_health;





	private void Awake ()
	{
//		boom.Play ();


	}


	// Use this for initialization
	public virtual void Start ()
	{
		explode.Stop ();
		MakeSound ();
		//		gameObject.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition) * 100);

	}

	// Update is called once per frame
	public void Update ()
	{

	}

	void MakeSound ()
	{
		manager = GameObject.FindGameObjectWithTag ("Manager");
		audioManager = manager.GetComponent<AudioManager> ();
		audioManager.PlayTankShot ();
	}

	public virtual void OnCollisionEnter2D (Collision2D coll)
	{

		if (coll.collider.tag == "Ground") {

			groundController.DestroyGround (destructionCircle);
			Explode ();
//			Destroy (this.gameObject);
//			Instantiate (boom);
//			boom.Play ();


		} else if (coll.collider.tag == "Tank" || coll.collider.tag == "Hitable") {
//			Destroy (gameObject);
			Explode ();
//			Instantiate (boom);
//			boom.Play ();
                
			//health.TakeDamage(20);
			if (coll.gameObject.GetComponent<Player_Health> () != null) {
				//					print ("folgender Tank wurde getroffen: " + coll.gameObject);
				p_health = coll.gameObject.GetComponent<Player_Health> ();
				p_health.SetHealth (10f);
			}
                
		}
            

	}





	public void Explode ()
	{
		explode.Play ();
		smoke.Stop ();

		Destroy (this.gameObject.GetComponent<SpriteRenderer>());
		Destroy (this.gameObject.GetComponent<Rigidbody2D>());
		Destroy (this.gameObject.GetComponent<CircleCollider2D>());
		Destroy (this.gameObject.GetComponent<BulletController>());
		Destroy (gameObject, smoke.duration);


//		boom.Play ();
//		Instantiate (explosion, transform.position, explosion.transform.rotation);

	}

	public void SetPosition (Vector2 mouse, Vector2 fire)
	{
		mousePosition = mouse;
		firePointPosition = fire;

	}

	void OnBecameInvisible ()
	{
//		Destroy (gameObject);
	}
}
