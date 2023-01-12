using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFire : MonoBehaviour
{
    public GameObject fire;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("FireCaught");
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag=="Slipper")
        {

            fire.SetActive(true);
        }
    }
}
