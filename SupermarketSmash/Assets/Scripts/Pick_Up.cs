using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{

    public Transform hand;
    public Transform snapper; //thing to be snapped to 
    private bool ready = false;
    private bool selected = false;

    void Start()
    {
        hand = GameObject.Find("hand").transform;
        GetComponentInChildren<MeshRenderer>().material.color = Color.white;

    }

    void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.name)
        {
            case "floor":
                break;
            case "hand":
                selected = true;
                break;
            default:
                //Debug.Log("Selected!!!.");//Debugging comment 
                break;
        }
    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "hand") selected = false;
    }



    /*Pick up/interact with an object*/
    void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = hand.position;
    }

    void OnMouseDrag()
    {
        this.transform.position = hand.position;
    }

    /*Release the object, and turn on gravity. If object is released within shelf box
	then object snaps into position. */
    void OnMouseUp()
    {
        if (ready)
        {
            snapToLocale();
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            this.transform.parent = null;
        }
    }

    void snapToLocale()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = snapper.position;
    }

    void FixedUpdate()
    {
        if (selected)
        {
            GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            GetComponentInChildren<MeshRenderer>().material.color = Color.white;
        }
    }


}
