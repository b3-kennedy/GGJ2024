using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI Instance;
    public int player1Score;
    public int player2Score;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    
    public void IncrementPlayer1Score()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();

        GameManager.Instance.player1.GetComponent<Health>().health = 0;
        GameManager.Instance.player2.GetComponent<Health>().health = 0;
        GameManager.Instance.player1.transform.position = GameManager.Instance.player1StartPos;
        GameManager.Instance.player2.transform.position = GameManager.Instance.player2StartPos;
    }

    public void IncrementPlayer2Score()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();

        GameManager.Instance.player1.GetComponent<Health>().health = 0;
        GameManager.Instance.player2.GetComponent<Health>().health = 0;
        GameManager.Instance.player1.transform.position = GameManager.Instance.player1StartPos;
        GameManager.Instance.player2.transform.position = GameManager.Instance.player2StartPos;
    }

}
