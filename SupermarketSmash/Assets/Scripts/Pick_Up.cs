using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
	
	public Transform hand; 
	public Transform shelfCube; 
	private bool repaired = false; 

	void Start()
    {
        hand = GameObject.Find("Hand").transform;
    }

	void OnCollisionEnter(Collision col){
		switch(col.gameObject.name){
			case "floor":
				Debug.Log("Floor collision detected.");//Debugging comment 
				break;
			case "test_cubicle": //Not being detected correctly. 
				repaired = true; 
				break; 
			default: 
				Debug.Log("Collision detected.");//Debugging comment 
				break; 
		}
	}
	
	/*Pick up/interact with an object*/ 
    void OnMouseDown(){
		if(!repaired){

			GetComponent<Rigidbody>().useGravity = false; 
			this.transform.position = hand.position; 
        }
    }
	
	void OnMouseDrag(){
		this.transform.position = hand.position; 
	}

	/*Release the object, and turn on gravity. If object is released within shelf box
	then object snaps into position. */ 
    void OnMouseUp(){
		GetComponent<Rigidbody>().useGravity = true;
		this.transform.parent = null; 
	}

}
