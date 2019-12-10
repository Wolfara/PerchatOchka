using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLvl3 : MonoBehaviour
{
    float minUkPalecK1 = 361, minUkPalecK2 = 361, minMidPalecK1 = 361, minMidPalecK2 = 361, minNNPalecK1 = 361, minNNPalecK2 = 361, minMizinecK1 = 361, minMizinecK2 = 361;
    bool kulakCalibrated, zahvat, kulakCalibrating;
    public float timer;
    int mid2K = 312, uk2K = 312, ukK = 327, midK = 314, nnK = 329, mid1K = 347;
    public Transform ukPalec1, ukPalec2, mizinec1, midPalec1, midPalec2, nnPalec1, liana;
    float maxRotateLiana = 18;
    float minRotateLiana = -18;
    public Text calibrating;
    bool jumpA = false, jumpD;
    bool shvatilsa = false;
    float jumpF;
    Rigidbody rb;
    Vector3 startPos;
    bool lianaIL = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        zahvat = false;
        jumpF = 12;
        kulakCalibrated = false;
        kulakCalibrating = false;
        jumpD = false;
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (kulakCalibrated)
        {
            Debug.Log(zahvat);
            if (ukPalec1.localEulerAngles.x - 2 <= minUkPalecK1 && ukPalec2.localEulerAngles.x - 2 <= minUkPalecK2)
            {
                if (mizinec1.localEulerAngles.x - 2 <= minMizinecK2)
                    if (midPalec1.localEulerAngles.x - 2 <= minMidPalecK1 && midPalec2.localEulerAngles.x - 2 <= minMidPalecK2)
                        if (nnPalec1.localEulerAngles.x - 2 <= minNNPalecK1)
                        {
                            zahvat = true;
                            if (!jumpD)
                                jumpA = true;
                        }
            }

            else
            {
                rb.useGravity = true;
                zahvat = false;
                jumpA = false;
                shvatilsa = false;
            }
            if (!shvatilsa)
                transform.position += new Vector3(3, 0, 0) * Time.deltaTime;
            if (jumpA /*&& !jumpD*/&& transform.position.y <= 50)
            {
                transform.position += new Vector3(0, jumpF, 0) * Time.deltaTime;
                //jumpA = false;
                //jumpD = true;
            }
            if (!zahvat && transform.position.y > 44.79)
            {
                transform.parent = null;
                transform.localEulerAngles = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(1, 2.5f, 1);
            }

        }
        if (timer <= 5)
        {
            calibrating.text = "Калибровка кулака";
            if (ukPalec1.localEulerAngles.x < ukK && ukPalec2.localEulerAngles.x <= uk2K && mizinec1.localEulerAngles.x < mid1K)
                if (midPalec1.localEulerAngles.x < midK && midPalec2.localEulerAngles.x < mid2K && nnPalec1.localEulerAngles.x < nnK)
                {
                    timer += 1 * Time.deltaTime;
                    minUkPalecK1 = ukPalec1.localEulerAngles.x;
                    minUkPalecK2 = ukPalec2.localEulerAngles.x;
                    minMidPalecK1 = midPalec1.localEulerAngles.x;
                    minMidPalecK2 = midPalec2.localEulerAngles.x;
                    minNNPalecK1 = nnPalec1.localEulerAngles.x;
                    minMizinecK1 = mizinec1.localEulerAngles.x;
                    kulakCalibrating = true;
                }
            if (!kulakCalibrated && !kulakCalibrating)
                timer = 0;
            else if (kulakCalibrating && timer >= 5)
            {
                kulakCalibrated = true;
                calibrating.text = "";
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Liana")
        {
            if (zahvat)
            {
                shvatilsa = true;
                transform.parent = liana;
                rb.useGravity = false;
                if (liana.localEulerAngles.z < maxRotateLiana&&!lianaIL)
                {
                    liana.localEulerAngles += new Vector3(0, 0, 16) * Time.deltaTime;
                    Debug.Log(liana.localEulerAngles.z);
                    if (liana.localEulerAngles.z >= maxRotateLiana)
                        lianaIL = true;
                }
                else if (liana.localEulerAngles.z > minRotateLiana&&lianaIL)
                {
                    liana.localEulerAngles += new Vector3(0, 0, 16) * Time.deltaTime;
                    lianaIL = true;
                }
                if (liana.localEulerAngles.z <= minRotateLiana && lianaIL)
                    lianaIL = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bonus")
        {

        }
    }
}
