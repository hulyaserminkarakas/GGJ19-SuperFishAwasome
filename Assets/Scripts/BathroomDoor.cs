using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomDoor : MonoBehaviour {
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        Physics.IgnoreLayerCollision(8,9,true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy") {
            Destroy(collision.gameObject);
        }
    }
}
