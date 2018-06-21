using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public int speedx;
    public int speedy;
    public int speedz;

	void Update () {
        transform.Rotate(new Vector3(speedx, speedy, speedz) * Time.deltaTime);
	}
}
