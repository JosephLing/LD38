using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour {

    public GameObject star;
    public Planet[] planets;

    public Moon[] moonPrefabs;

    public Camera MiniMap;
    public PlayerCamera playerView;

    public int playerId;

    public int mapSize;



    public GameObject Asteroid;
    public int AsteriodCount = 500;
    public int asteroidWaveCount = 200;
    public int asteroidTickCount = 200;


    public bool PLANETS_ENABLED = false;
    public bool ASTEROIDS_ENABLED = false;


    private int tick;
    private float maxDistance;

    // Use this for initialization
    void Start()
    {
        tick = 0;
        createPlanets();
        setUpCameras();

        createAsteroidsInit();


    }

    
    private void setUpCameras()
    {
        if (MiniMap != null)
        {
            MiniMap.orthographicSize = mapSize;
        }
        else
        {
            Debug.LogWarning("no minimap specified");
        }
       
    }

    private void setUpPlayerCamera(Planet player)
    {
        if (playerView != null)
        {
            bool cameraSet = false;
            if (planets != null && playerId != -1)
            {
                if (playerId < planets.Length)
                {
                    cameraSet = true;

                    playerView = Instantiate<PlayerCamera>(playerView);
                    playerView.setPlayer(player.gameObject);
                    
                }
            }
            if (!cameraSet)
            {
                playerView.transform.position = new Vector3(0.0f, playerView.transform.position.y, 0.0f);
            }
        }
        else
        {
            Debug.LogWarning("Could not find playerCamera");
        }
    }



   

    private void createPlanets()
    {
        if (PLANETS_ENABLED)
        {
            if (star != null)
            {
                Instantiate(star);
            }else
            {
                Debug.LogWarning("no star created");
            }

            for (int i = 0; i < planets.Length; i++)
            {
                if (planets[i] != null)
                {
                    Planet planetCopy = Instantiate<Planet>(planets[i]);
                    maxDistance = (i + 1) * 8.0f;
                    Vector3 pos = Orbit.randomPointOnCircumferance(maxDistance);
                    planetCopy.transform.position = new Vector3(pos.x, (planets[i].transform.lossyScale.y / 2.0f), pos.z);
                    planetCopy.setMoonPrefabs(moonPrefabs);
                    if (i == playerId)
                    {
                        setUpPlayerCamera(planetCopy);
                    }
                }
                else
                {
                    Debug.LogWarning("no planet found in array index: " + i);
                }
                
            }
        }
    }
    
    
    //------------------------------------------
    private void createAsteriod(float distance)
    {
        Vector3 pos = Orbit.randomPointOnCircumferance(distance + Random.Range(-distance / 8, distance / 8));
        GameObject temp = Instantiate<GameObject>(Asteroid,new Vector3(pos.x, 1f, pos.z), Quaternion.identity);
        temp.transform.parent = transform;
    }

    private void createAsteroids()
    {
        if (maxDistance == 0.0f)
        {
            maxDistance = 50.0f;
        }
        else
        {
            maxDistance += 5;
        }
        for (int i = 0; i < 25; i++)
        {
            createAsteriod(75);
        }
    }

    private void createAsteroidsInit()
    {
        if (ASTEROIDS_ENABLED)
        {
            
            for (int i = 0; i < AsteriodCount; i++)
            {
                createAsteriod(maxDistance);
            }
        }
       
    }

    //----------------------------------------------



    private void Update()
    {
        if (tick >= asteroidTickCount)
        {
            if (ASTEROIDS_ENABLED)
            {
                createAsteroids();
            }
            tick = 0;
        }
        else
        {
            tick++;
        }

    }


}
