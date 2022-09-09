using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float respawnDelay = 0.5f;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Ground")
        {
            Invoke("ReloadScene", respawnDelay);
        }   
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
