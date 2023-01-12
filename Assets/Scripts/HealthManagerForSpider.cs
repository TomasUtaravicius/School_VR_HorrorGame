using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerForSpider : MonoBehaviour {

    public float health = 100f;
    public Spider spiderController;

    public void GetHit(float damage)
    {
        health = health - damage;
        if(health<=0f)
        {
            spiderController.Die();
        }
    }
}
