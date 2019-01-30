using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    public Animator anim;
    public PlayerCombat combat;
    public float walkingSpeed = 0.05f; //default value, could be changed by inspector
    public float jumpHeight = 10; //default value, could be changed by inspector
    public int defaultHeight = 5;
    public bool isWalking;
    public bool isSwimming;
    public bool isAttacking;
    public bool isAlive;
    public float attackDuration = 0.1f;

    public GameObject background;

    private bool isLongAttackActivated;
    public bool isJumping = false;
    private bool jumpTrigger = false;
    private float timer = 0;

    void Start()
    {
        player = this.gameObject;
        rb = player.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        combat = GetComponent<PlayerCombat>();
        //player.gameObject.transform.position = new Vector3(-3, 0, 0);
    }


    void FixedUpdate()
    {


        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        //rb.AddForce(movement * walkingSpeed);
        /*
        Vector3 movement = new Vector3(moveHorizontal * walkingSpeed * Time.deltaTime / 5.0f, 0.0f, 0.0f);
        player.gameObject.transform.position += movement;

        if(Input.GetKey(KeyCode.Space))
        {
            jumpTrigger = true;
        }

        if (!isJumping && jumpTrigger)
        {
            jump();
            jumpTrigger = false;
        }

        else if(!isJumping)
        {
            miniJump();
        }*/

        if (isAlive) {
            if (isSwimming)
            {
                WaterMovement();
            }
            else {
                LandMovement();
            }

            if(isAttacking && isLongAttackActivated && timer >= attackDuration)
            {
                    isAttacking = false;
                    isLongAttackActivated = false;
                    timer = 0;
            }
        
            if (isAttacking && isLongAttackActivated && timer <= attackDuration)
            {
                timer += Time.deltaTime;
                player.transform.position = new Vector3(player.transform.position.x + 1, 5.0f, 0.0f);
            }
        }
    }

    public void LandMovement()
    {
        rb.gravityScale = 1.0f;
        Debug.Log("LandMovement");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal * walkingSpeed * Time.deltaTime , 0.0f, 0.0f);
        player.gameObject.transform.position += movement;
        //rb.AddForce(movement * walkingSpeed);

        if (Input.GetKey(KeyCode.Space))
        {
            jumpTrigger = true;
        }

        if (!isJumping && jumpTrigger)
        {
            isWalking = true;
            jump();
            jumpTrigger = false;
        }
        Debug.Log("HP::  "+ combat.health + "   combatCD:: " + combat.cooldown);
        if (Input.GetKeyDown(KeyCode.J))
        {
            combat.FireProjectile();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(NormalAttack());
        }
        else if(!isJumping)
        {
            isWalking = true;
            miniJump();
        }
        anim.SetBool("isWalking", isWalking);

        if (Input.GetKey(KeyCode.H) && !isLongAttackActivated)
        {
            longAttack();
            Debug.Log("Long jump key pressed");
        }

        if (Input.GetKey(KeyCode.K) )
        {
            jumpHeight = 12;
        }
    }

    public IEnumerator NormalAttack() {
        anim.SetBool("normalAttack", true);
        yield return new WaitForSecondsRealtime(0.55f);
        anim.SetBool("normalAttack", false);
    }
    public void WaterMovement() {
        Debug.Log("WaterMovement");
    if (Input.GetKey(KeyCode.W) && transform.position.y < 3.17f)
    {
        player.transform.Translate(Vector3.up * Time.deltaTime * walkingSpeed / 2f);

    }
    if (Input.GetKey(KeyCode.S) && transform.position.y > -3.17f)
    {
        player.transform.Translate(Vector3.down * Time.deltaTime * walkingSpeed / 2f);

    }
    if (Input.GetKey(KeyCode.A) && transform.position.x > -8f)
    {
        player.transform.Translate(Vector3.left * Time.deltaTime * walkingSpeed / 2f);
        background.transform.Translate(Vector3.left * Time.deltaTime * walkingSpeed / 6f);

     }
    if (Input.GetKey(KeyCode.D))
    {
        player.transform.Translate(Vector3.right * Time.deltaTime * walkingSpeed / 2f);

            if(player.transform.position.x <= 53.0f)
            {

                background.transform.Translate(Vector3.right * Time.deltaTime * walkingSpeed / 6f);
            }

     }

    }

    void longAttack()
    {
        isAttacking = true;
        isLongAttackActivated = true;

    }
    public void jump()
    {
        jumpTrigger = true;
        isJumping = true;
        rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
    }

    public void miniJump()
    {
        isJumping = true;
        rb.AddForce(new Vector2(0, jumpHeight/3), ForceMode2D.Impulse);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isJumping = false;
            isWalking = false;
        }
    }

    public void LeaveOcean() {
        rb.gravityScale = 1.0f;
        isSwimming = false;
        isWalking = true;
    }

}
