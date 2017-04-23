using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMiniMap : MonoBehaviour {


    private Camera minimapCamera;
    private Rect baseRect;
    private Rect adjustedRect;


    // http://answers.unity3d.com/questions/403039/drawing-border-around-minimap.html

    // Use this for initialization
    void Start () {
        minimapCamera = GetComponent<Camera>();
        baseRect = minimapCamera.rect;
        float correctionFactor = 1.77778f / Camera.main.aspect;
        adjustedRect = new Rect(baseRect.x - ((baseRect.width * correctionFactor) - baseRect.width), baseRect.y, baseRect.width * correctionFactor, baseRect.height);
        minimapCamera.rect = adjustedRect;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
