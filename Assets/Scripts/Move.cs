using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    float maxSpeed;
    Rigidbody rb;
    int path;
    bool prisel;
    [HideInInspector]
    public int lifes;
    [HideInInspector]
    public int deathsByLR = 0;
    [HideInInspector]
    public int deathsByUp = 0;
    [HideInInspector]
    public int deathsByDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        lifes = 3;
        speed = 1;
        path = 2;
        maxSpeed = 10;
        rb = gameObject.GetComponent<Rigidbody>();
        prisel = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = new Vector3();
        Vector3 forceUp = new Vector3();
        forceUp += transform.up * 7;
        force += transform.forward * speed * Time.deltaTime;
        rb.AddForce(force, ForceMode.Impulse);
        if (speed < maxSpeed)
            speed += 0.1f * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A) && path > 1)
        {
            gameObject.transform.position -= new Vector3(0, 0, 2);
            path--;
        }
        if (Input.GetKeyDown(KeyCode.D) && path < 3)
        {
            gameObject.transform.position += new Vector3(0, 0, 2);
            path++;
        }
        if (Input.GetKeyDown(KeyCode.S) && prisel == false)
        {
            gameObject.GetComponent<BoxCollider>().size = new Vector3(1, 0.5f, 1);
            prisel = true;
        }
        else if (Input.GetKeyDown(KeyCode.S) && prisel == true)
        {
            gameObject.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
            gameObject.transform.position += new Vector3(0, 0.3f, 0);
            prisel = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(forceUp, ForceMode.Impulse);
        }
    }

}
