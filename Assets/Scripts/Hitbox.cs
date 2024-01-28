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
            player.GetComponent<CharacterAudio>().PunchHit();
            Vector2 dir = (other.transform.GetComponent<Health>().hitDirectionBase.position - player.transform.position).normalized;
            other.GetComponent<Health>().TakeDamage(damage, dir, player.gameObject);
        }
        else
        {
            player.GetComponent<CharacterAudio>().PunchMiss();
        }
        //if (other.CompareTag("PowerUp"))
        //{
        //    PowerUp pup = other.GetComponent<PowerUp>();
        //    player.gameObject.AddComponent(pup.GetType());
        //    Destroy(other.gameObject);
        //}
    }

    
}
