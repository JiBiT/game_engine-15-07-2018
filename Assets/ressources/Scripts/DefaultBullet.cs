using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultBullet : MonoBehaviour {
    public GameObject cannon;
    public GameObject bulletPrefab;
    
    public bool isCreated = false;

    public float lifepoints = 100;
    //GUI
    public Image healthbar_P1;
    public Text lifepointsText;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
       

    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detection");
        if (other.gameObject.CompareTag("HITABLE"))
        {
            Debug.Log("is HITABLE");
            GameObject.Destroy(gameObject, 2);
            lifepoints = lifepoints - 20;
            lifepointsText.text = lifepoints.ToString() + "%";
            healthbar_P1.fillAmount = 0;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
