using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//Assignment/Lab/Project: Mobile Game Final project 
//Name: Daniel Sanchez

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Magnet magnet;
    private Lash lash;
    private SoundFXController sfx;

    [Header("Player Settings")]
    public Transform targetLookTowards;
    [SerializeField] private float speed;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float rotationSpeed;
    private LashSegment[] lashSegments;
    //[SerializeField] private int maxLinks = 8;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        lashSegments = FindObjectsOfType<LashSegment>();
        lash = FindObjectOfType<Lash>();
        //System.Array.Reverse(lashSegments);
        magnet = FindObjectOfType<Magnet>();
        sfx = FindObjectOfType<SoundFXController>();
        sfx.PlayLashOn();

    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("LashButton")) 
        {
            MagnetToggle();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yAxis = CrossPlatformInputManager.GetAxisRaw("Vertical");
        float xAxis = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        MoveUp(yAxis);
        MoveSideways(xAxis);
        Rotation();

        /*if (CrossPlatformInputManager.GetButtonDown("r")) 
        {
            if (lash.numLinks < maxLinks) 
            {
                lash.AddLink();

            }            
        }

        if (CrossPlatformInputManager.GetButtonDown("f"))
        {
            if (lash.numLinks > 1)
            lash.RemoveLink();
        }
        */

        ClampVelocity();
    }

    private void Rotation()
    {

        var step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetLookTowards.rotation, step);
    }

    public void MagnetToggle() 
    {
        magnet = FindObjectOfType<Magnet>();

        if (magnet.isActiveAndEnabled == true) 
        {
            
            DeactivateMagnet();
            sfx.PlayLashOff();
        }

        else 
        {
            ActivateMagnet();
            sfx.PlayLashOn();
        }
    }

    IEnumerator DisplayLash(bool shouldDisplay) 
    {
        lashSegments = FindObjectsOfType<LashSegment>();
        System.Array.Reverse(lashSegments);

        foreach (LashSegment lash in lashSegments)
        {
            yield return new WaitForSeconds(.03f);
            lash.GetComponent<SpriteRenderer>().enabled = shouldDisplay;
        }
    }

    public void ActivateMagnet() 
    {
        magnet.enabled = true;
        StartCoroutine(DisplayLash(true));

    }

    public void DeactivateMagnet() 
    {
        magnet.enabled = false;
        StartCoroutine(DisplayLash(false));
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

    // Possible feature for the future
    /*private void Boost()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        Vector2 force = direction * speed;

        rb.AddForce(force);
    }*/
}
