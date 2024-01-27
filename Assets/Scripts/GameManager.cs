using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int scoreToWin;

    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject blockTimer1;
    public GameObject blockTimer2;

    [HideInInspector] public GameObject player1;
    [HideInInspector] public GameObject player2;

    public Vector2 player1StartPos;
    public Vector2 player2StartPos;

    [Header("Bounds")]
    public Vector2 topLeft;
    public Vector2 topRight;
    public Vector2 bottomLeft;
    public Vector2 bottomRight;

    [Header("Power Ups")]
    public List<GameObject> powerUpOrbs;
    public float minSpawnTime;
    public float maxSpawnTime;
    float powerUpTime;
    float timer;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        player1 = Instantiate(player1Prefab, new Vector3(player1StartPos.x, player1StartPos.y,0), Quaternion.identity);
        player2 = Instantiate(player2Prefab, new Vector3(player2StartPos.x,player2StartPos.y,0), Quaternion.identity);
        blockTimer1.GetComponent<FollowPlayer>().objectToFollow = player1.transform.GetChild(3);
        blockTimer2.GetComponent<FollowPlayer>().objectToFollow = player2.transform.GetChild(3);
        player1.GetComponent<Block>().blockText = blockTimer1;
        player2.GetComponent<Block>().blockText = blockTimer2;

        GetRandomPowerUpTime();
    }
    
    
    

    void GetRandomPowerUpTime()
    {
        powerUpTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if(timer >= powerUpTime)
        {
            int randomIndex = Random.Range(0, powerUpOrbs.Count);

            GameObject powerUp = Instantiate(powerUpOrbs[randomIndex], new Vector3(Random.Range(topLeft.x, topRight.x),Random.Range(topLeft.y, bottomLeft.y),0), Quaternion.identity);
            GetRandomPowerUpTime();
            timer = 0;
        }


        if(ScoreUI.Instance.player1Score == scoreToWin)
        {
            Debug.Log("Player 1 Wins");
        }

        if(ScoreUI.Instance.player2Score == scoreToWin)
        {
            Debug.Log("Player 2 Wins");
        }
    }
}
