using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            other.GetComponent<Health>().TakeDamage(damage, dir, player.gameObject);
        }
        //if (other.CompareTag("PowerUp"))
        //{
        //    PowerUp pup = other.GetComponent<PowerUp>();
        //    player.gameObject.AddComponent(pup.GetType());
        //    Destroy(other.gameObject);
        //}
    }

    
}
