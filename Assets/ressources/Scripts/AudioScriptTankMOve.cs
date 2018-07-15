using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ressources.Scripts
{
    public class AudioScriptTankMove : MonoBehaviour
    {

        public AudioSource sourceAudioTankMove;

        public AudioClip audioTankMove;

        public void Start()
        {
            sourceAudioTankMove.clip = audioTankMove;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                sourceAudioTankMove.mute = false;
                sourceAudioTankMove.Play();
            }
            //if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            //{
            //    sourceAudioTankMove.Stop();
            //    Debug.Log("Stop sound");
            //}
        }

    }
}
