using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    private float mass;


	// Use this for initialization
	void Start () {
        float scaleFactor = Random.Range(1, 5);
        mass = 5 + 5 * scaleFactor;
        scaleFactor = 1.0f + scaleFactor / 8;
        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

    }

    public float getMass()
    {
        return mass;
    }


    
}
