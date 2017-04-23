using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour {

    private string output;
    private List<Planet> planets;

    private int playerId;
    private bool playerIdSet;

    public StatsUI()
    {
        playerIdSet = false;
        planets = new List<Planet>();
    }


	// Use this for initialization
	void Start () {
        
	}

    public void addPlanet(Planet planet)
    {
        if (planet != null)
        {
            planets.Add(planet);

        }
    }

    public void setPlayerId(int playerId)
    {
        playerIdSet = true;
        this.playerId = playerId;
    }
	
	// Update is called once per frame
	void Update () {
        output = "planets:\n";
        int i = 0;
        foreach (Planet planet in planets)
        {
            if (planet != null)
            {
                output += planet.name.Replace("(Clone)", "") + " mass: " + (int)planet.getMass() + "\n";

            }else if (playerIdSet && playerId == i)
            {
                output = "\nGAME OVER";
                GetComponent<Text>().color = Color.red;
                break; // a hack but its getting late...
            }
            i++;
        }
        GetComponent<Text>().text = output;
	}
}
