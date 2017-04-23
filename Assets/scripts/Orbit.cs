using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    private float speed;

    private float distance;
    private Vector3 center;


    public Orbit(Vector3 test)
    {
        setOrbitingAround(test);
        
    }

    //void Start()
    //{
    //    setDistance();
    //    setSpeed();
        
    //}


    public void setOrbitingAround(Vector3 newCenter)
    {
        center = newCenter;
    }

    public void checkAlive()
    {
        

    }

    public void setSpeed()
    {
        speed = 3;
        //speed = (SolarSystem.getMaxSize() - distance) - transform.lossyScale.x;
    }

    public void setSpeed(float newSpeed)
    {
        if (newSpeed < 25.0f && newSpeed > -25.0f)
        {
            speed = newSpeed;
        }
    }

    public float getSpeed()
    {
        return speed;
    }


    public float getDistance()
    {
        return distance;
    }

    public void setDistance()
    {
        if (transform != null)
        {
            distance = Mathf.Sqrt((transform.position.x * transform.position.x) + (transform.position.z * transform.position.z));
        }else
        {
            Debug.LogWarning("transform null for " + name);
        }
    }


    public void rotate()
    {
        if (transform.name != "Moon(Clone)")
        {
            transform.position = new Vector3(transform.position.x, transform.lossyScale.y / 2, transform.position.z);
        }
        transform.RotateAround(center, Vector3.up, speed * Time.deltaTime);
    }

    public static Vector3 randomPointOnCircumferance(float distance)
    {
        float b = Random.Range(-(distance - distance/8), (distance - distance / 8));
        float a = Mathf.Sqrt((distance * distance) - (b * b));
        if (Random.value >= 0.5)
        {
            a *= -1;
        }
        return new Vector3(b, 0.5f, a);
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    rotate();
    //}
}
