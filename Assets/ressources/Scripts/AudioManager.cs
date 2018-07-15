using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AudioManager : MonoBehaviour {


	public AudioSource sourceAudioTankShot;
	public AudioClip audioTankShot;

//	public AudioSource sourceAudioTankMove;
//	public AudioClip audioTankMove;

	// Use this for initialization
	void Start () {
		sourceAudioTankShot.clip = audioTankShot;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayTankShot(){
		sourceAudioTankShot.mute = false;
		sourceAudioTankShot.Play();
	}

	public void PlayTankMove(){
//		sourceAudioTankMove.mute = false;
//		sourceAudioTankMove.Play();
	}
}
