using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject blockTimer1;
    public GameObject blockTimer2;

    [HideInInspector] public GameObject player1;
    [HideInInspector] public GameObject player2;

    public Vector2 player1StartPos;
    public Vector2 player2StartPos;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        player1 = Instantiate(player1Prefab, new Vector3(player1StartPos.x, player1StartPos.y,0), Quaternion.identity);
        player2 = Instantiate(player2Prefab, new Vector3(player2StartPos.x,player2StartPos.y,0), Quaternion.identity);
        blockTimer1.GetComponent<FollowPlayer>().objectToFollow = player1.transform.GetChild(3);
        blockTimer2.GetComponent<FollowPlayer>().objectToFollow = player2.transform.GetChild(3);
        player1.GetComponent<Block>().blockText = blockTimer1;
        player2.GetComponent<Block>().blockText = blockTimer2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
