using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float maxSpeed;
    float minSpeed;
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
        minSpeed = 2;
        speed = minSpeed;
        path = 2;
        maxSpeed = 20;
        rb = gameObject.GetComponent<Rigidbody>();
        prisel = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forceUp = new Vector3();
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        if (speed < maxSpeed)
            speed += 0.1f * Time.deltaTime;
        forceUp += transform.up * 7;
        if (Input.GetKeyDown(KeyCode.A) && path > 1)
        {
            transform.position -= new Vector3(0, 0, 2);
            path--;
        }
        if (Input.GetKeyDown(KeyCode.D) && path < 3)
        {
            transform.position += new Vector3(0, 0, 2);
            path++;
        }
        if (Input.GetKeyDown(KeyCode.S) && !prisel)
        {
            GetComponent<BoxCollider>().size = new Vector3(1, 0.5f, 1);
            GetComponent<CapsuleCollider>().height = 0.5f;
            prisel = true;
        }
        else if (Input.GetKeyDown(KeyCode.S) && prisel)
        {
            GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
            GetComponent<CapsuleCollider>().height = 1.1f;
            transform.position += new Vector3(0, 0.3f, 0);
            prisel = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(forceUp, ForceMode.Impulse);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other, other);
        if (other.tag == "ObstLR")
        {
            Debug.Log("Life-");
            speed = minSpeed;
            lifes--;
            deathsByLR++;
            Destroy(other);
        }
        if (other.tag == "ObstUp")
        {
            Debug.Log("Life-");
            lifes--;
            deathsByUp++;
            Destroy(other);
        }
    }

}
