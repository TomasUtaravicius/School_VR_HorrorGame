using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {
	Animator animator;
	bool doorOpen;
    public AudioSource audioForDoor;
	// Use this for initialization
	void Start () {
		doorOpen = true;
		animator = GetComponent<Animator>();
		
	}
	
void OnTriggerExit(Collider col){
	if (doorOpen){
		doorOpen = false;
		DoorControl("Close");
        audioForDoor.PlayOneShot(audioForDoor.clip);

	}
}
void OnTriggerEnter(Collider col){
	if (col.gameObject.tag == "Key"){
		doorOpen = true;
		DoorControl("Open");
        audioForDoor.PlayOneShot(audioForDoor.clip);
        }
}
void DoorControl(string direction){
	animator.SetTrigger(direction);
}

}
