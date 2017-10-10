using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour {

    public GameObject FirePoint;

	// Use this for initialization
	void Start () {
        FirePoint.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
