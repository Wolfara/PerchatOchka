using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
    int sp;
    public GameObject bonus;
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
        if(other.tag == "Player")
        {
            sp = Random.Range(1, 3);
            if (sp == 1)
                Instantiate(bonus, new Vector3(transform.position.x - 12, transform.position.y, transform.position.z), transform.rotation);
        }
    }
}
