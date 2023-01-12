using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTurned : MonoBehaviour {
    private bool isActivated = false;
    public RemoveDoor doorScript;
    public AudioSource audioForLever;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		if(transform.eulerAngles.x<=330 && transform.eulerAngles.x >= 300 && isActivated==false)
        {
            audioForLever.Play();
            isActivated = true;
            Invoke("InvokeDoorDestruction",3f);
        }
	}
    public void InvokeDoorDestruction()
    {
        doorScript.removeDoor();
    }
}
