using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour {
    GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 pos = transform.position;
        pos.x = player.transform.position.x;
        pos.y = player.transform.position.y;
        transform.position = pos;
	}
}
