using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SubTitle : MonoBehaviour
{
    [SerializeField]
    private string[] key = new string[3];

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            for(int i = 0;  i < key.Length; i++)
            {
                if (key[i] != null)
                {
                    DOTween.Play(key[i]);
                }
            }
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < key.Length; i++)
            {
                if (key[i] != null)
                {
                    DOTween.Kill(key[i]);
                }
            }
        }

    }*/
}
