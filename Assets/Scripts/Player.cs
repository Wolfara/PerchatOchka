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
    public Text hp, calibrating, ubp, um, up;
    public GameObject calibratingGO;
    public int bonus = 0;
    public GameObject dead;
    public float minMizinec, maxMizinec;
    public float minBPalec, maxBPalec;
    public float deltaMizinec, deltaBPalec;
    public float deltaJump, minJump, maxJump;
    bool gameStarted = false;
    bool mizinecCalibrated = false, bPalecCalibrated = false, kulakCalibrated = false, kulakCalibrating = false, jumpCalibrated = false, jumpCalibrating = false;
    float minUkPalecK1 = 361, minUkPalecK2 = 361, minMidPalecK1 = 361, minMidPalecK2 = 361, minNNPalecK1 = 361, minNNPalecK2 = 361, minMizinecK1 = 361, minMizinecK2 = 361;
    public float timer = 0;
    bool bPalecCalibrating = false, mizinecCalibrating = false;
    public GameObject cam;
    public int badMizinecR = 0, badBPalecR = 0;
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
        if (minBPalec >= 20 && minBPalec < 26)
            ubp.text = "20";
        if (minBPalec >= 10 && minBPalec < 20)
            ubp.text = "45";
        if (minBPalec >= 300)
            ubp.text = "80";
        if (minMizinec >= 332 && minMizinec < 335)
            um.text = "10";
        if (minMizinec >= 335 && minMizinec < 338)
            um.text = "20";
        if (minMizinec >= 338)
            um.text = "45";
        if (minJump >= 300)
            up.text = "45";
        if (minJump >= 280 && minJump < 300)
            up.text = "90";
        if (minJump >= 240 && minJump < 280)
            up.text = "120";
        if (minJump < 200)
            up.text = "180";
        //deltaBP = 331-55
        //55-34, 331-310
        //deltaMizinec = 20max
        //Debug.Log(deltaMizinec);
        //Debug.Log(mizinec1.localEulerAngles.z);
        cam.transform.position = new Vector3(transform.position.x + 4, transform.position.y + 2.7f, 0);
        if (gameStarted)
        {
            if (deltaBPalec - 14 < deltaMizinec)
                Debug.Log(1);
            if (deltaMizinec - 2 < deltaBPalec - 12)
                Debug.Log(2);
            hp.text = lifes.ToString();
            Vector3 forceUp = new Vector3();
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            if (speed < maxSpeed)
                speed += 0.1f * Time.deltaTime;
            forceUp += transform.up * 7;
            if (ukPalec1.localEulerAngles.x - 2 <= minUkPalecK1 && ukPalec2.localEulerAngles.x - 2 <= minUkPalecK2)
                if (mizinec1.localEulerAngles.x - 2 <= minMizinecK2)
                    if (midPalec1.localEulerAngles.x - 2 <= minMidPalecK1 && midPalec2.localEulerAngles.x - 2 <= minMidPalecK2)
                        if (nnPalec1.localEulerAngles.x - 2 <= minNNPalecK1)
                        {
                            if (!prisel)
                                prisel = true;
                            else if (prisel)
                                prisel = false;
                        }
            if (badMizinecR >= 5 && minMizinec < 330)
            {
                minMizinec -= 2;
                badMizinecR = 0;
                Debug.Log("bad and minmiz");
            }
            if (badBPalecR == 20)
            {
                if (minBPalec <= 25)
                {
                    minBPalec += 2;

                    Debug.Log("bad<=25");
                }
                else if (minBPalec >= 340 && minBPalec <= 360)
                {
                    minBPalec += 2;
                    if (minBPalec >= 360)
                        minBPalec = 2;
                }
                badBPalecR = 0;
                Debug.Log("bad");
            }
            if (mizinec1.localEulerAngles.z >= 334 && rightActive)
            {
                Debug.Log(3);
                if (mizinec1.localEulerAngles.z + 2 >= minMizinec)
                {
                    inRight = true;
                    if (mizinec1.localEulerAngles.z > maxMizinec)
                        maxMizinec = mizinec1.localEulerAngles.z;
                    if (deltaMizinec - 12 >= 7)
                        minMizinec += 3;
                    Debug.Log("Gagagaggg");
                }
                else if (mizinec1.localEulerAngles.z + 2 < minMizinec)
                {
                    badMizinecR++;
                    Debug.Log(5);
                }
            }
            if (mizinec1.localEulerAngles.z <= minMizinec - 1 && path < 3)
            {
                rightActive = false;
            }
            if (bPalec.localEulerAngles.x < 20 || bPalec.localEulerAngles.x > 70)
            {
                Debug.Log("bpalec gest true");
                if (bPalec.localEulerAngles.x <= 26 || bPalec.localEulerAngles.x < 360 && bPalec.localEulerAngles.x > 300 && leftActive)
                {
                    if (minBPalec < 26 && bPalec.localEulerAngles.x - 1 <= minBPalec || minBPalec > 300 && bPalec.localEulerAngles.x + 1 >= minBPalec)
                    {
                        Debug.Log("true");
                        inLeft = true;
                        Debug.Log(bPalec.localEulerAngles.x);
                        if (bPalec.localEulerAngles.x > 300 || maxBPalec > bPalec.localEulerAngles.x)
                        {
                            maxBPalec = bPalec.localEulerAngles.x;
                            Debug.Log(8);
                        }
                        else if (bPalec.localEulerAngles.x < maxBPalec && maxBPalec < 300)
                        {
                            maxBPalec = bPalec.localEulerAngles.x;
                            Debug.Log(7);
                        }
                        if (deltaBPalec <= 1 && bPalec.localEulerAngles.x < 25)
                        {
                            minBPalec -= 3;
                            if (minBPalec <= 0)
                                minBPalec = 359;
                        }
                        else if (deltaBPalec - 313 >= 1 && bPalec.localEulerAngles.x > 300)
                        {
                            minBPalec -= 3;
                        }
                    }
                    else
                    {
                        Debug.Log("bpalec+");
                        badBPalecR++;
                    }
                }
            }




            if (minBPalec - maxBPalec - 10 > deltaBPalec)
                deltaBPalec = minBPalec - 10 - maxBPalec;
            if (maxMizinec - minMizinec > deltaMizinec)
                deltaMizinec = maxMizinec - minMizinec;
            if (bPalec.localEulerAngles.x >= minBPalec + 1 && path > 1)
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
            if (glove.localEulerAngles.z >= minJump && !jump && !jumpA)
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
        if (mizinecCalibrated && bPalec && kulakCalibrated && jumpCalibrated)
        {
            gameStarted = true;
        }
        if (!jumpCalibrated)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpCalibrated = true;
                timer = 0;
            }
            if (timer <= 5)
            {
                calibrating.text = "Калибровка прыжка";
                if (glove.localEulerAngles.z > 150 && glove.localEulerAngles.z < 300)
                {
                    timer += 1 * Time.deltaTime;
                    if (glove.localEulerAngles.z < minJump)
                        minJump = glove.localEulerAngles.z;
                    jumpCalibrating = true;
                }
            }
            else if (timer >= 5 && !jumpCalibrating && !jumpCalibrated)
            {
                timer = 0;
            }
            else if (jumpCalibrating && timer >= 5)
            {
                jumpCalibrated = true;
                timer = 0;
            }
        }
        if (!mizinecCalibrated && jumpCalibrated)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                mizinecCalibrated = true;
                timer = 0;
            }
            if (timer <= 5)
            {
                calibrating.text = "Калибровка мизинца";
                if (mizinec1.localEulerAngles.z > 334)
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
        if (!bPalecCalibrated && mizinecCalibrated && jumpCalibrated)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bPalecCalibrated = true;
                timer = 0;
            }
            if (timer <= 5)
            {
                calibrating.text = "Калибровка большого пальца";
                if (bPalec.localEulerAngles.x < 26 || bPalec.localEulerAngles.x > 300)
                {
                    timer += 1 * Time.deltaTime;
                    if (bPalec.localEulerAngles.x > 300 && bPalec.localEulerAngles.x < minBPalec)
                        minBPalec = bPalec.localEulerAngles.x;
                    else if (bPalec.localEulerAngles.x < minBPalec && minBPalec < 26)
                    {
                        minBPalec = bPalec.localEulerAngles.x;
                        if (minBPalec <= 1)
                            minBPalec = 359;
                    }
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
        if (!kulakCalibrated && bPalecCalibrated && mizinecCalibrated && jumpCalibrated)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                kulakCalibrated = true;
                timer = 0;
            }
            if (timer <= 5)
            {
                calibrating.text = "Калибровка кулака";
                if (ukPalec1.localEulerAngles.x < 327 && ukPalec2.localEulerAngles.x <= 312 && mizinec1.localEulerAngles.x < 347)
                    if (midPalec1.localEulerAngles.x < 314 && midPalec2.localEulerAngles.x < 312 && nnPalec1.localEulerAngles.x < 329)
                    {
                        timer += 1 * Time.deltaTime;
                        if (ukPalec1.localEulerAngles.x < minUkPalecK1)
                        {
                            minUkPalecK1 = ukPalec1.localEulerAngles.x;
                        }
                        if (ukPalec2.localEulerAngles.x < minUkPalecK2)
                        {
                            minUkPalecK2 = ukPalec2.localEulerAngles.x;
                        }
                        if (midPalec1.localEulerAngles.x < minMidPalecK1)
                        {
                            minMidPalecK1 = midPalec1.localEulerAngles.x;
                        }
                        if (midPalec2.localEulerAngles.x < minMidPalecK2)
                        {
                            minMidPalecK2 = midPalec2.localEulerAngles.x;
                        }
                        if (nnPalec1.localEulerAngles.x < minNNPalecK1)
                        {
                            minNNPalecK1 = nnPalec1.localEulerAngles.x;
                        }
                        if (mizinec1.localEulerAngles.x < minMizinecK1)
                        {
                            minMizinecK1 = mizinec1.localEulerAngles.x;
                        }
                        kulakCalibrating = true;

                    }
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