using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Hoop : MonoBehaviour
{

    public enum Side {RIGHT, LEFT};
    public Side side;
    public float timer;
    public float shakeForce;
    private float timeLeft;
    private bool finishCount = false;
    private bool player1 = false;
    private bool player2 = false;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private CinemachineImpulseSource _impulseSource;
    private void Start()
    {
        timeLeft = timer;
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        finishCount = false;
        player1 = false;
        player2 = false;
    }
    private void Update()
    {
        if (finishCount == true) {
        
            timeLeft -= Time.deltaTime;
        
        }
        if (timeLeft < 0)
        { 
            if(player1 == true)
            {
                ScoreUI.Instance.IncrementPlayer2Score();
                player1 = false;
            }
            else if(player2 == true)
            {
                ScoreUI.Instance.IncrementPlayer1Score();
                player2 = false;           
            } 

            finishCount = false;
            timeLeft = timer;
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        finishCount = true;
        if (side == Side.LEFT)
        {
            _particle.Play();
            CamShakeManager.instance.cameraShake(_impulseSource,shakeForce);
                if (other.CompareTag("Player1"))
                {
                   
                    player1 = true;
                }
                
            
        }
        else if (side == Side.RIGHT)
        {
            _particle.Play();
            CamShakeManager.instance.cameraShake(_impulseSource,shakeForce);
            if (other.CompareTag("Player2"))
                {
                    
                    player2 = true;
                }
               
            
        }

    }
}
