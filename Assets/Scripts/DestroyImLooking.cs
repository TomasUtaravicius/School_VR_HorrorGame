using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyImLooking : MonoBehaviour {

    public ImLookingAtYou scriptRef;
    private Vector3 currentTransform;
    public GameObject Skull;
	// Use this for initialization
	void Start () {
        currentTransform = Skull.transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        float offsetY = Math.Abs(currentTransform.y - Skull.transform.position.y);
        if (offsetY>0.1f)
        {
            Debug.Log("Destroying looking functionality");
            Destroy(scriptRef);
        }
	}
}
