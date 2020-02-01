using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{

    private Transform hand;
    private Material itemMat;

    private bool onFloor = false;
    private bool selected = false;

    private Color defaultColor = Color.white;
    private Color highlightedColor = Color.red;

    void Start()
    {

        hand = GameObject.Find("hand").transform;
        itemMat = GetComponentInChildren<MeshRenderer>().material; //Item colour 

    }


    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "hand" && onFloor == true) itemMat.color = highlightedColor;

    }


    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.name == "hand") itemMat.color = defaultColor;

    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name == "floorPlane") onFloor = true;

    }

    void OnCollisionExit(Collision col)
    {

        if (col.gameObject.name == "floorPlane") onFloor = false;

    }


    void OnMouseDown()
    {

        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = hand.position;
    }

    void OnMouseDrag()
    {

        this.transform.position = hand.position;
    }

    void OnMouseUp()
    {
        GetComponent<Rigidbody>().useGravity = true;
        this.transform.parent = null;
    }

}
