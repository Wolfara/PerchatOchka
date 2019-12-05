﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObst : MonoBehaviour
{
    float deltaBPalec, deltaMizinec;
    public GameObject player;
    int obstaclesGroupNumber;
    public GameObject[] obstaclesGroup;
    int delayb, delaym;
    // Start is called before the first frame update
    void Start()
    {
        delayb = 0;
        delaym = 0;
    }

    // Update is called once per frame
    void Update()
    {
        deltaBPalec = player.GetComponent<Player>().deltaBPalec;
        deltaMizinec = player.GetComponent<Player>().deltaMizinec;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (deltaBPalec > 300)
            {
                if (deltaBPalec - 310 < deltaMizinec - 4&&delayb<=0)
                {
                    obstaclesGroupNumber = 2;
                    delayb = 3;
                }
                else if (deltaBPalec - 314 > deltaMizinec&& delaym<=0)
                {
                    obstaclesGroupNumber = 2;
                    delaym = 3;
                }
            }
            else if (deltaBPalec < 300)
            {
                if (deltaBPalec - 34 < deltaMizinec - 4&&delayb<=0)
                {
                    obstaclesGroupNumber = 2;
                    delayb = 3;
                }
                else if (deltaBPalec - 38 > deltaMizinec&& delaym<=0)
                {
                    obstaclesGroupNumber = 2;
                    delaym = 3;
                }
            }
            else
            {
                obstaclesGroupNumber = Random.Range(4, 6);
            }
            Vector3 vec = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Instantiate(obstaclesGroup[obstaclesGroupNumber], vec, obstaclesGroup[obstaclesGroupNumber].transform.rotation);
            Destroy(gameObject);
            delaym--; delayb--;
        }
    }
}
