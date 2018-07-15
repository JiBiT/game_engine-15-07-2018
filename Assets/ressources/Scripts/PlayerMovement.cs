using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.ressources.Scripts;

public class PlayerMovement : MonoBehaviour
{

	private static GameObject manager;
	public AudioManager audioManager;

	private Rigidbody2D Char;
	public float speed = 100;
	public int playerID = 0;
//	private static GameObject manager;
//	public PlayerManager playerManager;
    
	public bool is_movable = false;
	public bool is_dead = false;
	private SpriteRenderer facing_right;

    public Sprite nonActivePlayer;
    public Sprite activePlayer;

    private float h;
	private float jump_duration;

//    AudioScriptTankShot audioTankShot;
    

    public void Awake()
    {
        
    }

    void Start ()
	{
		Char = GetComponent<Rigidbody2D> ();
		facing_right = GetComponent<SpriteRenderer> ();
		manager = GameObject.FindGameObjectWithTag ("Manager");
		audioManager = manager.GetComponent<AudioManager> ();



	}

	void Update ()
	{
//        		playerManager.NextPlayerMove();
        if (is_movable)
        {
            
            this.gameObject.GetComponent<SpriteRenderer>().sprite = activePlayer;
        }
        else {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = nonActivePlayer;
        }
    }


	public void FixedUpdate ()
	{



		if (is_movable == true) {
			h = Input.GetAxis ("Horizontal");
			//Check to flip;
			Flip ();
            Vector3 actual_velocity = Char.velocity;

//			audioManager.PlayTankMove ();
            


			if (Input.GetButton ("Jump")) {
				
				if (jump_duration <= 1f) {
					jump_duration += 0.1f;
				}

				actual_velocity.y = jump_duration * speed * Time.deltaTime;

			}

			if (Input.GetButtonUp ("Jump")) {
				jump_duration = 0;
			}
            


			actual_velocity.x = h * speed * Time.deltaTime;

			Char.velocity = actual_velocity;

           
		}
        
       
	}

//	void CheckState ()
//	{
//		float check = playerManager.currentPlayer;
//		if (check == playerID) {
//			is_movable = true;
//		} else {
//			is_movable = false;
//		}
//    
//	}

	void Flip ()
	{
		if (h < 0) {
			facing_right.flipX = true;

		} else if ((h > 0)) {
			facing_right.flipX = false;
		}

	}
   
	//    void OnMouseDown()
	//    {
	//        GameObject[] objs;
	//        objs = GameObject.FindGameObjectsWithTag("Tank");
	//        foreach (GameObject tank in objs)
	//        {
	//            var script = tank.GetComponent<PlayerMovement>();
	//            script.is_movable = false;
	//            Debug.Log("Tanks deactivated");
	//            Debug.Log(this.is_movable + "für" + this);
	//        }
	//               this.is_movable = true;
	//            }
}

