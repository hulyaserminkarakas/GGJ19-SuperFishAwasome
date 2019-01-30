using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed = 4.0f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0.15f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "Boss")
        {
            EnemyBehaviour eb = collision.gameObject.GetComponent<EnemyBehaviour>();
            eb.ReceiveDamage(20);
            
        }
        Destroy(gameObject);
    }
}
