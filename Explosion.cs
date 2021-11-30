using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    private void Awake()
    {
        transform.position = Player.GetComponent<Transform>().position;
    }

    public void Explode()
    {
        var exp = GetComponent<ParticleSystem>();
        exp.Play();
    }

    void Update()
    {
        
    }
}
