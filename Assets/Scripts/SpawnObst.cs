using System.Collections;
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
                if (deltaBPalec - 310 < deltaMizinec - 4 && delayb <= 0)
                {
                    obstaclesGroupNumber = 2;
                    player.GetComponent<Player>().delayB = 3;
                    Debug.Log("Gleb");
                }
                else if (deltaBPalec - 313 > deltaMizinec && delaym <= 0)
                {
                    obstaclesGroupNumber = 2;
                    player.GetComponent<Player>().delayM = 3;
                    Debug.Log("Hleb");
                }
            }
            else if (deltaBPalec < 300)
            {
                if (deltaBPalec - 34 < deltaMizinec - 4 && delaym <= 0)
                {
                    obstaclesGroupNumber = 2;
                    player.GetComponent<Player>().delayM = 3;
                    Debug.Log("He Gleb");
                }
                else if (deltaBPalec - 38 > deltaMizinec && delayb <= 0)
                {
                    obstaclesGroupNumber = 2;
                    player.GetComponent<Player>().delayB = 3;
                    Debug.Log("He Hleb");
                }
            }
            else
            {
                obstaclesGroupNumber = Random.Range(4, 6);
            }
            Vector3 vec = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Instantiate(obstaclesGroup[obstaclesGroupNumber], vec, obstaclesGroup[obstaclesGroupNumber].transform.rotation);
            Destroy(gameObject);
            player.GetComponent<Player>().delayM--; player.GetComponent<Player>().delayB--;
        }
    }
}
