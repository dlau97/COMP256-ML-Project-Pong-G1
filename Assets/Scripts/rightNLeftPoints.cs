using UnityEngine;
using System.Collections;

public class rightNLeftPoints : MonoBehaviour
{
    string borderName;  
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Ball")
        {
            string pointPoint= transform.name;
            collider.gameObject.SendMessage("RestartGame", 1.0f);
        }
    }
}
