using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionChecker : MonoBehaviour {
    public AudioSource audioForGroundHit;
    public AudioSource audioForWallHit;
    private float nextTimeToFire = 0f;
    private float timeForNextSound = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Walls" && Time.time>=nextTimeToFire)
        {
            nextTimeToFire = Time.time + timeForNextSound;
            if (audioForWallHit != null)
            {
                audioForWallHit.Play();
            }
        }
        if (collision.gameObject.tag == "Floor" && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + timeForNextSound;
            if (audioForGroundHit!=null)
            {
                audioForGroundHit.Play();
            }
            
        }
    }
}
