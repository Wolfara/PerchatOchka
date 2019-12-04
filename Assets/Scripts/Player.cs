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
    public Transform mizinec1, ukPalec1, ukPalec2, mizinec2, midPalec1, midPalec2, nnPalec1, nnPalec2, glove, bPalec;
    bool leftActive = false, rightActive = false, jumpA = false;
    public Text hp, calibrating;
    public GameObject calibratingGO;
    public int bonus = 0;
    public GameObject dead;
    float minMizinec, maxMizinec, deltaMizinec;
    float minBPalec = 361, maxBPalec, deltaBPalec;
    public bool gameStarted = false;
    public bool mizinecCalibrated = false, bPalecCalibrated = false, kulakCalibrated = false, kulakCalibrating;
    float minUkPalecK1 = 361, minUkPalecK2 = 361, minMidPalecK1 = 361, minMidPalecK2 = 361, minNNPalecK1 = 361, minNNPalecK2 = 361, minMizinecK1 = 361, minMizinecK2 = 361;
    public float timer = 0;
    bool bPalecCalibrating = false, mizinecCalibrating = false;

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
            Debug.Log(deltaBPalec);
            if (ukPalec1.localEulerAngles.x - 1 <= minUkPalecK1 && ukPalec2.localEulerAngles.x - 1 <= minUkPalecK2)
                if (mizinec1.localEulerAngles.x - 1 <= minMizinecK2)
                    if (midPalec1.localEulerAngles.x - 1 <= minMidPalecK1 && midPalec2.localEulerAngles.x - 1 <= minMidPalecK2)
                        if (nnPalec1.localEulerAngles.x - 1 <= minNNPalecK1)
                        {
                            if (!prisel)
                                prisel = true;
                            else if (prisel)
                                prisel = false;
                        }

            if (mizinec1.localEulerAngles.z + 1 >= minMizinec)
            {
                inRight = true;
                if (mizinec1.localEulerAngles.z > maxMizinec)
                    maxMizinec = mizinec1.localEulerAngles.z;
                if (deltaMizinec-10 >= 7)
                    minMizinec += 3;
            }
            if (mizinec1.localEulerAngles.z <= minMizinec - 1)
            {
                rightActive = false;
            }
            if (minBPalec < 200 && bPalec.localEulerAngles.x - 1 <= minBPalec || minBPalec > 200 && bPalec.localEulerAngles.x + 1 >= minBPalec)
            {
                inLeft = true;
                if (bPalec.localEulerAngles.x < maxBPalec)
                    maxBPalec = bPalec.localEulerAngles.x;
                if (deltaBPalec-10 >= 7)
                    minBPalec += 3;
            }
            if (minBPalec - maxBPalec > deltaBPalec)
                deltaBPalec = minBPalec - maxBPalec;
            if (maxMizinec - minMizinec > deltaMizinec)
                deltaMizinec = maxMizinec - minMizinec;
            if (bPalec.localEulerAngles.x >= minBPalec + 1)
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
            if (timer <= 5)
            {
                calibrating.text = "Калибровка мизинца";
                if (mizinec1.localEulerAngles.z > 338)
                {
                    timer += 1 * Time.deltaTime;
                    if (mizinec1.localEulerAngles.x > minMizinec)
                        minMizinec = mizinec1.localEulerAngles.z;
                    mizinecCalibrating = true;
                }
                if (!mizinecCalibrated && !mizinecCalibrating)
                    timer = 0;
                else if (mizinecCalibrating && timer >= 5)
                {
                    mizinecCalibrated = true;
                    timer = 0;
                }
            }
        }
        if (!bPalecCalibrated && mizinecCalibrated)
        {
            if (timer <= 5)
            {
                Debug.Log(bPalec.localEulerAngles.x);
                calibrating.text = "Калибровка большого пальца";
                if (bPalec.localEulerAngles.x < 29 || bPalec.localEulerAngles.x < 360 && bPalec.localEulerAngles.x > 300)
                {
                    timer += 1 * Time.deltaTime;
                    if (bPalec.localEulerAngles.x < minBPalec)
                        minBPalec = bPalec.localEulerAngles.x;
                    bPalecCalibrating = true;
                }
                if (!bPalecCalibrated && !bPalecCalibrating)
                    timer = 0;
                else if (bPalecCalibrating && timer >= 5)
                {
                    bPalecCalibrated = true;
                    timer = 0;
                }
            }
        }
        if (!kulakCalibrated && bPalecCalibrated && mizinecCalibrated)
        {
            if (ukPalec1.localEulerAngles.x <= minUkPalecK1 && ukPalec2.localEulerAngles.x <= minUkPalecK2)
                if (mizinec1.localEulerAngles.x <= minMizinecK2 /*&& mizinec2.localEulerAngles.x <= minMizinecK1*/)
                    if (midPalec1.localEulerAngles.x <= minMidPalecK1 && midPalec2.localEulerAngles.x <= minMidPalecK2)
                        if (nnPalec1.localEulerAngles.x <= minNNPalecK1 /*&& nnPalec2.localEulerAngles.x <= minNNPalecK2*/)
                        {
                            Debug.Log("a");
                        }
            if (timer <= 5)
            {
                calibrating.text = "Калибровка кулака";
                if (ukPalec1.localEulerAngles.x < 326 && ukPalec2.localEulerAngles.x <= 311 && mizinec1.localEulerAngles.x < 346)
                    if (midPalec1.localEulerAngles.x < 313 && midPalec2.localEulerAngles.x < 311 && nnPalec1.localEulerAngles.x < 328)
                    {
                        timer += 1 * Time.deltaTime;
                        if (ukPalec1.localEulerAngles.x < minUkPalecK1)
                        {
                            minUkPalecK1 = ukPalec1.localEulerAngles.x;
                            Debug.Log("1");
                        }
                        if (ukPalec2.localEulerAngles.x < minUkPalecK2)
                        {
                            minUkPalecK2 = ukPalec2.localEulerAngles.x;
                            Debug.Log("2");
                        }
                        if (midPalec1.localEulerAngles.x < minMidPalecK1)
                        {
                            minMidPalecK1 = midPalec1.localEulerAngles.x;
                            Debug.Log("3");
                        }
                        if (midPalec2.localEulerAngles.x < minMidPalecK2)
                        {
                            minMidPalecK2 = midPalec2.localEulerAngles.x;
                            Debug.Log("4");
                        }
                        if (nnPalec1.localEulerAngles.x < minNNPalecK1)
                        {
                            minNNPalecK1 = nnPalec1.localEulerAngles.x;
                            Debug.Log("5");
                        }
                        //if (nnPalec2.localEulerAngles.x < minNNPalecK2)
                        //    {
                        //        minNNPalecK2 = nnPalec2.localEulerAngles.x;
                        //        Debug.Log("6");
                        //    }
                        if (mizinec1.localEulerAngles.x < minMizinecK1)
                        {
                            minMizinecK1 = mizinec1.localEulerAngles.x;
                            Debug.Log("7");
                        }
                        //if (mizinec2.localEulerAngles.x < minMizinecK2)
                        //    {
                        //        minMizinecK2 = mizinec2.localEulerAngles.x;
                        //        Debug.Log("8");
                        //    }
                        /*timer null*/
                        kulakCalibrating = true;

                    }

                //}
                if (!kulakCalibrated && !kulakCalibrating)
                    timer = 0;
                else if (kulakCalibrating && timer >= 5)
                {
                    kulakCalibrated = true;
                    calibratingGO.SetActive(false);
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
            Destroy(other);
        }
        if (other.tag == "ObstUp")
        {
            Debug.Log("Life-");
            lifes--;
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