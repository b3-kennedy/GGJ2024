using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    Rigidbody2D rb;
    public Transform hitDirectionBase;
    [SerializeField] private ParticleSystem _particle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    public void TakeDamage(float dmg, Vector2 dir, GameObject otherPlayer)
    {
        if(GetComponent<Block>().isBlocking && GetComponent<Block>().parryTimer <= GetComponent<Block>().parryWindow)
        {
            GetComponent<CharacterAudio>().PlayParry();
            if (otherPlayer.GetComponent<ProjectileAttack>())
            {
                AudioSource.PlayClipAtPoint(AudioManager.Instance.projectileParry, Camera.main.transform.position);
            }
            Vector2 direction = (otherPlayer.GetComponent<Health>().hitDirectionBase.position - transform.position).normalized;
            otherPlayer.GetComponent<Health>().TakeDamage(dmg, direction, gameObject);
        }

        if (!GetComponent<Block>().isBlocking)
        {
            AudioSource.PlayClipAtPoint(AudioManager.Instance.takeDamage, Camera.main.transform.position);

            _particle.Play();

            health += dmg;
            GetComponent<PlayerMovement>().hitStun = true;
            rb.AddForce(dir * health, ForceMode2D.Impulse);
        }

        
    }

}
