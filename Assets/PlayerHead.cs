using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator animator;
    private string currentAnimState;
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerSprite.flipX) sprite.flipX = true;
        else sprite.flipX = false;

        int animHash = 0;
        if (playerAnimator.isActiveAndEnabled)
        {
            animHash = (playerAnimator.GetCurrentAnimatorStateInfo(0).tagHash);
        }

        if (Animator.StringToHash("Idle") == animHash) ChangeAnimationState("Idle");
        else if (Animator.StringToHash("Run") == animHash) ChangeAnimationState("Run");
        else if (Animator.StringToHash("Wall") == animHash) ChangeAnimationState("Wall");
        else if (Animator.StringToHash("Rise") == animHash) ChangeAnimationState("Rise");
        else if (Animator.StringToHash("Peak") == animHash) ChangeAnimationState("Peak");
        else if (Animator.StringToHash("Fall") == animHash) ChangeAnimationState("Fall");
        else if (Animator.StringToHash("Death") == animHash) ChangeAnimationState("Death");
        else if (Animator.StringToHash("Respawn") == animHash) ChangeAnimationState("Respawn");
    }

    void ChangeAnimationState(string newState)
    {
        if (currentAnimState == newState) return;
        animator.Play(newState);
        currentAnimState = newState;
    }
}
