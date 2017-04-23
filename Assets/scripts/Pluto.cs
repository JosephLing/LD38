using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pluto : Planet {

    public float leftIncrement;
    public float rightIncrement;

    public Pluto() : base( "Pluto", 35)
    {
        nMoons = 3;
    }


	// Use this for initialization
	void Start () {
        setDistance();
        setSpeed();
        createMoons();  
    
	}
	


    bool getLeft()
    {
        return Input.GetKey("left") || Input.GetKey("a");
    }

    bool getRight()
    {
        return Input.GetKey("right") || Input.GetKey("d");
    }

    bool getUp()
    {
        return Input.GetKey("up") || Input.GetKey("w");
    }

    bool getDown()
    {
        return Input.GetKey("down") || Input.GetKey("w");
    }



    void setNewSpeed(float newSpeed)
    {
        if (newSpeed < 25.0f && newSpeed > -25.0f)
        {
            setSpeed(newSpeed);
        }
    }

    float calDistance(Vector3 pos)
    {
        return Mathf.Sqrt((pos.x * pos.x) + (pos.z * pos.z));
    }

    void changeDistance(float newDistance)
    {

        float amount = 0.015f;
        Vector3 pos;

        if (newDistance > 0.0f )
        {
            pos = new Vector3(transform.position.x - (transform.position.x * amount), transform.position.y, transform.position.z - transform.position.z * amount);
            setDistance();
        }
        else 
        {
           pos = new Vector3(transform.position.x + (transform.position.x * amount), transform.position.y, transform.position.z + transform.position.z * amount);
        }

        
        if (pos != null)
        {
            float distance = calDistance(pos);
            if ( distance > 3.0f && distance < 70.0f)
            {
                transform.position = pos;
                setDistance();
            }
        }
        
    }

	// Update is called once per frame
	void Update () {

        bool up = getUp();
        bool down = getDown();
        if (up && down)
        {

        }else if (up)
        {
            changeDistance(1f);
            takeDamage(0.5f);

        }
        else if (down)
        {
            changeDistance(-1f);
            takeDamage(0.5f);
        }

        bool right = getRight();
        bool left = getLeft();
        if (right && left)
        {

        }else if (right){
            setNewSpeed(getSpeed() + leftIncrement);
        }else if (left)
        {
            setNewSpeed(getSpeed() - rightIncrement);
        }


        if (Input.GetKeyDown("space"))
        {
            if (transform.childCount > 0)
            {
                setMass(transform.GetChild(0).gameObject.GetComponent<Moon>().getMass() / 4);
                Destroy(transform.GetChild(0).gameObject);

            }
        }

        


        checkAlive();



        rotate();




    }
}
