using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{

    public enum Side {RIGHT, LEFT};
    public Side side;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(side == Side.LEFT)
        {
            if (other.CompareTag("Player1"))
            {
                ScoreUI.Instance.IncrementPlayer2Score();
            }
        }
        else if(side == Side.RIGHT)
        {
            if (other.CompareTag("Player2"))
            {
                ScoreUI.Instance.IncrementPlayer1Score();
            }
        }

    }
}
