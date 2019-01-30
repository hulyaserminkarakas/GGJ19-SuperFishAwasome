using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {
    public CombatData combatData;
    public int health;
    public GameObject projectilePrefab;
    public float cooldown = 1.0f;
    public float cooldownDef = 1.0f;
    // Use this for initialization
    void Start () {
        health = combatData.hp;
        
    }
	
	// Update is called once per frame
	void Update () {
	}
    public bool ReceiveDamage(int damage) {
        health = health - damage;
        Debug.Log("Health:: "+ health);
        if (health <= 0) {
            return true;
        }
        return false;
    }
    public void FireProjectile()
    {
        cooldown = -1f;
        Instantiate(projectilePrefab, new Vector2(transform.position.x + 0.4f, transform.position.y), Quaternion.identity);
        StartCoroutine(Cooldown());
        Debug.Log("FireProjectile!!");
    }
    IEnumerator Cooldown() {
        yield return new WaitForSecondsRealtime(cooldownDef);
        cooldown = 1f;
    }
    public void DeathAnimFinished()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Knife")
        {
            Destroy(collision.gameObject);
            GameManager.instance.DamagePlayer(10);
        }
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            GameManager.instance.DamagePlayer(15);
        }
    }
}
