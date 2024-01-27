using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [HideInInspector] public string tagToCompare;
    [HideInInspector] public float damage;
    [HideInInspector] public Transform player;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToCompare))
        {
            Vector2 dir = (other.transform.GetComponent<Health>().hitDirectionBase.position - player.transform.position).normalized;
            other.GetComponent<Health>().TakeDamage(damage, dir);
        }
    }

    
}
