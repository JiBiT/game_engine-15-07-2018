using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AudioManager : MonoBehaviour
{


    public AudioSource sourceAudioTankShot;
    public AudioClip audioTankShot;

    public AudioSource sourceAudioExplosion;
    public AudioClip audioTankExplosion;

    public AudioSource sourceBackgroundMusic;
    public AudioClip audioBackgroundMusic;

    //	public AudioSource sourceAudioTankMove;
    //	public AudioClip audioTankMove;

    // Use this for initialization
    void Start()
    {
        sourceAudioTankShot.clip = audioTankShot;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayTankShot()
    {
        sourceAudioTankShot.mute = false;
        sourceAudioTankShot.Play();
    }

    public void PlayTankMove()
    {
        //		sourceAudioTankMove.mute = false;
        //		sourceAudioTankMove.Play();
    }
    public void PlayBackgroundMusic()
    {
        sourceBackgroundMusic.Play();
    }
    public void PlayAudioExlosion()
    {
        sourceAudioExplosion.mute = false;
        sourceAudioExplosion.Play();
    }
}