using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnObst2LVL : MonoBehaviour
{
    public GameObject player;
    float deltaBPalec, deltaMizinec;
    int delayb, delaym, obstaclesGroupNumber;
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
            //if (deltaBPalec > 300)
            //{
            //    if (deltaBPalec - 310 < deltaMizinec - 4 && delayb <= 0)
            //    {
            //        obstaclesGroupNumber = 2;
            //        player.GetComponent<Player>().delayB = 3;
            //        Debug.Log("Gleb");
            //    }
            //    else if (deltaBPalec - 313 > deltaMizinec && delaym <= 0)
            //    {
            //        obstaclesGroupNumber = 2;
            //        player.GetComponent<Player>().delayM = 3;
            //        Debug.Log("Hleb");
            //    }
            //}
            //else if (deltaBPalec < 300)
            //{
            //    if (deltaBPalec - 34 < deltaMizinec - 4 && delaym <= 0)
            //    {
            //        obstaclesGroupNumber = 2;
            //        player.GetComponent<Player>().delayM = 3;
            //    }
            //    else if (deltaBPalec - 38 > deltaMizinec && delayb <= 0)
            //    {
            //        obstaclesGroupNumber = 2;
            //        player.GetComponent<Player>().delayB = 3;
            //    }
            //}

            obstaclesGroupNumber = Random.Range(4, 6);
            Vector3 vec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(obstaclesGroup[obstaclesGroupNumber], vec, obstaclesGroup[obstaclesGroupNumber].transform.rotation);
            Destroy(gameObject);
            //player.GetComponent<Player2LVL>().delayM--; player.GetComponent<Player2LVL>().delayB--;
        }
    }
}