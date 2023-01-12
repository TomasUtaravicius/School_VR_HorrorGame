using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {
    public Image image;
    public float r;
    public float g;
    public float b;
    public float speed;
    private float actualSpeed;
    private void Start()
    {
        actualSpeed = 0.1f / speed;
        StartCoroutine("Fade");
        Invoke("ReturnToNormal", 5f);
    }
    public void Begin()
    {
        gameObject.SetActive(true);
        StartCoroutine("Fade");
        Invoke("ReturnToNormal", 5f);
    }
    IEnumerator Fade()
    {
        Debug.Log("Fadeing out courutinem");
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            
            image.color = new Color(r, g, b, f);
            

            yield return new WaitForSeconds(actualSpeed);
        }
    }
    public void ReturnToNormal()
    {
        gameObject.SetActive(false);
        image.color= image.color = new Color(r, g, b, 1);
        
    }
}
