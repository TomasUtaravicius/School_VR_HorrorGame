using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundScript : MonoBehaviour {

    public AudioSource audioForSound;
    public BoxCollider boxCollider;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            Debug.Log("Collision between player and I See you collider");
            audioForSound.PlayOneShot(audioForSound.clip);
            Destroy(boxCollider);
            
        }
    }
}
