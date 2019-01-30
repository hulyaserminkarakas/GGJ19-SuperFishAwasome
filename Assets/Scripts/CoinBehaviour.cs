using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Triggered!");
        if (col.tag == "Player")
        {
            GameManager.instance.IncreaseScore(1);
            Destroy(gameObject);
        }
    }
}
