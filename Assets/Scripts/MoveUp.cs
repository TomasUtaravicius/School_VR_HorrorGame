using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed = 1f;
    public GameObject target;
    public bool hasBeenCalled = false;
    public AudioSource audioForOpening;
    public bool audioReadyToPlay = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }
    void Moving()
    {

        if(audioReadyToPlay == true)
        {
            audioReadyToPlay = false;
            audioForOpening.Play();

        }
        float step = speed * Time.deltaTime;
        if(hasBeenCalled==true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        }
    }
    void RemoveAudio()
    {

    }
}
