using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour



{
    
    [SerializeField] float moveSpeed = 1f;
    
    // Start is called before the first frame update, it will happen once
    void Start()
    {
         PrintInstruction();
    }

    // Update is called once per frame (Happens all the time)
    void Update()
    {
        MovePlayer();
    }

    void PrintInstruction()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Use the arrow keys to control the player");
        Debug.Log("Enjoy - Don't hit the walls");
    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal")* Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue); 
    }
}
