using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Paddle1Movement : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float restrictOnYAxis = 2.25f;
    private Rigidbody2D rBody;


    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        var vel = rBody.velocity;
        if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }
        rBody.velocity = vel;

    }

}