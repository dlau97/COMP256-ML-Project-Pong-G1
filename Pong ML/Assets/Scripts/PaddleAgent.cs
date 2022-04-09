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

    public Transform ballTransform;
    public Rigidbody ballRB;

    public Transform opposingPaddle;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        initialPos = this.transform.localPosition;
    }

    public override void OnEpisodeBegin()
    {
        //Reset Paddle Velocity and Position
        this.rb.angularVelocity = Vector3.zero;
        this.rb.velocity = Vector3.zero;
        this.transform.localPosition = initialPos;
        ballTransform.gameObject.GetComponent<BallController>().ResetBall();
        opposingPaddle.gameObject.GetComponent<PaddleAIController>().ResetPaddle();

    }


    public override void CollectObservations(VectorSensor sensor)
    {
        // Ball, Opposing Paddle and Agent positions
        sensor.AddObservation(ballTransform.localPosition);
        sensor.AddObservation(opposingPaddle.localPosition);
        sensor.AddObservation(this.transform.localPosition);

        //Ball velocity
        sensor.AddObservation(rb.velocity.x);
        sensor.AddObservation(rb.velocity.y);

        // Agent velocity
        sensor.AddObservation(rb.velocity.x);
        sensor.AddObservation(rb.velocity.y);
    }

    public float paddleSpeedMultiplier = 5f;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Actions, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.y = actionBuffers.ContinuousActions[0] * paddleSpeedMultiplier;
        rb.velocity = controlSignal;

        //Constraints
        if(this.transform.localPosition.y > 3.2f)
        {
            this.transform.localPosition = new Vector3(initialPos.x, 3.2f, 9.5f);
        }
        else if (this.transform.localPosition.y < -3.2f)
        {
            this.transform.localPosition = new Vector3(initialPos.x, -3.2f, 9.5f);
        }

        // Rewards

        // Reached target
        if (ballTransform.localPosition.x >= 9f)
        {
            SetReward(1.0f);
            EndEpisode();
        }

        // Fell off platform
        else if (ballTransform.localPosition.x <= -9f)
        {
            EndEpisode();
        }
    }

    //Manual Controls
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Vertical");
    }



}
