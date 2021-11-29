using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpButton : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject up_Player;

    [SerializeField]
    private float up_Speed; // value 값

    private Rigidbody rigid;

    private float startPoint;

    public bool isTouch = false;

    void Start()
    {
        startPoint = up_Player.transform.position.y;
    }

    private void Awake()
    {
        rigid = up_Player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isTouch)
        {
            rigid.AddForce(new Vector3(0, up_Speed, 0), ForceMode.Impulse);

            if (up_Player.transform.position.y > startPoint)
            {
                rigid.AddForce(new Vector3(0, -up_Speed * 0.9f, 0), ForceMode.Impulse);
            }
            if (up_Player.transform.position.y > startPoint * 1.8f)
            {
                up_Player.transform.position = Vector3.MoveTowards(up_Player.transform.position, new Vector3(up_Player.transform.position.x, startPoint, up_Player.transform.position.z), up_Speed * 0.1f);
                Debug.Log("good");
            }
        }
        else if (!GameObject.Find("Joy_Down").GetComponent<DownButton>().isTouch && up_Player.transform.position.y != startPoint)
        {
            up_Player.transform.position = Vector3.MoveTowards(up_Player.transform.position, new Vector3(up_Player.transform.position.x, startPoint, up_Player.transform.position.z), up_Speed*0.1f);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        rigid.AddForce(new Vector3(0, -up_Speed, 0), ForceMode.Impulse);
        up_Player.transform.position = Vector3.MoveTowards(up_Player.transform.position, new Vector3(up_Player.transform.position.x, startPoint, up_Player.transform.position.z), up_Speed * 0.1f);
    }
}
