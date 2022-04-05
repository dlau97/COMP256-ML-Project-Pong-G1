using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreasRestricter : MonoBehaviour
{
    public float minX = -8f, minY = -4f, maxX = 8f, maxY = 4f;
    private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        float newX, newY;
        newX = Mathf.Clamp(rBody.position.x, minX, maxX); 
        newY = Mathf.Clamp(rBody.position.y, minY, maxY);
        rBody.position = new Vector2(newX, newY);
    }
}