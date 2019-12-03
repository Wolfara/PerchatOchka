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
    bool inLeft = false, inRight = false, jump = false;
    [HideInInspector]
    public int lifes;
    [HideInInspector]
    public int deathsByLR = 0;
    [HideInInspector]
    public int deathsByUp = 0;
    [HideInInspector]
    public int deathsByDown = 0;
    public Transform mizinec1, ukPalec1, ukPalec2, mizinec2, midPalec1, midPalec2, nnPalec1, nnPalec2, glove;
    bool leftActive = false, rightActive = false, jumpA = false;
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
        Debug.Log(glove.localEulerAngles.z);
        if (ukPalec1.localEulerAngles.x <= 320 && ukPalec2.localEulerAngles.x <= 285)
            if (mizinec1.localEulerAngles.x <= 320 && mizinec2.localEulerAngles.x <= 315)
                if (midPalec1.localEulerAngles.x <= 305 && midPalec2.localEulerAngles.x <= 290)
                    if (nnPalec1.localEulerAngles.x <= 315 && nnPalec2.localEulerAngles.x <= 315)
                    {
                        if (!prisel)
                            prisel = true;
                        else if (prisel)
                            prisel = false;
                    }
        
        if (mizinec1.localEulerAngles.z >= 342)
        {
            inRight = true;
        }
        if (mizinec1.localEulerAngles.z <= 337)
        {
            rightActive = false;
        }
        if (ukPalec1.localEulerAngles.z <= 18)
        {
            inLeft = true;
        }
        if (ukPalec1.localEulerAngles.z >= 23)
            leftActive = false;
        if (Input.GetKeyDown(KeyCode.A) && path > 1)
        {
            inLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            inRight = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && !prisel)
        {
            prisel = true;
        }
        else if (Input.GetKeyDown(KeyCode.S) && prisel)
        {
            prisel = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && !jump)
        {
            jump = true;
        }
        if (glove.localEulerAngles.z >= 200 && !jump&& glove.localEulerAngles.z < 260)
        {
            jump = true;
        }
        if (jump && !jumpA)
        {
            transform.position += new Vector3(0,3,0);
            jumpA = true;
            jump = false;
        }
        if (prisel)
        {
            GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
        }
        else if (!prisel)
        {
            GetComponent<BoxCollider>().size = new Vector3(1, 0.5f, 1);
        }
        if (inRight && path < 3 && !rightActive)
        {
            transform.position += new Vector3(0, 0, 2);
            path++;
            inRight = false;
            rightActive = true;
        }
        if (inLeft && path > 1 && !leftActive)
        {
            transform.position -= new Vector3(0, 0, 2);
            path--;
            inLeft = false;
            leftActive = true;
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
        if (other.tag == "Platform")
        {
            jumpA = false;
        }
    }

}
