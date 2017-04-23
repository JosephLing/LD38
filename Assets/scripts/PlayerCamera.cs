using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {


    private GameObject player;

    public  void setPlayer(GameObject newPlayer)
    {
        Debug.Log("Camera centered on " + newPlayer.name);
        player = newPlayer;
    }
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        }
    }
}
