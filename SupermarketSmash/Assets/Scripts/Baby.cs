using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    private float _timer = 0f;
    private Rigidbody _rigidbody;
    public float force = 10000f;
    private int wait_time;
    private bool waiting = false;
    private IEnumerator coroutine;
    private Shelf[] shelves;
    private int choice;
    private GameObject target;

    void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
        shelves = FindObjectsOfType(typeof(Shelf)) as Shelf[];
        //Debug.Log(shelves.Length);
    }

    void Update()
    {
        //Only launch if it's time to launch
        if (!waiting)
        {
            coroutine = WaitRand();
            StartCoroutine(coroutine);
        }
    }

    IEnumerator WaitRand()
    {
        //Have to use this structure in order to allow a pause between jumps (waitforseconds is weird)
        waiting = true;
        wait_time = Random.Range(1, 6);
        Launch(force);
        yield return new WaitForSeconds(2);
        waiting = false;
    }

    void Launch(float force)
    {
        //Debug.Log("Launch!");
        //Choose a random shelf as the target
        choice = Random.Range(0, shelves.Length);
        target = shelves[choice].gameObject;
        //Move a bit upwards if you're on the floor, to avoid hitting the floor and throwing off the angle
        if (this.transform.position.y <= 0)
        {
            this.transform.position = this.transform.position + new Vector3(0, 1, 0);
        }
        //Apply a force in the direction of that shelf (with a random vertical component to target different levels)
        _rigidbody.AddForce((target.transform.position - transform.position + new Vector3(0, Random.Range(1, 4), 0)) * force);
        //_rigidbody.AddForce(new Vector3(0, force, 0));
    }

    private void OnCollisionEnter(Collision other)
    {
        Launch(force);
    }
}
