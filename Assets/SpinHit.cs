using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinHit : MonoBehaviour
{
    public string otherPlayerTag;
    public GameObject player;
    public float damage;

    bool startTimer;

    public float timeToReappear;
    float timer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(otherPlayerTag))
        {
            AudioSource.PlayClipAtPoint(AudioManager.Instance.yellowAttackHit, Camera.main.transform.position);
            Vector2 dir = (other.transform.GetComponent<Health>().hitDirectionBase.position - player.transform.position).normalized;
            other.GetComponent<Health>().TakeDamage(damage, dir, player.gameObject);
            startTimer = true;
            gameObject.SetActive(false);
        }
    }

    public void SpinUpdate()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            if(timer >= timeToReappear)
            {
                gameObject.SetActive(true);
                timer = 0;
            }
        }
    }
}
