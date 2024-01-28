using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator animator;
    private string currentAnimState;
    private Rigidbody2D rb;
    private PlayerMovement pMove;
    private KeyCode attackKey;
    public bool isRedAttack;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        pMove = transform.parent.GetComponent<PlayerMovement>();
        attackKey = transform.parent.GetComponent<Attack>().attackKey;

    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetAxis("Horizontal") > 0) sprite.flipX = false;
        //else if (Input.GetAxis("Horizontal") < 0) sprite.flipX = true;

        if (isRedAttack)
        {
            if (Input.GetKeyDown(attackKey))
            {
                ChangeAnimationState("Attack");
            }
        }


        
        if (!pMove.grounded)
        {
            //Air
            if (rb.velocity.y > 0.1f)
            {
                ChangeAnimationState("Rise");
            }
            else if (rb.velocity.y < 0.1f)
            {
                ChangeAnimationState("Peak");
            }
            else
            {
                ChangeAnimationState("Fall");
            }
        }
        else
        {
            if (rb.velocity.x > 0.2f || rb.velocity.x < -0.2f)
            {

                ChangeAnimationState("Run");
            }
            else
            {
                ChangeAnimationState("Idle");
            }
        }



    }

    void ChangeAnimationState(string newState)
    {
        if (currentAnimState == newState) return;
        animator.Play(newState);
        currentAnimState = newState;
    }
}
