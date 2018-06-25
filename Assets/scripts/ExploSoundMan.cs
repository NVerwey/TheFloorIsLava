using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploSoundMan : MonoBehaviour { 

    private AudioSource explo;

    // Use this for initialization
    void Start()
    {
        explo = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("rocket"))
        {
            explo.Play();
        }
    }
}
