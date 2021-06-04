using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
