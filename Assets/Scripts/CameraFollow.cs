using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameManager.instance.player;
	}
	
	// Update is called once per frame
	void Update () {
        if(player.transform.position.x > -2.5f) { 

            transform.position = new Vector3(player.transform.position.x + 2.63f, 0f, -10f);
        }
    }
}
