using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Assets.ressources.Scripts;

public class PlayerManager : MonoBehaviour
{
	public int currentPlayer = 1;
	public int activePlayers;
	public GameObject[] tanks;
	public PlayerMovement playerScript;
	public Weapon weaponScript;
	private static GameObject manager;
	public ButtonManager buttonManager;

	[SerializeField]
	public Health health;
	[SerializeField]
	public Image healthbar;

    public Text nextPlayerTurnText;

	public enum PerformAction
	{
		
	}

	// Use this for initialization
	void Start ()
	{
		//	Initialize active Players
		activePlayers = 0;
		//	FindObjectOfType all the Players

		tanks = GameObject.FindGameObjectsWithTag ("Tank");
		foreach (GameObject tank in tanks) {
			activePlayers++;
			playerScript = tank.GetComponent<PlayerMovement> ();

			//healthbar.fillAmount = health.TakeDamage(-Health.maxHealth);

			playerScript.playerID = activePlayers;
			Debug.Log (tank + " hat die ID: " + playerScript.playerID);
            
		}
		print ("Es gibt " + activePlayers + "aktive Player");
		SetActivePlayer ();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void SetActivePlayer ()
	{

		tanks = GameObject.FindGameObjectsWithTag ("Tank");
        

		foreach (GameObject tank in tanks) {
			playerScript = tank.GetComponent<PlayerMovement> ();

			if (playerScript.playerID == currentPlayer && playerScript.is_dead == false) {
				playerScript.is_movable = true;
				weaponScript = playerScript.GetComponentInChildren<Weapon> ();
				manager = GameObject.FindGameObjectWithTag ("Manager");
				buttonManager = manager.GetComponent<ButtonManager> ();
				buttonManager.SetActiveButton (weaponScript.bulletPrefab);
				Debug.Log ("Tank mit der ID: " + playerScript.playerID + " wurde aktiviert!");

			} else if (playerScript.playerID != currentPlayer) {
				playerScript.is_movable = false;

            } else if (playerScript.is_dead) {
				print ("player was dead");
				NextPlayerMove ();
			}
		}
	}
    IEnumerator NextPlayerMoveTextWait()
    {
        yield return new WaitForSeconds(1);
        nextPlayerTurnText.enabled = false;
    }

    public void NextPlayerMove ()
	{
        nextPlayerTurnText.enabled = true;
        StartCoroutine(NextPlayerMoveTextWait());
        if (currentPlayer < activePlayers) {
			currentPlayer++;
        } else {
			currentPlayer = 1;
		}
		SetActivePlayer ();
	}

//	public void PlayerDied ()
//	{
//		activePlayers = activePlayers - 1;
//		print ("Es gibt noch active player: " + activePlayers);
//		if (activePlayers <= 1) {
//			print ("___________________SPIELENDE_______________");
//			tanks = GameObject.FindGameObjectsWithTag ("Tank");
//			foreach (GameObject tank in tanks) {
//				playerScript = tank.GetComponent<PlayerMovement> ();
//				if (playerScript.is_dead) {
//					print ("player: " + tank + " wins");
//
//				}
//			}
//
//		}

//	}
}

