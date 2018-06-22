using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public float speed;

    private AudioSource exploaudio;
    
	void Start () {
        exploaudio = GetComponent<AudioSource>();
    }
	
	void Update () {
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Shooter")
        {
            exploaudio.Play();
            Destroy(gameObject);
        }
        
    }
}
