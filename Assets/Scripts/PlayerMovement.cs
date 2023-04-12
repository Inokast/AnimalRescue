using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assignment/Lab/Project: Mobile Game Final project 
//Name: Daniel Sanchez

public class PlayerMovement : MonoBehaviour
{
    //private PlayerStats player;
    private Rigidbody2D rb;
    public Camera cam;

    public Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float rotationSpeed;
    //[SerializeField] private float stability = 0.3f;
    //[SerializeField] private float angularSpeed = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotation();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yAxis = Input.GetAxisRaw("Vertical");
        float xAxis = Input.GetAxisRaw("Horizontal");

        MoveUp(yAxis);
        MoveSideways(xAxis);
        //RotatePlayer();


        ClampVelocity();
    }

    private void RotatePlayer()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;

    }

    private void Rotation()
    {

        var step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);

        /*
        Vector2 predictedUp = Quaternion.AngleAxis(
            rb.angularVelocity * Mathf.Rad2Deg * stability / angularSpeed,
            gameObject.transform.up
            ) * transform.up;

        Vector2 torqueVector = Vector2.Reflect(predictedUp, Vector2.up);
        rb.AddTorque(torqueVector.magnitude * angularSpeed);*/
    }



    private void ClampVelocity() 
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }

    private void MoveUp(float amount) 
    {
        Vector2 force = Vector2.up * amount * speed;

        rb.AddForce(force);
    }

    private void MoveSideways(float amount) 
    {
        Vector2 force = Vector2.right * amount * speed;

        rb.AddForce(force);
    }

    private void Boost()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        Vector2 force = direction * speed;

        rb.AddForce(force);
    }
}
