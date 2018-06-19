using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    public float speed;

    private int min;
    private int max;
    private float actual;
    private float last;


    private void Start()
    {
        max = 10;
        min = 0;
        actual = 0;
        last = 0 + speed;
    }
    private void Update () {

        if (actual < max && last < actual || actual == min && last == min + speed)
        {
            transform.position = transform.position + Vector3.right * speed;
            last = actual;
            actual = actual + speed;
        }
        else if (actual > min && last > actual || actual == max && last == max - speed)
        {
            transform.position = transform.position + Vector3.left * speed;
            last = actual;
            actual = actual - speed;
        }
        
        
	}
}
