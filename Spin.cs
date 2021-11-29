using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    Transform trs;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private Vector3 dir;

    private void Awake()
    {
        trs = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        SpinSpace(dir);
    }

    void SpinSpace(Vector3 dir)
    {
        trs.Rotate(dir * rotateSpeed * Time.deltaTime, Space.World);
    }
   
}
