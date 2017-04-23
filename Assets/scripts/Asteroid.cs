using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        //rb.angularVelocity = Random.insideUnitSphere * 3.0f;
    }

    // Update is called once per frame
    void Update () {
	}

    
}
