using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LashSegment : MonoBehaviour
{
    public GameObject connectedAbove, connectedBelow;

    void Start()
    {
        ResetAnchor();
    }

    public void ResetAnchor() 
    {
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        LashSegment aboveSegment = connectedAbove.GetComponent<LashSegment>();
        if (aboveSegment != null)
        {
            aboveSegment.connectedBelow = gameObject;
            float spriteBottom = connectedAbove.GetComponent<SpriteRenderer>().bounds.size.y; // finds the correct point to place hingejoint2d anchor
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, spriteBottom * -2);
        }

        else
        {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
    }

}
