using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    Rigidbody2D rb;
    public Transform hitDirectionBase;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    public void TakeDamage(float dmg, Vector2 dir)
    {
        health += dmg;
        GetComponent<PlayerMovement>().hitStun = true;
        rb.AddForce(dir * health, ForceMode2D.Impulse);
        
    }

}
