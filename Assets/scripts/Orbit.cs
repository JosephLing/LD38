using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    private float speed;

    private float distance;
    private Vector3 center;
    private float mass;

    public Orbit(Vector3 test)
    {
        setOrbitingAround(test);
        
    }



    public void setOrbitingAround(Vector3 newCenter)
    {
        center = newCenter;
    }

    

    public void setSpeed()
    {
        speed = mass * 0.15f;
        //speed = (SolarSystem.getMaxSize() - distance) - transform.lossyScale.x;
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
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
        distance = Mathf.Sqrt((transform.position.x * transform.position.x) + (transform.position.z * transform.position.z));
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
        float b = Random.Range(-(distance), (distance));
        float a = Mathf.Sqrt((distance * distance) - (b * b));
        if (Random.value >= 0.5)
        {
            a *= -1;
        }
        return new Vector3(b, 0.5f, a);
    }


    public void takeDamage(float damage)
    {
        mass -= damage * 1 / Random.Range(4, 16);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "asteroid")
        {
            Destroy(col.gameObject);

            Asteroid temp = col.gameObject.GetComponent<Asteroid>();
            takeDamage(temp.getMass());

        }
    }


    public void checkAlive()
    {
        if (getMass() <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public float getMass()
    {
        return mass;
    }

    public void setMass(float mass)
    {
        this.mass = mass;
        setSpeed();
    }
}
