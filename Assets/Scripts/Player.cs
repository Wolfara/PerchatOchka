using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Transform mizinec1, ukPalec1, ukPalec2, mizinec2, midPalec1, midPalec2, nnPalec1, nnPalec2, glove, bPalec;
    bool leftActive = false, rightActive = false, jumpA = false;
    public Text hp;
    public int bonus = 0;
    public GameObject dead;
    float minMizinec, maxMizinec, deltaMizinec;
    float minBPalec, maxBPalec, deltaBPalec;
    bool gameStarted = false;
    bool mizinecCalibrated = false, bPalecCalibrated = false, kulakCalibrated = false;
    float minUkPalecK1, minUkPalecK2, minMidPalecK1, minMidPalecK2, minNNPalecK1, minNNPalecK2, minMizinecK1, minMizinecK2;
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
        if (gameStarted)
        {
            hp.text = lifes.ToString();
            Vector3 forceUp = new Vector3();
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            if (speed < maxSpeed)
                speed += 0.1f * Time.deltaTime;
            forceUp += transform.up * 7;
            Debug.Log(nnPalec2.localEulerAngles.x);
            if (ukPalec1.localEulerAngles.x <= minUkPalecK1 && ukPalec2.localEulerAngles.x <= minUkPalecK2)
                if (mizinec1.localEulerAngles.x <= minMizinecK2 && mizinec2.localEulerAngles.x <= minMizinecK1)
                    if (midPalec1.localEulerAngles.x <= minMidPalecK1 && midPalec2.localEulerAngles.x <= minMidPalecK2)
                        if (nnPalec1.localEulerAngles.x <= minNNPalecK1 && nnPalec2.localEulerAngles.x <= minNNPalecK2)
                        {
                            if (!prisel)
                                prisel = true;
                            else if (prisel)
                                prisel = false;
                        }

            if (mizinec1.localEulerAngles.z >= minMizinec)
            {
                inRight = true;
                if (maxMizinec > minMizinec)
                    maxMizinec = mizinec1.localEulerAngles.z;
            }
            if (mizinec1.localEulerAngles.z <= minMizinec-1)
            {
                rightActive = false;
            }
            if (bPalec.localEulerAngles.x <= minBPalec)
            {
                inLeft = true;
                if (maxBPalec < minBPalec)
                    maxBPalec = bPalec.localEulerAngles.z;
            }
            if (bPalec.localEulerAngles.x >= minBPalec+1)
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
            if (glove.localEulerAngles.z >= 200 && !jump && glove.localEulerAngles.z < 260 && !jumpA)
            {
                jump = true;
            }
            if (jump && !jumpA && prisel)
            {
                transform.position += new Vector3(0, 3, 0);
                jumpA = true;
                jump = false;
            }
            if (prisel)
            {
                GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
            }
            if (bonus == 10)
            {
                lifes++;
                bonus = 0;
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
            if (lifes <= 0)
            {
                dead.SetActive(true);
            }
        }
        if (mizinecCalibrated && bPalec && kulakCalibrated)
        {
            gameStarted = true;
        }
        if (!mizinecCalibrated)
        {
            for (float i = 0; i < 2;)
                if (mizinec1.localEulerAngles.z > 340.5)
                {
                    i += 1 * Time.deltaTime;
                    minMizinec = mizinec1.localEulerAngles.z;
                    if (i >= 1.5)
                    {
                        mizinecCalibrated = true;
                        break;
                    }
                }
        }

        if (!bPalecCalibrated)
        {
            for (float i = 0; i < 2;)
                if (bPalec.localEulerAngles.x < 55)
                {
                    i += 1 * Time.deltaTime;
                    minBPalec = bPalec.localEulerAngles.x;
                    if (i >= 1.5)
                    {
                        bPalecCalibrated = true;
                        break;
                    }
                }
        }
        if (!kulakCalibrated)
        {
            for (float i = 0; i < 2;)
                if (ukPalec1.localEulerAngles.x <= 325 && ukPalec2.localEulerAngles.x <= 310 && mizinec1.localEulerAngles.x < 345 && mizinec2.localEulerAngles.x < 347)
                    if (midPalec1.localEulerAngles.x < 312 && midPalec2.localEulerAngles.x < 310 && nnPalec1.localEulerAngles.x < 312 && nnPalec2.localEulerAngles.x < 290)
                    {
                        i += 1 * Time.deltaTime;
                        minUkPalecK1 = ukPalec1.localEulerAngles.x; minUkPalecK2 = ukPalec2.localEulerAngles.x;
                        minMidPalecK1 = midPalec1.localEulerAngles.x; minMidPalecK2 = midPalec2.localEulerAngles.x;
                        minNNPalecK1 = nnPalec1.localEulerAngles.x; minNNPalecK2 = nnPalec2.localEulerAngles.x;
                        minMizinecK1 = mizinec1.localEulerAngles.x; minMizinecK2 = mizinec2.localEulerAngles.x;
                        if (i >= 1.5)
                        {
                            kulakCalibrated = true;
                            break;
                        }
                    }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other, other);
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
        if (other.tag == "Bonus")
        {
            bonus++;
            Destroy(other);
        }
    }

}
