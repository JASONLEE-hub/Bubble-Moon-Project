using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DownButton : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject down_Player;

    [SerializeField]
    private float down_Speed; // value 값

    private Rigidbody rigid;

    private float startPoint;

    public bool isTouch = false;

    void Start()
    {
        startPoint = down_Player.transform.position.y;
    }

    private void Awake()
    {
        rigid = down_Player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isTouch)
        {
            rigid.AddForce(new Vector3(0, -down_Speed, 0), ForceMode.Impulse);

            if (down_Player.transform.position.y < startPoint)
            {
                rigid.AddForce(new Vector3(0, down_Speed * 0.9f, 0), ForceMode.Impulse);
            }
            if (down_Player.transform.position.y < startPoint * -1.4f)
            {
                down_Player.transform.position = Vector3.MoveTowards(down_Player.transform.position, new Vector3(down_Player.transform.position.x, startPoint, down_Player.transform.position.z), down_Speed * 0.1f);
            }

        }
        else if (!GameObject.Find("Joy_Up").GetComponent<UpButton>().isTouch && down_Player.transform.position.y != startPoint)
        {
            down_Player.transform.position = Vector3.MoveTowards(down_Player.transform.position, new Vector3(down_Player.transform.position.x, startPoint, down_Player.transform.position.z), down_Speed * 0.1f);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        rigid.AddForce(new Vector3(0, down_Speed, 0), ForceMode.Impulse);
        down_Player.transform.position = Vector3.MoveTowards(down_Player.transform.position, new Vector3(down_Player.transform.position.x, startPoint, down_Player.transform.position.z), down_Speed * 0.1f);
    }
}
