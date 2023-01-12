using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public float health = 100;
    public Transform spawnPoint;
    public GameObject cameraRig;
    public FadeIn FadeDeath;
    public FadeOut FadeAlive;
    public void GetHit(float damage)
    {
        Debug.Log("Damage done");
        health = health - damage;
        if(health<=0)
        {
            FadeDie();
            Invoke("Die", 1.5f);
        }
    }
    private void FadeDie()
    {
        FadeDeath.Begin();
        Invoke("FadeLive", 1.5f);
    }
    private void FadeLive()
    {
        FadeAlive.Begin();

    }
    private void Die()
    {
        cameraRig.transform.position = spawnPoint.position;
        health = 100f;
    }
}
