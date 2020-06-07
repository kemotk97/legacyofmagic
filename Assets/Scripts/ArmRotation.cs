using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{

    public int rotationOffset = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 differrence = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
        differrence.Normalize();

        float rotZ = Mathf.Atan2(differrence.y, differrence.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
    }
}
