using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lash : MonoBehaviour
{
    [SerializeField] private Rigidbody2D hook;
    [SerializeField] private GameObject prefabLashSegment;
    [SerializeField] private GameObject magnet;
    public int numLinks = 5;

    public HingeJoint2D top;

    void Start()
    {
        GenerateLash(); 
    }

    void GenerateLash() 
    {
        Rigidbody2D prevBod = hook;
        for (int i = 0; i < numLinks; i++)
        {
            GameObject newSeg = Instantiate(prefabLashSegment);
            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
            hj.connectedBody = prevBod;

            prevBod = newSeg.GetComponent<Rigidbody2D>();

            if (i == 0) 
            {
                top = hj;
            }

            if (i == numLinks - 1) 
            {
                newSeg = Instantiate(magnet);
                newSeg.transform.parent = transform;
                newSeg.transform.position = transform.position;
                hj = newSeg.GetComponent<HingeJoint2D>();
                hj.connectedBody = prevBod;
            }
        }

        
    }

    public void AddLink() 
    {
        GameObject newLink = Instantiate(prefabLashSegment);
        newLink.transform.parent = transform;
        newLink.transform.position = transform.position;
        HingeJoint2D hj = newLink.GetComponent<HingeJoint2D>();
        hj.connectedBody = hook;
        newLink.GetComponent<LashSegment>().connectedBelow = top.gameObject;
        top.connectedBody = newLink.GetComponent<Rigidbody2D>();
        top.GetComponent<LashSegment>().ResetAnchor();
        top = hj;
    }

    public void RemoveLink() 
    {
        HingeJoint2D newTop = top.gameObject.GetComponent<LashSegment>().connectedBelow.GetComponent<HingeJoint2D>();
        newTop.connectedBody = hook;
        newTop.gameObject.transform.position = hook.gameObject.transform.position;
        newTop.GetComponent<LashSegment>().ResetAnchor();
        Destroy(top.gameObject);
        top = newTop;
    }
}
