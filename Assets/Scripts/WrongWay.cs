using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WrongWay : MonoBehaviour {
	private AudioSource source;
	 public AudioClip boom;

	 public GameObject spawnPoint;
	 public GameObject player;
	
	// Use this for initialization
	void Start () {
		
	}
	private void Awake() {
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
	if (other.gameObject.tag == "Player"){
		 gameObject.SetActive(false);
		 source.PlayOneShot(boom,2f);
		  player.transform.position = spawnPoint.transform.position;
		  gameObject.SetActive(true);
         
	}	
	}
}
