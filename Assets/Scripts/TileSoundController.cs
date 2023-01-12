using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSoundController : MonoBehaviour {

    public AudioSource downSound;
    public AudioSource upSound;
    private float nextTimeToFire = 0f;
    private float timeForNextSound = 0.5f;
    public void onPushed()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + timeForNextSound;
            downSound.PlayOneShot(downSound.clip);
        }
        Debug.Log("Pushed tile sound");
       
    }
    public void onReleased()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + timeForNextSound;
            upSound.PlayOneShot(upSound.clip);
        }
        
    }
}
