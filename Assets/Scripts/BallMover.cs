using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    [SerializeField]float constantSpeed = 10f;
    private Rigidbody2D rBody;
    public Transform paddle1;
    public void movingBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rBody.AddForce(new Vector2(20, -15));
        }
        else
        {
            rBody.AddForce(new Vector2(-20, -15));
        }

       
    }
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        Invoke("movingBall", 2);
    }

    private void Update()
    {


        rBody.velocity = constantSpeed * (rBody.velocity.normalized);


    }
    public void RestartBall()
    {
        rBody.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    public void RestartGame()
    {
        RestartBall();
        Invoke("movingBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.collider.CompareTag("wood"))
        {
            Destroy(coll.gameObject);
        }

    }


}