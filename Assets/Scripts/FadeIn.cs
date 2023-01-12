using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
    public Image image;
    public float r;
    public float g;
    public float b;
    public float speed;
    private float actualSpeed;
    public float returnSpeed;
    private void Start()
    {
        actualSpeed = 0.1f/speed;
        Debug.Log("Starting fade out");
        StartCoroutine("Fade");
        Invoke("ReturnToNormal", 5f);
    }
    public void Begin()
    {
        gameObject.SetActive(true);
        StartCoroutine("Fade");
        Invoke("ReturnToNormal", returnSpeed);
    }
    public void ReturnToNormal()
    {
        gameObject.SetActive(false);
        image.color = image.color = new Color(r, g, b, 0);
        
    }
    IEnumerator Fade()
    {
        Debug.Log("Fadeing out courutinem");
        for (float f = 0f; f <= 1; f += 0.01f)
        {
            Debug.Log(f);
            image.color = new Color(r, g, b, f);


            yield return new WaitForSeconds(actualSpeed);
        }
    }

}
