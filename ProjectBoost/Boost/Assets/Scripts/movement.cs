using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    //Perameters - Typically set in editor
    //Cache - References for readability
    //State - Private instance variables

    [SerializeField] float powerThrust = 100;
    [SerializeField] float rotationThrust = 10;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem LeftEngineParticles;
    [SerializeField] ParticleSystem rightEngineParticles;


    Rigidbody myrb;
    AudioSource myAudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }

    }
    void StartThrusting()
    {
        myrb.AddRelativeForce(Vector3.up * powerThrust * Time.deltaTime);
        if (!myAudioSource.isPlaying)
        {
            myAudioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }
    void StopThrusting()
    {
        myAudioSource.Stop();
        mainEngineParticles.Stop();
    }
    void StopRotating()
    {
        rightEngineParticles.Stop();
        LeftEngineParticles.Stop();
    }
    void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!rightEngineParticles.isPlaying)
        {
            rightEngineParticles.Play();
        }
    }
    void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (!LeftEngineParticles.isPlaying)
        {
            LeftEngineParticles.Play();
        }
    }
    void ApplyRotation(float rotationThisFrame)
    {
        myrb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        myrb.freezeRotation = false;
    }
}


