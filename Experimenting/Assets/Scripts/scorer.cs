using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorer : MonoBehaviour
{
    int hits = 0;
    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag != "Hit")
        {
        hits++;
        Debug.Log("I bumped into a wall this many times: " + hits);
        }
        
        
    }
}
