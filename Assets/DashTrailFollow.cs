using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTrailFollow : MonoBehaviour
{
    public GameObject target;
    public float followSpeed = 10;
    private SpriteRenderer sprite;
    private Animator animator;
    private string currentAnimState;
    private Animator playerAnimator;
    private SpriteRenderer playerSprite;
    public SpriteRenderer headSprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Vector3 newPosition;
        if (target != null)
        {
            newPosition = new Vector3(target.transform.position.x, target.transform.position.y, 0);

            float step = (transform.position - newPosition).magnitude * followSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
        }
        if (sprite.color.a > 0)
        {
            if (sprite != null)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - 0.6f * Time.deltaTime);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (playerSprite.flipX)
        {
            sprite.flipX = true;
            if (headSprite != null) headSprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
            if (headSprite != null) headSprite.flipX = false;
        }

        int animHash = (playerAnimator.GetCurrentAnimatorStateInfo(0).tagHash);

        Debug.Log(animHash);
        Debug.Log(Animator.StringToHash("Run"));


        if (Animator.StringToHash("Idle") == animHash) ChangeAnimationState("Idle");
        else if (Animator.StringToHash("Run") == animHash) ChangeAnimationState("Run");
        else if (Animator.StringToHash("Wall") == animHash) ChangeAnimationState("Wall");
        else if (Animator.StringToHash("Rise") == animHash) ChangeAnimationState("Rise");
        else if (Animator.StringToHash("Peak") == animHash) ChangeAnimationState("Peak");
        else if (Animator.StringToHash("Fall") == animHash) ChangeAnimationState("Fall");
    }

    void ChangeAnimationState(string newState)
    {
        if (currentAnimState == newState) return;
        animator.Play(newState);
        currentAnimState = newState;
    }
}
