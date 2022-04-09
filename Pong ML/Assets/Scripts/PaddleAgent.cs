using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;


public class PaddleAgent : Agent
{

    private Rigidbody rb;
    private Vector3 initialPos;

    public Transform ballTarget;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        initialPos = this.transform.position;
    }

    public override void OnEpisodeBegin()
    {
        //Reset Paddle Velocity and Position
        this.rb.angularVelocity = Vector3.zero;
        this.rb.velocity = Vector3.zero;
        this.transform.localPosition = initialPos;
    }
    


}
