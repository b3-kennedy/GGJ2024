using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    [HideInInspector] public GameObject shootingPlayer;
    public Transform hitDirectionBase;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            Vector2 dir = -(hitDirectionBase.position - transform.position).normalized;
            other.gameObject.GetComponent<Health>().TakeDamage(damage, dir, shootingPlayer.gameObject);
        }
        Destroy(gameObject);
    }

}
