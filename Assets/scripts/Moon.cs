using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : Orbit {



    public Moon(): base(Vector3.zero)
    {
        setSpeed(50);
        setDistance();
    }

   
	
	// Update is called once per frame
	void Update () {
        setOrbitingAround(transform.parent.gameObject.transform.position);
        setSpeed(50);
        rotate();
	}
}
