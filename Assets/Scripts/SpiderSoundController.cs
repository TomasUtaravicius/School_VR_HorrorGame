using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSoundController : MonoBehaviour {
    public AudioSource attack1Sound;
    public AudioSource attack2Sound;
    public AudioSource death;
    public AudioSource chasingSound;
    public AudioSource walkingSound;
    public AudioSource hitSound;
    
    public void PlayAttack1()
    {
        Debug.Log("PlayAttack1");
        attack1Sound.PlayOneShot(attack1Sound.clip);
    }
    public void PlayAttack2()
    {
        Debug.Log("PlayAttack2");
        attack2Sound.PlayOneShot(attack2Sound.clip);
    }
    public void PlayDeath()
    {
        Debug.Log("PlayDeath");
        death.PlayOneShot(death.clip);
    }
    public void PlayChase()
    {
        Debug.Log("PlayChase");
        chasingSound.Play();

    }
    public void StopChase()
    {
        Debug.Log("StopChase");
        
        chasingSound.Stop();
    }
    public void PlayWalk()
    {
        Debug.Log("PlayWalk");
        walkingSound.Play();
    }
    public void StopWalk()
    {
        Debug.Log("StopWalk");
        walkingSound.Stop();
    }
    public void HitSpider()
    {
        Debug.Log("HitSpider");
        hitSound.PlayOneShot(hitSound.clip);
    }

}
