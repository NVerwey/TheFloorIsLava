using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public float speed;

    private bool ready;
	// Use this for initialization
	void Start () {
        ready = false;
	}
	
	// Update is called once per frame
	private void FixedUpdate () {
        if (ready)
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed * Time.deltaTime);
            ready = false;
        }
        else if (!ready && Input.GetKeyDown("x"))
        {
            ready = true;
        }

    }

}
