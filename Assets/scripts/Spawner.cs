using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject playerprefab;

    public void SpawnPlayer()
    {
        GameObject player = Instantiate(playerprefab, transform.position, Quaternion.identity) as GameObject;
    }
}
