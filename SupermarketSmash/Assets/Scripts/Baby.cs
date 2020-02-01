using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    private float _timer = 0f;
    private Rigidbody _rigidbody;
    public float force = 100f;

    void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Launch(force);
        }
    }

    void Launch(float force)
    {
        Debug.Log("Launch!");
        _rigidbody.AddForce(new Vector3(0, force, 0));
    }

    private void OnCollisionEnter(Collision other)
    {
        Launch(force);
    }
}
