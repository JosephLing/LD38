using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : Orbit {



    public Moon(): base(Vector3.zero)
    {
       
    }

    private void Start()
    {
        setSpeed(50);
        setDistance();
        setMass(30f);
    }

  


    // Update is called once per frame
    void Update () {
        setOrbitingAround(transform.parent.gameObject.transform.position);
        setSpeed(50);
        rotate();
	}


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "moon")
        {
            if (transform.parent != null && transform.parent != null)
            {
                if (transform.parent.name != transform.parent.name)
                {
                    Destroy(col.gameObject);
                    Destroy(this);
                }
            }
        }
    }
}
