using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colliosionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip crashRocket;
    [SerializeField] AudioClip landRocket;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem landParticle;
    



    AudioSource anotherAudioSource;
    bool isTransitioning = false;
    bool disableCollision = false;

    void Start()
    {
        anotherAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    { 
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            disableCollision = !disableCollision; //toggle collision     
        }   
    }



    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || disableCollision){ return; }
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Unfriendly":
                Debug.Log("This thing is unfriendly");
                break;
            case "Fin":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        anotherAudioSource.PlayOneShot(crashRocket);
        crashParticle.Play();
        GetComponent<movement>().enabled = false;
        Invoke("ReloadLevel", delayTime); 
        
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        anotherAudioSource.Stop();
        anotherAudioSource.PlayOneShot(landRocket);
        landParticle.Play();
        //add particle effect on crash
        GetComponent<movement>().enabled = false;
        Invoke("LoadNextLevel", delayTime);
    }



    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}