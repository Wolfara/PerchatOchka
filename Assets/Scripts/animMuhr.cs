﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animMuhr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles += new Vector3(0, 50, 0) * Time.deltaTime;
    }
}
