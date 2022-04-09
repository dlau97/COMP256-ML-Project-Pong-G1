using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float ballSpeedFactor = 12f;
    private Rigidbody ballRB;
    private Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        initialPos = this.transform.localPosition;
        ResetBall();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckBallVelocity();
    }

    void RandomiseBallVelocity()
    {
        float randomX = Mathf.Sign(Random.Range(-1f, 1f));
        float randomY = Mathf.Sign(Random.Range(-1f, 1f));

        ballRB.velocity = new Vector3(ballSpeedFactor * randomX, ballSpeedFactor * randomY, 0f);

    }

    public void ResetBall()
    {
        this.transform.localPosition = initialPos;
        ballRB.angularVelocity = Vector3.zero;
        ballRB.velocity = Vector3.zero;
        RandomiseBallVelocity();
    }

    void CheckBallVelocity()
    {
        //Debug.Log("X Velocity:" + ballRB.velocity.x);
        float xDir = Mathf.Sign(ballRB.velocity.x);

        if (Mathf.Abs(ballRB.velocity.x) <= ballSpeedFactor)
        {
            ballRB.velocity = new Vector3((Mathf.Abs(ballRB.velocity.x) + 1f) * xDir, ballRB.velocity.y, 0f);
        }

        //Debug.Log("Y Velocity:" + ballRB.velocity.y);
        float yDir = Mathf.Sign(ballRB.velocity.y);
        if (Mathf.Abs(ballRB.velocity.y) <= ballSpeedFactor)
        {
            ballRB.velocity = new Vector3(ballRB.velocity.x, (Mathf.Abs(ballRB.velocity.y) + 1f) * yDir, 0f);
        }

    }

    private float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - paddlePos.y) / paddleHeight;
    }
    /*
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Top Wall": case "Bottom Wall":
                Debug.Log("Hit Top or Bottom Wall");
                ballRB.velocity = new Vector3(ballRB.velocity.x, -1f * ballRB.velocity.y, 0f);
                break;  
            case "Left Paddle":
                // Calculate hit Factor
                float y1 = hitFactor(transform.position,
                                    other.transform.position,
                                    other.collider.bounds.size.y);

                // Calculate direction, make length=1 via .normalized
                Vector2 dir1 = new Vector2(1, y1).normalized;

                // Set Velocity with dir * speed
                GetComponent<Rigidbody2D>().velocity = dir1 * ballSpeedFactor * 100;
                break;
            case "Right Paddle":
                // Calculate hit Factor
                float y2 = hitFactor(transform.position,
                                    other.transform.position,
                                    other.collider.bounds.size.y);

                // Calculate direction, make length=1 via .normalized
                Vector2 dir2 = new Vector2(-1, y2).normalized;

                // Set Velocity with dir * speed
                GetComponent<Rigidbody2D>().velocity = dir2 * ballSpeedFactor * 100;
                break;
            default:
                break;
        }
    }
    */
}
