using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour {

    private bool isKnifeSpawn = false;
    public GameObject knife;

    private float spawnStartPosX = 240.0f;
    private float spawnStartPosY = 6.5f;
    private float spawnTime = 0;


    void Start () {
		
	}
	
	void FixedUpdate () {

        spawnTime += Time.deltaTime; 

        if(spawnTime >= 0.8f)
        {
            SpawnKnife(190);
            SpawnKnife(265);
            SpawnKnife(295);
            SpawnKnife(312);
            spawnTime = 0;
        }

	}


    void SpawnKnife(float posX)
    {
        Instantiate(knife, new Vector3(posX + Random.Range(0,10), spawnStartPosY, 0), Quaternion.identity);
    }
}
