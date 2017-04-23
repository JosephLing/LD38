using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOpenMenu : MonoBehaviour {


    public string level;

    public Button toHist;
    public Button play;

    public GameObject hist;
    public GameObject main;


	// Use this for initialization
	void Start () {
        play.onClick.AddListener(loadLevel);
        toHist.onClick.AddListener(loadHist);
    }


    void loadHist()
    {
        main.SetActive(false);
        hist.SetActive(true);
    }

    void loadLevel()
    {

        SceneManager.LoadScene(level);
    }

}
