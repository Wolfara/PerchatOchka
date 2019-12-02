using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByLR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<Move>().lifes--;
            col.GetComponent<Move>().deathsByLR++;
            col.GetComponent<Move>().speed = 0;
            Destroy(gameObject);
        }
    }
}
