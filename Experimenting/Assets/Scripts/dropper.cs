using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropper : MonoBehaviour
{
    MeshRenderer rendererM;
    Rigidbody rigidbodyM;
    [SerializeField] float TimetoWait = 5f;


    // Start is called before the first frame update
    
    void Start()
    {
        rendererM = GetComponent<MeshRenderer>();
        rigidbodyM = GetComponent<Rigidbody>();


        rendererM.enabled = false;
        rigidbodyM.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time>TimetoWait)
        {
            //Debug.Log("The time elapsed = " + Time.time);
            rendererM.enabled = true;
            rigidbodyM.useGravity = true;

        }
        

    }
}
