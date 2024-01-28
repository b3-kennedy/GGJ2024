using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int scoreToWin;

    public GameObject redPrefab;
    public GameObject bluePrefab;
    public GameObject yellowPrefab;


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
        DontDestroyOnLoad(gameObject);
    }

    public void PickRed(int num)
    {
        if(num == 1)
        {
            player1Prefab = redPrefab;
        }
        else if(num == 2)
        {
            player2Prefab = redPrefab;
        }
    }

    public void PickBlue(int num)
    {
        if (num == 1)
        {
            player1Prefab = bluePrefab;
        }
        else if (num == 2)
        {
            player2Prefab = bluePrefab;
        }
    }

    public void PickYellow(int num)
    {
        if (num == 1)
        {
            player1Prefab = yellowPrefab;
        }
        else if (num == 2)
        {
            player2Prefab = yellowPrefab;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        


        //GetRandomPowerUpTime();
    }

    public void OnStartGame()
    {
        player1 = Instantiate(player1Prefab, new Vector3(player1StartPos.x, player1StartPos.y, 0), Quaternion.identity);
        player2 = Instantiate(player2Prefab, new Vector3(player2StartPos.x, player2StartPos.y, 0), Quaternion.identity);

        blockTimer1 = GameObject.Find("BlockTimerPlayer1");
        blockTimer2 = GameObject.Find("BlockTimerPlayer2");

        Debug.Log(blockTimer1);
        Debug.Log(blockTimer2);

        blockTimer1.GetComponent<FollowPlayer>().objectToFollow = player1.transform.GetChild(3);
        blockTimer2.GetComponent<FollowPlayer>().objectToFollow = player2.transform.GetChild(3);
        player1.GetComponent<Block>().blockText = blockTimer1;
        player2.GetComponent<Block>().blockText = blockTimer2;

        player2.GetComponent<PlayerMovement>().jumpKey = KeyCode.I;
        player2.GetComponent<PlayerMovement>().axisName = "Player2Horizontal";
        player2.GetComponent<Block>().blockKey = KeyCode.O;
        player2.GetComponent<Attack>().attackKey = KeyCode.U;
        player2.GetComponent<FallThrough>().fallKey = KeyCode.K;
        player2.tag = "Player2";
        player2.GetComponent<Attack>().otherPlayerTag = "Player1";
        if (player2.GetComponent<SpawnAttack>())
        {
            player2.GetComponent<SpawnAttack>().otherPlayer = "Player1";
            player2.GetComponent<SpawnAttack>().player = player2;
        }
        if (player2.GetComponent<ProjectileAttack>())
        {
            player2.GetComponent<ProjectileAttack>().attackKey = KeyCode.U;
        }


        player1.GetComponent<PlayerMovement>().jumpKey = KeyCode.W;
        player1.GetComponent<PlayerMovement>().axisName = "Horizontal";
        player1.GetComponent<Block>().blockKey = KeyCode.Q;
        player1.GetComponent<Attack>().attackKey = KeyCode.E;
        player1.GetComponent<FallThrough>().fallKey = KeyCode.S;
        player1.tag = "Player1";
        player1.GetComponent<Attack>().otherPlayerTag = "Player2";
        if (player1.GetComponent<SpawnAttack>())
        {
            player1.GetComponent<SpawnAttack>().otherPlayer = "Player2";
            player1.GetComponent<SpawnAttack>().player = player1;
        }
        if (player1.GetComponent<ProjectileAttack>())
        {
            player1.GetComponent<ProjectileAttack>().attackKey = KeyCode.E;
        }
    }


    //void GetRandomPowerUpTime()
    //{
    //    powerUpTime = Random.Range(minSpawnTime, maxSpawnTime);
    //}

    // Update is called once per frame
    void Update()
    {

        //timer += Time.deltaTime;

        //if(timer >= powerUpTime)
        //{
        //    int randomIndex = Random.Range(0, powerUpOrbs.Count);

        //    GameObject powerUp = Instantiate(powerUpOrbs[randomIndex], new Vector3(Random.Range(topLeft.x, topRight.x),Random.Range(topLeft.y, bottomLeft.y),0), Quaternion.identity);
        //    GetRandomPowerUpTime();
        //    timer = 0;
        //}

        if (ScoreUI.Instance)
        {
            if (ScoreUI.Instance.player1Score == scoreToWin)
            {
                if(player1.GetComponent<PlayerMovement>().colour == "Red")
                {
                    ScoreUI.Instance.redWin.SetActive(true);
                }
                else if(player1.GetComponent<PlayerMovement>().colour == "Blue")
                {
                    ScoreUI.Instance.blueWin.SetActive(true);
                }
                else if(player1.GetComponent<PlayerMovement>().colour == "Yellow")
                {
                    ScoreUI.Instance.yellowWin.SetActive(true);
                }
                Debug.Log("Player 1 Wins");
                StartCoroutine(Restart());
            }

            if (ScoreUI.Instance.player2Score == scoreToWin)
            {
                if (player2.GetComponent<PlayerMovement>().colour == "Red")
                {
                    ScoreUI.Instance.redWin.SetActive(true);
                }
                else if (player2.GetComponent<PlayerMovement>().colour == "Blue")
                {
                    ScoreUI.Instance.blueWin.SetActive(true);
                }
                else if (player2.GetComponent<PlayerMovement>().colour == "Yellow")
                {
                    ScoreUI.Instance.yellowWin.SetActive(true);
                }
                Debug.Log("Player 2 Wins");
                StartCoroutine(Restart());
            }


        }


    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        
    }

}
