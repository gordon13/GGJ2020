using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpactSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip impact;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bone"))
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = impact;
            audioSource.Play();
        }
    }
}