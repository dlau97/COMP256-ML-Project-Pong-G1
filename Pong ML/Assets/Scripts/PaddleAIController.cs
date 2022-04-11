using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAIController : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 initialPos;

    public Transform ballTransform;

    public bool enableAI = true;

    public float followSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        initialPos = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableAI == true)
        {
            followball();
        }
        else
        {
            Vector3 inputVector = Vector3.zero;
            inputVector.y = Input.GetAxis("Vertical2") * 20f;
            rb.velocity = inputVector;
        }

    }

    public void ResetPaddle()
    {
        //Reset Paddle Velocity and Position
        this.rb.angularVelocity = Vector3.zero;
        this.rb.velocity = Vector3.zero;
        this.transform.localPosition = initialPos;
    }

    private void followball()
    {
        if (ballTransform.position.y < transform.position.y)
        {
            rb.velocity = (Vector3.down * followSpeed);
        }
        else if (ballTransform.position.y > transform.position.y)
        {
            rb.velocity = (Vector3.up * followSpeed);
        }

        //Constraints
        if (this.transform.localPosition.y > 3.2f)
        {
            this.transform.localPosition = new Vector3(initialPos.x, 3.2f, 9.5f);
        }
        else if (this.transform.localPosition.y < -3.2f)
        {
            this.transform.localPosition = new Vector3(initialPos.x, -3.2f, 9.5f);
        }
    }

}
