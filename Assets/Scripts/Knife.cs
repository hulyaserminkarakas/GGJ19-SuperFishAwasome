using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DieAntwoord());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator DieAntwoord() {
        yield return new WaitForSecondsRealtime(1.35f);
        Destroy(gameObject);
    }


}
