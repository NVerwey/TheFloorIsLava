using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public float speed;
    
    
	void Start () {
 
    }
	
	void Update () {
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Shooter")
        {
            
            Destroy(gameObject);
        }
        
    }
}
