using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public float value;

    private int ready;

	void Start () {
        ready = 0;
	}

    private void Update()
    {
        ready ++;
    }

    // Update is called once per frame
    private void FixedUpdate () {
        if (ready >= value)
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            ready = 0;
        }

    }

}
