using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float respawnDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool isCrashed = false;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Ground" && !isCrashed)
        {
            isCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", respawnDelay);
        }   
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
