using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{

	public float healthPoints = 100f;

	private static GameObject manager;
	private PlayerManager playerManager;

	//GUI
	public Image healthbar;
	public float lifepoints;
	public Text lifepointsText;
	public Text playerName;
    public Text playerDeadText;

	private float fillAmount;

	// Use this for initialization
	void Start ()
	{
		playerName.text = this.gameObject.GetComponent<PlayerMovement>().playerID.ToString() + "0";

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void SetHealth (float amount)
	{
		healthPoints -= amount;
		if (healthPoints > 0) {
			healthbar.fillAmount = healthPoints / 100f;
			//this.healthbar_P1.fillAmount = TakeDamage(lifepoints);
			lifepointsText.text = healthPoints.ToString () + "%";
		}
		if (healthPoints <= 0) {
			healthbar.fillAmount = 0f;
			lifepointsText.text = "Destroyed";
            StartCoroutine(Death());
            PlayerDeath ();
		}
	}

	void PlayerDeath(){
		print ("player died" + this.gameObject);
		this.gameObject.GetComponent<PlayerMovement> ().is_dead = true;
		Destroy (this.gameObject.GetComponent<PolygonCollider2D> ());

		manager = GameObject.FindGameObjectWithTag ("Manager");
		playerManager = manager.GetComponent<PlayerManager> ();
//		playerManager.PlayerDied (); 


        

    }


    IEnumerator Death(){
        playerDeadText.enabled = true;
        yield return new WaitForSeconds (2);
        playerDeadText.enabled = false;
        Destroy (this.gameObject.GetComponent<Rigidbody2D> ());

	}

}
