using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerMove : MonoBehaviour
{
    Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        transform.position = playerTransform.position;
    }
}
