using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{

    public enum Side {RIGHT, LEFT};
    public Side side;
    public float timer;
    private float timeLeft;
    private bool finishCount = false;
    private bool player1 = false;
    private bool player2 = false;
    [SerializeField] private ParticleSystem _particle;
    private void Start()
    {
        timeLeft = timer;
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
                if (other.CompareTag("Player1"))
                {
                   
                    player1 = true;
                }
                
            
        }
        else if (side == Side.RIGHT)
        {
            _particle.Play();
                if (other.CompareTag("Player2"))
                {
                    
                    player2 = true;
                }
               
            
        }

    }
}
