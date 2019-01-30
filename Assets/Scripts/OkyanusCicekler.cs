using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkyanusCicekler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.position += new Vector3 (-0.004f, 0.0f, 0.0f);
	}
}
