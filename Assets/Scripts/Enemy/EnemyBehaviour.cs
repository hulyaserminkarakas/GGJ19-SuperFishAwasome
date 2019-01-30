using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    [SerializeField]
    private GameObject player;
    public EnemyData data;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField]
    private bool isAlive;
    private bool canJump;
    private float timeBetweenJump;
    private float jumpForce;
    private float timeBetweenAttack;
    private bool isAttacking;
    private int attackDamage;
    private float speed;
    private float direction;
    private bool walk;
    private bool patrol;
    private float patrolRange;
    public float hp;
    private Vector2 defaultPos;
    // Use this for initialization
    void Start () {
        Initialize();
    }
    public bool IsAlive() {
        return isAlive;
    }
	private void Initialize()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        canJump = data.movement.canJump;
        timeBetweenJump = data.movement.timeBetweenJump;
        jumpForce = data.movement.timeBetweenJump;
        isAttacking = false;
        speed = data.movement.speed;
        direction = 1f;
        isAlive = true;
        if (player.transform.position.x < transform.position.x)
        {
            direction = -1f;
        }
        walk = data.movement.moveForwardOnly;
        patrol = data.movement.patrol;
        patrolRange = data.movement.patrolRange;
        defaultPos = transform.position;
        hp = data.combat.hp;
        Move();
    }
	// Update is called once per frame
	void Update ()
    {
        if (isAlive) {
            if (walk)
            {
                Walk();
            }
            else if (patrol)
            {
                Patrol();
            }
        }
    }
    private void Walk()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }
    private void Patrol()
    {

    }
    private void Move()
    {
        if (data.movement.canJump){
            StartCoroutine(Jump());
        }
        StartCoroutine(Attack());
    }



    IEnumerator Jump()
    {
        while (isAlive)
        {
            yield return new WaitForSecondsRealtime(timeBetweenJump);
            //add jump animation
            rb.AddForce(new Vector2(0, 200 * jumpForce));
        }
    }
    IEnumerator Attack()
    {
        while (isAlive)
        {
            //add attack animation
            int attackIndex = Random.Range(0, data.combat.attackSet.Count);
            attackDamage = data.combat.attackSet[attackIndex].damage;
            isAttacking = true;
            timeBetweenAttack = data.combat.attackSet[attackIndex].timeBetweenAttacks;
            yield return new WaitForSecondsRealtime(timeBetweenAttack);
            //Put event at the end of animation to set isAttackingFalse
        }
    }
    public void AttackFinished() {
        isAttacking = false;
    }
    public void DeathAnimFinished() {
        Destroy(gameObject);
    }
    public int InflictDamage()
    {
        if (isAttacking)
        {
            return attackDamage;
        }
        return data.combat.touchDamage;
    }
    public void ReceiveDamage(int dmg)
    {
        hp = hp - dmg;
        if (!isAttacking && hp < 0)
        {
            isAlive = false;
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        Destroy(gameObject);
        //play Death sound and animation
        //and destroy gameobject with event
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Hotel? Trigaro!");
        if(collision.tag == "Reverser" && gameObject.transform.name == "Boss")
        {
            direction = direction * (-1);
        }
    }
}
