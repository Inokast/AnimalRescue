using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float forceFactor = 200f;

    List<Rigidbody2D> selectedObjects = new List<Rigidbody2D>();

    private Vector2 magnetP;


    private void FixedUpdate()
    {
        magnetP = new Vector2(transform.position.x, transform.position.y);
        foreach (Rigidbody2D obj in selectedObjects)
        {
            obj.AddForce((magnetP - obj.position) * forceFactor * Time.fixedDeltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball") || other.CompareTag("Metal"))
        {
            selectedObjects.Add(other.GetComponent<Rigidbody2D>());
            other.GetComponent<Rigidbody2D>().gravityScale = .5f;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball") || other.CompareTag("Metal"))
        {
            selectedObjects.Remove(other.GetComponent<Rigidbody2D>());
            other.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
