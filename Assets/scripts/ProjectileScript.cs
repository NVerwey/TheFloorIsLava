using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        transform.Rotate(0, 0, 90);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        //rb.AddForce(Vector3.left * speed * Time.deltaTime);
        //rb.AddForce(Vector3.up * 10 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Shooter")
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
