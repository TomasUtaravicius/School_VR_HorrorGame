using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFade : MonoBehaviour {

    public GameObject Fade;
    public GameObject EndScreen;
    public BoxCollider boxCollider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collision between player and I See you collider");
            Fade.SetActive(true);
            if(EndScreen!=null)
            {
                Invoke("EndingScreen", 3f);
                Invoke("EndingScene", 6f);
            }
            Destroy(boxCollider);

        }
    }
    private void EndingScreen()
    {
        EndScreen.SetActive(true);
    }

    private void EndingScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
