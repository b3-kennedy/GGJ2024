using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectileSpawn;
    public float fireRate;
    float timer;
    public float projectileForce;
    public float damage;
    public KeyCode attackKey;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            if (Input.GetKeyDown(attackKey))
            {
                GameObject proj = Instantiate(projectile, projectileSpawn.position, Quaternion.Euler(0,transform.eulerAngles.y,0));
                proj.GetComponent<Projectile>().damage = damage;
                proj.GetComponent<Projectile>().shootingPlayer = gameObject;
                proj.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileForce, ForceMode2D.Impulse);
                timer = fireRate;
            }
        }

    }
}
