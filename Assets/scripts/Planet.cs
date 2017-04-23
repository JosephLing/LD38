using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet: Orbit {

    public static string RANDALPHABET = "abcdefghijklmnopqrstuvwxyz!12345";

    private List<Moon> moons;
    private Moon[] moonPrefabs;
    private int weight;
    private string planetName;
	
    public Planet(string newName) : base(Vector3.up)
    {
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
        

        setDistance();
        setSpeed();
    }


   public void createMoon()
    {
        if (moonPrefabs != null && moonPrefabs.Length != 0)
        {
            Moon moonCopy = Instantiate<Moon>(moonPrefabs[(int)Random.Range(0, moonPrefabs.Length)]);
            Vector3 pos = Orbit.randomPointOnCircumferance(Random.Range(0.3f, 1.25f) + transform.lossyScale.z / 2);
            moonCopy.transform.position = new Vector3(pos.x, Random.Range(transform.position.y, transform.lossyScale.y), pos.z);
            moonCopy.transform.parent = transform;
            moons.Add(moonCopy);
        }else
        {
            Debug.LogWarning("no moonPrefabs set for planet: " + name);
        }
        
    }

	// Update is called once per frame
	void Update () {
        rotate();
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "asteroid")
        {
            Destroy(col.gameObject);
            if (weight > 5)
            {
                createMoon();
                weight = 0;
            }
            weight++;
        }
    }

}
