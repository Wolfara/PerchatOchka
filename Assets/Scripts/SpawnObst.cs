using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObst : MonoBehaviour
{
    int deathsByUp, deathsByDown, deathsByLR;
    public GameObject player;
    int obstaclesGroupNumber;
    public GameObject[] obstaclesGroup;
    int totalDBU, totalDBD, totalDBLR;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        deathsByDown = player.GetComponent<Player>().deathsByDown;
        deathsByLR = player.GetComponent<Player>().deathsByLR;
        deathsByUp = player.GetComponent<Player>().deathsByUp;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (deathsByDown >= 2 && deathsByDown > deathsByLR && deathsByDown > deathsByUp)
            {
                obstaclesGroupNumber = 0;
                totalDBD = deathsByDown;
                other.GetComponent<Player>().deathsByDown = 0;
            }
            else if (deathsByUp >= 2 && deathsByUp > deathsByLR && deathsByUp > deathsByDown)
            {
                obstaclesGroupNumber = 1;
                totalDBU = deathsByUp;
                other.GetComponent<Player>().deathsByUp = 0;
            }
            else if (deathsByLR >= 2 && deathsByLR > deathsByDown && deathsByLR > deathsByUp)
            {
                obstaclesGroupNumber = 2;
                totalDBLR = deathsByLR;
                other.GetComponent<Player>().deathsByLR = 0;
            }
            else
                obstaclesGroupNumber = Random.Range(4, 6);
            Vector3 vec = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Instantiate(obstaclesGroup[obstaclesGroupNumber], vec, obstaclesGroup[obstaclesGroupNumber].transform.rotation);
            Destroy(gameObject);
        }
    }
}
