using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pluto : Planet {

    public float leftIncrement;
    public float rightIncrement;

    public Pluto() : base( "Pluto")
    {

    }


	// Use this for initialization
	void Start () {
        setDistance();
        setSpeed();
    
	}
	


    bool getLeft()
    {
        return Input.GetKey("left") || Input.GetKey("a");
    }

    bool getRight()
    {
        return Input.GetKey("right") || Input.GetKey("d");
    }

	// Update is called once per frame
	void Update () {
        bool right = getRight();
        bool left = getLeft();
        if (right && left)
        {

        }else if (right){
            setSpeed(getSpeed() + leftIncrement);
        }else if (left)
        {
            setSpeed(getSpeed() - rightIncrement);
        }



        rotate();




    }
}
