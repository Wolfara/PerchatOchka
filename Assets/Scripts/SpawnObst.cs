using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObst : MonoBehaviour
{
    float deltaBPalec, deltaMizinec;
    public GameObject player;
    int obstaclesGroupNumber;
    public GameObject[] obstaclesGroup;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (deltaBPalec > 300)
            {
                if (deltaBPalec - 310 < deltaMizinec - 4)
                {
                    obstaclesGroupNumber = 2;
                }
                else if (deltaBPalec - 313 > deltaMizinec)
                {
                    obstaclesGroupNumber = 2;
                }
            }
            else if (deltaBPalec < 300)
            {
                if (deltaBPalec - 34 < deltaMizinec - 4)
                {
                    obstaclesGroupNumber = 2;
                }
                else if (deltaBPalec - 38 > deltaMizinec)
                {
                    obstaclesGroupNumber = 2;
                }
            }
            else
            {
                obstaclesGroupNumber = Random.Range(4, 6);
            }
            Vector3 vec = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Instantiate(obstaclesGroup[obstaclesGroupNumber], vec, obstaclesGroup[obstaclesGroupNumber].transform.rotation);
            Destroy(gameObject);
        }
    }
}
