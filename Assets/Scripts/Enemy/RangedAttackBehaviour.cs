using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackBehaviour : MonoBehaviour {
    public GameObject itemPre;
    public float speed; 
	// Use this for initialization
	void Start () {
        StartCoroutine(ThrowItem());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ThrowItem() {
        Transform parent = GameObject.Find("Boss").transform;
        EnemyBehaviour eb = parent.gameObject.GetComponent<EnemyBehaviour>();
        while (eb.IsAlive())
        {
            float rand = 1.25f;
            int amount = 1;
            Debug.Log("rand: " + rand);
            for (int i = 0; i < amount; i++) {
                GameObject newItem = Instantiate(itemPre, new Vector2(parent.position.x -0.75f, parent.transform.position.y - 0.5f), Quaternion.identity);
                newItem.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.deltaTime, speed * Time.deltaTime * -1);
            }
            yield return new WaitForSecondsRealtime(rand);
        }
    }
}