using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Health : MonoBehaviour
{
    public float health;
    Rigidbody2D rb;
    public Transform hitDirectionBase;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private CinemachineImpulseSource _impulseSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }



    public void TakeDamage(float dmg, Vector2 dir, GameObject otherPlayer)
    {
        if(GetComponent<Block>().isBlocking && GetComponent<Block>().parryTimer <= GetComponent<Block>().parryWindow)
        {
            CamShakeManager.instance.cameraShake(_impulseSource, 0.5f);
            GetComponent<CharacterAudio>().PlayParry();
            Vector2 direction = (otherPlayer.GetComponent<Health>().hitDirectionBase.position - transform.position).normalized;
            otherPlayer.GetComponent<Health>().TakeDamage(dmg, direction, gameObject);
        }

        if (!GetComponent<Block>().isBlocking)
        {
            AudioSource.PlayClipAtPoint(AudioManager.Instance.takeDamage, Camera.main.transform.position);
            _particle.Play();
            CamShakeManager.instance.cameraShake(_impulseSource,0.8f);
            health += dmg;
            GetComponent<PlayerMovement>().hitStun = true;
            rb.AddForce(dir * health, ForceMode2D.Impulse);
        }

        
    }

}
