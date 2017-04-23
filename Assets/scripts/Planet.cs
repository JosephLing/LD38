using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet: Orbit {

    public static string RANDALPHABET = "abcdefghijklmnopqrstuvwxyz!12345";

    public int nMoons = 0;

    private List<Moon> moons;
    private Moon[] moonPrefabs;
    private string planetName;
	
    public Planet(string newName, float mass) : base(Vector3.up)
    {
        if (mass > 0.0f)
        {
            setMass(mass);
        }
        setName(newName);
    }

    public void setName(string newName)
    {
        if (newName != null)
        {
            planetName = newName;
        }
        else
        {
            planetName = "planet";

        }
    }

    public void setMoonPrefabs(Moon[] moonPrefabArray)
    {
        moonPrefabs = moonPrefabArray;
    }



    public void setMat(Material planetMat)
    {

        if (planetMat != null)
        {
            Renderer rend = GetComponent<Renderer>();

            if (rend != null)
            {
                rend.sharedMaterial = planetMat;
            }
            else
            {
                Debug.LogWarning("could not find render for planet: " + name);
            }
        }
        else
        {
            Debug.Log("no materail assigned for planet via constructor: " + name);
        }
    }

    void Start()
    {
        if (getMass() == 0.0f)
        {
            setMass(Random.Range(3, 6) * 15);
        }
        setDistance();
        setSpeed();
        createMoons();
    }


    public void createMoons()
    {
        for (int i = 0; i <= nMoons; i++)
        {
            createMoon();
        }
    }

   public void createMoon()
    {


        if (moonPrefabs != null && moonPrefabs.Length != 0)
        {
            int index = (int)Random.Range(0, moonPrefabs.Length);
            if (moonPrefabs[index] != null)
            {
                Moon moonCopy = Instantiate<Moon>(moonPrefabs[index]);
                Vector3 pos = Orbit.randomPointOnCircumferance( Random.Range(0.3f, 1.25f) + transform.lossyScale.z / 2);
                moonCopy.transform.position = new Vector3(pos.x+transform.position.x, Random.Range(transform.position.y, transform.lossyScale.y), pos.z + transform.position.z);
                moonCopy.transform.parent = transform;
                //moons.Add(moonCopy);
            }
           
        }else
        {
            Debug.LogWarning("no moonPrefabs set for planet: " + name);
        }
        
    }

	// Update is called once per frame
	void Update () {
        rotate();
        checkAlive();
	}



    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "asteroid")
        {
            Destroy(col.gameObject);

            Asteroid temp = col.gameObject.GetComponent<Asteroid>();


            if (getMass() - temp.getMass() > 50)
            {
                createMoon();
            }
            takeDamage(temp.getMass());
        }
            if (col.gameObject.tag == "moon")
            {
                Debug.Log(col.gameObject.transform.parent.name);
                Destroy(col.gameObject);
                takeDamage(col.gameObject.GetComponent<Moon>().getMass());
            }
        
    }
}
