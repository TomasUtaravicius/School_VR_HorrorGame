using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public bool alive = true;

	public  Spider sp;

	void OnTriggerEnter(Collider other) {
	if (other.gameObject.name == "Eyes"){
		other.transform.parent.GetComponent<Spider>().checkSight(); 
		sp.checkSight();
	}	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
