using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{

    private Transform hand;
    private Material itemMat;

    public bool onFloor = false;
    private bool selected = false;

    private Color defaultColor;
    private Color highlightedColor = Color.red;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        hand = GameObject.Find("hand").transform;
        itemMat = GetComponentInChildren<MeshRenderer>().material; //Item colour 
        defaultColor = itemMat.color;

    }


    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "hand" && onFloor == true) itemMat.color = highlightedColor;
        if (col.gameObject.GetComponent<ShelfItemPlacement>())
        {
            //gameObject.transform.rotation.SetEulerAngles(0f,0f,0f);
            gameObject.transform.eulerAngles = new Vector3(0f,0f,0f);
            _rigidbody.freezeRotation = true;
        }
    }


    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.name == "hand") itemMat.color = defaultColor;
        if (col.gameObject.GetComponent<ShelfItemPlacement>())
        {
            _rigidbody.freezeRotation = false;
        }
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
