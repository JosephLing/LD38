using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOpenMenu : MonoBehaviour {


    public Button start;
    public string level;

	// Use this for initialization
	void Start () {

        Button btn = start.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Application.LoadLevel(level);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
