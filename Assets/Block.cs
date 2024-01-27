using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{

    public bool isBlocking;
    public KeyCode blockKey;

    public GameObject blockObj;

    public float maxBlockTime;
    public float parryWindow;
    [HideInInspector] public float blockTimer;
    [HideInInspector] public float parryTimer;

    public float blockCooldown;
    float cdTimer;

    bool onCooldown;

    GameObject spawnedBlockObj;

    public GameObject blockText;

    // Start is called before the first frame update
    void Start()
    {
        blockText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<PlayerMovement>().hitStun && !onCooldown)
        {
            if (Input.GetKeyDown(blockKey))
            {
                if(spawnedBlockObj == null)
                {
                    spawnedBlockObj = Instantiate(blockObj, transform);
                }
                
            }

            if (Input.GetKey(blockKey))
            {
                if (spawnedBlockObj != null)
                {
                    spawnedBlockObj.SetActive(true);
                    isBlocking = true;
                }

            }

            if (Input.GetKeyUp(blockKey))
            {
                isBlocking = false;
                parryTimer = 0;
            }

            if (!isBlocking)
            {
                blockText.SetActive(false);
                if(spawnedBlockObj != null)
                {
                    spawnedBlockObj.SetActive(false);
                }
                
            }


            if (isBlocking)
            {
                blockText.SetActive(true);
                blockText.GetComponent<TextMeshPro>().color = Color.white;
                blockText.GetComponent<TextMeshPro>().text = (Mathf.Round((maxBlockTime - blockTimer)*10.0f)*0.1f).ToString();

                parryTimer += Time.deltaTime;

                blockTimer += Time.deltaTime;
                if(blockTimer >= maxBlockTime-1)
                {
                    blockText.SetActive(false);
                    isBlocking = false;
                    Destroy(spawnedBlockObj);
                    blockTimer = 0;
                    parryTimer = 0;
                    onCooldown = true;
                }
            }
        }

        if (onCooldown)
        {
            blockText.SetActive(true);
            blockText.GetComponent<TextMeshPro>().color = Color.red;
            blockText.GetComponent<TextMeshPro>().text = (Mathf.Round((blockCooldown - cdTimer) * 10.0f) * 0.1f).ToString();

            cdTimer += Time.deltaTime;
            if(cdTimer >= blockCooldown - 1)
            {
                blockText.SetActive(false);
                blockText.GetComponent<TextMeshPro>().text = (Mathf.Round((maxBlockTime - blockTimer) * 10.0f) * 0.1f).ToString();
                onCooldown = false;
                cdTimer = 0;
            }
        }
    }
}
